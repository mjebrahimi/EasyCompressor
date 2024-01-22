// Ignore Spelling: Zstd

using EasyCompressor;
using EasyCompressor.ZstdSharp;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add ZstdSharpCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, int level = 3)
    {
        return services.AddZstdSharpCompressor(null, level);
    }

    /// <summary>
    /// Add ZstdSharpCompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, string name, int level = 3)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZstdSharpCompressor>(_ => new ZstdSharpCompressor(name, level));
        return services;
    }
}
