
using System.Reflection;
using BuberDinner.Api.Common.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;
public static class DependencyInjection
{
     public static IServiceCollection AddPresentation(this IServiceCollection Services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        Services.AddSingleton(config);
        Services.AddScoped<IMapper , ServiceMapper>();

        Services.AddControllers();
        Services.AddSingleton<ProblemDetailsFactory,BubberDinnerPoblemDetailFactory>();
        
        return Services;
    }
}