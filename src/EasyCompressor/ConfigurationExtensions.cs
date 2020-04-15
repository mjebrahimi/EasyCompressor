using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO.Compression;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Configuration extensions
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Add GZipCompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddGZipCompressor(this IServiceCollection services, CompressionLevel level = CompressionLevel.Optimal)
        {
            return services.AddGZipCompressor(null, level);
        }

        /// <summary>
        /// Add GZipCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddGZipCompressor(this IServiceCollection services, string name, CompressionLevel level = CompressionLevel.Optimal)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, GZipCompressor>(x =>
            {
                return new GZipCompressor(name, level);
            });
            return services;
        }

        /// <summary>
        /// Add DeflateCompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddDeflateCompressor(this IServiceCollection services, CompressionLevel level = CompressionLevel.Optimal)
        {
            return services.AddDeflateCompressor(null, level);
        }

        /// <summary>
        /// Add DeflateCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddDeflateCompressor(this IServiceCollection services, string name, CompressionLevel level = CompressionLevel.Optimal)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, DeflateCompressor>(x =>
            {
                return new DeflateCompressor(name, level);
            });
            return services;
        }

#if NETCOREAPP2_1 || NETSTANDARD2_1
        /// <summary>
        /// Add BrotliCompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddBrotliCompressor(this IServiceCollection services, CompressionLevel level = CompressionLevel.Optimal)
        {
            return services.AddBrotliCompressor(null, level);
        }

        /// <summary>
        /// Add BrotliCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="level">CompressionLevel</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddBrotliCompressor(this IServiceCollection services, string name, CompressionLevel level = CompressionLevel.Optimal)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, BrotliCompressor>(x =>
            {
                return new BrotliCompressor(name, level);
            });
            return services;
        }
#endif
    }
}
