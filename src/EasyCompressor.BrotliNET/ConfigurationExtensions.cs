using EasyCompressor;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Configuration extensions
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Add BrotliNETCompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="quality">Quality</param>
        /// <param name="window">Window</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, uint quality = 11, uint window = 22)
        {
            return services.AddBrotliNETCompressor(null, quality, window);
        }

        /// <summary>
        /// Add BrotliNETCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="quality">Quality</param>
        /// <param name="window">Window</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddBrotliNETCompressor(this IServiceCollection services, string name, uint quality = 11, uint window = 22)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, BrotliNETCompressor>(x =>
            {
                return new BrotliNETCompressor(name, quality, window);
            });
            return services;
        }
    }
}
