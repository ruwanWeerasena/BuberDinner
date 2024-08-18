namespace BuberDinner.Contracts.Dinners;

public record CreateDinnerRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string Status,
    Boolean IsPublic,
    int MaxGuests,
    Price Price,
    string MenuId,
    string ImageUrl,
    Location Location, 
    List<Reservation> Reservations 
);

public record Reservation(
    int GuestCount,
    string ReservationStatus,
    string GuestId,
    string BillId
);

public record Price(
    double Amount,
    string Currency
);

public record Location(
     string Name,
     string Address,
     double Latitude,
     double Longitude
);