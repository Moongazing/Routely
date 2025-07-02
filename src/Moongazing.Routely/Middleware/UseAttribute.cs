namespace Moongazing.Routely.Middleware;

/// <summary>
/// Indicates that a specific endpoint or class should be processed by the given endpoint filter type.
/// Can be applied to controller classes or action methods to attach custom logic such as validation,
/// authorization, logging, or rate limiting.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class UseAttribute : Attribute
{
    /// <summary>
    /// Gets the type of the filter to be applied.
    /// The specified type must implement <see cref="IEndpointFilter"/>.
    /// </summary>
    public Type FilterType { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UseAttribute"/> class with the specified filter type.
    /// </summary>
    /// <param name="filterType">The type of the filter to apply. Must implement <see cref="IEndpointFilter"/>.</param>
    public UseAttribute(Type filterType)
    {
        FilterType = filterType;
    }
}
