using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZstdNet;

namespace EasyCompressor
{
    /// <summary>
    /// Zstd compressor
    /// </summary>
    public class ZstdCompressor : BaseCompressor
    {
        /// <summary>
        /// Level
        /// </summary>
        protected readonly int Level;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="level">Level</param>
        public ZstdCompressor(string name = "default", int level = 3)
        {
            Name = name;
            Level = level;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            byte[] compressedBytes;
            using (var options = new CompressionOptions(Level))
            using (var compressor = new Compressor(options))
            {
                compressedBytes = compressor.Wrap(bytes);
            }
            return compressedBytes;
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            byte[] decompressedBytes;
            using (var decompressor = new Decompressor())
            {
                decompressedBytes = decompressor.Unwrap(compressedBytes);
            }
            return decompressedBytes;
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using (var inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory);
                inputStream.Flush();
                inputMemory.Flush();

                var compressedBytes = BaseCompress(inputMemory.ToArray());

                outputStream.Write(compressedBytes, 0, compressedBytes.Length);
                outputStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (var inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory, DefaultBufferSize);
                inputStream.Flush();
                inputMemory.Flush();

                var compressedBytes = BaseDecompress(inputMemory.ToArray());

                outputStream.Write(compressedBytes, 0, compressedBytes.Length);
                outputStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken);
                await inputStream.FlushAsync(cancellationToken);
                await inputMemory.FlushAsync(cancellationToken);

                var compressedBytes = BaseCompress(inputMemory.ToArray());

                await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken);
                await outputStream.FlushAsync();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken);
                await inputStream.FlushAsync(cancellationToken);
                await inputMemory.FlushAsync(cancellationToken);

                var compressedBytes = BaseDecompress(inputMemory.ToArray());

                await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken);
                await outputStream.FlushAsync();
            }
        }
    }
}
