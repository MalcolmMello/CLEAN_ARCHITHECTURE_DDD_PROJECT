using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating? AverageRating { get; private set; }
        public HostId HostId { get; private set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            List<MenuSection> menuSections,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) : base(menuId)
        {
            Name = name;
            Description= description;
            HostId = hostId;
            _sections = menuSections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        #pragma warning disable CS8618
        private Menu()
        {
        }
        #pragma warning restore CS8618

        public static Menu Create(
            string name,
            string description,
            HostId hostId,
            List<MenuSection> sections
        )
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow            
            );
        }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
    }
}