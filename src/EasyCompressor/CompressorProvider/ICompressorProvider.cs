namespace EasyCompressor;

/// <summary>
/// Compressor provider
/// </summary>
public interface ICompressorProvider
{
    /// <summary>
    /// Gets the compressor by name.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The compressor.</returns>
    ICompressor GetCompressor(string name);
}
