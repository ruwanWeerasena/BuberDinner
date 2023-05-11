using BuberDinner.Application.Common.Errors;
using BuberDinner.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;

namespace BuberDinner.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    
    public readonly IMediator _mediator;
    public readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register (RegisterRequest request)
    {
        // var command = new Registercommand(request.FirstName, request.LastName, request.Email, request.Password);
        var command = _mapper.Map<Registercommand>(request);
       Result<AuthenticationResult> registerResult = await _mediator.Send(command);

            if(registerResult.IsSuccess)
            {
                return Ok(_mapper.Map<AuthenticationResponse>(registerResult.Value));
            }
            
   

            var firstError = registerResult.Errors[0];
            
            if(firstError is DuplicateEmailError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, title:firstError.Message);
            }

        return Problem();

    

        
    }


    
    [HttpPost("Login")]
    public async Task<IActionResult> Login (LoginRequest request)
    {
        // var query = new LoginQuery (request.Email,request.Password);
        var query = _mapper.Map<LoginQuery>(request);
        Result<AuthenticationResult> authresult = await _mediator.Send(query);
        
        if(authresult.IsSuccess)
        {
            return Ok(_mapper.Map<AuthenticationResponse>(authresult.Value));
        }

        var firstError = authresult.Errors[0];
        if(firstError is InvalidCredentials)
        {
            return Problem(statusCode:StatusCodes.Status401Unauthorized,title:firstError.Message);
        }
        
        return Problem();

    }

  



}