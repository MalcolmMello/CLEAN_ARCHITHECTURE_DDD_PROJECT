using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public int Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; } 
        private MenuReview(
            MenuReviewId menuReviewId,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        : base(menuReviewId)
        {
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static MenuReview Create(
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId
        )
        {
            return new(
                MenuReviewId.CreateUnique(),
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }       
    }
}