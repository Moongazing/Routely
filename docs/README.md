# Routely

**Routely** is a senior-level, modular and extensible **Minimal API Framework** for ASP.NET Core (.NET 6+).  
Inspired by Carter, it offers a clean modular routing structure with powerful built-in features such as:

- Route modules
- Result pattern with `ToIResult()` extensions
- Global exception handling using `ProblemDetails`
- Attribute-based endpoint filters
- Swagger/OpenAPI integration with versioning support
- 

## ✨ Features

- ✅ `RouteModule` abstraction with automatic discovery
- ✅ `Result<T>` + `Result` classes for unified success/error flow
- ✅ Extension methods to convert `Result` to ASP.NET Core `IResult`
- ✅ Global exception handler using ProblemDetails standard
- ✅ Attribute-based middleware filters via `[Use(typeof(MyFilter))]`
- ✅ OpenAPI (Swagger) support with API versioning
- ✅ Service registration via `IServiceRegistrar`



## 📦 Installation

> Coming soon as a NuGet package

For now, clone the repository and include the `Routely` project in your solution.


## 🚀 Getting Started

### 1. Define a Module

public class ProductModule : RouteModule
{
    public override string RoutePrefix => "/products";

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => Results.Ok(new[] { "Product A", "Product B" }));
    }
}


2. Register and Use Modules

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouteModules(typeof(ProductModule));
builder.AddSwaggerWithVersioning();

var app = builder.Build();
app.UseGlobalExceptionHandler();
app.MapRouteModules();
app.UseSwaggerWithUI();
app.Run();

Project Structure

Routely/
├── Routing/
│   ├── RouteModule.cs
│   ├── IRouteModule.cs
│   └── EndpointRegistrar.cs
├── Results/
│   ├── Result.cs
│   └── ResultExtensions.cs
├── Middleware/
│   ├── ExceptionHandlingMiddleware.cs
│   ├── UseAttribute.cs
│   └── IEndpointFilter.cs
├── Validation/
│   └── IValidator.cs
├── DependencyInjection/
│   └── IServiceRegistrar.cs
└── Extensions/
    └── ApplicationBuilderExtensions.cs


    License

MIT © [Tunahan Ali Öztürk]
🙌 Contributions

Contributions are welcome! Feel free to open issues or submit PRs.