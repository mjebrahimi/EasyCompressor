using BenchmarkDotNet.Attributes;
using EasyCompressor;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EasySerializer.Benchmark;

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
[Display(Name = "Benchmark of Stream Compressor of '{0}' type", GroupName = "Benchmark of Stream Compressors")]
public class StreamBenchmark<T> : BaseBenchmark<T> where T : BaseCompressor
{
    public override string CompressionType => "Stream";

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        CompressorInstance.Compress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.CompressedBytes);
        using var outputStream = new MemoryStream();

        CompressorInstance.Decompress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        CompressorInstance.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.ToArray();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        CompressorInstance.Decompress(inputStream2, outputStream2);
    }
}
