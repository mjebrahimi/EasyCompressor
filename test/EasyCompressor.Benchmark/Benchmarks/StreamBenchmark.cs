using BenchmarkDotNet.Attributes;
using System.IO;

namespace EasySerializer.Benchmark;

public class StreamBenchmark : BaseBenchmark
{
    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        using var inputStream = new MemoryStream(OriginalBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compressor.Compress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        using var inputStream = new MemoryStream(CompressionRatio.CompressedBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compressor.Decompress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(CompressorArg Compressor, CompressedArg CompressionRatio)
    {
        using var inputStream = new MemoryStream(OriginalBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compressor.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.ToArray();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        Compressor.Compressor.Decompress(inputStream2, outputStream2);
    }
}
