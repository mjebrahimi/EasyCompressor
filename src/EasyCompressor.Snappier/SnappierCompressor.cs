using Snappier;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together")]

namespace EasyCompressor;

/// <summary>
/// Snappier compressor
/// </summary>
public class SnappierCompressor : BaseCompressor
{
    /// <summary>
    /// Provides a default shared (thread-safe) instance.
    /// </summary>
    public static SnappierCompressor Shared { get; } = new(name: "shared");

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Snappy;

    /// <summary>
    /// Initializes a new instance of the <see cref="SnappierCompressor"/> class.
    /// </summary>
    public SnappierCompressor()
        : this(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnappierCompressor"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public SnappierCompressor(string name)
    {
        Name = name;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        return Snappy.CompressToArray((ReadOnlySpan<byte>)bytes);

        //var length = Snappy.GetMaxCompressedLength(bytes.Length);
        //#if NET5_0_OR_GREATER
        //var compressed = GC.AllocateUninitializedArray<byte>(length);
        //#else
        //var compressed = new byte[length];
        //#endif
        //var compressedLength = Snappy.Compress((ReadOnlySpan<byte>)bytes, (Span<byte>)compressed);
        //Array.Resize(ref compressed, compressedLength);
        //return compressed;
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        return Snappy.DecompressToArray((ReadOnlySpan<byte>)compressedBytes);

        //const int MaxByteArrayLength = 2147483591;
        //var length = Snappy.GetUncompressedLength((ReadOnlySpan<byte>)compressedBytes);
        //#pragma warning disable S112 // General or reserved exceptions should never be thrown
        //if (length > MaxByteArrayLength)
        //    throw new OutOfMemoryException($"Decompressed content size {length} is greater than max possible byte array size {MaxByteArrayLength}");
        //#pragma warning restore S112 // General or reserved exceptions should never be thrown
        //#if NET5_0_OR_GREATER
        //var decompressed = GC.AllocateUninitializedArray<byte>((int)length);
        //#else
        //var decompressed = new byte[length];
        //#endif
        //int decompressedLength = Snappy.Decompress((ReadOnlySpan<byte>)compressedBytes, (Span<byte>)decompressed);
        //if (decompressedLength != decompressed.Length)
        //    Array.Resize(ref decompressed, decompressedLength);
        //return decompressed;
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var snappyStream = new SnappyStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            inputStream.CopyTo(snappyStream);

            // Disposing the compressor also flushes the buffers to the inner stream
            // We pass true to the constructor above so that it doesn't close/dispose the inner stream
            // Alternatively, we could call snappyStream.Flush() //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var snappyStream = new SnappyStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            snappyStream.CopyTo(outputStream);

            //snappyStream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var snappyStream = new SnappyStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            await inputStream.CopyToAsync(snappyStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await snappyStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var snappyStream = new SnappyStream(inputStream, CompressionMode.Decompress, leaveOpen: true))
        {
            await snappyStream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await snappyStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}