using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using EasyCompressor;
using System.Collections.Generic;
using System.IO;

namespace EasySerializer.Benchmark;

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
            OriginalBytes = Serializer.SerializeMessagePack(spotifyAlbums);
        }

        protected byte[] OriginalBytes;

        public IEnumerable<object[]> GetArguments
        {
            get
            {
                yield return new object[] { new CompressorArg(new GZipCompressor()), new CompressedArg(new GZipCompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new DeflateCompressor()), new CompressedArg(new DeflateCompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new BrotliCompressor()), new CompressedArg(new BrotliCompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new BrotliNETCompressor()), new CompressedArg(new BrotliNETCompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new LZ4Compressor()), new CompressedArg(new LZ4Compressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new LZMACompressor()), new CompressedArg(new LZMACompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new SnappyCompressor()), new CompressedArg(new SnappyCompressor(), OriginalBytes) };
                //yield return new object[] { new CompressorArg(new ZstandardCompressor()), new CompressedArg(new ZstandardCompressor(), OriginalBytes) };
                yield return new object[] { new CompressorArg(new ZstdCompressor()), new CompressedArg(new ZstdCompressor(), OriginalBytes) };
            }
        }

    public class CompressorArg(ICompressor compressor)
        {
        public ICompressor Compressor { get; } = compressor;

            public override string ToString() => Compressor.GetType().Name;
        }

        public class CompressedArg
        {
            private readonly int compressedRatio;
            private readonly decimal savingPercent;
            public byte[] CompressedBytes { get; }

            public CompressedArg(ICompressor compressor, byte[] originalBytes)
            {
                CompressedBytes = compressor.Compress(originalBytes);
                compressedRatio = originalBytes.Length / CompressedBytes.Length;
                savingPercent = (originalBytes.Length - CompressedBytes.Length) * 100 / (decimal)originalBytes.Length;
            }

            public override string ToString() => string.Format("{0} ({1} bytes)", compressedRatio, CompressedBytes.Length);
        }
    }
