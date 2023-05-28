using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }


    private User(
        UserId userId,
        string firstname,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ):base(userId)
    {
        FirstName = firstname;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime =  createdDateTime;
        UpdatedDateTime = updatedDateTime; 
    }

    public static User Create(
        string firstname,
        string lastName,
        string email,
        string password
    )
    {
        return new(
            UserId.CreateUnique(),
            firstname,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

#pragma warning disable CS8618
    private User()
    {

    }   
#pragma warning restore CS8618
}
