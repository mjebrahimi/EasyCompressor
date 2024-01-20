using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add ZstandardCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Level</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstandardCompressor(this IServiceCollection services, int level = 3)
    {
        return services.AddZstandardCompressor(null, level);
    }

    /// <summary>
    /// Add ZstandardCompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Level</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstandardCompressor(this IServiceCollection services, string name, int level = 3)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZstandardCompressor>(_ => new ZstandardCompressor(name, level));
        return services;
    }
}
