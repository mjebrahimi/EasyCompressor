using EasyCompressor;
using K4os.Compression.LZ4;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services)
    {
        return services.AddLZ4Compressor(name: null);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, string name)
    {
        return services.AddLZ4Compressor(name, LZ4Level.L00_FAST);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="LZ4Level.L00_FAST"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, LZ4Level level)
    {
        return services.AddLZ4Compressor(name: null, level);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="binaryCompressionMode">The binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.Optimal"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, LZ4BinaryCompressionMode binaryCompressionMode)
    {
        return services.AddLZ4Compressor(name: null, LZ4Level.L00_FAST, binaryCompressionMode);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="level">Compression level (Defaults to <see cref="LZ4Level.L00_FAST"/>)</param>
    /// <param name="binaryCompressionMode">The binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.Optimal"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, LZ4Level level, LZ4BinaryCompressionMode binaryCompressionMode)
    {
        return services.AddLZ4Compressor(name: null, level, binaryCompressionMode);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level (Defaults to <see cref="LZ4Level.L00_FAST"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, string name, LZ4Level level)
    {
        return services.AddLZ4Compressor(name, level, LZ4BinaryCompressionMode.Optimal);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="binaryCompressionMode">The binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.Optimal"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, string name, LZ4BinaryCompressionMode binaryCompressionMode)
    {
        return services.AddLZ4Compressor(name, LZ4Level.L00_FAST, binaryCompressionMode);
    }

    /// <summary>
    /// Add BrotliNETCompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level (Defaults to <see cref="LZ4Level.L00_FAST"/>)</param>
    /// <param name="binaryCompressionMode">The binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.Optimal"/>)</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, string name, LZ4Level level, LZ4BinaryCompressionMode binaryCompressionMode)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, LZ4Compressor>(_ => new LZ4Compressor(name, level, binaryCompressionMode));
        return services;
    }
}
