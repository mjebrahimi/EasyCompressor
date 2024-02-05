// Ignore Spelling: LZ

namespace EasyCompressor;

/// <summary>
/// LZ4 Binary Compression Mode
/// </summary>
public enum LZ4BinaryCompressionMode
{
    /// <summary>
    /// Legacy compatibility with old/legacy versions. (NOT compatible with other modes neither StreamCompatible nor Optimal modes)
    /// It's fastest mode (a bit faster than Optimal) but less efficient in memory allocation. (Fast_GCInefficient)
    /// Note:
    /// It prepends 4 bytes to the beginning of the array to define the original array length.
    /// It applies only to binary Compress/Decompress and have no effect on Stream/Stream[Async] methods.
    /// </summary>
    LegacyCompatible,

    /// <summary>
    /// StreamCompatible which is compatible with Stream's output. (NOT compatible with other modes neither LegacyCompatible nor Optimal modes)
    /// It's slower than other modes but moderate in memory allocation. (Slow_GCModerated)
    /// </summary>
    /// <remarks>
    /// More info: https://github.com/MiloszKrajewski/K4os.Compression.LZ4#other-stream-like-data-structures
    /// </remarks>
    StreamCompatible,

    /// <summary>
    /// Default compression mode. (NOT compatible with other modes neither LegacyCompatible nor StreamCompatible modes)
    /// But it's fast and most efficient in memory allocation. (Best Performance overall - Fast_GCEfficient)
    /// Note:
    /// It applies only to binary Compress/Decompress and have no effect on Stream/Stream[Async] methods.
    /// </summary>
    /// <remarks>
    /// More info: https://github.com/MiloszKrajewski/K4os.Compression.LZ4#pickler
    /// </remarks>
    Optimal,
}