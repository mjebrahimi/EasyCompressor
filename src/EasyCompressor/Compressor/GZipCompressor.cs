using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor
{
    /*
    TODO
    
    Flush or Close/Dispose?
    -------------------
    Use Dispose() (or in using) instead of Close()
    Dispose() => Close() => Dispose(true)
    
    CopyTo/WriteTo or Read/Write
    -------------------
    inputStream.WriteTo(gZipStream); //MemoryStream for Stream
    Writes the entire contents of this memory stream to another stream.
    Resetting the read position to zero before copying the data
    
    inputStream.CopyTo(gZipStream); //Global for Stream
    Reads the bytes from the current memory stream and writes them to another stream.
    Copy whatever data remains after the current position in the stream,
    That means if you did not reset the position yourself, no data will be read at all.
    
    gZipStream.Write(bytes, 0, bytes.Length); //Global for bytes
    
    Flush or Not
    -------------------
    Flush is useful for non-memory stream like FileStream
    Flush after Write add Extera bytes (6)
    
    StreamReader/Writer vs StringReader/Writer
    -------------------
    StreamWriter:TextWriter (most used) : write string to another stream (in a particular Encoding) like writing to FileStream
    StreamReader:TextReader (most used) : read string to another stream  (in a particular Encoding) like reading from FileStream
    StringWriter:TextWriter (less used) : write data to string (using underlying StringBuilder)
    StringReader:TextReader (less used) : read from string
    */

    /// <summary>
    /// GZip compressor
    /// </summary>
    public class GZipCompressor : BaseCompressor
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
        public GZipCompressor(string name = null, CompressionLevel level = CompressionLevel.Optimal)
        {
            Name = name;
            Level = level;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            using var inputStream = new MemoryStream(bytes);
            using var outputStream = new MemoryStream();
            using (var gZipStream = new GZipStream(outputStream, Level))
            {
                inputStream.CopyTo(gZipStream, bytes.Length);
                //inputStream.WriteTo(gZipStream);
                //gZipStream.Write(bytes, 0, bytes.Length);

                inputStream.Flush();
                gZipStream.Flush();
            }
            return outputStream.ToArray();
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            using var inputStream = new MemoryStream(compressedBytes);
            using var outputStream = new MemoryStream();
            using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            {
                gZipStream.CopyTo(outputStream, compressedBytes.Length);

                outputStream.Flush();
                gZipStream.Flush();
            }
            return outputStream.ToArray();
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using var gZipStream = new GZipStream(outputStream, Level, true);
            inputStream.CopyTo(gZipStream);

            inputStream.Flush();
            gZipStream.Flush();
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress, true);
            gZipStream.CopyTo(outputStream);

            outputStream.Flush();
            gZipStream.Flush();
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using var gZipStream = new GZipStream(outputStream, Level, true);
            await inputStream.CopyToAsync(gZipStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

            await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress, true);
            await gZipStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

            await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
