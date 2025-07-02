using Microsoft.Extensions.DependencyInjection;

namespace Moongazing.Routely.DependencyInjection;


/// <summary>
/// Defines a contract for registering services into the dependency injection container.
/// Implement this interface to encapsulate service registration logic for modular components or features.
/// </summary>
public interface IServiceRegistrar
{
    /// <summary>
    /// Registers application services into the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which services will be registered.</param>
    void RegisterServices(IServiceCollection services);
}