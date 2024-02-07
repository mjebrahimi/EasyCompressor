```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]   : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Method                | Type        | Compressor                       | Data           | CompressedSize        | Mean           | Error         | StdDev       | Allocated |
|---------------------- |------------ |--------------------------------- |--------------- |---------------------- |---------------:|--------------:|-------------:|----------:|
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **37,467.7 ns** |   **9,399.81 ns** |    **515.24 ns** |   **11264 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    70,239.6 ns |   8,989.18 ns |    492.73 ns |   35906 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    30,903.4 ns |   5,359.86 ns |    293.79 ns |   20961 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **61,597.2 ns** |  **25,477.55 ns** |  **1,396.51 ns** |   **77453 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   110,426.7 ns |  13,476.98 ns |    738.72 ns |  188625 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    38,889.4 ns |   6,167.89 ns |    338.08 ns |  107488 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **64,840.4 ns** |  **15,734.56 ns** |    **862.46 ns** |    **3936 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    89,057.3 ns |  36,814.22 ns |  2,017.91 ns |   25048 B |
| Decompress            | StreamAsync | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,354.0 ns |   2,946.96 ns |    161.53 ns |   21112 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **65,087.7 ns** |  **33,037.04 ns** |  **1,810.87 ns** |    **4264 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    88,857.5 ns |  12,741.17 ns |    698.39 ns |   25408 B |
| Decompress            | StreamAsync | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,808.0 ns |   5,349.47 ns |    293.22 ns |   21144 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,386 bytes (21.22 %)** |    **22,144.1 ns** |   **5,136.62 ns** |    **281.56 ns** |   **14128 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    28,300.5 ns |   5,672.42 ns |    310.92 ns |   41272 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    11,054.0 ns |   4,295.78 ns |    235.47 ns |   22728 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **4,012,791.3 ns** | **517,585.72 ns** | **28,370.62 ns** | **1540039 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,737,240.4 ns | 724,326.85 ns | 39,702.80 ns | 1662355 B |
| Decompress            | StreamAsync | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   586,056.9 ns | 150,178.99 ns |  8,231.82 ns |  119473 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |   **230,536.8 ns** |  **30,835.86 ns** |  **1,690.22 ns** |  **234848 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |   260,477.0 ns |  46,668.56 ns |  2,558.06 ns |  256010 B |
| Decompress            | StreamAsync | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |       280.1 ns |      59.50 ns |      3.26 ns |     352 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **15,126.7 ns** |  **11,525.12 ns** |    **631.73 ns** |   **54648 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    23,724.0 ns |  15,919.90 ns |    872.62 ns |  101040 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     8,458.6 ns |   1,284.02 ns |     70.38 ns |   46392 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **69,374.0 ns** |  **29,862.96 ns** |  **1,636.89 ns** |    **4256 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |   100,474.0 ns |  13,445.04 ns |    736.97 ns |   25400 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,162.9 ns |   4,560.87 ns |    250.00 ns |   21144 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **24,054.7 ns** |   **6,539.35 ns** |    **358.44 ns** |   **28328 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    36,458.9 ns |   8,108.54 ns |    444.46 ns |   73680 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,732.1 ns |   3,927.33 ns |    215.27 ns |   45352 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **68,369.8 ns** |  **15,537.71 ns** |    **851.67 ns** |    **4168 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    88,846.6 ns |  19,857.51 ns |  1,088.46 ns |   25184 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,236.8 ns |   2,506.29 ns |    137.38 ns |   21016 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **12,023.0 ns** |   **3,847.55 ns** |    **210.90 ns** |    **2696 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    29,087.6 ns |   1,753.60 ns |     96.12 ns |   13753 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,596.4 ns |   5,358.88 ns |    293.74 ns |   10232 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **21,675.0 ns** |  **12,245.86 ns** |    **671.24 ns** |   **68881 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    61,311.6 ns |  55,701.43 ns |  3,053.18 ns |  155742 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    22,812.0 ns |   8,334.46 ns |    456.84 ns |   86032 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **21,500.4 ns** |   **1,523.82 ns** |     **83.53 ns** |    **1240 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    30,993.1 ns |   3,259.91 ns |    178.69 ns |   11624 B |
| Decompress            | StreamAsync | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,695.0 ns |   2,113.61 ns |    115.85 ns |   10384 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **22,945.8 ns** |   **2,578.15 ns** |    **141.32 ns** |    **1568 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    33,178.9 ns |   5,667.07 ns |    310.63 ns |   11984 B |
| Decompress            | StreamAsync | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,116.2 ns |     950.28 ns |     52.09 ns |   10416 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Medium (10 KB)** | **928 bytes (9.33 %)**    |     **4,285.6 ns** |     **980.44 ns** |     **53.74 ns** |    **3752 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     9,521.9 ns |     678.38 ns |     37.18 ns |   16704 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     4,525.3 ns |     507.72 ns |     27.83 ns |   12000 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,731,793.7 ns** | **875,022.22 ns** | **47,962.92 ns** | **1533543 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 1,931,633.2 ns | 190,008.94 ns | 10,415.03 ns | 1643121 B |
| Decompress            | StreamAsync | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   169,716.3 ns |   7,137.65 ns |    391.24 ns |  108744 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |   **231,447.5 ns** |  **32,609.71 ns** |  **1,787.45 ns** |  **231395 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |   259,310.0 ns |  40,737.96 ns |  2,232.99 ns |  241840 B |
| Decompress            | StreamAsync | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |       245.4 ns |      36.19 ns |      1.98 ns |     352 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **4,334.4 ns** |   **6,140.67 ns** |    **336.59 ns** |   **24440 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     7,127.2 ns |  10,526.35 ns |    576.98 ns |   45888 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     2,420.2 ns |     283.04 ns |     15.51 ns |   21448 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,390.2 ns** |   **5,610.72 ns** |    **307.54 ns** |    **1560 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    37,002.4 ns |   4,794.95 ns |    262.83 ns |   11976 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,415.6 ns |   1,070.27 ns |     58.67 ns |   10416 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **7,993.7 ns** |   **1,471.84 ns** |     **80.68 ns** |   **12032 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    12,802.1 ns |   7,128.23 ns |    390.72 ns |   33144 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     4,139.1 ns |   5,323.23 ns |    291.78 ns |   21112 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |    **42,637.5 ns** |  **15,209.42 ns** |    **833.68 ns** |    **1136 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |    47,544.9 ns |  14,069.07 ns |    771.17 ns |   11424 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     2,548.7 ns |   1,809.34 ns |     99.18 ns |   10288 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **15,026.6 ns** |   **4,337.83 ns** |    **237.77 ns** |    **4760 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |    25,989.6 ns |   3,703.87 ns |    203.02 ns |    8544 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |    10,089.9 ns |   3,114.30 ns |    170.71 ns |    2296 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **27,745.5 ns** |  **17,069.50 ns** |    **935.64 ns** |   **70930 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    51,360.5 ns |  12,539.67 ns |    687.34 ns |  142621 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    15,100.5 ns |   5,344.38 ns |    292.94 ns |   70160 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Small (2 KB)**   | **1,386 bytes (68.96 %)** |    **28,589.8 ns** |     **688.35 ns** |     **37.73 ns** |    **1752 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |    39,202.6 ns |   8,394.53 ns |    460.13 ns |    4208 B |
| Decompress            | StreamAsync | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |     8,257.6 ns |     708.36 ns |     38.83 ns |    2448 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Small (2 KB)**   | **1,404 bytes (69.85 %)** |    **30,529.3 ns** |  **19,238.42 ns** |  **1,054.52 ns** |    **2088 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |    39,183.0 ns |   8,269.26 ns |    453.27 ns |    4560 B |
| Decompress            | StreamAsync | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |     8,322.1 ns |     922.28 ns |     50.55 ns |    2480 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,768 bytes (87.96 %)** |     **6,019.6 ns** |     **767.56 ns** |     **42.07 ns** |    **6272 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     8,612.4 ns |   1,233.40 ns |     67.61 ns |   12128 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     2,371.0 ns |     697.64 ns |     38.24 ns |    4064 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Small (2 KB)**   | **1,342 bytes (66.77 %)** | **1,458,457.7 ns** | **227,012.74 ns** | **12,443.33 ns** | **1535213 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) | 1,774,662.8 ns | 274,970.17 ns | 15,072.04 ns | 1637599 B |
| Decompress            | StreamAsync | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) |   238,657.2 ns |  42,838.64 ns |  2,348.13 ns |  100808 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Small (2 KB)**   | **1,813 bytes (90.20 %)** |   **154,939.3 ns** |  **19,726.60 ns** |  **1,081.28 ns** |  **203220 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |   193,318.8 ns |  21,244.66 ns |  1,164.49 ns |  205683 B |
| Decompress            | StreamAsync | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |       256.2 ns |      64.02 ns |      3.51 ns |     352 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,770 bytes (88.06 %)** |     **3,468.6 ns** |   **1,418.80 ns** |     **77.77 ns** |    **8232 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |     4,482.8 ns |     550.60 ns |     30.18 ns |   14304 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |     1,089.2 ns |   1,380.16 ns |     75.65 ns |    6072 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **29,168.9 ns** |   **1,359.41 ns** |     **74.51 ns** |    **2072 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |    40,173.3 ns |   6,246.63 ns |    342.40 ns |    4552 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |     8,767.2 ns |     824.98 ns |     45.22 ns |    2480 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **7,205.1 ns** |     **236.18 ns** |     **12.95 ns** |    **5760 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |    10,741.1 ns |     689.24 ns |     37.78 ns |   11808 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,897.8 ns |     280.94 ns |     15.40 ns |    6064 B |
|                       |             |                                  |                |                       |                |               |              |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |    **38,715.7 ns** |  **12,307.55 ns** |    **674.62 ns** |    **1976 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |    45,489.0 ns |   8,598.21 ns |    471.30 ns |    4328 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,898.6 ns |   1,917.27 ns |    105.09 ns |    2352 B |
