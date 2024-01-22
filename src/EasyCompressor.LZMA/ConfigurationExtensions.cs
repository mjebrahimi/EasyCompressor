using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add LZMACompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="options">The options</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, LZMACompressionOptions options = null)
    {
        return services.AddLZMACompressor(null, options);
    }

    /// <summary>
    /// Add LZMACompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="options">The options</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, string name, LZMACompressionOptions options = null)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, LZMACompressor>(_ => new LZMACompressor(name, options));
        return services;
    }
}
