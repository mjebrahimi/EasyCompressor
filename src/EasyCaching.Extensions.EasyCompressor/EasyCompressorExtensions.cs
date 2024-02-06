using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCompressor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        var extensions = TryGetExtensions(options);
        if (extensions?.Contains(serializerName) == false)
            throw new EasyCachingNotFoundException($"Can not find a matched Serializer instance with name '{serializerName}'.");

        var optionsExtension = new EasyCompressorEasyCachingOptionsExtension(serializerName, compressorName);

        options.RegisterExtension(optionsExtension);

        return options;
    }

    private static string[] TryGetExtensions(EasyCachingOptions options)
    {
        try
        {
            return GetProperty<IList<IEasyCachingOptionsExtension>>(options, "Extensions").Select(p => GetField<string>(p, "_name")).ToArray();
        }
        catch
        {
            return null;
        }
    }

    private static T GetField<T>(this object obj, string name)
    {
        //Set the flags so that private and public fields from instances will be found
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var field = obj.GetType().GetField(name, bindingFlags);
        return (T)field?.GetValue(obj);
    }


    private static T GetProperty<T>(this object obj, string name)
    {
        //Set the flags so that private and public fields from instances will be found
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var field = obj.GetType().GetProperty(name, bindingFlags);
        return (T)field?.GetValue(obj);
    }
}
