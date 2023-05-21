
using BuberDinner.Application.Authentication.Queries.Login;
using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
    
        RuleFor(x=>x.Email).NotEmpty();
        RuleFor(x=>x.Password).NotEmpty();
    }
}