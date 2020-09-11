using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using EasyCompressor;
using System.Collections.Generic;
using System.IO;

namespace EasySerializer.Benchmark
{
    //[DryJob]
    [ShortRunJob]
    //[SimpleJob(RunStrategy.Throughput)]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(false)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BaseBenchmark
    {
        public BaseBenchmark()
        {
            var json = File.ReadAllText("Data\\spotifyAlbum.json");
            var spotifyAlbums = Serializer.FromJson<SpotifyAlbumArray>(json);
            ObjectBytes = Serializer.SerializeMessagePack(spotifyAlbums);
        }

        protected byte[] ObjectBytes;

        public IEnumerable<CompressorArg> GetCompressors
        {
            get
            {
                yield return new CompressorArg(new GZipCompressor());
                yield return new CompressorArg(new DeflateCompressor());
                yield return new CompressorArg(new BrotliCompressor());
                yield return new CompressorArg(new BrotliNETCompressor());
                yield return new CompressorArg(new LZ4Compressor());
                yield return new CompressorArg(new LZMACompressor());
                yield return new CompressorArg(new SnappyCompressor());
                yield return new CompressorArg(new ZstandardCompressor());
                yield return new CompressorArg(new ZstdCompressor());
            }
        }

        public IEnumerable<object[]> GetDeompressors
        {
            get
            {
                yield return new object[] { new CompressorArg(new GZipCompressor()), new CompressedBytesArg(new GZipCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new DeflateCompressor()), new CompressedBytesArg(new DeflateCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new BrotliCompressor()), new CompressedBytesArg(new BrotliCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new BrotliNETCompressor()), new CompressedBytesArg(new BrotliNETCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new LZ4Compressor()), new CompressedBytesArg(new LZ4Compressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new LZMACompressor()), new CompressedBytesArg(new LZMACompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new SnappyCompressor()), new CompressedBytesArg(new SnappyCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new ZstandardCompressor()), new CompressedBytesArg(new ZstandardCompressor(), ObjectBytes) };
                yield return new object[] { new CompressorArg(new ZstdCompressor()), new CompressedBytesArg(new ZstdCompressor(), ObjectBytes) };
            }
        }

        public class CompressorArg
        {
            public readonly ICompressor Compressor;
            public CompressorArg(ICompressor compressor)
            {
                Compressor = compressor;
            }
            public override string ToString() => Compressor.GetType().Name;
        }

        public class CompressedBytesArg
        {
            public readonly byte[] CompressedBytes;
            public CompressedBytesArg(ICompressor compressor, byte[] bytes)
            {
                CompressedBytes = compressor.Compress(bytes);
            }
            public override string ToString() => CompressedBytes.Length + " bytes";
        }
    }
}
