

using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using FluentResults;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, Result<Dinner>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public CreateDinnerCommandHandler(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public async Task<Result<Dinner>> Handle(CreateDinnerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //create Dinner
        var dinner = Dinner.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.IsPublic,
            request.MaxGuests,
            Price.Create(request.Price.Amount,request.Price.Currency),
            HostId.Create(request.HostId),
            MenuId.Create(request.MenuId),
            request.ImageUrl,
            Location.CreateNew(request.Location.Name,request.Location.Address,request.Location.Latitude,request.Location.Longitude),
            request.Reservations.ConvertAll(reservation=>Reservation.Create(
                reservation.GuestCount,
                GuestId.Create(reservation.GuestId),
                BillId.Create(reservation.BillId)

            ))

        );

        //save
        _dinnerRepository.Add(dinner);

        return dinner;
    }

    // public async Task<Result<Dinner>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    // {
    //     await Task.CompletedTask;
    //     //create Menu
    //     var menu = Menu.Create(
    //         hostId:HostId.Create(request.HostId),
    //         name:request.Name,
    //         description:request.Description,
    //         sections:request.Sections.ConvertAll(section=>  MenuSection.Create(
    //             section.Name,
    //             section.Description,
    //             section.Items.ConvertAll(item=>  MenuItem.Create(
    //                 item.Name,
    //                 item.Description
    //             ))
    //         ))
    //     );
    //     //Persist Menu

    //     _menuRepository.Add(menu);

    //     //Return The Menu
    //     return menu;
    // }
}