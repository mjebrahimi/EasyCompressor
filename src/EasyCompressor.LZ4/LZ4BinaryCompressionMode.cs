// Ignore Spelling: LZ

namespace EasyCompressor;

/// <summary>
/// LZ4 Binary Compression Mode
/// </summary>
public enum LZ4BinaryCompressionMode
{
    /// <summary>
    /// Legacy compatibility with old/legacy versions. (NOT compatible with other modes neither StreamCompatible nor Fastest modes).
    /// It's a bit faster than StreamCompatible but less efficient in memory allocation specially for large arrays
    /// Note: It prepends 4 bytes to the beginning of the array to define the original array length.
    /// </summary>
    LegacyCompatible,

    /// <summary>
    /// Default compression mode which is compatible with Stream's output. (NOT compatible with other modes neither LegacyCompatible nor Fastest modes).
    /// It's a bit slower than LegacyCompatible but more efficient in memory allocation specially for large arrays.
    /// </summary>
    /// <remarks>
    /// More info: https://github.com/MiloszKrajewski/K4os.Compression.LZ4#other-stream-like-data-structures
    /// </remarks>
    StreamCompatible,

    /// <summary>
    /// The optimized mode. (NOT compatible with other modes neither LegacyCompatible nor StreamCompatible modes)
    /// But it's the fastest and most efficient in memory allocation.
    /// </summary>
    /// <remarks>
    /// More info: https://github.com/MiloszKrajewski/K4os.Compression.LZ4#pickler
    /// </remarks>
    Optimized
}