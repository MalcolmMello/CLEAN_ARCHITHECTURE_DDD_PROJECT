using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static HostId Create(string id)
        {
            var guid = new Guid(id);
            return new(guid);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}