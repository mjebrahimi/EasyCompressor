// Ignore Spelling: Zstd

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZstdSharp;

namespace EasyCompressor;

/// <summary>
/// Snappier compressor
/// </summary>
public class ZstdSharpCompressor : BaseCompressor
{
    /// <summary>
    /// Compression level
    /// </summary>
    protected readonly int Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Zstd;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
    public ZstdSharpCompressor(string name = null, int level = 3)
    {
        Name = name;
        Level = level;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        var length = Compressor.GetCompressBound(bytes.Length);
#if NET5_0_OR_GREATER
        var compressed = GC.AllocateUninitializedArray<byte>(length);
#else
        var compressed = new byte[length];
#endif

        using var compressor = new Compressor(Level);
        var compressedLength = compressor.Wrap((ReadOnlySpan<byte>)bytes, (Span<byte>)compressed);
        Array.Resize(ref compressed, compressedLength);
        return compressed;
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        const ulong MaxByteArrayLength = 2147483591uL;
        var length = Decompressor.GetDecompressedSize((ReadOnlySpan<byte>)compressedBytes);

#pragma warning disable S112 // General or reserved exceptions should never be thrown
        if (length > MaxByteArrayLength)
            throw new OutOfMemoryException($"Decompressed content size {length} is greater than max possible byte array size {MaxByteArrayLength}");
#pragma warning restore S112 // General or reserved exceptions should never be thrown

#if NET5_0_OR_GREATER
        var decompressed = GC.AllocateUninitializedArray<byte>((int)length);
#else
        var decompressed = new byte[length];
#endif
        using var decompressor = new Decompressor();
        var decompressedLength = decompressor.Unwrap((ReadOnlySpan<byte>)compressedBytes, (Span<byte>)decompressed);
        if (decompressedLength != decompressed.Length)
            Array.Resize(ref decompressed, decompressedLength);
        return decompressed;
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var compressionStream = new CompressionStream(outputStream, Level, leaveOpen: true))
        {
            inputStream.CopyTo(compressionStream); //Don't pass buffer size

            //compressionStream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var decompressionStream = new DecompressionStream(inputStream, leaveOpen: true))
        {
            decompressionStream.CopyTo(outputStream); //Don't pass buffer size

            //decompressionStream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        await using (var compressionStream = new CompressionStream(outputStream, Level, leaveOpen: true))
        {
            await inputStream.CopyToAsync(compressionStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await compressionStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        await using (var decompressionStream = new DecompressionStream(inputStream, leaveOpen: true))
        {
            await decompressionStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await decompressionStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}
