// Ignore Spelling: Brotli

using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together")]

namespace EasyCompressor;

/// <summary>
/// BrotliNET compressor
/// </summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Instead, use the built-in BrotliCompressor class in the EasyCompressor package. (for projects with target-framework NETStandard2.1 or NETCore2.1 or above)")]
#pragma warning restore S1133 // Deprecated code should be removed
#endif
#pragma warning disable S101 // Types should be named in PascalCase
public class BrotliNETCompressor : BaseCompressor
#pragma warning restore S101 // Types should be named in PascalCase
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static BrotliNETCompressor Shared { get; } = new(name: "shared");

    /// <summary>
    /// Quality
    /// </summary>
    public int Quality { get; set; }

    /// <summary>
    /// Window
    /// </summary>
    public int Window { get; set; }

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Brotli;

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    public BrotliNETCompressor()
        : this(name: null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public BrotliNETCompressor(CompressionLevel compressionLevel)
        : this(name: null, compressionLevel: compressionLevel)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    public BrotliNETCompressor(int quality)
        : this(name: null, quality: quality)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    public BrotliNETCompressor(CompressionLevel compressionLevel, int window)
        : this(name: null, compressionLevel: compressionLevel, window: window)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    public BrotliNETCompressor(int quality, int window)
        : this(name: null, quality: quality, window: window)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public BrotliNETCompressor(string name)
        : this(name: name, compressionLevel: CompressionLevel.Fastest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public BrotliNETCompressor(string name, CompressionLevel compressionLevel)
        : this(name: name, compressionLevel: compressionLevel, window: BrotliUtils.WindowBits_Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    public BrotliNETCompressor(string name, int quality)
        : this(name: name, quality: quality, window: BrotliUtils.WindowBits_Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="compressionLevel">The compression level. (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    public BrotliNETCompressor(string name, CompressionLevel compressionLevel, int window)
        : this(name: name, quality: BrotliUtils.GetQualityFromCompressionLevel(compressionLevel), window: window)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliNETCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="quality">Quality between 0 and 11 (Default: to <c>4</c>, The minimum value is 0 (no compression), and the maximum value is 11.)</param>
    /// <param name="window">Window between 10 and 24 (Defaults to <c>22</c>, The minimum value is 10, and the maximum value is 24.)</param>
    public BrotliNETCompressor(string name, int quality, int window)
    {
#pragma warning disable S3236 // Caller information arguments should not be provided explicitly
        BrotliUtils.ThrowIfQualityIsNotValid(quality, nameof(quality));
        BrotliUtils.ThrowIfWindowIsNotValid(window, nameof(window));
#pragma warning restore S3236 // Caller information arguments should not be provided explicitly

        Name = name;
        Quality = quality;
        Window = window;
    }
    #endregion

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var outputStream = new MemoryStream();
        using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            brotliStream.SetQuality((uint)Quality);
            brotliStream.SetWindow((uint)Window);
            brotliStream.WriteAllBytes(bytes);

            // Disposing the compressor also flushes the buffers to the inner stream
            // We pass true to the constructor above so that it doesn't close/dispose the inner stream
            // Alternatively, we could call brotliStream.Flush() //It's not necessary based on my experiments
        }
        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true);
        //brotliStream.Flush(); //It's not necessary based on my experiments
        return brotliStream.ReadAllBytes();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            brotliStream.SetQuality((uint)Quality);
            brotliStream.SetWindow((uint)Window);
            inputStream.CopyTo(brotliStream); //Don't pass buffer size

            //brotliStream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            brotliStream.CopyTo(outputStream); //Don't pass buffer size

            //brotliStream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            brotliStream.SetQuality((uint)Quality);
            brotliStream.SetWindow((uint)Window);
            await inputStream.CopyToAsync(brotliStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It adds some extra bytes but it's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var brotliStream = new Brotli.BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            await brotliStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false); //Flush only works when compressing (not when decompressing)
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? $"{GetType().Name}(Quality:{Quality}, Window:{Window})";
    }
}
