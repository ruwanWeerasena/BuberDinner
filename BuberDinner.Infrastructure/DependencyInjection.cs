
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Persistence.Repositories;
using BuberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
            this IServiceCollection Services,
            ConfigurationManager Configuration)
    {

        var JwtSettings = new JwtSettings();
        Configuration.Bind(JwtSettings.SectionName, JwtSettings);

        // Services.Configure <JwtSettings>(Configuration.GetSection(JwtSettings.SectionName));
        Services.AddSingleton(Options.Create(JwtSettings));

        Services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
        Services.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options=> options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer =true,
                ValidateAudience = true,
                ValidateLifetime =true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer ,
                ValidAudience = JwtSettings.Audience ,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtSettings.Secret)
                )
            });

        Services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        Services.AddScoped<IUserRepository,UserRepository>();
        Services.AddScoped<IMenuRepository,MenuRepository>();

        Services.AddDbContext<BuberDinnerDbContext>(options=> options.UseSqlServer("Server=localhost;Database=BubberDinner;User Id=sa;Password=Ruwan2001;TrustServerCertificate=true"));
        
        return Services;
    }
}