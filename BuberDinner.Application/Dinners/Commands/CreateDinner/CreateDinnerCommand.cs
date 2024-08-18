
using BuberDinner.Domain.DinnerAggregate;

using FluentResults;

using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public record CreateDinnerCommand(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    string Status,
    Boolean IsPublic,
    int MaxGuests,
    PriceCommand Price,
    string HostId,
    string MenuId,
    string ImageUrl,
    LocationCommand Location, 
    List<ReservationCommand> Reservations

) : IRequest<Result<Dinner>>;

public record ReservationCommand(
    int GuestCount,
    string ReservationStatus,
    string GuestId,
    string BillId

);

public record PriceCommand(
    double Amount,
    string Currency
);

public record LocationCommand(
     string Name,
     string Address,
     double Latitude,
     double Longitude
);