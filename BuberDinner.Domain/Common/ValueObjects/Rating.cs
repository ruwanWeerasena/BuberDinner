using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{

    private Rating(double value )
    {
        Value = value;
    }
    public double Value { get; private set; }
    public static Rating Create(double rating = 0 )
    {
        return new(rating);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}