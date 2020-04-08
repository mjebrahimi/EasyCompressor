using BenchmarkDotNet.Attributes;
using System.IO;

namespace EasySerializer.Benchmark
{
    public class StreamBenchmark : BaseBenchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public void Compress(CompressorArg Compressor)
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compressor.Compress(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetDeompressors))]
        public void Decompress(CompressorArg Compressor, CompressedBytesArg CompressedSize)
        {
            using var inputStream = new MemoryStream(CompressedSize.CompressedBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compressor.Decompress(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public void CompressAndDecompress(CompressorArg Compressor)
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compressor.Compress(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            Compressor.Compressor.Decompress(inputStream2, outputStream2);
        }
    }
}
