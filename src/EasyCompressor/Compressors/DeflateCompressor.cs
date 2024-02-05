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
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static DeflateCompressor Shared { get; } = new(name: "shared");

    /// <summary>
    /// Compression level
    /// </summary>
    public CompressionLevel Level { get; set; }

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Deflate;

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DeflateCompressor"/> class.
    /// </summary>
    public DeflateCompressor()
        : this(name: null, level: CompressionLevel.Fastest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeflateCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public DeflateCompressor(string name)
        : this(name: name, level: CompressionLevel.Fastest)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeflateCompressor"/> class.
    /// </summary>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public DeflateCompressor(CompressionLevel level)
        : this(name: null, level: level)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeflateCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="level">Compression level (Defaults to <see cref="CompressionLevel.Fastest"/>)</param>
    public DeflateCompressor(string name, CompressionLevel level)
    {
        Name = name;
        Level = level;
    }
    #endregion

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var outputStream = new MemoryStream();
        using (var deflateStream = new DeflateStream(outputStream, Level, leaveOpen: true))
        {
            deflateStream.WriteAllBytes(bytes);

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
            inputStream.CopyTo(deflateStream); //Don't pass buffer size

            //deflateStream.Flush(); //It adds some extra bytes but it's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            deflateStream.CopyTo(outputStream); //Don't pass buffer size

            //deflateStream.Flush(); //Flush only works when compressing (not when decompressing)
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var deflateStream = new DeflateStream(outputStream, Level, leaveOpen: true))
        {
            await inputStream.CopyToAsync(deflateStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await deflateStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It adds some extra bytes but it's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            await deflateStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await deflateStream.FlushAsync(cancellationToken).ConfigureAwait(false); //Flush only works when compressing (not when decompressing)
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? $"{GetType().Name}(Level:{Level})";
    }
}