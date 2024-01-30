using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guest.ValueObjects
{
    public sealed class RatingsId : ValueObject
    {
        public Guid Value { get; }

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