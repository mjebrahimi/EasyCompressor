using Snappy;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// Snappy compressor
/// </summary>
#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Instead, use SnappierCompressor in the EasyCompressor.Snappier package.")]
#pragma warning restore S1133 // Deprecated code should be removed
public class SnappyCompressor : BaseCompressor
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static SnappyCompressor Shared { get; } = new(name: "shared");

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Snappy;

    /// <summary>
    /// Initializes a new instance of the <see cref="SnappyCompressor"/> class.
    /// </summary>
    public SnappyCompressor()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnappyCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public SnappyCompressor(string name)
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

        outputStream.WriteAllBytes(compressedBytes);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var compressedBytes = inputStream.ReadAllBytes();

        var bytes = BaseDecompress(compressedBytes);

        outputStream.WriteAllBytes(bytes);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var bytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);

        var compressedBytes = BaseCompress(bytes);

        await outputStream.WriteAllBytesAsync(compressedBytes, cancellationToken).ConfigureAwait(false);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);

        var bytes = BaseDecompress(compressedBytes);

        await outputStream.WriteAllBytesAsync(bytes, cancellationToken).ConfigureAwait(false);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}
