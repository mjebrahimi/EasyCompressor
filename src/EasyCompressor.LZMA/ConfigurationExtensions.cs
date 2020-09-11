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
        /// Add LZMACompressor to services
        /// </summary>
        /// <param name="services">services</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddLZMACompressor(this IServiceCollection services)
        {
            return services.AddLZMACompressor(null);
        }

        /// <summary>
        /// Add LZMACompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddLZMACompressor(this IServiceCollection services, string name)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, LZMACompressor>(_ => new LZMACompressor(name));
            return services;
        }
    }
}
