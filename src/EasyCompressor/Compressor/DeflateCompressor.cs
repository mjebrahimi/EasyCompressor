using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// Deflate compressor
/// </summary>
public class DeflateCompressor : BaseCompressor
{
    /// <summary>
    /// Compression level
    /// </summary>
    protected readonly CompressionLevel Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Deflate;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level</param>
    public DeflateCompressor(string name = null, CompressionLevel level = CompressionLevel.Optimal)
    {
        Name = name;
        Level = level;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var outputStream = new MemoryStream();
        using (var deflateStream = new DeflateStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            deflateStream.WriteAllBytes((ReadOnlySpan<byte>)bytes);
#else
            deflateStream.WriteAllBytes(bytes);
#endif
            //Since we Dispose before returning and Dispose will Flush, we don't need to Flush anymore.
            //If we use using statement we have to Flush the deflateStream before returning.
            //deflateStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true);
        //deflateStream.Flush(); //Flush only works when compressing (not when decompressing)
        return deflateStream.ReadAllBytes();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var deflateStream = new DeflateStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            inputStream.CopyTo(deflateStream); //Don't pass buffer size
#else
            inputStream.CopyTo(deflateStream, DefaultBufferSize);
#endif
            //deflateStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            deflateStream.CopyTo(outputStream); //Don't pass buffer size
#else
            deflateStream.CopyTo(outputStream, DefaultBufferSize);
#endif
            //deflateStream.Flush(); //Flush only works when compressing (not when decompressing)
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await
#endif
        using (var deflateStream = new DeflateStream(outputStream, Level, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            await inputStream.CopyToAsync(deflateStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size
#else
            await inputStream.CopyToAsync(deflateStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
#endif
            //await deflateStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It adds some extra bytes but it's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await
#endif
        using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
            await deflateStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size
#else
            await deflateStream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
#endif
            //await deflateStream.FlushAsync(cancellationToken).ConfigureAwait(false); //Flush only works when compressing (not when decompressing)
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}