using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// ICompressor extensions
/// </summary>
public static class CompressorExtensions
{
    #region byte[] to Stream

    /// <summary>
    /// Compress input byte[] and write to output Stream
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="bytes">bytes</param>
    /// <param name="outputStream">outputStream</param>
    public static void Compress(this ICompressor compressor, byte[] bytes, Stream outputStream)
    {
        using var inputStream = new MemoryStream(bytes);
        compressor.Compress(inputStream, outputStream);
    }

    /// <summary>
    /// Decompress input byte[] and write to output Stream
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="compressedBytes">compressedBytes</param>
    /// <param name="outputStream">outputStream</param>
    public static void Decompress(this ICompressor compressor, byte[] compressedBytes, Stream outputStream)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        compressor.Decompress(inputStream, outputStream);
    }

    /// <summary>
    /// Compress input byte[] and write to output Stream
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="bytes">bytes</param>
    /// <param name="outputStream">outputStream</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public static async Task CompressAsync(this ICompressor compressor, byte[] bytes, Stream outputStream, CancellationToken cancellationToken = default)
    {
#pragma warning disable RCS1261 // Resource can be disposed asynchronously
        using var inputStream = new MemoryStream(bytes);
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
        await compressor.CompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Decompress input byte[] and write to output Stream
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="compressedBytes">compressedBytes</param>
    /// <param name="outputStream">outputStream</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public static async Task DecompressAsync(this ICompressor compressor, byte[] compressedBytes, Stream outputStream, CancellationToken cancellationToken = default)
    {
#pragma warning disable RCS1261 // Resource can be disposed asynchronously
        using var inputStream = new MemoryStream(compressedBytes);
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
        await compressor.DecompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
    }
    #endregion

    #region Stream to byte[]

    /// <summary>
    /// Read from input Stream then compress it's content and return byte[]
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="inputStream">inputStream</param>
    /// <returns>Task</returns>
    public static byte[] Compress(this ICompressor compressor, Stream inputStream)
    {
        using var outputStream = new MemoryStream();
        compressor.Compress(inputStream, outputStream);
        return outputStream.GetTrimmedBuffer();
    }

    /// <summary>
    /// Read from input Stream then decompress it's content  and return byte[]
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="inputStream">inputStream</param>
    /// <returns>Task</returns>
    public static byte[] Decompress(this ICompressor compressor, Stream inputStream)
    {
        using var outputStream = new MemoryStream();
        compressor.Decompress(inputStream, outputStream);
        return outputStream.GetTrimmedBuffer();
    }

    /// <summary>
    /// Read from input Stream then compress it's content and return byte[]
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="inputStream">inputStream</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public static async Task<byte[]> CompressAsync(this ICompressor compressor, Stream inputStream, CancellationToken cancellationToken = default)
    {
#pragma warning disable RCS1261 // Resource can be disposed asynchronously
        using var outputStream = new MemoryStream();
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
        await compressor.CompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
        return outputStream.GetTrimmedBuffer();
    }

    /// <summary>
    /// Read from input Stream then decompress it's content  and return byte[]
    /// </summary>
    /// <param name="compressor">compressor</param>
    /// <param name="inputStream">inputStream</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public static async Task<byte[]> DecompressAsync(this ICompressor compressor, Stream inputStream, CancellationToken cancellationToken = default)
    {
#pragma warning disable RCS1261 // Resource can be disposed asynchronously
        using var outputStream = new MemoryStream();
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
        await compressor.DecompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
        return outputStream.GetTrimmedBuffer();
    }
    #endregion
}
