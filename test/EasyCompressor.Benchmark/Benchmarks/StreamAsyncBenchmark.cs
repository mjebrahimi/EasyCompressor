using BenchmarkDotNet.Attributes;
using System.IO;
using System.Threading.Tasks;

namespace EasySerializer.Benchmark
{
    public class StreamAsyncBenchmark : BaseBenchmark
    {
        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public Task Compress(CompressorArg Compressor)
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            return Compressor.Compressor.CompressAsync(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetDeompressors))]
        public Task Decompress(CompressorArg Compressor, CompressedBytesArg CompressedSize)
        {
            using var inputStream = new MemoryStream(CompressedSize.CompressedBytes);
            using var outputStream = new MemoryStream();

            return Compressor.Compressor.DecompressAsync(inputStream, outputStream);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetCompressors))]
        public async Task CompressAndDecompress(CompressorArg Compressor)
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            await Compressor.Compressor.CompressAsync(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            await Compressor.Compressor.DecompressAsync(inputStream2, outputStream2);
        }
    }
}
