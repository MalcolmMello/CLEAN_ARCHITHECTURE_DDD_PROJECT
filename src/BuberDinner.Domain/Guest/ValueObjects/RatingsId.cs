using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class RatingsId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private RatingsId(Guid value)
        {
            Value = value;
        }

        public static RatingsId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}