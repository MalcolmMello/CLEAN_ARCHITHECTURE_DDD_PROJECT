using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<Ratings> _ratings = new();
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        private Guest(
            GuestId guestId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId
        )
        : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId
        )
        {
            return new(
                GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId
            );
        }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<Ratings> Ratings => _ratings.AsReadOnly();
    }
}