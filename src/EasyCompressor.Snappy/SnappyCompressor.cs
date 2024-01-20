using Snappy;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// Snappy compressor
/// </summary>
public class SnappyCompressor : BaseCompressor
{

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Snappy;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    public SnappyCompressor(string name = null)
    {
        Name = name;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        return SnappyCodec.Compress(bytes);
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        return SnappyCodec.Uncompress(compressedBytes);
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        var bytes = inputStream.ReadAllBytes();
        var compressedBytes = BaseCompress(bytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        outputStream.WriteAllBytes((ReadOnlySpan<byte>)compressedBytes);
#else
        outputStream.WriteAllBytes(compressedBytes);
#endif
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var compressedBytes = inputStream.ReadAllBytes();
        var bytes = BaseDecompress(compressedBytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        outputStream.WriteAllBytes((ReadOnlySpan<byte>)bytes);
#else
        outputStream.WriteAllBytes(bytes);
#endif
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var bytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var compressedBytes = BaseCompress(bytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        await outputStream.WriteAllBytesAsync((ReadOnlyMemory<byte>)compressedBytes, cancellationToken).ConfigureAwait(false);
#else
        await outputStream.WriteAllBytesAsync(compressedBytes, cancellationToken).ConfigureAwait(false);
#endif
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var bytes = BaseDecompress(compressedBytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        await outputStream.WriteAllBytesAsync((ReadOnlyMemory<byte>)bytes, cancellationToken).ConfigureAwait(false);
#else
        await outputStream.WriteAllBytesAsync(bytes, cancellationToken).ConfigureAwait(false);
#endif
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }
}
