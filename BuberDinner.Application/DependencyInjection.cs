using System.Reflection;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Behaviors;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
        Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // Services.AddScoped<IPipelineBehavior<Registercommand , Result<AuthenticationResult>>, ValidateRegisterCommandBehavior>();
        Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        /*
            dotnet add package FluentValidation.AspNetCore
            Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            will automatically get all validators instead of mentioning one by one
        */
        // Services.AddScoped<IValidator<Registercommand>,RegisterCommandValidator>();
        Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return Services;
    }
}