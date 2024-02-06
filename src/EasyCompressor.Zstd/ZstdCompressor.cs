// Ignore Spelling: Zstd

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZstdNet;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together")]

namespace EasyCompressor;

/// <summary>
/// Zstd compressor
/// </summary>
#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Instead, use ZstdSharpCompressor in the EasyCompressor.ZstdSharp package.")]
#pragma warning restore S1133 // Deprecated code should be removed
public class ZstdCompressor : BaseCompressor
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static ZstdCompressor Shared { get; } = new(name: "shared");

    /// <summary>
    /// Compression level
    /// </summary>
    public int Level { get; set; }

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Zstd;

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    public ZstdCompressor()
        : this(null, ZstdCompressionLevel.Fast)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    public ZstdCompressor(ZstdCompressionLevel compressionLevel)
        : this((int)compressionLevel)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    /// <param name="level">Compression level. (Defaults to <see cref="ZstdUtils.Level_Default"/> <c>-1</c>)</param>
    public ZstdCompressor(int level)
        : this(null, level)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public ZstdCompressor(string name)
        : this(name, ZstdCompressionLevel.Fast)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="ZstdCompressionLevel.Fast"/>)</param>
    public ZstdCompressor(string name, ZstdCompressionLevel compressionLevel)
        : this(name, (int)compressionLevel)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZstdCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level. (Defaults to <see cref="ZstdUtils.Level_Default"/> <c>-1</c>)</param>
    public ZstdCompressor(string name, int level)
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
        using var options = new CompressionOptions(Level);
        using var compressor = new Compressor(options);
        return compressor.Wrap((ReadOnlySpan<byte>)bytes);
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var decompressor = new Decompressor();
        return decompressor.Unwrap((ReadOnlySpan<byte>)compressedBytes);
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

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? $"{GetType().Name}(Level:{Level})";
    }
}
