
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Store.Domain.Abstractions;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        switch (isSuccess)
        {
            case true when error != Error.None:
                throw new InvalidOperationException();
            
            case false when error == Error.None:
                throw new InvalidOperationException();
            
            default:
                IsSuccess = isSuccess;
                Error = error;
                break;
        }
    }

    public Error Error { get; set; }
    public bool IsSuccess { get; set; }
    
    public bool IsFailure => !IsSuccess;

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new(default, false, error);

    public static Result<T> Create<T>(T? value) =>
        value is not null ? Success(value) : Failure<T>(Error.NullValue);
}

public class Result<T>(T? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    [NotNull] public T Value => value! ?? throw new InvalidOperationException("Result has no value");

    public static implicit operator Result<T>(T? value) => Create(value);
}