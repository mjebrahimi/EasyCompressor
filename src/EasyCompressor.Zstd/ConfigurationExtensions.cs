// Ignore Spelling: Zstd

using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Instead, use ZstdSharpCompressor (AddZstdSharpCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add ZstdCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, int level = 3)
    {
        return services.AddZstdCompressor(null, level);
    }

    /// <summary>
    /// Add ZstdCompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, string name, int level = 3)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZstdCompressor>(_ => new ZstdCompressor(name, level));
        return services;
    }
}
