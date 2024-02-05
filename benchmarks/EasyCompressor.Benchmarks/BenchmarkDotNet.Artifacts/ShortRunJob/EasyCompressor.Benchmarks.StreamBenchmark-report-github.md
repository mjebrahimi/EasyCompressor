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
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **38,054.0 ns** |   **3,018.77 ns** |    **165.47 ns** |   **11264 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    69,676.0 ns |   6,761.57 ns |    370.62 ns |   35906 B |
| Decompress            | Stream | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    30,174.6 ns |   9,531.18 ns |    522.44 ns |   20961 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **61,676.7 ns** |   **5,040.68 ns** |    **276.30 ns** |   **78097 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   125,642.3 ns |  35,058.88 ns |  1,921.70 ns |  190570 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    58,364.0 ns |   7,558.14 ns |    414.29 ns |  108793 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **63,577.4 ns** |  **14,433.34 ns** |    **791.14 ns** |    **3936 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    87,311.0 ns |  13,677.85 ns |    749.73 ns |   25048 B |
| Decompress            | Stream | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,510.9 ns |   4,772.28 ns |    261.58 ns |   21112 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **64,904.5 ns** |   **4,768.00 ns** |    **261.35 ns** |    **4264 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    89,746.6 ns |  18,355.07 ns |  1,006.10 ns |   25408 B |
| Decompress            | Stream | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,559.2 ns |   2,600.83 ns |    142.56 ns |   21144 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,386 bytes (21.22 %)** |    **16,006.9 ns** |   **2,261.57 ns** |    **123.96 ns** |   **14128 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    26,506.7 ns |   3,123.56 ns |    171.21 ns |   39904 B |
| Decompress            | Stream | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    10,042.5 ns |   1,295.11 ns |     70.99 ns |   21360 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **3,998,647.7 ns** | **344,912.37 ns** | **18,905.81 ns** | **1539969 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,698,000.8 ns | 465,003.32 ns | 25,488.40 ns | 1662236 B |
| Decompress            | Stream | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   580,457.1 ns |  45,519.47 ns |  2,495.08 ns |  119441 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |    **11,418.7 ns** |   **1,328.40 ns** |     **72.81 ns** |    **5384 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |    21,243.6 ns |   3,299.47 ns |    180.85 ns |   26440 B |
| Decompress            | Stream | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |       183.7 ns |     107.06 ns |      5.87 ns |     352 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **14,752.0 ns** |  **10,726.51 ns** |    **587.96 ns** |   **54576 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    22,228.1 ns |     297.79 ns |     16.32 ns |  100896 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     8,314.9 ns |   1,913.63 ns |    104.89 ns |   46320 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **69,881.4 ns** |  **40,024.60 ns** |  **2,193.88 ns** |    **4256 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |   100,155.8 ns |   9,086.93 ns |    498.09 ns |   25400 B |
| Decompress            | Stream | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,424.1 ns |     491.81 ns |     26.96 ns |   21144 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **24,068.9 ns** |   **4,760.94 ns** |    **260.96 ns** |   **28256 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    35,873.1 ns |   2,192.14 ns |    120.16 ns |   73536 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,492.5 ns |  11,840.12 ns |    649.00 ns |   45280 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **65,905.5 ns** |  **17,882.01 ns** |    **980.17 ns** |    **4168 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    86,544.7 ns |  53,890.90 ns |  2,953.94 ns |   25112 B |
| Decompress            | Stream | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,040.8 ns |   1,324.40 ns |     72.59 ns |   20944 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **11,992.6 ns** |   **2,437.78 ns** |    **133.62 ns** |    **2696 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    29,513.5 ns |   7,005.20 ns |    383.98 ns |   13753 B |
| Decompress            | Stream | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,162.2 ns |   1,764.02 ns |     96.69 ns |   10232 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **31,048.8 ns** |  **16,667.14 ns** |    **913.58 ns** |   **69527 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    75,991.1 ns |  21,023.90 ns |  1,152.39 ns |  157688 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    42,643.0 ns |   6,898.28 ns |    378.12 ns |   87336 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **21,336.4 ns** |   **3,892.86 ns** |    **213.38 ns** |    **1240 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    31,218.3 ns |   3,048.30 ns |    167.09 ns |   11624 B |
| Decompress            | Stream | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,645.5 ns |   1,066.76 ns |     58.47 ns |   10384 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **22,230.2 ns** |   **1,022.68 ns** |     **56.06 ns** |    **1568 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    32,289.6 ns |     753.73 ns |     41.31 ns |   11984 B |
| Decompress            | Stream | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,218.8 ns |   2,179.77 ns |    119.48 ns |   10416 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Medium (10 KB)** | **928 bytes (9.33 %)**    |     **4,021.6 ns** |     **343.50 ns** |     **18.83 ns** |    **3752 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     7,565.0 ns |     438.82 ns |     24.05 ns |   15336 B |
| Decompress            | Stream | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     3,489.0 ns |     537.10 ns |     29.44 ns |   10632 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,679,018.2 ns** | **233,299.41 ns** | **12,787.93 ns** | **1533548 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 1,907,928.1 ns | 230,052.26 ns | 12,609.94 ns | 1642992 B |
| Decompress            | Stream | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   171,222.9 ns |  23,489.42 ns |  1,287.53 ns |  108712 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |     **3,422.9 ns** |     **205.41 ns** |     **11.26 ns** |    **1920 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     6,868.0 ns |   1,169.27 ns |     64.09 ns |   12248 B |
| Decompress            | Stream | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |       143.7 ns |      34.92 ns |      1.91 ns |     352 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **4,136.8 ns** |   **4,184.24 ns** |    **229.35 ns** |   **24368 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     6,695.9 ns |   7,927.61 ns |    434.54 ns |   45744 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     2,510.1 ns |   4,504.94 ns |    246.93 ns |   21376 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,471.8 ns** |     **464.63 ns** |     **25.47 ns** |    **1560 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    37,306.8 ns |   2,993.15 ns |    164.06 ns |   11976 B |
| Decompress            | Stream | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,354.8 ns |   1,484.08 ns |     81.35 ns |   10416 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **7,920.0 ns** |   **1,169.60 ns** |     **64.11 ns** |   **11960 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    12,530.1 ns |   9,137.61 ns |    500.86 ns |   33000 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     4,011.2 ns |   4,194.21 ns |    229.90 ns |   21040 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |    **41,828.1 ns** |   **9,343.15 ns** |    **512.13 ns** |    **1136 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |    46,505.1 ns |  12,642.35 ns |    692.97 ns |   11352 B |
| Decompress            | Stream | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     2,559.8 ns |   1,620.25 ns |     88.81 ns |   10216 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **14,922.0 ns** |   **1,120.03 ns** |     **61.39 ns** |    **4760 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |    25,983.1 ns |   6,558.84 ns |    359.51 ns |    8584 B |
| Decompress            | Stream | BrotliCompressor                 | Small (2 KB)   | 1,478 bytes (73.53 %) |     9,979.3 ns |     289.50 ns |     15.87 ns |    2296 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,478 bytes (73.53 %)** |    **36,792.4 ns** |   **6,455.98 ns** |    **353.87 ns** |   **71592 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    69,414.0 ns |  18,021.64 ns |    987.83 ns |  144568 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,478 bytes (73.53 %) |    28,675.7 ns |  17,576.27 ns |    963.41 ns |   71462 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Small (2 KB)**   | **1,386 bytes (68.96 %)** |    **29,233.9 ns** |   **1,798.63 ns** |     **98.59 ns** |    **1760 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |    38,844.9 ns |   3,143.41 ns |    172.30 ns |    4208 B |
| Decompress            | Stream | DeflateCompressor                | Small (2 KB)   | 1,386 bytes (68.96 %) |     8,218.1 ns |   1,379.48 ns |     75.61 ns |    2448 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Small (2 KB)**   | **1,404 bytes (69.85 %)** |    **30,131.7 ns** |   **2,926.37 ns** |    **160.40 ns** |    **2088 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |    39,129.0 ns |   4,709.43 ns |    258.14 ns |    4568 B |
| Decompress            | Stream | GZipCompressor                   | Small (2 KB)   | 1,404 bytes (69.85 %) |     8,547.0 ns |   3,067.78 ns |    168.16 ns |    2480 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,768 bytes (87.96 %)** |     **5,721.2 ns** |     **631.60 ns** |     **34.62 ns** |    **6272 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     7,460.3 ns |   1,634.94 ns |     89.62 ns |   10760 B |
| Decompress            | Stream | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     1,272.9 ns |     501.40 ns |     27.48 ns |    2696 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Small (2 KB)**   | **1,342 bytes (66.77 %)** | **1,475,888.9 ns** | **202,972.28 ns** | **11,125.60 ns** | **1535193 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) | 1,739,690.3 ns | 115,233.71 ns |  6,316.35 ns | 1637511 B |
| Decompress            | Stream | LZMACompressor                   | Small (2 KB)   | 1,342 bytes (66.77 %) |   240,922.7 ns |  25,158.24 ns |  1,379.01 ns |  100776 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Small (2 KB)**   | **1,813 bytes (90.20 %)** |     **2,252.8 ns** |     **493.39 ns** |     **27.04 ns** |    **2440 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |     3,421.3 ns |     301.47 ns |     16.52 ns |    4832 B |
| Decompress            | Stream | SnappierCompressor               | Small (2 KB)   | 1,813 bytes (90.20 %) |       156.6 ns |      55.82 ns |      3.06 ns |     352 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,770 bytes (88.06 %)** |     **3,352.3 ns** |   **2,218.81 ns** |    **121.62 ns** |    **8160 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |     4,434.6 ns |   3,124.64 ns |    171.27 ns |   14160 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,770 bytes (88.06 %) |       943.9 ns |     152.51 ns |      8.36 ns |    6000 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **29,590.6 ns** |   **4,446.56 ns** |    **243.73 ns** |    **2072 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |    40,145.7 ns |  15,287.34 ns |    837.95 ns |    4552 B |
| Decompress            | Stream | ZLibCompressor                   | Small (2 KB)   | 1,392 bytes (69.25 %) |     8,936.2 ns |   2,063.66 ns |    113.12 ns |    2480 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **7,081.3 ns** |     **684.92 ns** |     **37.54 ns** |    **5672 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |    10,400.6 ns |     498.53 ns |     27.33 ns |   11664 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,849.6 ns |     559.71 ns |     30.68 ns |    5992 B |
|                       |        |                                  |                |                       |                |               |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |    **40,756.5 ns** |  **19,751.85 ns** |  **1,082.67 ns** |    **1976 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |    44,586.0 ns |   6,706.64 ns |    367.61 ns |    4256 B |
| Decompress            | Stream | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,551.2 ns |     756.23 ns |     41.45 ns |    2280 B |
