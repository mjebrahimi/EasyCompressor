// Ignore Spelling: Zstd

using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services)
    {
        return services.AddZstdCompressor(null, ZstdCompressionLevel.Fast);
    }

    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, ZstdCompressionLevel compressionLevel)
    {
        return services.AddZstdCompressor((int)compressionLevel);
    }

    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, int level)
    {
        return services.AddZstdCompressor(null, level);
    }

    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, string name)
    {
        return services.AddZstdCompressor(name, ZstdCompressionLevel.Fast);
    }

    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, string name, ZstdCompressionLevel compressionLevel)
    {
        return services.AddZstdCompressor(name, (int)compressionLevel);
    }

    /// <summary>
    /// Add <see cref="ZstdCompressor"/> to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    /// <returns>IServiceCollection</returns>
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use ZstdCompressor (AddZstdCompressor method) in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
    public static IServiceCollection AddZstdCompressor(this IServiceCollection services, string name, int level)
    {
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
        ZstdUtils.ThrowIfLevelIsNotValid(level, nameof(level));
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly

        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZstdCompressor>(_ => new ZstdCompressor(name, level));
        return services;
    }
}
