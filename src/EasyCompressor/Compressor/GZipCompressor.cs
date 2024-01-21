using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/*
NOTE:
Gzip vs Deflate
----------------------------------------------------------------
//https://stackoverflow.com/questions/7243705/what-is-the-advantage-of-gzip-vs-deflate-compression
//https://dev.to/biellls/compression-clearing-the-confusion-on-zip-gzip-zlib-and-deflate-15g1


CopyTo vs WriteTo
----------------------------------------------------------------
====== MemoryStream.WriteTo ======
inputStream.WriteTo(gZipStream);
Writes the entire contents of this memory stream to another stream.
Resetting the read position to zero before copying the data

====== Stream.CopyTo ======
inputStream.CopyTo(gZipStream);
Reads the bytes from the current memory stream and writes them to another stream.
Copy whatever data remains after the current position in the stream,
That means if you did not reset the position yourself, no data will be read at all.



Flush or Close/Dispose?
----------------------------------------------------------------
Use Dispose() (or in using) instead of Close()
Dispose() => Close() => Dispose(true)



Flush or Not
----------------------------------------------------------------
Flush is useful for non-memory stream like FileStream
Flush after Write add Extra bytes (6)



StreamReader/Writer vs StringReader/Writer
----------------------------------------------------------------
StreamWriter (TextWriter): write string to another stream (in a particular Encoding) like writing to FileStream
StreamReader (TextReader): read string to another stream  (in a particular Encoding) like reading from FileStream
StringWriter (TextWriter): write data to string (using underlying StringBuilder)
StringReader (TextReader): read from string
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

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.GZip;

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
        using var outputStream = new MemoryStream();
        using (var gZipStream = new GZipStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            gZipStream.WriteAllBytes((ReadOnlySpan<byte>)bytes);
#else
            gZipStream.WriteAllBytes(bytes);
#endif
            //Since we Dispose before returning and Dispose will Flush, we don't need to Flush anymore.
            //If we use using statement we have to Flush the gZipStream before returning.
            //gZipStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress, leaveOpen: true);
        //gZipStream.Flush(); //Flush only works when compressing (not when decompressing)
        return gZipStream.ReadAllBytes();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var gZipStream = new GZipStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            inputStream.CopyTo(gZipStream); //Don't pass buffer size
#else
            inputStream.CopyTo(gZipStream, DefaultBufferSize);
#endif
            //gZipStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            gZipStream.CopyTo(outputStream); //Don't pass buffer size
#else
            gZipStream.CopyTo(outputStream, DefaultBufferSize);
#endif
            //gZipStream.Flush(); //Flush only works when compressing (not when decompressing)
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await
#endif
        using (var gZipStream = new GZipStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            await inputStream.CopyToAsync(gZipStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size
#else
            await inputStream.CopyToAsync(gZipStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
#endif
            //await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It adds some extra bytes but it's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await
#endif
        using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            await gZipStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size
#else
            await gZipStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
#endif
            //await gZipStream.FlushAsync(cancellationToken).ConfigureAwait(false); //Flush only works when compressing (not when decompressing)
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}