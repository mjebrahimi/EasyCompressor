```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]   : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Compressor                                                 | Data           | CompressedSize        | Mean          | Allocated   |
|----------------------------------------------------------- |--------------- |---------------------- |--------------:|------------:|
| LZMACompressor(Level:Ultra, DictionarySize:VeryLarge_64MB) | Large (20 KB)  | 2,606 bytes (12.61 %) | 84,938.393 us | 705300365 B |
| BrotliCompressor(Level:SmallestSize)                       | Large (20 KB)  | 2,679 bytes (12.96 %) | 36,070.549 us |      2981 B |
| ZstdSharpCompressor(Level:22)                              | Large (20 KB)  | 2,886 bytes (13.96 %) | 14,575.178 us |     23793 B |
|                                                            |                |                       |               |             |
| BrotliCompressor(Level:SmallestSize)                       | Medium (10 KB) | 652 bytes (6.55 %)    |  2,240.902 us |       877 B |
| LZMACompressor(Level:Ultra, DictionarySize:VeryLarge_64MB) | Medium (10 KB) | 738 bytes (7.42 %)    | 62,333.740 us | 705292309 B |
| ZstdSharpCompressor(Level:22)                              | Medium (10 KB) | 749 bytes (7.53 %)    |  1,147.036 us |     10882 B |
