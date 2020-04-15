using EasyCompressor;
using K4os.Compression.LZ4;
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
        /// <param name="level">LZ4Level</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, LZ4Level level = LZ4Level.L12_MAX)
        {
            return services.AddLZ4Compressor(null, level);
        }

        /// <summary>
        /// Add BrotliNETCompressor to services with specified name
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="name">Name</param>
        /// <param name="level">LZ4Level</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddLZ4Compressor(this IServiceCollection services, string name, LZ4Level level = LZ4Level.L12_MAX)
        {
            services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            services.AddSingleton<ICompressor, LZ4Compressor>(x =>
            {
                return new LZ4Compressor(name, level);
            });
            return services;
        }
    }
}
