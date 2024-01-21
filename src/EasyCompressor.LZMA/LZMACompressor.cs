using SevenZip.Compression.LZMA;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// LZMA compressor
/// https://gist.github.com/ststeiger/cb9750664952f775a341
/// </summary>
public class LZMACompressor : BaseCompressor
{
    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.LZMA;

    /// <summary>
    /// Gets the options.
    /// </summary>
    /// <value>
    /// The options.
    /// </value>
    public LZMACompressionOptions Options { get; }

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="options">Options</param>
    public LZMACompressor(string name = null, LZMACompressionOptions options = null)
    {
        Name = name;
        Options = options;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        using var inputStream = new MemoryStream(bytes);
        using var outputStream = new MemoryStream();

        BaseCompress(inputStream, outputStream);

        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        using var inputStream = new MemoryStream(compressedBytes);
        using var outputStream = new MemoryStream();

        BaseDecompress(inputStream, outputStream);

        return outputStream.GetTrimmedBuffer();
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        var encoder = new Encoder();

        if (Options is not null)
            encoder.SetCoderProperties(LZMACompressionOptions.PropIDs, Options.GetProperties());

        // Write the encoder properties
        encoder.WriteCoderProperties(outputStream);

        var fileSize = BitConverter.GetBytes(inputStream.Length);
        // Write the decompressed file size.
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        outputStream.Write((ReadOnlySpan<byte>)fileSize);
#else
        outputStream.Write(fileSize, 0, 8);
#endif

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var decoder = new Decoder();

        var properties = new byte[5];

        // Read the decoder properties
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        inputStream.Read(properties.AsSpan());
#else
        inputStream.Read(properties, 0, 5);
#endif
        decoder.SetDecoderProperties(properties);

        var fileLengthBytes = new byte[8];

        // Read in the decompress file size.
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        inputStream.Read(fileLengthBytes.AsSpan());
        var fileLength = BitConverter.ToInt64((ReadOnlySpan<byte>)fileLengthBytes);
#else
        inputStream.Read(fileLengthBytes, 0, 8);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
#endif

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var encoder = new Encoder();

        if (Options is not null)
            encoder.SetCoderProperties(LZMACompressionOptions.PropIDs, Options.GetProperties());

        // Write the encoder properties
        encoder.WriteCoderProperties(outputStream);

        var fileSize = BitConverter.GetBytes(inputStream.Length);
        // Write the decompressed file size.
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await outputStream.WriteAsync((ReadOnlyMemory<byte>)fileSize, cancellationToken).ConfigureAwait(false);
#else
        await outputStream.WriteAsync(fileSize, 0, 8, cancellationToken).ConfigureAwait(false);
#endif

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var decoder = new Decoder();

        var properties = new byte[5];

        // Read the decoder properties
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await inputStream.ReadAsync(properties.AsMemory(), cancellationToken).ConfigureAwait(false);
#else
        await inputStream.ReadAsync(properties, 0, 5, cancellationToken).ConfigureAwait(false);
#endif

        decoder.SetDecoderProperties(properties);

        var fileLengthBytes = new byte[8];

        // Read in the decompress file size.
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        await inputStream.ReadAsync(fileLengthBytes.AsMemory(), cancellationToken).ConfigureAwait(false);
        var fileLength = BitConverter.ToInt64((ReadOnlySpan<byte>)fileLengthBytes);
#else
        await inputStream.ReadAsync(fileLengthBytes, 0, 8, cancellationToken).ConfigureAwait(false);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
#endif

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }
}