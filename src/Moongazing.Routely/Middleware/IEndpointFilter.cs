using Microsoft.AspNetCore.Http;

namespace Moongazing.Routely.Middleware;


/// <summary>
/// Defines a contract for creating custom endpoint-level middleware-like filters that can
/// intercept and process HTTP requests before and after they reach the endpoint handler.
/// </summary>
public interface IEndpointFilter
{
    /// <summary>
    /// Executes custom logic before and/or after the next middleware or endpoint handler in the pipeline.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="next">The next delegate in the request processing pipeline.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task InvokeAsync(HttpContext context, RequestDelegate next);
}
