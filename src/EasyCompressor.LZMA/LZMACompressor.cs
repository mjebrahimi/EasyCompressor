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
        outputStream.WriteAllBytes(fileSize);

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var decoder = new Decoder();

        var properties = new byte[5];

        // Read the decoder properties
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        inputStream.Read((Span<byte>)properties);
#else
        inputStream.Read(properties, 0, 5);
#endif
        decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        Span<byte> fileLengthBytes = stackalloc byte[8];
        inputStream.Read(fileLengthBytes);
        var fileLength = BitConverter.ToInt64((ReadOnlySpan<byte>)fileLengthBytes);
#else
        var fileLengthBytes = new byte[8];
        inputStream.Read(fileLengthBytes, 0, 8);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
#endif

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
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
        await outputStream.WriteAllBytesAsync(fileSize, cancellationToken).ConfigureAwait(false);

        // Encode
        encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var decoder = new Decoder();

        var properties = new byte[5];

        // Read the decoder properties
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        await inputStream.ReadAsync((Memory<byte>)properties, cancellationToken).ConfigureAwait(false);
#else
        await inputStream.ReadAsync(properties, 0, 5, cancellationToken).ConfigureAwait(false);
#endif

        decoder.SetDecoderProperties(properties);

        // Read in the decompress file size.
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        Memory<byte> fileLengthBytes = new byte[8];
        await inputStream.ReadAsync(fileLengthBytes, cancellationToken).ConfigureAwait(false);
        var fileLength = BitConverter.ToInt64(fileLengthBytes.Span);
#else
        var fileLengthBytes = new byte[8];
        await inputStream.ReadAsync(fileLengthBytes, 0, 8, cancellationToken).ConfigureAwait(false);
        var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
#endif

        // Decode
        decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}