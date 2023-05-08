

using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.MiddleWare;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>());  
    builder.Services.AddControllers();  
    builder.Services.AddSingleton<ProblemDetailsFactory,BubberDinnerPoblemDetailFactory>();
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}



