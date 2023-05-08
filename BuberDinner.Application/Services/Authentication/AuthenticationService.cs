using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistent;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository=userRepository;
    }

    public Result<AuthenticationResult> Login(string Email, string Password)
    {
        //validate the user
        if(_userRepository.GetUserByEmail(Email) is not User user)
        {
             return Result.Fail<AuthenticationResult>(new InvalidCredentials() );
        }


        //validate the password
        if(user.Password != Password)
        {
           return Result.Fail<AuthenticationResult>(new InvalidCredentials() );
        }

        //create token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token);
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //check user already exists
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new DuplicateEmailError() );
        }
        //create user

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);
        //create JwtToken
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);
    }
}