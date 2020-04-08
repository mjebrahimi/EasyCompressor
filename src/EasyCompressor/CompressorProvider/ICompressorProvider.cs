namespace EasyCompressor
{
    /// <summary>
    /// Compressor provider
    /// </summary>
    public interface ICompressorProvider
    {
        /// <summary>
        /// The compressor by name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns>The compressor.</returns>
        ICompressor GetCompressor(string name);
    }
}
