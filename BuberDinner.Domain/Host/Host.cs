using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public UserId UserId { get; }
        public List<MenuId> _menuIds = new();
        public List<DinnerId> _dinnerIds = new();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(
            string firstName,
            string lastName,
            UserId userId
        )
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }

        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();     
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();        
    }
}