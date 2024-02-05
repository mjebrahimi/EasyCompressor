// Ignore Spelling: Brotli

using System;
using System.ComponentModel;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace EasyCompressor;

/// <summary>
/// BrotliUtils
/// </summary>
public static class BrotliUtils
{
    /// <summary>
    /// The window bits minimum
    /// </summary>
    public const int WindowBits_Min = 10;
    /// <summary>
    /// The window bits default
    /// </summary>
    public const int WindowBits_Default = 22;
    /// <summary>
    /// The window bits maximum
    /// </summary>
    public const int WindowBits_Max = 24;

    /// <summary>
    /// The quality minimum
    /// </summary>
    public const int Quality_Min = 0;
    /// <summary>
    /// The quality default
    /// </summary>
    public const int Quality_Default = 4;
    /// <summary>
    /// The quality maximum
    /// </summary>
    public const int Quality_Max = 11;

    /// <summary>
    /// The maximum input size
    /// </summary>
    public const int MaxInputSize = int.MaxValue - 515; // 515 is the max compressed extra bytes

    /// <summary>
    /// Gets the quality from compression level.
    /// </summary>
    /// <param name="compressionLevel">The compression level.</param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    public static int GetQualityFromCompressionLevel(CompressionLevel compressionLevel)
    {
        return compressionLevel switch
        {
            CompressionLevel.NoCompression => Quality_Min,
            CompressionLevel.Fastest => 1,
            CompressionLevel.Optimal => Quality_Default,
#if NET6_0_OR_GREATER
            CompressionLevel.SmallestSize => Quality_Max,
#endif
            _ => (int)compressionLevel
            //_ => throw new InvalidEnumArgumentException(nameof(compressionLevel), Convert.ToInt32(compressionLevel), typeof(CompressionLevel))
        };
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="quality"/> is not in the valid range.
    /// </summary>
    /// <param name="quality">The quality to validate.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="quality"/> corresponds.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfQualityIsNotValid(int quality,
#if NETCOREAPP3_0_OR_GREATER
        [CallerArgumentExpression(nameof(quality))]
#endif
        string paramName = null)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(quality, Quality_Min, paramName);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(quality, Quality_Max, paramName);
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="window"/> is not in the valid range.
    /// </summary>
    /// <param name="window">The window to validate.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="window"/> corresponds.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfWindowIsNotValid(int window,
#if NETCOREAPP3_0_OR_GREATER
        [CallerArgumentExpression(nameof(window))]
#endif
        string paramName = null)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(window, WindowBits_Min, paramName);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(window, WindowBits_Max, paramName);
    }
}