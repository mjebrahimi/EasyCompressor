``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]   : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  ShortRun : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                Method |          Compressor | CompressedSize |         Mean |        Error |     StdDev |     Gen 0 |     Gen 1 |    Gen 2 |   Allocated |
|---------------------- |-------------------- |--------------- |-------------:|-------------:|-----------:|----------:|----------:|---------:|------------:|
|            Decompress |    SnappyCompressor |     5811 bytes |     38.40 μs |    13.820 μs |   0.758 μs |   27.7710 |   27.7710 |  27.7710 |    87.47 KB |
|            Decompress |      ZstdCompressor |      775 bytes |     42.04 μs |    29.933 μs |   1.641 μs |   27.7710 |   27.7710 |  27.7710 |    87.66 KB |
|            Decompress |       LZ4Compressor |     1234 bytes |     61.83 μs |     4.063 μs |   0.223 μs |   55.5420 |   55.5420 |  55.5420 |   174.97 KB |
|            Decompress |   DeflateCompressor |     1683 bytes |    223.91 μs |    62.264 μs |   3.413 μs |   68.8477 |   68.8477 |  68.8477 |   342.03 KB |
|            Decompress |      GZipCompressor |     1701 bytes |    228.27 μs |    24.495 μs |   1.343 μs |   68.8477 |   68.8477 |  68.8477 |   342.06 KB |
|            Decompress | ZstandardCompressor |      775 bytes |    238.88 μs |    42.793 μs |   2.346 μs |   68.8477 |   68.8477 |  68.8477 |   342.98 KB |
|            Decompress |    BrotliCompressor |      659 bytes |    258.83 μs |    18.021 μs |   0.988 μs |   68.8477 |   68.8477 |  68.8477 |   342.92 KB |
|            Decompress | BrotliNETCompressor |      659 bytes |    350.41 μs |    93.837 μs |   5.144 μs |  137.6953 |   68.8477 |  68.8477 |   471.01 KB |
|            Decompress |      LZMACompressor |      789 bytes |    641.93 μs |   106.228 μs |   5.823 μs |  219.7266 |  208.9844 | 208.0078 |  4304.71 KB |
|                       |                     |                |              |              |            |           |           |          |             |
|              Compress |    SnappyCompressor |              ? |     45.86 μs |     7.755 μs |   0.425 μs |   32.2266 |   32.2266 |  32.2266 |   107.77 KB |
|              Compress |       LZ4Compressor |              ? |     51.32 μs |     4.870 μs |   0.267 μs |   28.5645 |   28.5645 |  28.5645 |    89.09 KB |
|              Compress |      ZstdCompressor |              ? |     65.97 μs |    30.565 μs |   1.675 μs |   28.5645 |   28.5645 |  28.5645 |    88.76 KB |
|              Compress |   DeflateCompressor |              ? |    168.16 μs |    68.002 μs |   3.727 μs |    2.1973 |         - |        - |     6.98 KB |
|              Compress |      GZipCompressor |              ? |    169.56 μs |    54.810 μs |   3.004 μs |    2.1973 |         - |        - |     7.33 KB |
|              Compress | ZstandardCompressor |              ? |    403.50 μs |    68.359 μs |   3.747 μs |    0.9766 |         - |        - |     3.42 KB |
|              Compress | BrotliNETCompressor |              ? | 11,681.38 μs | 1,739.442 μs |  95.345 μs |   15.6250 |         - |        - |    66.98 KB |
|              Compress |    BrotliCompressor |              ? | 11,862.39 μs | 2,527.424 μs | 138.537 μs |         - |         - |        - |     2.91 KB |
|              Compress |      LZMACompressor |              ? | 15,143.42 μs | 5,036.823 μs | 276.085 μs | 1031.2500 | 1000.0000 | 937.5000 | 47736.97 KB |
|                       |                     |                |              |              |            |           |           |          |             |
| CompressAndDecompress |    SnappyCompressor |              ? |    132.37 μs |    42.518 μs |   2.331 μs |   60.5469 |   60.5469 |  60.5469 |   195.23 KB |
| CompressAndDecompress |      ZstdCompressor |              ? |    168.91 μs |   142.817 μs |   7.828 μs |   55.1758 |   55.1758 |  55.1758 |   176.41 KB |
| CompressAndDecompress |       LZ4Compressor |              ? |    213.78 μs |    93.448 μs |   5.122 μs |   83.2520 |   83.2520 |  83.2520 |   264.05 KB |
| CompressAndDecompress |   DeflateCompressor |              ? |    491.20 μs |   402.593 μs |  22.067 μs |   68.3594 |   68.3594 |  68.3594 |   349.01 KB |
| CompressAndDecompress |      GZipCompressor |              ? |    508.54 μs |   503.868 μs |  27.619 μs |   68.8477 |   68.8477 |  68.8477 |   349.39 KB |
| CompressAndDecompress | ZstandardCompressor |              ? |    714.53 μs |    35.200 μs |   1.929 μs |   68.3594 |   68.3594 |  68.3594 |    346.4 KB |
| CompressAndDecompress | BrotliNETCompressor |              ? | 12,261.90 μs | 2,270.761 μs | 124.468 μs |  125.0000 |   62.5000 |  62.5000 |   537.99 KB |
| CompressAndDecompress |    BrotliCompressor |              ? | 12,316.17 μs | 1,658.981 μs |  90.934 μs |   62.5000 |   62.5000 |  62.5000 |   345.83 KB |
| CompressAndDecompress |      LZMACompressor |              ? | 15,865.26 μs | 3,599.289 μs | 197.289 μs | 1031.2500 |  968.7500 | 937.5000 | 52040.31 KB |
