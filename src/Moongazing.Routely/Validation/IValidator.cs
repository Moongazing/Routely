using Moongazing.Routely.Results;

namespace Moongazing.Routely.Validation;


/// <summary>
/// Defines a contract for validating a request of type <typeparamref name="T"/> asynchronously.
/// Returns a <see cref="Result"/> indicating whether the validation passed or failed,
/// along with any associated error message.
/// </summary>
/// <typeparam name="T">The type of the request to validate.</typeparam>
public interface IValidator<T>
{
    /// <summary>
    /// Validates the specified request asynchronously.
    /// </summary>
    /// <param name="request">The request object to validate.</param>
    /// <returns>
    /// A <see cref="Result"/> representing the outcome of the validation.
    /// Returns a success result if the request is valid; otherwise, a failure result with an error message.
    /// </returns>
    Task<Result> ValidateAsync(T request);
}