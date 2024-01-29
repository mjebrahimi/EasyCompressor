using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EasyCompressor.Benchmarks;

[Display(Name = "Benchmark of Binary Compressors", GroupName = "Benchmark of Binary Compressors")]
public class BinaryBenchmark : BaseBenchmark
{
    public override string CompressionType => "Binary";

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        Compressor.Compress(Compressed.OriginalBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        Compressor.Decompress(Compressed.CompressedBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        var compressedBytes = Compressor.Compress(Compressed.OriginalBytes);
        Compressor.Decompress(compressedBytes);
    }
}
