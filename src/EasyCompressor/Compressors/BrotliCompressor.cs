#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
// Ignore Spelling: Brotli

using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// Brotli compressor
/// </summary>
public class BrotliCompressor : BaseCompressor
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static BrotliCompressor Shared { get; } = new(name: "shared");

    /// <summary>
    /// Compression level
    /// </summary>
    public CompressionLevel Level { get; set; }

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Brotli;

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor"/> class.
    /// </summary>
    public BrotliCompressor()
        : this(name: null, level: CompressionLevel.Fastest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public BrotliCompressor(string name)
        : this(name: name, level: CompressionLevel.Fastest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor"/> class.
    /// </summary>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public BrotliCompressor(CompressionLevel level)
        : this(name: null, level: level)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BrotliCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public BrotliCompressor(string name, CompressionLevel level)
    {
        Name = name;
        Level = level;
    }
    #endregion

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var outputStream = new MemoryStream();
        using (var brotliStream = new BrotliStream(outputStream, Level, leaveOpen: true))
        {
            brotliStream.WriteAllBytes(bytes);

            //Since we Dispose before returning and Dispose will Flush, we don't need to Flush anymore.
            //If we use using statement we have to Flush the brotliStream before returning.
            //brotliStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true);
        //brotliStream.Flush(); //Flush only works when compressing (not when decompressing)
        return brotliStream.ReadAllBytes();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var brotliStream = new BrotliStream(outputStream, Level, leaveOpen: true))
        {
            inputStream.CopyTo(brotliStream); //Don't pass buffer size

            //brotliStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            brotliStream.CopyTo(outputStream); //Don't pass buffer size

            //brotliStream.Flush(); //Flush only works when compressing (not when decompressing)
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        await using (var brotliStream = new BrotliStream(outputStream, Level, leaveOpen: true))
        {
            await inputStream.CopyToAsync(brotliStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It adds some extra bytes but it's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        await using (var brotliStream = new BrotliStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            await brotliStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await brotliStream.FlushAsync(cancellationToken).ConfigureAwait(false); //Flush only works when compressing (not when decompressing)
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? $"{GetType().Name}(Level:{Level})";
    }
}
#endif