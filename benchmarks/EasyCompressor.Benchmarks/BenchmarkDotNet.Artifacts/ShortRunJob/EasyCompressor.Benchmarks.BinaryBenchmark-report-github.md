```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]   : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Method                | Type   | Compressor                       | Data           | CompressionRatio      | Mean           | Error         | StdDev       | Allocated |
|---------------------- |------- |--------------------------------- |--------------- |---------------------- |---------------:|--------------:|-------------:|----------:|
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **38,513.6 ns** |   **3,437.92 ns** |    **188.44 ns** |   **14880 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    69,393.7 ns |   4,746.06 ns |    260.15 ns |   35842 B |
| Decompress            | Binary | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    30,382.5 ns |   2,303.90 ns |    126.28 ns |   20961 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **67,087.8 ns** |  **29,377.78 ns** |  **1,610.30 ns** |   **81713 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   125,899.0 ns |   8,426.55 ns |    461.89 ns |  190505 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    60,820.6 ns |  20,717.54 ns |  1,135.60 ns |  108793 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **62,880.6 ns** |  **23,331.03 ns** |  **1,278.85 ns** |    **3872 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    86,682.1 ns |  13,359.21 ns |    732.26 ns |   24984 B |
| Decompress            | Binary | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,595.6 ns |   3,092.48 ns |    169.51 ns |   21112 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **62,950.8 ns** |  **13,693.90 ns** |    **750.61 ns** |    **4200 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    90,293.9 ns |   7,192.39 ns |    394.24 ns |   25344 B |
| Decompress            | Binary | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,660.6 ns |   4,187.29 ns |    229.52 ns |   21144 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,356 bytes (21.07 %)** |    **13,107.8 ns** |   **2,362.26 ns** |    **129.48 ns** |    **4384 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Large (20 KB)  | 4,356 bytes (21.07 %) |    18,069.8 ns |   1,852.87 ns |    101.56 ns |   25088 B |
| Decompress            | Binary | LZ4Compressor                    | Large (20 KB)  | 4,356 bytes (21.07 %) |     4,278.2 ns |   3,955.13 ns |    216.79 ns |   20704 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **4,064,055.3 ns** | **520,991.69 ns** | **28,557.31 ns** | **1542791 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,743,787.0 ns | 648,290.62 ns | 35,535.00 ns | 1662268 B |
| Decompress            | Binary | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   594,430.6 ns | 149,268.55 ns |  8,181.91 ns |  119441 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |     **8,933.8 ns** |   **2,828.27 ns** |    **155.03 ns** |    **4864 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |    15,366.9 ns |   3,653.71 ns |    200.27 ns |   25648 B |
| Decompress            | Binary | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |     5,456.1 ns |   1,269.61 ns |     69.59 ns |   20784 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **12,844.7 ns** |   **3,934.02 ns** |    **215.64 ns** |   **28960 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    19,995.3 ns |  10,455.03 ns |    573.08 ns |   49664 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     6,928.9 ns |   2,700.65 ns |    148.03 ns |   20704 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **68,568.5 ns** |  **20,949.07 ns** |  **1,148.29 ns** |    **4192 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    99,510.0 ns |  20,063.44 ns |  1,099.75 ns |   25336 B |
| Decompress            | Binary | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,156.2 ns |   2,464.18 ns |    135.07 ns |   21144 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **20,191.4 ns** |   **5,621.11 ns** |    **308.11 ns** |    **3752 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    31,622.1 ns |   1,633.87 ns |     89.56 ns |   24528 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |     9,490.4 ns |   5,814.19 ns |    318.70 ns |   20776 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **19,161.6 ns** |   **5,808.41 ns** |    **318.38 ns** |   **24512 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    30,203.2 ns |   5,555.92 ns |    304.54 ns |   45240 B |
| Decompress            | Binary | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |     9,875.0 ns |   3,496.37 ns |    191.65 ns |   20728 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **11,744.9 ns** |   **1,545.99 ns** |     **84.74 ns** |    **3456 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    29,481.9 ns |   5,493.49 ns |    301.12 ns |   13689 B |
| Decompress            | Binary | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,269.5 ns |   3,302.59 ns |    181.03 ns |   10232 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **32,443.5 ns** |  **18,839.17 ns** |  **1,032.64 ns** |   **70288 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    79,219.4 ns |  45,302.31 ns |  2,483.17 ns |  157625 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    43,257.1 ns |  12,515.63 ns |    686.02 ns |   87336 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **20,986.7 ns** |   **3,071.51 ns** |    **168.36 ns** |    **1176 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    30,872.8 ns |   4,755.03 ns |    260.64 ns |   11560 B |
| Decompress            | Binary | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,580.1 ns |   2,675.37 ns |    146.65 ns |   10384 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **21,938.7 ns** |   **7,947.83 ns** |    **435.65 ns** |    **1504 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    32,303.3 ns |   6,517.83 ns |    357.26 ns |   11920 B |
| Decompress            | Binary | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,238.7 ns |     888.57 ns |     48.71 ns |   10416 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Medium (10 KB)** | **914 bytes (9.19 %)**    |     **3,007.4 ns** |     **335.39 ns** |     **18.38 ns** |     **944 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Medium (10 KB) | 914 bytes (9.19 %)    |     4,954.7 ns |     753.24 ns |     41.29 ns |   10920 B |
| Decompress            | Binary | LZ4Compressor                    | Medium (10 KB) | 914 bytes (9.19 %)    |     1,041.0 ns |   1,816.53 ns |     99.57 ns |    9976 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,704,514.4 ns** | **503,922.41 ns** | **27,621.69 ns** | **1534304 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 2,003,206.1 ns | 336,327.31 ns | 18,435.23 ns | 1643063 B |
| Decompress            | Binary | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   166,793.4 ns |  12,005.02 ns |    658.04 ns |  108712 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |     **2,112.9 ns** |     **233.94 ns** |     **12.82 ns** |    **1408 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     3,985.9 ns |   2,908.86 ns |    159.44 ns |   11464 B |
| Decompress            | Binary | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     1,481.7 ns |   1,591.58 ns |     87.24 ns |   10056 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **3,182.2 ns** |   **2,805.21 ns** |    **153.76 ns** |   **12968 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     4,714.5 ns |     882.82 ns |     48.39 ns |   22944 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     1,820.5 ns |   1,237.62 ns |     67.84 ns |    9976 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,238.3 ns** |   **9,271.99 ns** |    **508.23 ns** |    **1496 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    37,213.2 ns |   6,129.93 ns |    336.00 ns |   11912 B |
| Decompress            | Binary | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,502.1 ns |   1,251.86 ns |     68.62 ns |   10416 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **6,038.1 ns** |   **1,985.44 ns** |    **108.83 ns** |     **968 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    10,297.6 ns |   1,381.01 ns |     75.70 ns |   11016 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     3,154.2 ns |   2,455.11 ns |    134.57 ns |   10048 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **5,457.6 ns** |   **1,443.05 ns** |     **79.10 ns** |   **10992 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     8,087.7 ns |   6,289.35 ns |    344.74 ns |   20992 B |
| Decompress            | Binary | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     1,854.3 ns |     326.63 ns |     17.90 ns |   10000 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **14,897.0 ns** |     **958.03 ns** |     **52.51 ns** |    **6208 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |    26,236.6 ns |   4,612.26 ns |    252.81 ns |    8480 B |
| Decompress            | Binary | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |     9,793.4 ns |   4,004.95 ns |    219.52 ns |    2296 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **36,634.8 ns** |   **4,711.83 ns** |    **258.27 ns** |   **73072 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    69,709.7 ns |  18,028.61 ns |    988.21 ns |  144472 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    28,248.4 ns |  12,634.81 ns |    692.56 ns |   71456 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Small (2 KB)**   | **1,386 bytes (68.96 %)** |    **29,076.7 ns** |   **8,098.72 ns** |    **443.92 ns** |    **1696 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |    38,641.7 ns |   2,296.65 ns |    125.89 ns |    4136 B |
| Decompress            | Binary | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |     8,120.8 ns |     214.30 ns |     11.75 ns |    2448 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Small (2 KB)**   | **1,404 bytes (69.85 %)** |    **30,290.9 ns** |   **4,055.66 ns** |    **222.30 ns** |    **2024 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |    38,509.5 ns |   2,650.33 ns |    145.27 ns |    4496 B |
| Decompress            | Binary | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |     8,277.6 ns |   1,733.82 ns |     95.04 ns |    2480 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,747 bytes (86.92 %)** |     **4,743.6 ns** |   **1,147.29 ns** |     **62.89 ns** |    **1776 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Small (2 KB)   | 1,747 bytes (86.92 %) |     5,751.4 ns |   2,088.99 ns |    114.50 ns |    3816 B |
| Decompress            | Binary | LZ4Compressor                    | Small (2 KB)   | 1,747 bytes (86.92 %) |       400.8 ns |     389.75 ns |     21.36 ns |    2040 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Small (2 KB)**   | **1,342 bytes (66.77 %)** | **1,440,037.3 ns** | **189,301.34 ns** | **10,376.25 ns** | **1536455 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) | 1,762,095.6 ns | 145,642.86 ns |  7,983.18 ns | 1637552 B |
| Decompress            | Binary | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) |   252,763.9 ns |  55,314.51 ns |  3,031.97 ns |  100777 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Small (2 KB)**   | **1,813 bytes (90.20 %)** |     **1,860.0 ns** |     **285.50 ns** |     **15.65 ns** |    **1928 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |     2,422.3 ns |      26.24 ns |      1.44 ns |    4040 B |
| Decompress            | Binary | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |       509.5 ns |     394.79 ns |     21.64 ns |    2120 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,770 bytes (88.06 %)** |     **3,007.6 ns** |     **944.49 ns** |     **51.77 ns** |    **4200 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |     3,688.9 ns |     911.49 ns |     49.96 ns |    6240 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |       721.8 ns |     257.13 ns |     14.09 ns |    2040 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **28,604.7 ns** |   **2,302.67 ns** |    **126.22 ns** |    **2000 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |    41,262.1 ns |  20,487.52 ns |  1,122.99 ns |    4488 B |
| Decompress            | Binary | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |     8,675.1 ns |   1,365.39 ns |     74.84 ns |    2480 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **6,494.3 ns** |   **1,470.17 ns** |     **80.59 ns** |    **1792 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     9,495.3 ns |     977.90 ns |     53.60 ns |    3904 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,323.2 ns |     211.97 ns |     11.62 ns |    2112 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **5,380.4 ns** |     **184.18 ns** |     **10.10 ns** |    **3848 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     6,919.8 ns |   1,439.68 ns |     78.91 ns |    5912 B |
| Decompress            | Binary | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,250.1 ns |     549.46 ns |     30.12 ns |    2064 B |
