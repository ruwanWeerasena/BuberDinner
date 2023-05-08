
using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
        Services.AddScoped<IAuthenticationService, AuthenticationService>();
        return Services;
    }
}