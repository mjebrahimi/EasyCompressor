using SevenZip;

namespace EasyCompressor;

/// <summary>
/// LZMA Compression Options
/// </summary>
#pragma warning disable S101 // Types should be named in PascalCase
public class LZMACompressionOptions
#pragma warning restore S101 // Types should be named in PascalCase
{
    /// <summary>
    /// Gets or sets the speed. (Defaults to <see cref="LZMASpeed.VerySlow"/>
    /// </summary>
    /// <value>
    /// The speed.
    /// </value>
    public LZMASpeed Speed { get; set; } = LZMASpeed.VerySlow;

    /// <summary>
    /// Gets or sets the size of the dictionary. (Defaults to <see cref="DictionarySize.Large"/> <c>(8 MiB)</c> )
    /// </summary>
    /// <value>
    /// The size of the dictionary.
    /// </value>
    public DictionarySize DictionarySize { get; set; } = DictionarySize.Large;

    /// <summary>
    /// Gets the properties.
    /// </summary>
    /// <returns></returns>
    internal object[] GetProperties()
    {
        const int posStateBits = 2; // default: 2
        const int litContextBits = 3; // 3 for normal files, 0 for 32-bit data (uint)
        const int litPosBits = 0; // 0 for 64-bit data, 2 for 32-bit data (uint)
        //const int algorithm = 2; // default: 2
        var numFastBytes = (int)Speed; //default: 128 (LZMASpeed.VerySlow)
        const string matchFinder = "BT4"; // default: BT4
        const bool endMarker = true; // default: false

        return
            [
                (int)DictionarySize,
                posStateBits,
                litContextBits,
                litPosBits,
                numFastBytes,
                matchFinder,
                endMarker
            ];
    }

    internal static readonly CoderPropID[] PropIDs =
        [
            CoderPropID.DictionarySize,
            CoderPropID.PosStateBits, // (0 <= x <= 4).
            CoderPropID.LitContextBits, // (0 <= x <= 8).
            CoderPropID.LitPosBits, // (0 <= x <= 4).
            //CoderPropID.Algorithm,
            CoderPropID.NumFastBytes,
            CoderPropID.MatchFinder, // "BT2", "BT4".
            CoderPropID.EndMarker
        ];
}

/// <summary>
/// LZMA Speed
/// </summary>
public enum LZMASpeed
{
    /// <summary>
    /// Fastest
    /// </summary>
    Fastest = 5,
    /// <summary>
    /// Very fast
    /// </summary>
    VeryFast = 8,
    /// <summary>
    /// Fast
    /// </summary>
    Fast = 16,
    /// <summary>
    /// Medium
    /// </summary>
    Medium = 32,
    /// <summary>
    /// Slow
    /// </summary>
    Slow = 64,
    /// <summary>
    /// Very slow
    /// </summary>
    VerySlow = 128,
}

/// <summary>
/// Dictionary Size
/// </summary>
public enum DictionarySize
{
    ///<summary>
    ///64 KiB
    ///</summary>
    VerySmall = 1 << 16,
    ///<summary>
    ///1 MiB
    ///</summary>
    Small = 1 << 20,
    ///<summary>
    ///4 MiB
    ///</summary>
    Medium = 1 << 22,
    ///<summary>
    ///8 MiB (Default)
    ///</summary>
    Large = 1 << 23,
    ///<summary>
    ///16 MiB
    ///</summary>
    Larger = 1 << 24,
    ///<summary>
    ///64 MiB
    ///</summary>
    VeryLarge = 1 << 26,
}