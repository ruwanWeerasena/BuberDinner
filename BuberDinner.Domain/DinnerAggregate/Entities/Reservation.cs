
using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;
public sealed class Reservation :Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }


    public Reservation(ReservationId reservationId,
                       int guestCount,
                       ReservationStatus reservationStatus,
                       GuestId guestId,
                       BillId billId,
                       DateTime createdDateTime,
                       DateTime updatedDateTime
                       )
        : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = null;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

#pragma warning disable CS8618
    public Reservation()
    {

    }
#pragma warning restore CS8618
    public static Reservation Create(
            int guestCount,
            GuestId guestId,
            BillId billId
         
        )
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            ReservationStatus.PendingGuestConfirmation,
            guestId,
            billId,
            DateTime.UtcNow,
            DateTime.UtcNow
            );
    }
}