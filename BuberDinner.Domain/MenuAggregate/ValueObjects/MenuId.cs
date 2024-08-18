using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }
    private MenuId()
    {
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
    public static MenuId Create(string value)
    {
        return new MenuId(new Guid(value));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}