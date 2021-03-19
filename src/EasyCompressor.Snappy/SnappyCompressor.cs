using Snappy;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// Snappy compressor
    /// </summary>
    public class SnappyCompressor : BaseCompressor
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        public SnappyCompressor(string name = null)
        {
            Name = name;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            return SnappyCodec.Compress(bytes);
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            return SnappyCodec.Uncompress(compressedBytes);
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false)
        {
            using (var inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory);
                inputStream.Flush();
                inputMemory.Flush();

                var compressedBytes = BaseCompress(inputMemory.ToArray());

                outputStream.Write(compressedBytes, 0, compressedBytes.Length);
                outputStream.Flush();

                if (!leaveOutputStreamOpen)
                    outputStream.Dispose();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false)
        {
            using (var inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory, DefaultBufferSize);
                inputStream.Flush();
                inputMemory.Flush();

                var compressedBytes = BaseDecompress(inputMemory.ToArray());

                outputStream.Write(compressedBytes, 0, compressedBytes.Length);
                outputStream.Flush();

                if (!leaveInputStreamOpen)
                    inputStream.Dispose();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            using (var inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);

                var compressedBytes = BaseCompress(inputMemory.ToArray());

                await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken).ConfigureAwait(false);
                await outputStream.FlushAsync().ConfigureAwait(false);

                if (!leaveOutputStreamOpen)
                    outputStream.Dispose();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, bool leaveInputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            using (var inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);

                var compressedBytes = BaseDecompress(inputMemory.ToArray());

                await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken).ConfigureAwait(false);
                await outputStream.FlushAsync().ConfigureAwait(false);

                if (!leaveInputStreamOpen)
                    inputStream.Dispose();
            }
        }
    }
}
