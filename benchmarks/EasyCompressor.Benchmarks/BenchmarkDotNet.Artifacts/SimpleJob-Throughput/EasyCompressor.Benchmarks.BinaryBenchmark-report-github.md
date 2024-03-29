```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-KKQZIR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

RunStrategy=Throughput  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Method                | Type   | Compressor                       | Data           | CompressedSize        | Mean           | Error        | StdDev       | Median         | Allocated |
|---------------------- |------- |--------------------------------- |--------------- |---------------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **38,621.1 ns** |    **441.65 ns** |    **413.12 ns** |    **38,667.4 ns** |   **14881 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    69,793.1 ns |    479.38 ns |    448.41 ns |    69,711.9 ns |   35842 B |
| Decompress            | Binary | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    30,052.3 ns |    252.11 ns |    235.82 ns |    30,029.9 ns |   20961 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **74,157.9 ns** |  **2,138.56 ns** |  **6,305.60 ns** |    **77,607.9 ns** |   **81713 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   126,530.3 ns |  1,259.82 ns |  1,237.31 ns |   126,378.0 ns |  190507 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    57,720.2 ns |  1,058.69 ns |    990.30 ns |    57,311.5 ns |  108793 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **63,283.4 ns** |    **501.42 ns** |    **444.49 ns** |    **63,331.9 ns** |    **3874 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    87,077.7 ns |    421.21 ns |    394.00 ns |    87,180.8 ns |   24985 B |
| Decompress            | Binary | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,231.1 ns |    193.83 ns |    171.82 ns |    19,193.1 ns |   21112 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **63,156.8 ns** |    **741.81 ns** |    **693.89 ns** |    **63,126.6 ns** |    **4202 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    89,193.8 ns |    406.95 ns |    380.66 ns |    89,301.1 ns |   25345 B |
| Decompress            | Binary | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,294.4 ns |    136.11 ns |    127.32 ns |    20,273.7 ns |   21144 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,356 bytes (21.07 %)** |    **12,738.1 ns** |     **79.67 ns** |     **74.52 ns** |    **12,730.9 ns** |    **4384 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Large (20 KB)  | 4,356 bytes (21.07 %) |    18,236.7 ns |    221.80 ns |    196.62 ns |    18,170.0 ns |   25088 B |
| Decompress            | Binary | LZ4Compressor                    | Large (20 KB)  | 4,356 bytes (21.07 %) |     4,465.0 ns |     85.64 ns |    108.31 ns |     4,470.7 ns |   20704 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **3,953,108.5 ns** | **51,892.33 ns** | **48,540.12 ns** | **3,937,018.4 ns** | **1542552 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,608,579.0 ns | 44,337.50 ns | 41,473.33 ns | 4,626,689.8 ns | 1661889 B |
| Decompress            | Binary | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   581,904.5 ns |  2,042.66 ns |  1,910.70 ns |   581,904.2 ns |  119447 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |     **8,744.1 ns** |     **40.85 ns** |     **38.21 ns** |     **8,754.1 ns** |    **4864 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |    15,028.4 ns |    182.30 ns |    170.52 ns |    15,113.4 ns |   25648 B |
| Decompress            | Binary | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |     5,701.1 ns |    112.79 ns |    110.78 ns |     5,720.0 ns |   20784 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **12,788.4 ns** |    **216.68 ns** |    **202.68 ns** |    **12,908.6 ns** |   **28960 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    20,246.9 ns |    245.43 ns |    229.57 ns |    20,290.6 ns |   49664 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     6,842.3 ns |     44.42 ns |     39.38 ns |     6,844.7 ns |   20704 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **68,778.4 ns** |    **589.81 ns** |    **492.52 ns** |    **68,766.3 ns** |    **4192 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    98,181.3 ns |    553.87 ns |    490.99 ns |    98,150.4 ns |   25337 B |
| Decompress            | Binary | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,038.3 ns |    129.06 ns |    114.41 ns |    25,046.9 ns |   21144 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **20,047.0 ns** |    **145.86 ns** |    **136.44 ns** |    **20,022.5 ns** |    **3752 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    31,265.3 ns |    461.21 ns |    431.41 ns |    31,098.6 ns |   24528 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |     9,585.3 ns |    111.23 ns |    104.04 ns |     9,596.3 ns |   20776 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **19,450.1 ns** |    **144.01 ns** |    **134.71 ns** |    **19,448.8 ns** |   **24512 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    29,756.5 ns |    210.27 ns |    196.68 ns |    29,753.4 ns |   45240 B |
| Decompress            | Binary | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |     9,998.8 ns |     75.79 ns |     67.18 ns |    10,005.9 ns |   20728 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **11,716.2 ns** |    **146.57 ns** |    **137.11 ns** |    **11,712.5 ns** |    **3456 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    28,783.9 ns |    241.78 ns |    226.16 ns |    28,720.8 ns |   13689 B |
| Decompress            | Binary | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,413.7 ns |    170.09 ns |    159.10 ns |    16,374.1 ns |   10232 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **33,157.0 ns** |    **378.80 ns** |    **335.80 ns** |    **33,190.0 ns** |   **70287 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    77,778.3 ns |    728.81 ns |    608.59 ns |    77,769.7 ns |  157625 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    43,216.5 ns |    753.05 ns |    773.32 ns |    43,266.6 ns |   87336 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **20,761.5 ns** |    **111.08 ns** |     **92.76 ns** |    **20,735.3 ns** |    **1176 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    30,997.1 ns |    229.75 ns |    214.91 ns |    30,962.9 ns |   11560 B |
| Decompress            | Binary | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,511.8 ns |     97.11 ns |     86.09 ns |     7,472.8 ns |   10384 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **21,245.3 ns** |     **87.30 ns** |     **77.39 ns** |    **21,251.5 ns** |    **1504 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    32,529.1 ns |    181.40 ns |    169.68 ns |    32,528.5 ns |   11920 B |
| Decompress            | Binary | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,199.3 ns |    108.67 ns |    101.65 ns |     8,217.3 ns |   10416 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Medium (10 KB)** | **914 bytes (9.19 %)**    |     **3,356.9 ns** |     **31.37 ns** |     **29.34 ns** |     **3,353.4 ns** |     **944 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Medium (10 KB) | 914 bytes (9.19 %)    |     4,565.4 ns |     19.53 ns |     17.32 ns |     4,567.2 ns |   10920 B |
| Decompress            | Binary | LZ4Compressor                    | Medium (10 KB) | 914 bytes (9.19 %)    |     1,027.7 ns |     11.93 ns |     26.45 ns |     1,028.7 ns |    9976 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,685,347.4 ns** | **20,283.70 ns** | **18,973.39 ns** | **1,692,652.0 ns** | **1533909 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 1,902,558.1 ns | 12,301.75 ns | 11,507.06 ns | 1,899,810.0 ns | 1642643 B |
| Decompress            | Binary | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   172,319.5 ns |  1,926.07 ns |  1,801.65 ns |   171,670.2 ns |  108714 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |     **2,111.2 ns** |     **14.37 ns** |     **12.74 ns** |     **2,108.6 ns** |    **1408 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     3,865.7 ns |     76.88 ns |    105.24 ns |     3,879.2 ns |   11464 B |
| Decompress            | Binary | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     1,447.2 ns |     28.95 ns |     84.00 ns |     1,414.0 ns |   10056 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **3,008.1 ns** |     **27.50 ns** |     **24.38 ns** |     **3,013.7 ns** |   **12968 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     4,779.9 ns |     52.64 ns |     43.96 ns |     4,768.3 ns |   22944 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     1,627.5 ns |     18.61 ns |     18.28 ns |     1,620.3 ns |    9976 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,243.1 ns** |     **97.39 ns** |     **86.33 ns** |    **24,233.3 ns** |    **1496 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    36,667.7 ns |    152.89 ns |    143.01 ns |    36,639.4 ns |   11912 B |
| Decompress            | Binary | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,331.7 ns |     61.41 ns |     54.44 ns |    10,335.9 ns |   10416 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **6,136.2 ns** |    **122.23 ns** |    **171.35 ns** |     **6,110.8 ns** |     **968 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    10,319.1 ns |    117.88 ns |    110.27 ns |    10,329.6 ns |   11016 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     3,163.8 ns |     62.90 ns |     83.97 ns |     3,160.1 ns |   10048 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **5,750.3 ns** |     **44.19 ns** |     **34.50 ns** |     **5,747.0 ns** |   **10992 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     7,797.9 ns |    113.42 ns |    106.10 ns |     7,825.0 ns |   20992 B |
| Decompress            | Binary | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     1,903.0 ns |     25.69 ns |     20.06 ns |     1,898.4 ns |   10000 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **15,028.7 ns** |     **66.64 ns** |     **59.08 ns** |    **15,026.1 ns** |    **6192 B** |
| CompressAndDecompress | Binary | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |    25,474.5 ns |     78.89 ns |     65.88 ns |    25,468.2 ns |    8489 B |
| Decompress            | Binary | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |     9,956.3 ns |     49.08 ns |     43.51 ns |     9,951.7 ns |    2296 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **36,464.3 ns** |    **610.02 ns** |    **570.61 ns** |    **36,375.8 ns** |   **73040 B** |
| CompressAndDecompress | Binary | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    70,776.0 ns |  1,378.96 ns |  2,105.82 ns |    70,064.9 ns |  144505 B |
| Decompress            | Binary | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    27,544.7 ns |    501.49 ns |    444.55 ns |    27,418.1 ns |   71457 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **DeflateCompressor**                | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **28,010.1 ns** |     **81.83 ns** |     **76.55 ns** |    **28,015.2 ns** |    **1688 B** |
| CompressAndDecompress | Binary | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |    38,231.9 ns |    294.87 ns |    275.82 ns |    38,191.8 ns |    4144 B |
| Decompress            | Binary | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |     7,999.6 ns |     91.83 ns |     85.90 ns |     7,983.6 ns |    2448 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **GZipCompressor**                   | **Small (2 KB)**   | **1,410 bytes (70.15 %)** |    **28,254.5 ns** |    **183.88 ns** |    **153.55 ns** |    **28,246.0 ns** |    **2016 B** |
| CompressAndDecompress | Binary | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |    38,937.0 ns |    148.84 ns |    131.95 ns |    38,952.4 ns |    4504 B |
| Decompress            | Binary | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |     8,271.2 ns |     87.56 ns |     81.90 ns |     8,256.4 ns |    2480 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,747 bytes (86.92 %)** |     **4,666.1 ns** |     **25.44 ns** |     **23.80 ns** |     **4,662.7 ns** |    **1776 B** |
| CompressAndDecompress | Binary | LZ4Compressor                    | Small (2 KB)   | 1,747 bytes (86.92 %) |     5,279.6 ns |     24.59 ns |     19.19 ns |     5,283.7 ns |    3816 B |
| Decompress            | Binary | LZ4Compressor                    | Small (2 KB)   | 1,747 bytes (86.92 %) |       386.4 ns |      2.40 ns |      4.07 ns |       385.6 ns |    2040 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **LZMACompressor**                   | **Small (2 KB)**   | **1,337 bytes (66.52 %)** | **1,452,197.8 ns** | **12,147.27 ns** | **11,362.57 ns** | **1,454,204.5 ns** | **1536320 B** |
| CompressAndDecompress | Binary | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) | 1,736,171.6 ns | 12,362.54 ns | 10,959.07 ns | 1,735,079.8 ns | 1637377 B |
| Decompress            | Binary | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) |   241,441.3 ns |  1,546.28 ns |  1,446.39 ns |   241,846.5 ns |  100778 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappierCompressor**               | **Small (2 KB)**   | **1,812 bytes (90.15 %)** |     **1,896.3 ns** |     **19.37 ns** |     **17.17 ns** |     **1,891.7 ns** |    **1928 B** |
| CompressAndDecompress | Binary | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |     2,404.1 ns |     24.31 ns |     21.55 ns |     2,401.3 ns |    4056 B |
| Decompress            | Binary | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |       496.0 ns |      9.92 ns |     15.45 ns |       488.9 ns |    2120 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,772 bytes (88.16 %)** |     **2,966.9 ns** |     **36.97 ns** |     **34.58 ns** |     **2,976.5 ns** |    **4200 B** |
| CompressAndDecompress | Binary | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |     3,811.8 ns |     32.47 ns |     27.11 ns |     3,820.0 ns |    6240 B |
| Decompress            | Binary | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |       741.4 ns |      8.13 ns |      7.61 ns |       741.9 ns |    2040 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,398 bytes (69.55 %)** |    **29,545.5 ns** |    **569.81 ns** |    **533.00 ns** |    **29,365.1 ns** |    **2008 B** |
| CompressAndDecompress | Binary | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |    39,666.2 ns |    291.72 ns |    272.88 ns |    39,629.5 ns |    4488 B |
| Decompress            | Binary | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |     8,784.3 ns |    131.56 ns |    123.06 ns |     8,780.0 ns |    2480 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **6,400.1 ns** |     **31.93 ns** |     **29.87 ns** |     **6,403.3 ns** |    **1792 B** |
| CompressAndDecompress | Binary | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     9,324.6 ns |     25.61 ns |     22.70 ns |     9,318.5 ns |    3904 B |
| Decompress            | Binary | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,314.9 ns |      7.96 ns |      7.06 ns |     2,315.8 ns |    2112 B |
|                       |        |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **Binary** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **5,337.8 ns** |     **28.93 ns** |     **27.06 ns** |     **5,338.1 ns** |    **3848 B** |
| CompressAndDecompress | Binary | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     6,811.5 ns |     81.76 ns |     76.48 ns |     6,803.7 ns |    5912 B |
| Decompress            | Binary | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,390.3 ns |     15.87 ns |     13.26 ns |     1,392.0 ns |    2064 B |
