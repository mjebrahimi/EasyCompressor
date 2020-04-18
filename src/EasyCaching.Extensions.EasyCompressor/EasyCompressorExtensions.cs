using EasyCaching.Core.Configurations;
using EasyCompressor;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// EasyCompressor extensions for EasyCaching
    /// </summary>
    public static partial class EasyCompressorExtensions
    {
        /// <summary>
        /// Add default compressor upon the default serializer.
        /// </summary>
        /// <param name="options">EasyCachingOptions</param>
        /// <returns>EasyCachingOptions</returns>
        public static EasyCachingOptions WithCompressor(this EasyCachingOptions options)
        {
            var optionsExtension = new EasyCompressorEasyCachingOptionsExtension();

            options.RegisterExtension(optionsExtension);

            return options;
        }

        /// <summary>
        /// Add specified compressor upon the specified serializer by name.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="serializerName"></param>
        /// <param name="compressorName"></param>
        /// <returns></returns>
        public static EasyCachingOptions WithCompressor(this EasyCachingOptions options, string serializerName, string compressorName)
        {
            var optionsExtension = new EasyCompressorEasyCachingOptionsExtension(serializerName, compressorName);

            options.RegisterExtension(optionsExtension);

            return options;
        }
    }
}
