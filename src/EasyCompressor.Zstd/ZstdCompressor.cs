using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
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
        static ZstdCompressor()
        {
            //This is no longer needed according to ZstdNet v1.4.5 update
            #region Load libzstd v1.4.4 DLL
            ////Workaround to fix "System.DllNotFoundException: Unable to load DLL 'libzstd' or one of its dependencies: The specified module could not be found."

            //if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //    return;

            //var bit = Environment.Is64BitProcess ? "x64" : "x86";
            //var folder = Path.Combine(Path.GetTempPath(), "zstd-v1.4.4", bit);
            //Directory.CreateDirectory(folder);

            //var fileName = Path.Combine(folder, "libzstd.dll");
            //if (!File.Exists(fileName))
            //{
            //    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"libzstd.{bit}.dll"))
            //    using (var file = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            //        stream.CopyTo(file);
            //}

            //var type = typeof(Compressor).Assembly.GetType("ZstdNet.ExternMethods");
            //var method = type.GetMethod("SetDllDirectory", BindingFlags.NonPublic | BindingFlags.Static);
            //method.Invoke(null, new[] { folder });
            #endregion
        }

        /// <summary>
        /// Level
        /// </summary>
        protected readonly int Level;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="level">Level</param>
        public ZstdCompressor(string name = null, int level = 3)
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
            using var inputMemory = new MemoryStream();
            inputStream.CopyTo(inputMemory);
            inputStream.Flush();
            inputMemory.Flush();

            var compressedBytes = BaseCompress(inputMemory.ToArray());

            outputStream.Write(compressedBytes, 0, compressedBytes.Length);
            outputStream.Flush();
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using var inputMemory = new MemoryStream();
            inputStream.CopyTo(inputMemory, DefaultBufferSize);
            inputStream.Flush();
            inputMemory.Flush();

            var compressedBytes = BaseDecompress(inputMemory.ToArray());

            outputStream.Write(compressedBytes, 0, compressedBytes.Length);
            outputStream.Flush();
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using var inputMemory = new MemoryStream();
            await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
            await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);

            var compressedBytes = BaseCompress(inputMemory.ToArray());

            await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken).ConfigureAwait(false);
            await outputStream.FlushAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using var inputMemory = new MemoryStream();
            await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
            await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);

            var compressedBytes = BaseDecompress(inputMemory.ToArray());

            await outputStream.WriteAsync(compressedBytes, 0, compressedBytes.Length, cancellationToken).ConfigureAwait(false);
            await outputStream.FlushAsync().ConfigureAwait(false);
        }
    }
}
