using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /// <summary>
    /// ICompressor extensions
    /// </summary>
    public static class CompressorExtensions
    {
        #region byte[] to Stream/StreamWriter

        /// <summary>
        /// Compress input byte[] and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="bytes">bytes</param>
        /// <param name="outputStream">outputStream</param>
        public static void Compress(this ICompressor compressor, byte[] bytes, Stream outputStream)
        {
            using (var inputStream = new MemoryStream(bytes))
            {
                compressor.Compress(inputStream, outputStream);
            }
        }

        /// <summary>
        /// Decompress input byte[] and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="compressedBytes">compressedBytes</param>
        /// <param name="outputStream">outputStream</param>
        public static void Decompress(this ICompressor compressor, byte[] compressedBytes, Stream outputStream)
        {
            using (var inputStream = new MemoryStream(compressedBytes))
            {
                compressor.Decompress(inputStream, outputStream);
            }
        }

        /// <summary>
        /// Compress input byte[] and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="bytes">bytes</param>
        /// <param name="outputStream">outputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task CompressAsync(this ICompressor compressor, byte[] bytes, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var inputStream = new MemoryStream(bytes))
            {
                return compressor.CompressAsync(inputStream, outputStream, cancellationToken);
            }
        }

        /// <summary>
        /// Decompress input byte[] and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="compressedBytes">compressedBytes</param>
        /// <param name="outputStream">outputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task DecompressAsync(this ICompressor compressor, byte[] compressedBytes, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (var inputStream = new MemoryStream(compressedBytes))
            {
                return compressor.DecompressAsync(inputStream, outputStream, cancellationToken);
            }
        }

        /// <summary>
        /// Compress input byte[] and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="bytes">bytes</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Compress(this ICompressor compressor, byte[] bytes, StreamWriter outputWriter)
        {
            compressor.Compress(bytes, outputWriter.BaseStream);
        }

        /// <summary>
        /// Decompress input byte[] and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="compressedBytes">compressedBytes</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Decompress(this ICompressor compressor, byte[] compressedBytes, StreamWriter outputWriter)
        {
            compressor.Decompress(compressedBytes, outputWriter.BaseStream);
        }

        /// <summary>
        /// Compress input byte[] and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="bytes">bytes</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task CompressAsync(this ICompressor compressor, byte[] bytes, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.CompressAsync(bytes, outputWriter.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Decompress input byte[] and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="compressedBytes">compressedBytes</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task DecompressAsync(this ICompressor compressor, byte[] compressedBytes, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.DecompressAsync(compressedBytes, outputWriter.BaseStream, cancellationToken);
        }

        #endregion

        #region Stream to byte[]/StreamWriter

        /// <summary>
        /// Read from input Stream then compress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <returns>Task</returns>
        public static byte[] Compress(this ICompressor compressor, Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            {
                compressor.Compress(inputStream, outputStream);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Read from input Stream then decompress it's content  and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <returns>Task</returns>
        public static byte[] Decompress(this ICompressor compressor, Stream inputStream)
        {
            using (var outputStream = new MemoryStream())
            {
                compressor.Decompress(inputStream, outputStream);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Read from input Stream then compress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static async Task<byte[]> CompressAsync(this ICompressor compressor, Stream inputStream, CancellationToken cancellationToken = default)
        {
            using (var outputStream = new MemoryStream())
            {
                await compressor.CompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Read from input Stream then decompress it's content  and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static async Task<byte[]> DecompressAsync(this ICompressor compressor, Stream inputStream, CancellationToken cancellationToken = default)
        {
            using (var outputStream = new MemoryStream())
            {
                await compressor.DecompressAsync(inputStream, outputStream, cancellationToken).ConfigureAwait(false);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        /// Read from input Stream then compress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Compress(this ICompressor compressor, Stream inputStream, StreamWriter outputWriter)
        {
            compressor.Compress(inputStream, outputWriter.BaseStream);
        }

        /// <summary>
        /// Read from input Stream then decompress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Decompress(this ICompressor compressor, Stream inputStream, StreamWriter outputWriter)
        {
            compressor.Decompress(inputStream, outputWriter.BaseStream);
        }

        /// <summary>
        /// Read from input Stream then compress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task CompressAsync(this ICompressor compressor, Stream inputStream, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.CompressAsync(inputStream, outputWriter.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Read from input Stream then decompress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputStream">inputStream</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task DecompressAsync(this ICompressor compressor, Stream inputStream, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.DecompressAsync(inputStream, outputWriter.BaseStream, cancellationToken);
        }

        #endregion

        #region StreamReader to byte[]/Stream/StreamWriter

        /// <summary>
        /// Read from input StreamReader then compress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <returns>Task</returns>
        public static byte[] Compress(this ICompressor compressor, StreamReader inputReader)
        {
            return compressor.Compress(inputReader.BaseStream);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <returns>Task</returns>
        public static byte[] Decompress(this ICompressor compressor, StreamReader inputReader)
        {
            return compressor.Decompress(inputReader.BaseStream);
        }

        /// <summary>
        /// Read from input StreamReader then compress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task<byte[]> CompressAsync(this ICompressor compressor, StreamReader inputReader, CancellationToken cancellationToken = default)
        {
            return compressor.CompressAsync(inputReader.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and return byte[]
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task<byte[]> DecompressAsync(this ICompressor compressor, StreamReader inputReader, CancellationToken cancellationToken = default)
        {
            return compressor.DecompressAsync(inputReader.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Read from input StreamReader then compress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Compress(this ICompressor compressor, StreamReader inputReader, StreamWriter outputWriter)
        {
            compressor.Compress(inputReader.BaseStream, outputWriter.BaseStream);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputWriter">outputWriter</param>
        public static void Decompress(this ICompressor compressor, StreamReader inputReader, StreamWriter outputWriter)
        {
            compressor.Decompress(inputReader.BaseStream, outputWriter.BaseStream);
        }

        /// <summary>
        /// Read from input StreamReader then compress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task CompressAsync(this ICompressor compressor, StreamReader inputReader, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.CompressAsync(inputReader.BaseStream, outputWriter.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and write to output StreamWriter
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputWriter">outputWriter</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task DecompressAsync(this ICompressor compressor, StreamReader inputReader, StreamWriter outputWriter, CancellationToken cancellationToken = default)
        {
            return compressor.DecompressAsync(inputReader.BaseStream, outputWriter.BaseStream, cancellationToken);
        }

        /// <summary>
        /// Read from input StreamReader then compress it's content and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputStream">outputStream</param>
        public static void Compress(this ICompressor compressor, StreamReader inputReader, Stream outputStream)
        {
            compressor.Compress(inputReader.BaseStream, outputStream);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputStream">outputStream</param>
        public static void Decompress(this ICompressor compressor, StreamReader inputReader, Stream outputStream)
        {
            compressor.Decompress(inputReader.BaseStream, outputStream);
        }

        /// <summary>
        /// Read from input StreamReader then compress it's content and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputStream">outputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task CompressAsync(this ICompressor compressor, StreamReader inputReader, Stream outputStream, CancellationToken cancellationToken = default)
        {
            return compressor.CompressAsync(inputReader.BaseStream, outputStream, cancellationToken);
        }

        /// <summary>
        /// Read from input StreamReader then decompress it's content and write to output Stream
        /// </summary>
        /// <param name="compressor">compressor</param>
        /// <param name="inputReader">inputReader</param>
        /// <param name="outputStream">outputStream</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>Task</returns>
        public static Task DecompressAsync(this ICompressor compressor, StreamReader inputReader, Stream outputStream, CancellationToken cancellationToken = default)
        {
            return compressor.DecompressAsync(inputReader.BaseStream, outputStream, cancellationToken);
        }

        #endregion
    }
}
