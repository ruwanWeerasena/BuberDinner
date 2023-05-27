using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    private AverageRating(double value , int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    public double Value { get; private set; }
    public int NumRatings { get; private set; }

    public static AverageRating CreateNew(double rating = 4.5 ,int numRatings = 1)
    {
        return new AverageRating(rating,numRatings);
    }
    public  void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRatings)+rating.Value)/++NumRatings;
    }


    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings)-rating.Value)/--NumRatings;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}