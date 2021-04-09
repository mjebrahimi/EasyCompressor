using BenchmarkDotNet.Attributes;
using System.IO;
using System.Threading.Tasks;

namespace EasySerializer.Benchmark
{
    public class StreamAsyncBenchmark : BaseBenchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(GetArguments))]
        public Task Compress(CompressorArg Compressor, CompressedArg CompressionRatio)
        {
            using var inputStream = new MemoryStream(OriginalBytes);
            using var outputStream = new MemoryStream();

            return Compressor.Compressor.CompressAsync(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArguments))]
        public Task Decompress(CompressorArg Compressor, CompressedArg CompressionRatio)
        {
            using var inputStream = new MemoryStream(CompressionRatio.CompressedBytes);
            using var outputStream = new MemoryStream();

            return Compressor.Compressor.DecompressAsync(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetArguments))]
        public async Task CompressAndDecompress(CompressorArg Compressor, CompressedArg CompressionRatio)
        {
            using var inputStream = new MemoryStream(OriginalBytes);
            using var outputStream = new MemoryStream();

            await Compressor.Compressor.CompressAsync(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            await Compressor.Compressor.DecompressAsync(inputStream2, outputStream2);
        }
    }
}
