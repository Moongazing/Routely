using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Moongazing.Routely.Results;


/// <summary>
/// Provides extension methods to convert <see cref="Result"/> and <see cref="Result{T}"/>
/// into ASP.NET Core <see cref="IResult"/> responses.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to an ASP.NET Core <see cref="IResult"/>.
    /// Returns <c>200 OK</c> with the value on success, or <c>400 Bad Request</c> with an error message on failure.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult"/> representing the HTTP response.</returns>
    public static IResult ToIResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? Microsoft.AspNetCore.Http.Results.Ok(result.Value)
            : Microsoft.AspNetCore.Http.Results.BadRequest(new { error = result.Error }); 
    }

    /// <summary>
    /// Converts a non-generic <see cref="Result"/> instance to an ASP.NET Core <see cref="IResult"/>.
    /// Returns <c>200 OK</c> on success, or <c>400 Bad Request</c> with an error message on failure.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult"/> representing the HTTP response.</returns>
    public static IResult ToIResult(this Result result)
    {
        return result.IsSuccess
            ? Microsoft.AspNetCore.Http.Results.Ok()
            : Microsoft.AspNetCore.Http.Results.BadRequest(new { error = result.Error }); 
    }
}