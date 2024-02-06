// Ignore Spelling: Zstd

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZstdSharp;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together")]

namespace EasyCompressor;

/// <summary>
/// Snappier compressor
/// </summary>
public class ZstdSharpCompressor : BaseCompressor
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static ZstdSharpCompressor Shared { get; } = new(name: "shared");

    /// <summary>
    /// Compression level
    /// </summary>
    public int Level { get; set; }

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Zstd;

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    public ZstdSharpCompressor()
        : this(null, ZstdCompressionLevel.Fast)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    public ZstdSharpCompressor(ZstdCompressionLevel compressionLevel)
        : this((int)compressionLevel)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    public ZstdSharpCompressor(int level)
        : this(null, level)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public ZstdSharpCompressor(string name)
        : this(name, ZstdCompressionLevel.Fast)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    public ZstdSharpCompressor(string name, ZstdCompressionLevel compressionLevel)
        : this(name, (int)compressionLevel)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdSharpCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level. (Defaults to <c>-1</c> - <see cref="ZstdUtils.Level_Default"/>)</param>
    public ZstdSharpCompressor(string name, int level)
    {
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
        ZstdUtils.ThrowIfLevelIsNotValid(level, nameof(level));
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly

        Name = name;
        Level = level;
    }
    #endregion

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

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? $"{GetType().Name}(Level:{Level})";
    }
}
