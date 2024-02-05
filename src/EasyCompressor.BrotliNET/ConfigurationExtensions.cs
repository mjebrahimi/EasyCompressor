// Ignore Spelling: Brotli

using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO.Compression;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add BrotliNETCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor());
        return services;
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name));
        return services;
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, CompressionLevel compressionLevel)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name, compressionLevel));
        return services;
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, int quality)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name, quality));
        return services;
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, CompressionLevel compressionLevel, int window)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name, compressionLevel, window));
        return services;
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [System.Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, int quality, int window)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name, quality, window));
        return services;
    }
}