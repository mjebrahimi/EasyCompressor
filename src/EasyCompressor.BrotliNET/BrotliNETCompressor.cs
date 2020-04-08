using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// BrotliNET compressor
    /// </summary>
    public class BrotliNETCompressor : BaseCompressor
    {
        /// <summary>
        /// Quality
        /// </summary>
        protected readonly uint Quality;

        /// <summary>
        /// Window
        /// </summary>
        protected readonly uint Window;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="quality">Quality</param>
        /// <param name="window">Window</param>
        public BrotliNETCompressor(string name = "default", uint quality = 11, uint window = 22)
        {
            Name = name;
            Quality = quality;
            Window = window;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            using (var inputStream = new MemoryStream(bytes))
            using (var outputStream = new MemoryStream())
            {
                using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress))
                {
                    brotliStream.SetQuality(Quality);
                    brotliStream.SetWindow(Window);
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
                using (var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress))
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
            using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress))
            {
                brotliStream.SetQuality(Quality);
                brotliStream.SetWindow(Window);
                inputStream.CopyTo(brotliStream);

                inputStream.Flush();
                brotliStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress))
            {
                brotliStream.CopyTo(outputStream);

                outputStream.Flush();
                brotliStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress))
            {
                brotliStream.SetQuality(Quality);
                brotliStream.SetWindow(Window);
                await inputStream.CopyToAsync(brotliStream, DefaultBufferSize, cancellationToken);

                await inputStream.FlushAsync(cancellationToken);
                await brotliStream.FlushAsync(cancellationToken);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress))
            {
                await brotliStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken);

                await outputStream.FlushAsync(cancellationToken);
                await brotliStream.FlushAsync(cancellationToken);
            }
        }
    }
}
