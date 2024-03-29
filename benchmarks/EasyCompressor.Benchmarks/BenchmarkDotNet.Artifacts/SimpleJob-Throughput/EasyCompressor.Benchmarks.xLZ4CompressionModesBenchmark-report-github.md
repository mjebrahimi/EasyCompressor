```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-KKQZIR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

RunStrategy=Throughput  arg=EasyC(...)edArg [69]  

```
| Method                | Categories       | Size           | Mean        | Error     | StdDev    | Allocated |
|---------------------- |----------------- |--------------- |------------:|----------:|----------:|----------:|
| **Compress**              | **LegacyCompatible** | **Large (20 KB)**  | **13,400.8 ns** |  **53.54 ns** |  **50.08 ns** |   **25216 B** |
| Decompress            | LegacyCompatible | Large (20 KB)  |  3,589.0 ns |  24.25 ns |  21.49 ns |   20704 B |
| CompressAndDecompress | LegacyCompatible | Large (20 KB)  | 16,864.5 ns |  92.97 ns |  86.96 ns |   45920 B |
| Compress              | Native-Optimal   | Large (20 KB)  |  8,778.4 ns |  79.77 ns |  74.62 ns |    4672 B |
| Decompress            | Native-Optimal   | Large (20 KB)  |  3,903.3 ns |  24.93 ns |  30.62 ns |   20752 B |
| CompressAndDecompress | Native-Optimal   | Large (20 KB)  | 13,653.3 ns | 153.31 ns | 135.90 ns |   25424 B |
| Compress              | Optimal          | Large (20 KB)  | 12,806.0 ns |  37.82 ns |  35.37 ns |    4384 B |
| Decompress            | Optimal          | Large (20 KB)  |  4,409.6 ns |  88.18 ns | 114.66 ns |   20704 B |
| CompressAndDecompress | Optimal          | Large (20 KB)  | 17,649.5 ns | 155.20 ns | 137.58 ns |   25088 B |
| Compress              | StreamCompatible | Large (20 KB)  | 14,928.2 ns |  44.08 ns |  41.23 ns |    9848 B |
| Decompress            | StreamCompatible | Large (20 KB)  | 10,057.3 ns | 128.09 ns | 119.82 ns |   21280 B |
| CompressAndDecompress | StreamCompatible | Large (20 KB)  | 25,068.1 ns | 238.98 ns | 223.54 ns |   31128 B |
|                       |                  |                |             |           |           |           |
| **Compress**              | **LegacyCompatible** | **Medium (10 KB)** |  **4,182.2 ns** |  **65.69 ns** |  **54.85 ns** |   **11016 B** |
| Decompress            | LegacyCompatible | Medium (10 KB) |    811.5 ns |   9.31 ns |  16.06 ns |    9976 B |
| CompressAndDecompress | LegacyCompatible | Medium (10 KB) |  4,377.5 ns |  87.52 ns | 113.80 ns |   20992 B |
| Compress              | Native-Optimal   | Medium (10 KB) |  1,723.5 ns |   9.62 ns |   8.03 ns |    1128 B |
| Decompress            | Native-Optimal   | Medium (10 KB) |  1,254.2 ns |  24.19 ns |  32.29 ns |   10024 B |
| CompressAndDecompress | Native-Optimal   | Medium (10 KB) |  3,098.7 ns |  33.75 ns |  31.57 ns |   11152 B |
| Compress              | Optimal          | Medium (10 KB) |  3,329.9 ns |   9.15 ns |   8.11 ns |     944 B |
| Decompress            | Optimal          | Medium (10 KB) |    947.9 ns |  18.86 ns |  24.53 ns |    9976 B |
| CompressAndDecompress | Optimal          | Medium (10 KB) |  4,553.5 ns |  21.96 ns |  20.54 ns |   10920 B |
| Compress              | StreamCompatible | Medium (10 KB) |  3,605.6 ns |  26.40 ns |  23.40 ns |    2928 B |
| Decompress            | StreamCompatible | Medium (10 KB) |  3,494.6 ns |  46.47 ns |  38.81 ns |   10552 B |
| CompressAndDecompress | StreamCompatible | Medium (10 KB) |  7,250.5 ns |  49.15 ns |  43.57 ns |   13480 B |
|                       |                  |                |             |           |           |           |
| **Compress**              | **LegacyCompatible** | **Small (2 KB)**   |  **5,174.5 ns** |  **19.51 ns** |  **18.25 ns** |    **3872 B** |
| Decompress            | LegacyCompatible | Small (2 KB)   |    360.5 ns |   2.59 ns |   2.17 ns |    2040 B |
| CompressAndDecompress | LegacyCompatible | Small (2 KB)   |  5,978.4 ns |  32.53 ns |  27.16 ns |    5912 B |
| Compress              | Native-Optimal   | Small (2 KB)   |  1,799.7 ns |   9.60 ns |   8.01 ns |    1832 B |
| Decompress            | Native-Optimal   | Small (2 KB)   |    403.5 ns |   6.29 ns |   8.82 ns |    2088 B |
| CompressAndDecompress | Native-Optimal   | Small (2 KB)   |  2,417.6 ns |   8.20 ns |   7.67 ns |    3920 B |
| Compress              | Optimal          | Small (2 KB)   |  4,670.6 ns |  20.61 ns |  17.21 ns |    1776 B |
| Decompress            | Optimal          | Small (2 KB)   |    387.1 ns |   6.32 ns |   7.76 ns |    2040 B |
| CompressAndDecompress | Optimal          | Small (2 KB)   |  5,243.1 ns |  25.65 ns |  22.74 ns |    3816 B |
| Compress              | StreamCompatible | Small (2 KB)   |  5,572.8 ns |  27.91 ns |  26.10 ns |    4608 B |
| Decompress            | StreamCompatible | Small (2 KB)   |  1,290.2 ns |  10.51 ns |   9.32 ns |    2616 B |
| CompressAndDecompress | StreamCompatible | Small (2 KB)   |  6,908.6 ns |  72.70 ns |  68.00 ns |    7224 B |
