
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection Services,
            ConfigurationManager Configuration)
    {
        Services.Configure <JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));

        Services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        Services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        Services.AddScoped<IUserRepository,UserRepository>();
        
        return Services;
    }
}