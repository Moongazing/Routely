using Microsoft.AspNetCore.Routing;

namespace Moongazing.Routely.Routing;


/// <summary>
/// An abstract base class that simplifies the implementation of <see cref="IRouteModule"/>.
/// Inherit from this class to group and register related endpoints with a consistent route prefix.
/// </summary>
public abstract class RouteModule : IRouteModule
{
    /// <inheritdoc />
    public abstract string RoutePrefix { get; }

    /// <inheritdoc />
    public abstract void AddRoutes(IEndpointRouteBuilder builder);
}