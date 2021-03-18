﻿using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Zstandard.Net;

namespace EasyCompressor
{
    /// <summary>
    /// Zstandard compressor
    /// </summary>
    public class ZstandardCompressor : BaseCompressor
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
        public ZstandardCompressor(string name = null, int level = 3)
        {
            Name = name;
            Level = level;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            //using (var outputStream = new MemoryStream())
            //{
            //    using (var zstandardStream = new ZstandardStream(outputStream, DefaultLevel))
            //    {
            //        zstandardStream.Write(bytes, 0, bytes.Length);
            //        zstandardStream.Flush();
            //    }
            //    return outputStream.ToArray();
            //}

            using (var inputStream = new MemoryStream(bytes))
            using (var outputStream = new MemoryStream())
            {
                using (var zstandardStream = new ZstandardStream(outputStream, Level))
                {
                    inputStream.CopyTo(zstandardStream, bytes.Length);
                    //inputStream.WriteTo(zstandardStream);
                    //zstandardStream.Write(bytes, 0, bytes.Length);

                    inputStream.Flush();
                    zstandardStream.Flush();
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
                using (var gZipStream = new ZstandardStream(inputStream, CompressionMode.Decompress))
                {
                    gZipStream.CopyTo(outputStream, compressedBytes.Length);

                    outputStream.Flush();
                    gZipStream.Flush();
                }
                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false)
        {
            using (var gZipStream = new ZstandardStream(outputStream, Level, leaveOutputStreamOpen))
            {
                inputStream.CopyTo(gZipStream);

                inputStream.Flush();
                gZipStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false)
        {
            using (var gZipStream = new ZstandardStream(inputStream, CompressionMode.Decompress, leaveOutputStreamOpen))
            {
                gZipStream.CopyTo(outputStream);

                outputStream.Flush();
                gZipStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            using (var gZipStream = new ZstandardStream(outputStream, Level, leaveOutputStreamOpen))
            {
                await inputStream.CopyToAsync(gZipStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, bool leaveOutputStreamOpen = false, CancellationToken cancellationToken = default)
        {
            using (var gZipStream = new ZstandardStream(inputStream, CompressionMode.Decompress, leaveOutputStreamOpen))
            {
                await gZipStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

                await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
