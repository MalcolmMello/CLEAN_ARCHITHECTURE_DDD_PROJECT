using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public static class ReservationStatus {
        public static readonly string PendingGuestConfirmation = "PendingGuestConfirmation";
        public static readonly string Reserved = "Reserved";
        public static readonly string Cancelled = "Cancelled";
    }
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; } = null;

        private Reservation(
            ReservationId reservationId,
            string reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime? arrivalDateTime
        )
        : base(reservationId)
        {
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
        }

        public static Reservation Create(
            string reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime? arrivalDateTime
        )
        {
            return new(
                ReservationId.CreateUnique(),
                reservationStatus,
                guestId,
                billId,
                arrivalDateTime
            );
        }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
    }
}