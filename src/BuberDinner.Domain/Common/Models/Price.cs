namespace BuberDinner.Domain.Common.Models
{
    public sealed class Price
    {
        public float Amount { get; set; }
        public string Currency { get; set; } = null!;
    }
}