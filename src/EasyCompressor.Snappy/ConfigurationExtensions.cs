using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Instead, use SnappierCompressor (AddSnappierCompressor method) in the EasyCompressor.Snappier package.")]
#pragma warning restore S1133 // Deprecated code should be removed
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
