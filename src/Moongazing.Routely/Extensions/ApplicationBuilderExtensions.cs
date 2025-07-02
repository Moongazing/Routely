using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Moongazing.Routely.DependencyInjection;

namespace Moongazing.Routely.Extensions;


/// <summary>
/// Provides extension methods for configuring application services during startup.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Instantiates and invokes the given <see cref="IServiceRegistrar"/> types to register services
    /// into the application's dependency injection container.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> used to build the application.</param>
    /// <param name="registrarTypes">An array of types that implement <see cref="IServiceRegistrar"/>.</param>
    public static void UseServiceRegistrars(this WebApplicationBuilder builder, params Type[] registrarTypes)
    {
        foreach (var registrarType in registrarTypes)
        {
            if (Activator.CreateInstance(registrarType) is IServiceRegistrar registrar)
            {
                registrar.RegisterServices(builder.Services);
            }
        }
    }
    /// <summary>
    /// Adds minimal API Swagger generation support with versioning to the application.
    /// Registers the OpenAPI document with metadata derived from the application environment.
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance used to configure services.</param>
    public static void AddSwaggerWithVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = builder.Environment.ApplicationName,
                Version = "v1",
                Description = "Auto-generated documentation by Routely"
            });
        });
    }

    /// <summary>
    /// Enables the Swagger middleware and UI for browsing the generated API documentation at the root URL.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance used to configure the HTTP pipeline.</param>
    public static void UseSwaggerWithUI(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            options.RoutePrefix = string.Empty;
        });
    }

}