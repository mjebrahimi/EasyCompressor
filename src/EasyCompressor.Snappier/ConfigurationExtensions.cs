using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add SnappierCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddSnappierCompressor(this IServiceCollection services)
    {
        return services.AddSnappierCompressor(null);
    }

    /// <summary>
    /// Add SnappierCompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddSnappierCompressor(this IServiceCollection services, string name)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, SnappierCompressor>(_ => new SnappierCompressor(name));
        return services;
    }
}
