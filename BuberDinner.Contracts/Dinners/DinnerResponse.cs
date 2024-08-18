
namespace BuberDinner.Contracts.Dinners;

public record DinnerResponse(
    string Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime StartedDateTime,
    DateTime EndedDateTime,
    string Status,
    Boolean IsPublic,
    int MaxGuests,
    PriceResponse Price,
    string HostId,
    string MenuId,
    string ImageUrl,
    LocationResponse Location, 
    List<ReservationResponse> Reservations,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime 
);

public record ReservationResponse(
    string Id,
    int GuestCount,
    string ReservationStatus,
    string GuestId,
    string BillId
);

public record PriceResponse(
    double Amount,
    string Currency
);

public record LocationResponse(
     string Name,
     string Address,
     double Latitude,
     double Longitude
);