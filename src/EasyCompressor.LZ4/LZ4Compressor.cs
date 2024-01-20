using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// LZ4 compressor
/// </summary>
public class LZ4Compressor : BaseCompressor
{
    /// <summary>
    /// LZ4Level
    /// </summary>
    protected readonly LZ4Level Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.LZ4;

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
        var source = bytes.AsSpan();
        var target = new byte[LZ4Codec.MaximumOutputSize(source.Length) + 4].AsSpan();
        var size = BitConverter.GetBytes(source.Length).AsSpan();
        size.CopyTo(target);
        int compressedBytesSize = LZ4Codec.Encode(source, target[4..], Level);
        return target[..(compressedBytesSize + 4)].ToArray();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        var source = compressedBytes.AsSpan();
        var size = source[..4].ToArray();
        var length = BitConverter.ToInt32(size, 0);
        var target = new byte[length].AsSpan();
        int decoded = LZ4Codec.Decode(source[4..], target);
        return target[..decoded].ToArray();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using var lz4Stream = LZ4Stream.Encode(outputStream, Level, leaveOpen: true);
        inputStream.CopyTo(lz4Stream);

        inputStream.Flush();
        lz4Stream.Flush();
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using var lz4Stream = LZ4Stream.Decode(inputStream, leaveOpen: true);
        lz4Stream.CopyTo(outputStream);

        inputStream.Flush();
        lz4Stream.Flush();
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        using var lz4Stream = LZ4Stream.Encode(outputStream, Level, leaveOpen: true);
        await inputStream.CopyToAsync(lz4Stream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

        await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
        await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        using var lz4Stream = LZ4Stream.Decode(inputStream, leaveOpen: true);
        await lz4Stream.CopyToAsync(outputStream, DefaultBufferSize, cancellationToken).ConfigureAwait(false);

        await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
        await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }
}
