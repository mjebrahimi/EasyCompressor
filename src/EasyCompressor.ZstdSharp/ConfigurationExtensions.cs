// Ignore Spelling: Zstd

using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services)
    {
        return services.AddZstdSharpCompressor(null, ZstdCompressionLevel.Fast);
    }

    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, ZstdCompressionLevel compressionLevel)
    {
        return services.AddZstdSharpCompressor((int)compressionLevel);
    }

    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, int level)
    {
        return services.AddZstdSharpCompressor(null, level);
    }

    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, string name)
    {
        return services.AddZstdSharpCompressor(name, ZstdCompressionLevel.Fast);
    }

    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, string name, ZstdCompressionLevel compressionLevel)
    {
        return services.AddZstdSharpCompressor(name, (int)compressionLevel);
    }

    /// <summary>
    /// Add <see cref="ZstdSharpCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZstdSharpCompressor(this IServiceCollection services, string name, int level)
    {
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
        ZstdUtils.ThrowIfLevelIsNotValid(level, nameof(level));
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly

        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZstdSharpCompressor>(_ => new ZstdSharpCompressor(name, level));
        return services;
    }
}
