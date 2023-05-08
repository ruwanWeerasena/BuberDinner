using System.Net;
using FluentResults;

namespace BuberDinner.Application.Common.Errors;

public class InvalidCredentials : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Invalid Credentials";
    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}