using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Domain.DinnerAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories;
public class DinnerRepository : IDinnerRepository
{
    private  List<Dinner> _dinners = new();
    public void Add(Dinner dinner)
    {
        _dinners.Add(dinner);
    }
}