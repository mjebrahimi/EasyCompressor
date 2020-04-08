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
        /// Add ZstdCompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="level">Level</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddZstdCompressor(this IServiceCollection services, int level = 3)
        {
            return services.AddZstdCompressor("default", level);
        }

        /// <summary>
        /// Add ZstdCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="level">Level</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddZstdCompressor(this IServiceCollection services, string name, int level = 3)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, ZstdCompressor>(x =>
            {
                return new ZstdCompressor(name, level);
            });
            return services;
        }
    }
}
