using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class Ratings : Entity<RatingsId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public float Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Ratings(
            RatingsId ratingsId,
            HostId hostId,
            DinnerId dinnerId,
            float rating,
            DateTime createdDateTime,
            DateTime updatedDateTime
        ) 
        : base(ratingsId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Ratings Create(
            HostId hostId,
            DinnerId dinnerId,
            float rating,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
        {
            return new(
                RatingsId.CreateUnique(),
                hostId,
                dinnerId,
                rating,
                createdDateTime,
                updatedDateTime
            );
        }

    }
}