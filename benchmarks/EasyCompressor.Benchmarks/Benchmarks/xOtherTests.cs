using EasyCompressor.Benchmarks.Models;
using System;
using System.Diagnostics;

namespace EasyCompressor.Benchmarks;

public class SmallestSizeCompressionTest
{
    public void Test()
    {
        var large = SearchResponse.GetDataBinary();
        var medium = SpotifyAlbumArray.GetDataBinary();
        var small = Person.GetDataBinary();

        var lzma = new LZMACompressor(LZMACompressionLevel.Ultra, DictionarySize.VeryLarge_64MB);
        var brotli = new BrotliCompressor(System.IO.Compression.CompressionLevel.SmallestSize);
        var zstd = new ZstdSharpCompressor(ZstdCompressionLevel.SmallestSize);
        var lz4 = new LZ4Compressor(K4os.Compression.LZ4.LZ4Level.L12_MAX);

        byte[][] data = [small, medium, large];
        BaseCompressor[] compressors = [lzma, brotli, zstd, lz4];

        var stopwatch = new Stopwatch();
        foreach (var bytes in data)
        {
            foreach (var compressor in compressors)
            {
                stopwatch.Restart();
                var compressed = compressor.Compress(bytes);
                stopwatch.Stop();
                Console.WriteLine($"{bytes.Length}\t\tCompress\t\t{compressed.Length}\t\t{stopwatch.ElapsedMilliseconds}\t\t{compressor}");
                stopwatch.Restart();
                var decompressed = compressor.Decompress(compressed);
                stopwatch.Stop();
                Console.WriteLine($"{bytes.Length}\t\tDecompress\t\t{decompressed.Length}\t\t{stopwatch.ElapsedMilliseconds}\t\t{compressor}");
            }
        }
    }
}

//#if RELEASE
//[ShortRunJob]
//#else
//[MarkdownExporterAttribute.GitHub]
//#endif
//[MemoryDiagnoser]
//public class MyBench
//{
//    private static readonly byte[] smallData = Person.GetDataBinary();
//    private static readonly byte[] mediumData = Person.GetDataBinary();
//    private static readonly byte[] largeData = Person.GetDataBinary();

//    private IEasyCachingProvider easyCachingProviderNormal;
//    private IEasyCachingProvider easyCachingProviderWithCompressor;
//    private byte[] bytes;
//    //private byte[] compressedBytes;

//    [GlobalSetup]
//    public void Setup()
//    {
//        bytes = Data switch
//        {
//            "Small (2 KB)" => smallData,
//            "Medium (10 KB)" => mediumData,
//            "Large (20 KB)" => largeData,
//            _ => throw new System.NotImplementedException(),
//        };

//        {
//            var services = new ServiceCollection();

//            services.AddSnappierCompressor();

//            var dbPath = Path.GetTempPath();
//            services.AddEasyCaching(options =>
//            {
//                options
//                    .UseDisk(p =>
//                    {
//                        p.DBConfig.BasePath = "/";
//                        p.SerializerName = "msgpack";
//                    })
//                    .WithMessagePack("msgpack")
//                    .WithCompressor();
//            });

//            easyCachingProviderWithCompressor = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();
//        }

//        {
//            var services = new ServiceCollection();

//            var dbPath = Path.GetTempPath();
//            services.AddEasyCaching(options =>
//            {
//                options
//                    .UseDisk(p =>
//                    {
//                        p.DBConfig.BasePath = "/";
//                        p.SerializerName = "msgpack";
//                    })
//                    .WithMessagePack("msgpack");
//            });

//            easyCachingProviderNormal = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();
//        }
//    }

//    [Params("Small (2 KB)", "Medium (10 KB)", "Large (20 KB)")]
//    public string Data { get; set; }

//    [Benchmark]
//    public void Set_WithCompressor()
//    {
//        easyCachingProviderWithCompressor.Set("cacheKey", bytes, TimeSpan.FromMinutes(30));
//    }

//    [Benchmark]
//    public Task SetAsync_WithCompressor()
//    {
//        return easyCachingProviderWithCompressor.SetAsync("cacheKey", bytes, TimeSpan.FromMinutes(30));
//    }

//    [Benchmark]
//    public void Set_Normal()
//    {
//        easyCachingProviderNormal.Set("cacheKey", bytes, TimeSpan.FromMinutes(30));
//    }

//    [Benchmark]
//    public Task SetAsync_Normal()
//    {
//        return easyCachingProviderNormal.SetAsync("cacheKey", bytes, TimeSpan.FromMinutes(30));
//    }
//}