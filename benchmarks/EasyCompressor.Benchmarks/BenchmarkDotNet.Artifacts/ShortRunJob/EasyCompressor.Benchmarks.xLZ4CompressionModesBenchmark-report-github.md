```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]   : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  arg=EasyC(...)edArg [69]  

```
| Method                | Categories       | Size           | Mean        | Error       | StdDev    | Allocated |
|---------------------- |----------------- |--------------- |------------:|------------:|----------:|----------:|
| **Compress**              | **LegacyCompatible** | **Large (20 KB)**  | **13,263.3 ns** | **3,410.97 ns** | **186.97 ns** |   **25216 B** |
| Decompress            | LegacyCompatible | Large (20 KB)  |  3,452.3 ns | 1,260.17 ns |  69.07 ns |   20704 B |
| CompressAndDecompress | LegacyCompatible | Large (20 KB)  | 17,027.5 ns | 3,703.35 ns | 202.99 ns |   45920 B |
| Compress              | Native-Optimal   | Large (20 KB)  |  8,686.3 ns | 1,090.27 ns |  59.76 ns |    4672 B |
| Decompress            | Native-Optimal   | Large (20 KB)  |  3,782.1 ns | 1,112.60 ns |  60.99 ns |   20752 B |
| CompressAndDecompress | Native-Optimal   | Large (20 KB)  | 13,478.5 ns | 3,519.42 ns | 192.91 ns |   25424 B |
| Compress              | Optimized        | Large (20 KB)  | 12,725.6 ns |   299.84 ns |  16.44 ns |    4384 B |
| Decompress            | Optimized        | Large (20 KB)  |  4,218.6 ns | 4,440.18 ns | 243.38 ns |   20704 B |
| CompressAndDecompress | Optimized        | Large (20 KB)  | 18,212.9 ns |   795.73 ns |  43.62 ns |   25088 B |
| Compress              | StreamCompatible | Large (20 KB)  | 14,983.6 ns | 4,147.88 ns | 227.36 ns |    9848 B |
| Decompress            | StreamCompatible | Large (20 KB)  | 10,043.9 ns | 3,078.19 ns | 168.73 ns |   21280 B |
| CompressAndDecompress | StreamCompatible | Large (20 KB)  | 25,288.7 ns | 2,921.77 ns | 160.15 ns |   31128 B |
|                       |                  |                |             |             |           |           |
| **Compress**              | **LegacyCompatible** | **Medium (10 KB)** |  **3,840.2 ns** | **1,769.60 ns** |  **97.00 ns** |   **11016 B** |
| Decompress            | LegacyCompatible | Medium (10 KB) |    822.3 ns | 1,137.60 ns |  62.36 ns |    9976 B |
| CompressAndDecompress | LegacyCompatible | Medium (10 KB) |  4,606.0 ns | 1,046.42 ns |  57.36 ns |   20992 B |
| Compress              | Native-Optimal   | Medium (10 KB) |  1,714.6 ns |   162.81 ns |   8.92 ns |    1128 B |
| Decompress            | Native-Optimal   | Medium (10 KB) |  1,226.5 ns | 2,310.35 ns | 126.64 ns |   10024 B |
| CompressAndDecompress | Native-Optimal   | Medium (10 KB) |  3,000.4 ns |   219.39 ns |  12.03 ns |   11152 B |
| Compress              | Optimized        | Medium (10 KB) |  2,972.8 ns |   330.75 ns |  18.13 ns |     944 B |
| Decompress            | Optimized        | Medium (10 KB) |  1,009.6 ns | 1,859.36 ns | 101.92 ns |    9976 B |
| CompressAndDecompress | Optimized        | Medium (10 KB) |  4,782.1 ns | 1,574.86 ns |  86.32 ns |   10920 B |
| Compress              | StreamCompatible | Medium (10 KB) |  3,689.9 ns |   503.09 ns |  27.58 ns |    2928 B |
| Decompress            | StreamCompatible | Medium (10 KB) |  3,613.0 ns | 1,269.48 ns |  69.58 ns |   10552 B |
| CompressAndDecompress | StreamCompatible | Medium (10 KB) |  7,144.9 ns |   659.33 ns |  36.14 ns |   13480 B |
|                       |                  |                |             |             |           |           |
| **Compress**              | **LegacyCompatible** | **Small (2 KB)**   |  **4,797.2 ns** |   **293.17 ns** |  **16.07 ns** |    **3872 B** |
| Decompress            | LegacyCompatible | Small (2 KB)   |    376.3 ns |   387.79 ns |  21.26 ns |    2040 B |
| CompressAndDecompress | LegacyCompatible | Small (2 KB)   |  5,260.1 ns |   840.65 ns |  46.08 ns |    5912 B |
| Compress              | Native-Optimal   | Small (2 KB)   |  1,774.9 ns |   218.21 ns |  11.96 ns |    1832 B |
| Decompress            | Native-Optimal   | Small (2 KB)   |    429.8 ns |   444.64 ns |  24.37 ns |    2088 B |
| CompressAndDecompress | Native-Optimal   | Small (2 KB)   |  2,317.3 ns |    83.74 ns |   4.59 ns |    3920 B |
| Compress              | Optimized        | Small (2 KB)   |  5,054.7 ns | 1,247.68 ns |  68.39 ns |    1776 B |
| Decompress            | Optimized        | Small (2 KB)   |    407.5 ns |   385.95 ns |  21.15 ns |    2040 B |
| CompressAndDecompress | Optimized        | Small (2 KB)   |  5,219.1 ns |   886.99 ns |  48.62 ns |    3816 B |
| Compress              | StreamCompatible | Small (2 KB)   |  5,605.7 ns | 3,399.63 ns | 186.35 ns |    4608 B |
| Decompress            | StreamCompatible | Small (2 KB)   |  1,332.5 ns |   510.15 ns |  27.96 ns |    2616 B |
| CompressAndDecompress | StreamCompatible | Small (2 KB)   |  6,966.9 ns |   432.67 ns |  23.72 ns |    7224 B |
