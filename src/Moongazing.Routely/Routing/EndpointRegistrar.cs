using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Moongazing.Routely.Routing;


/// <summary>
/// Provides extension methods to register and map <see cref="IRouteModule"/> implementations
/// into the application's endpoint routing pipeline.
/// </summary>
public static class EndpointRegistrar
{
    /// <summary>
    /// Registers the specified route module types as singletons in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add the modules to.</param>
    /// <param name="moduleTypes">An array of types implementing <see cref="IRouteModule"/> to be registered.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddRouteModules(this IServiceCollection services, params Type[] moduleTypes)
    {
        foreach (var type in moduleTypes)
        {
            services.AddSingleton(typeof(IRouteModule), type);
        }
        return services;
    }

    /// <summary>
    /// Maps all registered <see cref="IRouteModule"/> instances to the application's endpoint routing system.
    /// Each module's routes will be grouped under its defined <see cref="IRouteModule.RoutePrefix"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to configure routes on.</param>
    /// <returns>The updated <see cref="IEndpointRouteBuilder"/> instance.</returns>
    public static IEndpointRouteBuilder MapRouteModules(this IEndpointRouteBuilder builder)
    {
        var modules = builder.ServiceProvider.GetServices<IRouteModule>();
        foreach (var module in modules)
        {
            var group = builder.MapGroup(module.RoutePrefix);
            module.AddRoutes(group);
        }
        return builder;
    }
}