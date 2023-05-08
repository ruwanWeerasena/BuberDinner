using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.MiddleWare;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private static Task HandleExceptionAsync(HttpContext  context , Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new {error = "An Error Occured while Processing your Request"});
        context.Response.ContentType="application/json";
        context.Response.StatusCode=(int)code;
        return context.Response.WriteAsync(result);
    }
}