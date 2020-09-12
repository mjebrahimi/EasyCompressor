using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;

namespace EasyCompressor
{
    /// <summary>
    /// LZ4 compressor
    /// </summary>
    public class LZ4Compressor : BaseCompressor
    {
        /// <summary>
        /// LZ4Level
        /// </summary>
        protected readonly LZ4Level Level;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="level">LZ4Level</param>
        public LZ4Compressor(string name = null, LZ4Level level = LZ4Level.L00_FAST)
        {
            Name = name;
            Level = level;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            var target = new byte[LZ4Codec.MaximumOutputSize(bytes.Length)].AsSpan();
            int compressedBytesSize = LZ4Codec.Encode(bytes, target, Level);
            return target.Slice(0, compressedBytesSize).ToArray();
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            var target = new byte[compressedBytes.Length * 255].AsSpan();
            int decoded = LZ4Codec.Decode(compressedBytes, target);
            return target.Slice(0, decoded).ToArray();
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using (var lz4Stream = LZ4Stream.Encode(outputStream, Level))
            {
                inputStream.CopyTo(lz4Stream);

                inputStream.Flush();
                lz4Stream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (var lz4Stream = LZ4Stream.Decode(inputStream))
            {
                lz4Stream.CopyTo(outputStream);

                inputStream.Flush();
                lz4Stream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var lz4Stream = LZ4Stream.Encode(outputStream, Level))
            {
                await inputStream.CopyToAsync(lz4Stream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var lz4Stream = LZ4Stream.Decode(inputStream))
            {
                await lz4Stream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
