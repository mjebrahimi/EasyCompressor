using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// ICompressor
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// Compressor name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Compress bytes
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Return compressed bytes</returns>
        byte[] Compress(byte[] bytes);

        /// <summary>
        /// Decompress bytes
        /// </summary>
        /// <param name="compressedBytes">Compressed bytes</param>
        /// <returns>Return uncompressed bytes</returns>
        byte[] Decompress(byte[] compressedBytes);

        /// <summary>
        /// Compress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveOutputStreamOpen">Indicates if output stream should be left open after the operation completes.</param>
        void Compress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false);

        /// <summary>
        /// Decompress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveInputStreamOpen">Indicates if input stream should be left open after the operation completes.</param>
        void Decompress(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false);

        /// <summary>
        /// Compress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveOutputStreamOpen">Indicates if output stream should be left open after the operation completes.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task CompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Decompress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveInputStreamOpen">Indicates if input stream should be left open after the operation completes.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task DecompressAsync(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false, CancellationToken cancellationToken = default);
    }
}
