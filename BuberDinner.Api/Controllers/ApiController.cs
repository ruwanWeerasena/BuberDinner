using BuberDinner.Api.Http;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    
    // protected IActionResult Problem ( List<Result> errors)
    // {
    //     HttpContext.Items[HttpContextItemKeys.Errors] = errors;
    //     var firstError = errors[0];

        // var statusCode = firstError.Type switch
        // {
        //     Result.Tyo => StatusCodes.Status409Conflict,
        //     ErrorType.Validation => StatusCodes.Status400BadRequest,
        //     ErrorType.NotFound => StatusCodes.Status404NotFound,
        //     _ => StatusCodes.Status500InternalServerError,
        // };

        // return Problem(statusCode:statusCode , title: firstError.Description);

    // }
}