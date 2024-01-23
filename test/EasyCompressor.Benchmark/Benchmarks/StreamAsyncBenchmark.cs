using BenchmarkDotNet.Attributes;
using EasyCompressor;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace EasySerializer.Benchmark;

#pragma warning disable RCS1261 // Resource can be disposed asynchronously
[GenericTypeArguments(typeof(GZipCompressor))]
[GenericTypeArguments(typeof(DeflateCompressor))]
[GenericTypeArguments(typeof(BrotliCompressor))]
[GenericTypeArguments(typeof(BrotliNETCompressor))]
[GenericTypeArguments(typeof(LZ4Compressor))]
[GenericTypeArguments(typeof(LZMACompressor))]
[GenericTypeArguments(typeof(SnappyCompressor))]
[GenericTypeArguments(typeof(SnappierCompressor))]
[GenericTypeArguments(typeof(ZstdCompressor))]
[GenericTypeArguments(typeof(ZstdSharpCompressor))]
[Display(Name = "Benchmark of StreamAsync Compressor of '{0}' type", GroupName = "Benchmark of StreamAsync Compressors")]
public class StreamAsyncBenchmark<T> : BaseBenchmark<T> where T : BaseCompressor
{
    public override string CompressionType => "StreamAsync";

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task Compress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        await CompressorInstance.CompressAsync(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task Decompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.CompressedBytes);
        using var outputStream = new MemoryStream();

        await CompressorInstance.DecompressAsync(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task CompressAndDecompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        await CompressorInstance.CompressAsync(inputStream, outputStream).ConfigureAwait(false);
        var compressedBytes = outputStream.ToArray();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        await CompressorInstance.DecompressAsync(inputStream2, outputStream2).ConfigureAwait(false);
    }
}
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
