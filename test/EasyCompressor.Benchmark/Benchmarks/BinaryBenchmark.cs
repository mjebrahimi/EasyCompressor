using BenchmarkDotNet.Attributes;

namespace EasySerializer.Benchmark;

public class BinaryBenchmark : BaseBenchmark
{
    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        Compressor.Compressor.Compress(OriginalBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        Compressor.Compressor.Decompress(CompressionRatio.CompressedBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        var compressedBytes = Compressor.Compressor.Compress(OriginalBytes);
        Compressor.Compressor.Decompress(compressedBytes);
    }
}
