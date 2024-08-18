

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;
public sealed class BillId : ValueObject
{
    public Guid Value { get; }

    private BillId(Guid value)
    {
        Value = value;
    }
    private BillId()
    {
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }
    public static BillId Create(string value)
    {
        return new BillId(new Guid(value));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}