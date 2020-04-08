using BenchmarkDotNet.Attributes;

namespace EasySerializer.Benchmark
{
    public class BinaryBenchmark : BaseBenchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public void Compress(CompressorArg Compressor)
        {
            Compressor.Compressor.Compress(ObjectBytes);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetDeompressors))]
        public void Decompress(CompressorArg Compressor, CompressedBytesArg CompressedSize)
        {
            Compressor.Compressor.Decompress(CompressedSize.CompressedBytes);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public void CompressAndDecompress(CompressorArg Compressor)
        {
            var compressedBytes = Compressor.Compressor.Compress(ObjectBytes);
            Compressor.Compressor.Decompress(compressedBytes);
        }
    }
}
