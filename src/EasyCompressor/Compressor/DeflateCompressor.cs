using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// Deflate compressor
    /// </summary>
    public class DeflateCompressor : BaseCompressor
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
        public DeflateCompressor(string name = "default", CompressionLevel level = CompressionLevel.Optimal)
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
                using (var deflateStream = new DeflateStream(outputStream, Level))
                {
                    inputStream.CopyTo(deflateStream, bytes.Length);
                    //inputStream.WriteTo(deflateStream);
                    //deflateStream.Write(bytes, 0, bytes.Length);

                    inputStream.Flush();
                    deflateStream.Flush();
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
                using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    deflateStream.CopyTo(outputStream, compressedBytes.Length);

                    outputStream.Flush();
                    deflateStream.Flush();
                }
                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using (var deflateStream = new DeflateStream(outputStream, Level))
            {
                inputStream.CopyTo(deflateStream);

                inputStream.Flush();
                deflateStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(outputStream);

                outputStream.Flush();
                deflateStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var deflateStream = new DeflateStream(outputStream, Level))
            {
                await inputStream.CopyToAsync(deflateStream, DefaultBufferSize, cancellationToken);

                await inputStream.FlushAsync(cancellationToken);
                await deflateStream.FlushAsync(cancellationToken);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress))
            {
                await deflateStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken);

                await outputStream.FlushAsync(cancellationToken);
                await deflateStream.FlushAsync(cancellationToken);
            }
        }
    }
}
