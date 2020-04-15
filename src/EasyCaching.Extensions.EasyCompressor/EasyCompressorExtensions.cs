using EasyCaching.Core.Configurations;
using EasyCompressor;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class EasyCompressorExtensions
    {
        public static EasyCachingOptions WithCompressor(this EasyCachingOptions options)
        {
            var optionsExtension = new EasyCompressorEasyCachingOptionsExtension();

            options.RegisterExtension(optionsExtension);

            return options;
        }

        public static EasyCachingOptions WithCompressor(this EasyCachingOptions options, string serializerName, string compressorName)
        {
            //serializerName.NotNullOrWhiteSpace(nameof(serializerName));

            var optionsExtension = new EasyCompressorEasyCachingOptionsExtension(serializerName, compressorName);

            options.RegisterExtension(optionsExtension);

            return options;
        }
    }
}
