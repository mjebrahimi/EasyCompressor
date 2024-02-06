using EasyCaching.Core.Configurations;
using EasyCompressor;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// EasyCompressor extensions for EasyCaching
/// </summary>
public static class EasyCompressorExtensions
{
    /// <summary>
    /// Assigns the only one nameless compressor (throws an exception if there is more than One nameless) to all the previously registered serializers that are not assigned to any compressor before.
    /// </summary>
    /// <remarks>
    /// Make sure that all registered serializes are registered before calling this method.
    /// </remarks>
    /// <param name="options">The options.</param>
    public static EasyCachingOptions WithCompressor(this EasyCachingOptions options)
    {
        //var extensionNames = GetPropertyValue<IList<IEasyCachingOptionsExtension>>(options, "Extensions").Select(p => GetFieldValue<string>(p, "_name")).ToArray();

        var optionsExtension = new EasyCompressorEasyCachingOptionsExtension();

        options.RegisterExtension(optionsExtension);

        return options;
    }

    /// <summary>
    /// Assigns the specified compressor by name to all the previously registered serializers that are not assigned to any compressor before.
    /// </summary>
    /// <remarks>
    /// Make sure that all registered serializes are registered before calling this method.
    /// </remarks>
    /// <param name="options">The options.</param>
    /// <param name="compressorName">Name of the compressor.</param>
    public static EasyCachingOptions WithCompressor(this EasyCachingOptions options, string compressorName)
    {
        var optionsExtension = new EasyCompressorEasyCachingOptionsExtension(null, compressorName);

        options.RegisterExtension(optionsExtension);

        return options;
    }

    /// <summary>
    /// Assigns the specified compressor by name to the specified serializer by name.
    /// </summary>
    /// <remarks>
    /// Make sure that all registered serializes are registered before calling this method.
    /// </remarks>
    /// <param name="options">The options.</param>
    /// <param name="serializerName">Name of the serializer.</param>
    /// <param name="compressorName">Name of the compressor.</param>
    public static EasyCachingOptions WithCompressor(this EasyCachingOptions options, string serializerName, string compressorName)
    {
        var optionsExtension = new EasyCompressorEasyCachingOptionsExtension(serializerName, compressorName);

        options.RegisterExtension(optionsExtension);

        return options;
    }
}
