
using BuberDinner.Domain.Common.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistent;

public interface IUserRepository
{
    User? GetUserByEmail (string email);
    void Add (User user);
}