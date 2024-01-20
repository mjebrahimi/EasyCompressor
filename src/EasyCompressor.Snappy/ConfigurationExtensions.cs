using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add SnappyCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <returns></returns>
    public static IServiceCollection AddSnappyCompressor(this IServiceCollection services)
    {
        return services.AddSnappyCompressor(null);
    }

    /// <summary>
    /// Add SnappyCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns></returns>
    public static IServiceCollection AddSnappyCompressor(this IServiceCollection services, string name)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, SnappyCompressor>(_ => new SnappyCompressor(name));
        return services;
    }
}
