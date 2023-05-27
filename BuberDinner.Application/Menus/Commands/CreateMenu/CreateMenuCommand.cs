using BuberDinner.Domain.MenuAggregate;

using FluentResults;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string HostId,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<Result<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description
);