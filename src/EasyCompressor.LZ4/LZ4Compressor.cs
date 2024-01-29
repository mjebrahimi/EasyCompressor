// Ignore Spelling: LZ

using K4os.Compression.LZ4;
using K4os.Compression.LZ4.Streams;
using System;
using System.Buffers;
using System.ComponentModel;
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
    /// Gets or sets the binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.StreamCompatible"/>)
    /// </summary>
    /// <value>
    /// The binary compression mode.
    /// </value>
    public LZ4BinaryCompressionMode BinaryCompressionMode { get; set; }

    /// <summary>
    /// LZ4Level
    /// </summary>
    protected readonly LZ4Level Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.LZ4;

    /// <summary>
    /// Initializes a new instance of the <see cref="LZ4Compressor"/> class.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="level">The level.</param>
    /// <param name="binaryCompressionMode">The binary compression mode. (Defaults to <see cref="LZ4BinaryCompressionMode.StreamCompatible"/>)</param>
    public LZ4Compressor(string name = null, LZ4Level level = LZ4Level.L00_FAST, LZ4BinaryCompressionMode binaryCompressionMode = LZ4BinaryCompressionMode.StreamCompatible)
    {
        Name = name;
        Level = level;
        BinaryCompressionMode = binaryCompressionMode;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        switch (BinaryCompressionMode)
        {
            case LZ4BinaryCompressionMode.LegacyCompatible:
                {
                    var length = bytes.Length;
                    ReadOnlySpan<byte> source = bytes;
                    var maxLength = LZ4Codec.MaximumOutputSize(length) + 4; // +4 bytes for specifying uncompressed length
#if NET5_0_OR_GREATER
                    Span<byte> target = GC.AllocateUninitializedArray<byte>(maxLength);
#else
                    Span<byte> target = new byte[maxLength];
#endif
                    Span<byte> size = BitConverter.GetBytes(length);
                    size.CopyTo(target);
#pragma warning disable IDE0057 // Use range operator (net462 and nestandard2.0 don't support System.Range)
                    var compressedLength = LZ4Codec.Encode(source, target.Slice(4), Level);
                    return target.Slice(0, compressedLength + 4).ToArray();
#pragma warning restore IDE0057 // Use range operator (net462 and nestandard2.0 don't support System.Range)
                }
            case LZ4BinaryCompressionMode.StreamCompatible:
                //https://github.com/MiloszKrajewski/K4os.Compression.LZ4#other-stream-like-data-structures
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
                var arrayBufferWriter = LZ4Frame.Encode(new Span<byte>(bytes), new ArrayBufferWriter<byte>(), Level);
                return arrayBufferWriter.WrittenSpan.ToArray();
#else
                using (var outputStream = new MemoryStream())
                {
                    using (var arrayBufferWriter = LZ4Frame.Encode(outputStream, Level, leaveOpen: true))
                        arrayBufferWriter.WriteManyBytes(bytes);
                    return outputStream.GetTrimmedBuffer();
                }
#endif
            case LZ4BinaryCompressionMode.Optimized:
                //https://github.com/MiloszKrajewski/K4os.Compression.LZ4#pickler
                return LZ4Pickler.Pickle((ReadOnlySpan<byte>)bytes, Level);
            default:
                throw new InvalidEnumArgumentException(nameof(BinaryCompressionMode), Convert.ToInt32(BinaryCompressionMode), typeof(LZ4BinaryCompressionMode));
        }
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        switch (BinaryCompressionMode)
        {
            case LZ4BinaryCompressionMode.LegacyCompatible:
                ReadOnlySpan<byte> source = compressedBytes;
#pragma warning disable IDE0057 // Use range operator (net462 and nestandard2.0 don't support System.Range)
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
                var length = BitConverter.ToInt32(source.Slice(0, 4));
#else
                var length = BitConverter.ToInt32(source.Slice(0, 4).ToArray(), 0);
#endif
#if NET5_0_OR_GREATER
                Span<byte> target = GC.AllocateUninitializedArray<byte>(length);
#else
                Span<byte> target = new byte[length];
#endif
                var decoded = LZ4Codec.Decode(source.Slice(4), target);
                return target.Slice(0, decoded).ToArray();
#pragma warning restore IDE0057 // Use range operator (net462 and nestandard2.0 don't support System.Range)
            case LZ4BinaryCompressionMode.StreamCompatible:
                //https://github.com/MiloszKrajewski/K4os.Compression.LZ4#other-stream-like-data-structures
                using (var reader = LZ4Frame.Decode((ReadOnlyMemory<byte>)compressedBytes)) //new ReadOnlySequence<byte>(compressedBytes)
                    return reader.AsStream().ReadAllBytes();
            case LZ4BinaryCompressionMode.Optimized:
                //https://github.com/MiloszKrajewski/K4os.Compression.LZ4#pickler
                return LZ4Pickler.Unpickle((ReadOnlySpan<byte>)compressedBytes);
            default:
                throw new InvalidEnumArgumentException(nameof(BinaryCompressionMode), Convert.ToInt32(BinaryCompressionMode), typeof(LZ4BinaryCompressionMode));
        }
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        using (var lz4Stream = LZ4Stream.Encode(outputStream, Level, leaveOpen: true))
        {
            inputStream.CopyTo(lz4Stream); //Don't pass buffer size

            //lz4Stream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        using (var lz4Stream = LZ4Stream.Decode(inputStream, leaveOpen: true))
        {
            lz4Stream.CopyTo(outputStream); //Don't pass buffer size

            //lz4Stream.Flush(); //It's not necessary based on my experiments
        }
        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var lz4Stream = LZ4Stream.Encode(outputStream, Level, leaveOpen: true))
        {
            await inputStream.CopyToAsync(lz4Stream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        await
#endif
        using (var lz4Stream = LZ4Stream.Decode(inputStream, leaveOpen: true))
        {
            await lz4Stream.CopyToAsync(outputStream, cancellationToken).ConfigureAwait(false); //Don't pass buffer size

            //await lz4Stream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's not necessary based on my experiments
        }
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var mode = (BinaryCompressionMode) switch
        {
            LZ4BinaryCompressionMode.LegacyCompatible => "LegacyCompatible",
            LZ4BinaryCompressionMode.StreamCompatible => "StreamCompatible",
            LZ4BinaryCompressionMode.Optimized => "Optimized",
            _ => throw new InvalidEnumArgumentException(nameof(BinaryCompressionMode), Convert.ToInt32(BinaryCompressionMode), typeof(LZ4BinaryCompressionMode)),
        };
        return $"{GetType().Name}-{mode}";
    }
}