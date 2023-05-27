using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem :Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    public MenuItem(MenuItemId menuItemId, string name , string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

#pragma warning disable CS8618
    public MenuItem()
    {

    }
#pragma warning restore CS8618
    public static MenuItem Create(string name , string description)
    {
        return new(
            MenuItemId.CreateUnique(),
            name,
            description
            );
    }
}