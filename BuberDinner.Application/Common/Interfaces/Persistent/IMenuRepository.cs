
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistent;
public interface IMenuRepository
{
    void Add (Menu menu);
}