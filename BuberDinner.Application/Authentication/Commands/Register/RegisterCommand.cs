using FluentResults;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;
public record Registercommand(string FirstName,
                              string LastName,
                              string Email,
                              string Password):IRequest<Result<AuthenticationResult>>;