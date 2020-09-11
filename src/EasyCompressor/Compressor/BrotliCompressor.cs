#pragma warning disable S1128 // Unused "using" should be removed
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
#pragma warning restore S1128 // Unused "using" should be removed

#pragma warning disable S3261 // Namespaces should not be empty
namespace EasyCompressor
{
#if NETCOREAPP2_1 || NETSTANDARD2_1
    /// <summary>
    /// Brotli compressor
    /// </summary>
    public class BrotliCompressor : BaseCompressor
    {
        /// <summary>
        /// Compression level
        /// </summary>
        protected readonly CompressionLevel Level;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="level">Compression level</param>
        public BrotliCompressor(string name = null, CompressionLevel level = CompressionLevel.Optimal)
        {
            Name = name;
            Level = level;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            using (var inputStream = new MemoryStream(bytes))
            using (var outputStream = new MemoryStream())
            {
                using (var brotliStream = new BrotliStream(outputStream, Level))
                {
                    inputStream.CopyTo(brotliStream, bytes.Length);
                    //inputStream.WriteTo(brotliStream);
                    //brotliStream.Write(bytes, 0, bytes.Length);

                    inputStream.Flush();
                    brotliStream.Flush();
                }
                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            using (var inputStream = new MemoryStream(compressedBytes))
            using (var outputStream = new MemoryStream())
            {
                using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress))
                {
                    brotliStream.CopyTo(outputStream, compressedBytes.Length);

                    outputStream.Flush();
                    brotliStream.Flush();
                }
                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using (var brotliStream = new BrotliStream(outputStream, Level))
            {
                inputStream.CopyTo(brotliStream);

                inputStream.Flush();
                brotliStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress))
            {
                brotliStream.CopyTo(outputStream);

                outputStream.Flush();
                brotliStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var brotliStream = new BrotliStream(outputStream, Level))
            {
                await inputStream.CopyToAsync(brotliStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress))
            {
                await brotliStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
#endif
}
#pragma warning restore S3261 // Namespaces should not be empty
