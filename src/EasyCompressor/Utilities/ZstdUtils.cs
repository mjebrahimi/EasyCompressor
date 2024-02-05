// Ignore Spelling: Zstd Utils

using System;
using System.Runtime.CompilerServices;

namespace EasyCompressor
{
    /// <summary>
    /// ZstdUtils
    /// </summary>
    public static class ZstdUtils
    {
        /// <summary>
        /// The minimum compression level (<see cref="ZstdCompressionLevel.NoCompression"/>)
        /// </summary>
        public const int Level_Min = -(1 << 17); // -131072
        /// <summary>
        /// The default compression level (<see cref="ZstdCompressionLevel.Fast"/>)
        /// </summary>
        public const int Level_Default = -1;
        /// <summary>
        /// The maximum compression level (<see cref="ZstdCompressionLevel.SmallestSize"/>)
        /// </summary>
        public const int Level_Max = 22;

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="compressionLevel"/> is not in the valid range.
        /// </summary>
        /// <param name="compressionLevel">The compression level to validate.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="compressionLevel"/> corresponds.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ThrowIfLevelIsNotValid(int compressionLevel,
#if NETCOREAPP3_0_OR_GREATER
            [CallerArgumentExpression(nameof(compressionLevel))]
#endif
        string paramName = null)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(compressionLevel, Level_Min, paramName);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(compressionLevel, Level_Max, paramName);
        }
    }

    /// <summary>
    /// ZStandard Compression Level
    /// </summary>
    public enum ZstdCompressionLevel
    {
        /// <summary>
        /// No compression should be performed on the file. (Equals to <c>-131072</c>)
        /// </summary>
        NoCompression = ZstdUtils.Level_Min,
        /// <summary>
        /// The compression operation should complete as quickly as possible, even if the resulting file is not optimally compressed. (Equals to <c>-22</c>)
        /// </summary>
        Fastest = -22,
        /// <summary>
        /// The compression operation should optimally balance compression speed and output size. (Our Default - Equals to <c>-1</c>)
        /// </summary>
        Fast = ZstdUtils.Level_Default,
        /// <summary>
        /// The compression operation should optimally balance compression speed and output size. (ZStandard Default - Equals to <c>3</c> or <c>0</c>)
        /// </summary>
        Optimal = 3,
        /// <summary>
        /// The compression operation should create output as small as possible, even if the operation takes a longer time to complete. (Equals to <c>22</c>)
        /// </summary>
        SmallestSize = ZstdUtils.Level_Max,
    }
}
