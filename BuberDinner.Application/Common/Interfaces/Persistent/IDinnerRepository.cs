
using BuberDinner.Domain.DinnerAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistent;
public interface IDinnerRepository
{
    void Add (Dinner dinner);
}