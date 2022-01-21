namespace EasyCompressor
{
    /// <summary>
    /// Compression method
    /// </summary>
    public enum CompressionMethod
    {
        /// <summary>
        /// Deflate
        /// </summary>
        Deflate,

        /// <summary>
        /// GZip
        /// </summary>
        GZip,

        /// <summary>
        /// Brotli
        /// </summary>
        Brotli,

        /// <summary>
        /// LZ4
        /// </summary>
        LZ4,

        /// <summary>
        /// LZMA
        /// </summary>
        LZMA,

        /// <summary>
        /// Snappy
        /// </summary>
        Snappy,

        /// <summary>
        /// Zstd
        /// </summary>
        Zstd
    }
}
