// Ignore Spelling: Brotli

using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

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
    /// Quality
    /// </summary>
    protected readonly uint Quality;

    /// <summary>
    /// Window
    /// </summary>
    protected readonly uint Window;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Brotli;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="quality">Quality (Defaults to <c>5</c>)</param>
    /// <param name="window">Window (Defaults to <c>22</c>)</param>
    public BrotliNETCompressor(string name = null, uint quality = 5, uint window = 22)
    {
        Name = name;
        Quality = quality;
        Window = window;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var outputStream = new MemoryStream();
        using (var brotliStream = new Brotli.BrotliStream(outputStream, CompressionMode.Compress, leaveOpen: true))
        {
            brotliStream.SetQuality(Quality);
            brotliStream.SetWindow(Window);
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
            brotliStream.SetQuality(Quality);
            brotliStream.SetWindow(Window);
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
            brotliStream.SetQuality(Quality);
            brotliStream.SetWindow(Window);
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
}
