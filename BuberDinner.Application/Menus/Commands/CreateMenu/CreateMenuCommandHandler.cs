using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using FluentResults;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<Result<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //create Menu
        var menu = Menu.Create(
            hostId:HostId.Create(request.HostId),
            name:request.Name,
            description:request.Description,
            sections:request.Sections.ConvertAll(section=>  MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item=>  MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );
        //Persist Menu

        _menuRepository.Add(menu);

        //Return The Menu
        return menu;
    }
}