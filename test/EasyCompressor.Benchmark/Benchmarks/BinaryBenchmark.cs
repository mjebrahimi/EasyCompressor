using BenchmarkDotNet.Attributes;
using EasyCompressor;
using System.ComponentModel.DataAnnotations;

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
[Display(Name = "Benchmark of Binary Compressor of '{0}' type", GroupName = "Benchmark of Binary Compressors")]
public class BinaryBenchmark<T> : BaseBenchmark<T> where T : BaseCompressor
{
    public override string CompressionType => "Binary";

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        CompressorInstance.Compress(Compressed.OriginalBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        CompressorInstance.Decompress(Compressed.CompressedBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(string Data, CompressedArg Compressed, string CompressionRatio)
    {
        var compressedBytes = CompressorInstance.Compress(Compressed.OriginalBytes);
        CompressorInstance.Decompress(compressedBytes);
    }
}
