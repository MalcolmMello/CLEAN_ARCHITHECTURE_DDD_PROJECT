using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public static class Status
    {
        public static readonly string Upcoming = "Upcoming";
        public static readonly string InProgress = "InProgress";
        public static readonly string Ended = "Ended";
        public static readonly string Cancelled = "Cancelled";
    }
    public sealed class Dinner : AggregateRoot<DinnerId, Guid>
    {
        private readonly List<Reservation> _reservations = new();
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; } = null;
        public DateTime? EndedDateTime { get; } = null;
        public string Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }
        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime? startedDateTime,
            DateTime? endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location
        )
        : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location; 
        }

        public static Dinner Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime? startedDateTime,
            DateTime? endedDateTime,
            string status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location
        )
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                startedDateTime,
                endedDateTime,
                status,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location
            );
        }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        
    }
}