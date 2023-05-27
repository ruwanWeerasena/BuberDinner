using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;
public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }
    private DinnerId()
    {
        
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}