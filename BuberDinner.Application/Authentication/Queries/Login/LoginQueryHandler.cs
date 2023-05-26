

using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Domain.Common.Entities;
using FluentResults;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
      
        await Task.CompletedTask;
                //validate the user
        if(_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Result.Fail<AuthenticationResult>(new InvalidCredentials() );
        }


        //validate the password
        if(user.Password != query.Password)
        {
        return Result.Fail<AuthenticationResult>(new InvalidCredentials() );
        }

        //create token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}