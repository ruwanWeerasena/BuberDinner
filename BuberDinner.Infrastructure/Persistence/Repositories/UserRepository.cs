using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Domain.Common.Entities;

namespace BuberDinner.Infrastructure.Persistence.Repositories;


public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user=>user.Email==email);
    }
}