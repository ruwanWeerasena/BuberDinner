
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Errors;
using FluentResults;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest , TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
    // where TResponse: IError
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator=null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validator is null)
        {
            return await next();
        }
        var validationResult = await  _validator.ValidateAsync(request,cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }
        
            
            
 
        var errors =  validationResult.Errors.ConvertAll(validationFailure => 
            new ValidationError(validationFailure.PropertyName,validationFailure.ErrorMessage)
            );

        return  (dynamic)Result.Fail<AuthenticationResult>(errors);


        // //before the handler
        // var result = await next();
        // //after the handler
        // return result;
    }
}