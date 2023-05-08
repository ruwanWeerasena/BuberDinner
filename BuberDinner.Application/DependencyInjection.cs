using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
        Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        return Services;
    }
}