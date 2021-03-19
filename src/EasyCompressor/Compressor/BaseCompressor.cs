using EasyCompressor.Internal;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// Base compressor
    /// </summary>
    public abstract class BaseCompressor : ICompressor
    {
        /// <summary>
        /// Default buffer size
        /// </summary>
        protected const int DefaultBufferSize = 81920;

        /// <inheritdoc/>
        public string Name { get; protected set; }

        /// <summary>
        /// Base dompress bytes
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Return compressed bytes</returns>
        protected abstract byte[] BaseCompress(byte[] bytes);

        /// <summary>
        /// Base decompress bytes
        /// </summary>
        /// <param name="compressedBytes">Compressed bytes</param>
        /// <returns>Return uncompressed bytes</returns>
        protected abstract byte[] BaseDecompress(byte[] compressedBytes);

        /// <summary>
        /// Base compress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveOutputStreamOpen">Indicates if output stream should be left open after the operation completes.</param>
        protected abstract void BaseCompress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false);

        /// <summary>
        /// Base decompress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveInputStreamOpen">Indicates if input stream should be left open after the operation completes.</param>
        protected abstract void BaseDecompress(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false);

        /// <summary>
        /// Base compress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveOutputStreamOpen">Indicates if output stream should be left open after the operation completes.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        protected abstract Task BaseCompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Base decompress input stream to output stream
        /// </summary>
        /// <param name="inputStream">Input stream</param>
        /// <param name="outputStream">Output stream</param>
        /// <param name="leaveInputStreamOpen">Indicates if input stream should be left open after the operation completes.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        protected abstract Task BaseDecompressAsync(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false, CancellationToken cancellationToken = default);

        /// <inheritdoc/>
        public byte[] Compress(byte[] bytes)
        {
            bytes.NotNullOrEmpty(nameof(bytes));

            return BaseCompress(bytes);
        }

        /// <inheritdoc/>
        public byte[] Decompress(byte[] compressedBytes)
        {
            compressedBytes.NotNullOrEmpty(nameof(compressedBytes));

            return BaseDecompress(compressedBytes);
        }

        /// <inheritdoc/>
        public void Compress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false)
        {
            inputStream.NotNull(nameof(inputStream));
            outputStream.NotNull(nameof(outputStream));

            BaseCompress(inputStream, outputStream, leaveOutputStreamOpen);
        }

        /// <inheritdoc/>
        public void Decompress(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false)
        {
            inputStream.NotNull(nameof(inputStream));
            outputStream.NotNull(nameof(outputStream));

            BaseDecompress(inputStream, outputStream, leaveInputStreamOpen);
        }

        /// <inheritdoc/>
        public Task CompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            inputStream.NotNull(nameof(inputStream));
            outputStream.NotNull(nameof(outputStream));

            return BaseCompressAsync(inputStream, outputStream, leaveOutputStreamOpen, cancellationToken);
        }

        /// <inheritdoc/>
        public Task DecompressAsync(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            inputStream.NotNull(nameof(inputStream));
            outputStream.NotNull(nameof(outputStream));

            return BaseDecompressAsync(inputStream, outputStream, leaveInputStreamOpen, cancellationToken);
        }
    }
}
