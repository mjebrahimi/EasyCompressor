using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configuration extensions
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Add LZMACompressor to services.
    /// </summary>
    /// <param name="services">The services</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services)
    {
        return services.AddLZMACompressor(name: null);
    }

    /// <summary>
    /// Add LZMACompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="name">The name.</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, string name)
    {
        return services.AddLZMACompressor(name, LZMACompressionLevel.UltraFast);
    }

    /// <summary>
    /// Add LZMACompressor to services.
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/></param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, LZMACompressionLevel compressionLevel)
    {
        return services.AddLZMACompressor(name: null, compressionLevel);
    }

    /// <summary>
    /// Add LZMACompressor to services.
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/></param>
    /// <param name="dictionarySize">Size of the dictionary. (Defaults to <see cref="DictionarySize.Smallest_64KB"/> <c>(64 KB)</c> )</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, LZMACompressionLevel compressionLevel, DictionarySize dictionarySize)
    {
        return services.AddLZMACompressor(name: null, compressionLevel, dictionarySize);
    }

    /// <summary>
    /// Add LZMACompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/></param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, string name, LZMACompressionLevel compressionLevel)
    {
#pragma warning disable RCS1196 // Call extension method as instance method
        return services.AddLZMACompressor(name, compressionLevel, LZMAProperties.GetDictionarySize(compressionLevel));
#pragma warning restore RCS1196 // Call extension method as instance method
    }

    /// <summary>
    /// Add LZMACompressor to services with specified <paramref name="name"/>.
    /// </summary>
    /// <param name="services">The services</param>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/></param>
    /// <param name="dictionarySize">Size of the dictionary. (Defaults to <see cref="DictionarySize.Smallest_64KB"/> <c>(64 KB)</c> )</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddLZMACompressor(this IServiceCollection services, string name, LZMACompressionLevel compressionLevel, DictionarySize dictionarySize)
    {
        services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
        services.AddSingleton<ICompressor, LZMACompressor>(_ => new LZMACompressor(name, compressionLevel, dictionarySize));
        return services;
    }
}