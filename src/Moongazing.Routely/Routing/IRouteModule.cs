using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Routely.Routing;
/// <summary>
/// Defines a contract for registering endpoint routes in a modular fashion.
/// Implement this interface to encapsulate a group of related routes with a common prefix.
/// </summary>
public interface IRouteModule
{
    /// <summary>
    /// Gets the base route prefix for the module. All endpoints in this module should be registered under this prefix.
    /// </summary>
    string RoutePrefix { get; }

    /// <summary>
    /// Registers the endpoints for this module using the provided <see cref="IEndpointRouteBuilder"/>.
    /// </summary>
    /// <param name="builder">The endpoint route builder used to register routes.</param>
    void AddRoutes(IEndpointRouteBuilder builder);
}