using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;
public sealed class Price : ValueObject
{
    private Price(double amount , string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public double Amount { get; private set; }
    public string Currency { get; private set; }

    #pragma warning disable CS8618
    public Price()
    {

    }
#pragma warning restore CS8618

    public static Price Create(double amount , string currency)
    {
        return new (amount,currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }
}