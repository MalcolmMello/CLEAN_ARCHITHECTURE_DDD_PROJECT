using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set;}

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuItemId Create(string id)
        {
            return new(new Guid(id));
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}