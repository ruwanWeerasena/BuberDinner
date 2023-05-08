using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using  BuberDinner.Domain.Common.Errors;
namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    public readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public IActionResult Register (RegisterRequest request)
    {
       Result<AuthenticationResult> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

            if(registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }
            
   

            var firstError = registerResult.Errors[0];
            
            if(firstError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, title:firstError.Message);
            }

        return Problem();

    

        
    }


    
    [HttpPost("Login")]
    public IActionResult Login (LoginRequest request)
    {
        Result<AuthenticationResult> authresult = _authenticationService.Login(
            request.Email,
            request.Password);
        
        if(authresult.IsSuccess)
        {
            return Ok(MapAuthResult(authresult.Value));
        }

        var firstError = authresult.Errors[0];
        if(firstError is InvalidCredentials)
        {
            return Problem(statusCode:StatusCodes.Status401Unauthorized,title:firstError.Message);
        }
        
        return Problem();

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authresult)
    {
            return new AuthenticationResponse(
                authresult.User.Id,
                authresult.User.FirstName,
                authresult.User.LastName,
                authresult.User.Email,
                authresult.Token
            );  
    }



}