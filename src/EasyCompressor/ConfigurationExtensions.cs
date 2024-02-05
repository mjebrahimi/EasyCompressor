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
    #region GZipCompressor
    /// <summary>
    /// Add GZipCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddGZipCompressor(this IServiceCollection services)
    {
        return services.AddGZipCompressor(null, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add GZipCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddGZipCompressor(this IServiceCollection services, CompressionLevel level)
    {
        return services.AddGZipCompressor(null, level);
    }

    /// <summary>
    /// Add GZipCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddGZipCompressor(this IServiceCollection services, string name)
    {
        return services.AddGZipCompressor(name, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add GZipCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddGZipCompressor(this IServiceCollection services, string name, CompressionLevel level)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, GZipCompressor>(_ => new GZipCompressor(name, level));
        return services;
    }
    #endregion

    #region DeflateCompressor
    /// <summary>
    /// Add DeflateCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddDeflateCompressor(this IServiceCollection services)
    {
        return services.AddDeflateCompressor(null, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add DeflateCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddDeflateCompressor(this IServiceCollection services, CompressionLevel level)
    {
        return services.AddDeflateCompressor(null, level);
    }

    /// <summary>
    /// Add DeflateCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddDeflateCompressor(this IServiceCollection services, string name)
    {
        return services.AddDeflateCompressor(name, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add DeflateCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddDeflateCompressor(this IServiceCollection services, string name, CompressionLevel level)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, DeflateCompressor>(_ => new DeflateCompressor(name, level));
        return services;
    }
    #endregion

    #region BrotliCompressor
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
    /// <summary>
    /// Add BrotliCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBrotliCompressor(this IServiceCollection services)
    {
        return services.AddBrotliCompressor(null, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add BrotliCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBrotliCompressor(this IServiceCollection services, CompressionLevel level)
    {
        return services.AddBrotliCompressor(null, level);
    }

    /// <summary>
    /// Add BrotliCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBrotliCompressor(this IServiceCollection services, string name)
    {
        return services.AddBrotliCompressor(name, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add BrotliCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBrotliCompressor(this IServiceCollection services, string name, CompressionLevel level)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, BrotliCompressor>(_ => new BrotliCompressor(name, level));
        return services;
    }
#endif
    #endregion

    #region ZLibCompressor
#if NET6_0_OR_GREATER
    /// <summary>
    /// Add ZLibCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZLibCompressor(this IServiceCollection services)
    {
        return services.AddZLibCompressor(null, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add ZLibCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZLibCompressor(this IServiceCollection services, CompressionLevel level)
    {
        return services.AddZLibCompressor(null, level);
    }

    /// <summary>
    /// Add ZLibCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZLibCompressor(this IServiceCollection services, string name)
    {
        return services.AddZLibCompressor(name, CompressionLevel.Fastest);
    }

    /// <summary>
    /// Add ZLibCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddZLibCompressor(this IServiceCollection services, string name, CompressionLevel level)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, ZLibCompressor>(_ => new ZLibCompressor(name, level));
        return services;
    }
#endif
    #endregion
}
