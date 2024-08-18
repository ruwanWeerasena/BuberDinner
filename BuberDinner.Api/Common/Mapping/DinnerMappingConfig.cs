


using Mapster;

using BuberDinner.Contracts.Dinners;
using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Domain.DinnerAggregate;
using Reservation = BuberDinner.Domain.DinnerAggregate.Entities.Reservation;
namespace BuberDinner.Api.Common.Mapping;

public class DinnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateDinnerRequest Request, string HostId ) , CreateDinnerCommand>()
            .Map(dest=>dest.HostId , src=>src.HostId)
            .Map(dest=>dest , src=>src.Request);

        

        config.NewConfig<Dinner , DinnerResponse>()
            .Map(dest=> dest.Id , src=> src.Id.Value)
            .Map(dest=>dest.HostId , src=> src.HostId.Value)
            .Map(dest=>dest.MenuId , src=> src.MenuId.Value)
            .Map(dest=>dest.Price , src=> src.Price)
            .Map(dest=>dest.Location , src=> src.Location);

        config.NewConfig<Reservation , ReservationResponse>()
            .Map(dest=> dest.Id , src=> src.Id.Value)
            .Map(dest=> dest , src=> src);
        
        
    
    }
}