using System.Net;
using FluentResults;

namespace BuberDinner.Application.Common.Errors;

public class ValidationError : IError
{
  

    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Validation Error";

    public string ErrorMessage ;
    public string PropertyName;
    
    

    public Dictionary<string, object> Metadata => throw new NotImplementedException();

    public ValidationError(string _propertyName , string _Message)
    {
        PropertyName = _propertyName;
        ErrorMessage = _Message;
    }
}