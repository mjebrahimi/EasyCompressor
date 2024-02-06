using SevenZip;
using System;
using System.ComponentModel;

namespace EasyCompressor;

/// <summary>
/// LZMA Properties
/// </summary>
/// <remarks>
/// https://gist.github.com/ststeiger/cb9750664952f775a341
/// https://7zip.bugaco.com/7zip/MANUAL/cmdline/switches/method.htm#LZMA
/// https://web.mit.edu/outland/arch/i386_rhel4/build/p7zip-current/DOCS/MANUAL/switches/method.htm#LZMA
/// https://android.googlesource.com/platform/external/lzma/+/idea133%5E1..idea133/
/// </remarks>
#pragma warning disable S101 // Types should be named in PascalCase
public static class LZMAProperties
#pragma warning restore S101 // Types should be named in PascalCase
{
    /// <summary>
    /// Gets the properties.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/>)</param>
    /// <returns></returns>
    public static object[] GetProperties(LZMACompressionLevel compressionLevel)
    {
        return GetProperties(compressionLevel, compressionLevel.GetDictionarySize());
    }

    /// <summary>
    /// Gets the properties.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="LZMACompressionLevel.UltraFast"/>)</param>
    /// <param name="dictionarySize">Size of the dictionary. (Defaults to <see cref="DictionarySize.Smallest_64KB"/>)</param>
    /// <returns></returns>
    public static object[] GetProperties(LZMACompressionLevel compressionLevel, DictionarySize dictionarySize)
    {
        const int litContextBits = 3;               // Default: 3 (from 0 to 8)
        const int litPosBits = 0;                   // Default: 0 (from 0 to 4)
        const int posStateBits = 2;                 // Default: 2 (from 0 to 4)
        const bool endMarker = false;               // Default: false (write End Of Stream marker. By default LZMA doesn't write eos marker, since LZMA decoder knows uncompressed size  stored in .lzma file header.)
        const string matchFinder = "BT4";           //compressionLevel.GetMatchFinder(); // Default: BT4 (BT2|BT3|BT4|HC4) - depends on compression level
        var numFastBytes = (int)compressionLevel;   // Default: there is not default but our default is LZMACompressionLevel.UltraFast (5) (from 5 to 273)
        var dictionary = (int)dictionarySize;       // Default: depends on compression level.
        //https://web.mit.edu/outland/arch/i386_rhel4/build/p7zip-current/DOCS/MANUAL/switches/method.htm#Solid [off | on | [e] [{N}f] [{N}b | {N}k | {N}m | {N}g)]
        //const string blockSize = "off";             // Default: depends on compression level (Fastest:16MB, Fast:128MB, Normal:2GB, Maximum:4GB, Ultra:4GB)

        return
            [
                litContextBits,
                litPosBits,
                posStateBits,
                endMarker,
                //matchFinderCycles
                matchFinder,
                numFastBytes,
                dictionary,
                //blockSize,
            ];
    }

    /// <summary>
    /// Gets the property IDs.
    /// </summary>
    /// <value>
    /// The property IDs.
    /// </value>
    public static readonly CoderPropID[] PropIDs =
        [
            CoderPropID.LitContextBits,             // Default: 3 (from 0 to 8)
            CoderPropID.LitPosBits,                 // Default: 0 (from 0 to 4)
            CoderPropID.PosStateBits,               // Default: 2 (from 0 to 4)
            CoderPropID.EndMarker,                  // Default: false (write End Of Stream marker. By default LZMA doesn't write eos marker, since LZMA decoder knows uncompressed size  stored in .lzma file header.)
            //CoderPropID.MatchFinderCycles,          // Default: (from 0 to 1000000000) - 0 can be good
            CoderPropID.MatchFinder,                // Default: BT4 (BT2|BT3|BT4|HC4)
            CoderPropID.NumFastBytes,               // Default: there is not default but our default is LZMACompressionLevel.UltraFast (5) (from 5 to 273)
            CoderPropID.DictionarySize,             // Default: depends on compression level.
            //https://web.mit.edu/outland/arch/i386_rhel4/build/p7zip-current/DOCS/MANUAL/switches/method.htm#Solid [off | on | [e] [{N}f] [{N}b | {N}k | {N}m | {N}g)]
            //CoderPropID.BlockSize,                  // Default: depends on compression level (Fastest:64MB, Fast:1GB, Normal:4GB, Maximum:8GB, Ultra:16GB)
        ];

    /// <summary>
    /// Gets the size of the dictionary based on the compression level
    /// </summary>
    /// <param name="compressionLevel">The compression level.</param>
    /// <returns></returns>
    public static DictionarySize GetDictionarySize(this LZMACompressionLevel compressionLevel)
    {
        return compressionLevel switch
        {
            LZMACompressionLevel.UltraFast => DictionarySize.Smallest_64KB,
            LZMACompressionLevel.Fastest => DictionarySize.VerySmall_256KB,
            LZMACompressionLevel.Fast => DictionarySize.Small_4MB,
            LZMACompressionLevel.Normal => DictionarySize.Medium_16MB,
            LZMACompressionLevel.Maximum => DictionarySize.Large_32MB,
            LZMACompressionLevel.Ultra => DictionarySize.VeryLarge_64MB,
            _ => throw new InvalidEnumArgumentException(nameof(compressionLevel), Convert.ToInt32(compressionLevel), typeof(LZMACompressionLevel))
        };
    }

    //private static string GetMatchFinder(this LZMACompressionLevel compressionLevel)
    //{
    //    return (compressionLevel) switch
    //    {
    //        LZMACompressionLevel.UltraFast => "HC4",
    //        LZMACompressionLevel.Fastest => "HC4",
    //        LZMACompressionLevel.Fast => "HC4",
    //        LZMACompressionLevel.Normal => "BT4",
    //        LZMACompressionLevel.Maximum => "BT4",
    //        LZMACompressionLevel.Ultra => "BT4",
    //        _ => throw new InvalidEnumArgumentException(nameof(compressionLevel), Convert.ToInt32(compressionLevel), typeof(LZMACompressionLevel))
    //    };
    //}
}

/// <summary>
/// LZMA Compression Level
/// </summary>
public enum LZMACompressionLevel
{
    /// <summary>
    /// UltraFast [custom mode] (our Default)
    /// </summary>
    UltraFast = 5,
    /// <summary>
    /// Fastest
    /// </summary>
    Fastest = 8,
    /// <summary>
    /// Fast
    /// </summary>
    Fast = 16,
    /// <summary>
    /// Normal
    /// </summary>
    Normal = 32,
    /// <summary>
    /// Maximum
    /// </summary>
    Maximum = 64,
    /// <summary>
    /// Ultra
    /// </summary>
    Ultra = 128
}

/// <summary>
/// Dictionary Size
/// </summary>
public enum DictionarySize
{
    ///<summary>
    ///64 KB (Default for <see cref="LZMACompressionLevel.UltraFast"/> mode)
    ///</summary>
    Smallest_64KB = 1 << 16,
    ///<summary>
    ///256 KB (Default for <see cref="LZMACompressionLevel.Fastest"/> mode)
    ///</summary>
    VerySmall_256KB = 1 << 18,
    ///<summary>
    ///4 MB (Default for <see cref="LZMACompressionLevel.Fast"/> mode)
    ///</summary>
    Small_4MB = 1 << 22,
    ///<summary>
    ///16 MB (Default for <see cref="LZMACompressionLevel.Normal"/> mode)
    ///</summary>
    Medium_16MB = 1 << 24,
    /// <summary>
    /// 32 MB (Default for <see cref="LZMACompressionLevel.Maximum"/> mode)
    /// </summary>
    Large_32MB = 1 << 25,
    ///<summary>
    ///64 MB (Default for <see cref="LZMACompressionLevel.Ultra"/> mode)
    ///</summary>
    VeryLarge_64MB = 1 << 26
}