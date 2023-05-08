using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute:ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        //method 2 with filter

        // var exception = context.Exception;//if we need a logging
        // context.Result=new ObjectResult(new { error = "An ErrorOccured While Processing Your Request"})
        // {
        //   StatusCode=500  
        // };
        // context.ExceptionHandled=true;

        //method 3 with problem details

        var exception = context.Exception;
        var problemDetails = new ProblemDetails
        {
            Title="An Error Occured While Processing Your Request",
            Status=(int)HttpStatusCode.InternalServerError,
        };
         context.Result=new ObjectResult(problemDetails);
       
        context.ExceptionHandled=true;

    }

}