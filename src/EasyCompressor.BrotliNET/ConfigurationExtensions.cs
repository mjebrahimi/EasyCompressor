// Ignore Spelling: Brotli

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
    /// Add BrotliNETCompressor to services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="quality">Quality (Defaults to <c>5</c>)</param>
    /// <param name="window">Window (Defaults to <c>22</c>)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, uint quality = 5, uint window = 22)
    {
        return services.AddBrotliNETCompressor(null, quality, window);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified name
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="quality">Quality (Defaults to <c>5</c>)</param>
    /// <param name="window">Window (Defaults to <c>22</c>)</param>
    /// <returns>IServiceCollection</returns>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
    [Obsolete("Instead, use the built-in BrotliCompressor class (using AddBrotliCompressor) in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
    public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, uint quality = 5, uint window = 22)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliNETCompressor>(_ => new BrotliNETCompressor(name, quality, window));
        return services;
    }
}