using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Routely.Results;

/// <summary>
/// Represents the result of an operation that can either succeed with a value or fail with an error.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public class Result<T>
{
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the value returned by the operation if it was successful; otherwise, <c>null</c>.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Gets the error message if the operation failed; otherwise, <c>null</c>.
    /// </summary>
    public string? Error { get; }

    public Result(bool success, T? value = default, string? error = null)
    {
        IsSuccess = success;
        Value = value;
        Error = error;
    }

    /// <summary>
    /// Creates a successful result with the specified value.
    /// </summary>
    /// <param name="value">The value to return as the result.</param>
    /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Success(T value) => new(true, value);

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message to associate with the result.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Fail(string error) => new(false, default, error);
}


/// <summary>
/// Represents the result of an operation that does not return a value but can still succeed or fail.
/// Useful for signaling success or failure without data.
/// </summary>
public class Result : Result<string>
{
    private Result(bool success, string? value, string? error)
        : base(success, value, error) { }

    /// <summary>
    /// Creates a successful result with no value.
    /// </summary>
    /// <returns>A successful <see cref="Result"/> instance.</returns>
    public static Result Success() => new(true, null, null);

    /// <summary>
    /// Creates a failed result with the specified error message.
    /// </summary>
    /// <param name="error">The error message to associate with the result.</param>
    /// <returns>A failed <see cref="Result"/> instance.</returns>
    public new static Result Fail(string error) => new(false, null, error);
}
