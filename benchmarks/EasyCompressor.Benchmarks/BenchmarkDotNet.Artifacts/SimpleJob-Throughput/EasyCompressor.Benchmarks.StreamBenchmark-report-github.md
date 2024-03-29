```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-KKQZIR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

RunStrategy=Throughput  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Method                | Type   | Compressor                       | Data           | CompressedSize        | Mean           | Error        | StdDev       | Allocated |
|---------------------- |------- |--------------------------------- |--------------- |---------------------- |---------------:|-------------:|-------------:|----------:|
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **37,288.3 ns** |    **469.28 ns** |    **438.96 ns** |   **11264 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    69,576.9 ns |    687.24 ns |    642.84 ns |   35907 B |
| Decompress            | Stream | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    35,637.1 ns |    126.42 ns |    118.25 ns |   20961 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **62,551.4 ns** |  **1,237.34 ns** |    **966.03 ns** |   **78097 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   124,482.6 ns |  1,346.09 ns |  1,259.13 ns |  190571 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    56,781.3 ns |    391.44 ns |    326.87 ns |  108793 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **63,045.6 ns** |    **516.68 ns** |    **458.02 ns** |    **3937 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    86,950.5 ns |    444.14 ns |    370.88 ns |   25049 B |
| Decompress            | Stream | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,309.3 ns |    181.11 ns |    169.41 ns |   21112 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **63,096.4 ns** |    **605.33 ns** |    **536.61 ns** |    **4264 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    89,466.2 ns |    667.91 ns |    624.77 ns |   25409 B |
| Decompress            | Stream | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,294.2 ns |    113.43 ns |    100.56 ns |   21144 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,386 bytes (21.22 %)** |    **15,462.2 ns** |     **57.93 ns** |     **51.36 ns** |   **14128 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    26,186.9 ns |    156.25 ns |    138.51 ns |   39904 B |
| Decompress            | Stream | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |     9,990.1 ns |     96.47 ns |     85.52 ns |   21360 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **3,944,462.3 ns** | **42,398.44 ns** | **39,659.53 ns** | **1539551 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,629,848.5 ns | 56,059.77 ns | 52,438.35 ns | 1661943 B |
| Decompress            | Stream | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   577,074.0 ns |  3,343.62 ns |  3,127.63 ns |  119441 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |    **11,229.2 ns** |     **54.11 ns** |     **50.62 ns** |    **5384 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |    21,340.3 ns |    169.74 ns |    150.47 ns |   26440 B |
| Decompress            | Stream | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |       179.9 ns |      3.61 ns |      5.18 ns |     352 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **14,232.6 ns** |    **124.68 ns** |    **166.44 ns** |   **54576 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    23,820.1 ns |    399.83 ns |    374.00 ns |  100896 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     8,482.6 ns |    126.27 ns |    118.12 ns |   46320 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **69,395.4 ns** |    **575.41 ns** |    **538.24 ns** |    **4256 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    98,318.9 ns |    635.99 ns |    563.78 ns |   25401 B |
| Decompress            | Stream | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,182.5 ns |    129.49 ns |    121.13 ns |   21144 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **23,591.6 ns** |     **85.05 ns** |     **79.55 ns** |   **28256 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    36,313.6 ns |    123.17 ns |    102.85 ns |   73536 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    12,366.1 ns |    245.91 ns |    217.99 ns |   45280 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **66,929.0 ns** |    **684.89 ns** |    **607.14 ns** |    **4169 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    86,125.6 ns |    790.34 ns |    739.29 ns |   25113 B |
| Decompress            | Stream | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,373.7 ns |    216.36 ns |    202.38 ns |   20944 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **11,254.7 ns** |     **96.56 ns** |     **80.63 ns** |    **2696 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    28,776.0 ns |    190.77 ns |    178.45 ns |   13753 B |
| Decompress            | Stream | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,131.3 ns |     98.80 ns |     87.59 ns |   10232 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **32,210.3 ns** |    **321.37 ns** |    **300.61 ns** |   **69528 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    77,189.0 ns |    475.59 ns |    444.87 ns |  157689 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    41,843.5 ns |    372.05 ns |    329.81 ns |   87337 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **21,339.8 ns** |    **131.59 ns** |    **123.09 ns** |    **1240 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    31,271.5 ns |    321.64 ns |    300.86 ns |   11624 B |
| Decompress            | Stream | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,505.3 ns |     62.19 ns |     58.17 ns |   10384 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **22,039.9 ns** |     **75.51 ns** |     **66.94 ns** |    **1568 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    32,445.5 ns |    272.35 ns |    241.43 ns |   11984 B |
| Decompress            | Stream | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,099.5 ns |    153.64 ns |    143.72 ns |   10416 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Medium (10 KB)** | **928 bytes (9.33 %)**    |     **3,797.7 ns** |     **23.99 ns** |     **21.27 ns** |    **3752 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     7,462.2 ns |     60.95 ns |     57.01 ns |   15336 B |
| Decompress            | Stream | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     3,650.1 ns |     28.90 ns |     25.61 ns |   10632 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,688,751.6 ns** | **17,479.84 ns** | **16,350.65 ns** | **1533178 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 1,910,325.4 ns | 17,588.35 ns | 16,452.15 ns | 1642707 B |
| Decompress            | Stream | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   170,925.8 ns |  1,380.11 ns |  1,290.95 ns |  108714 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |     **3,374.3 ns** |     **11.31 ns** |     **10.02 ns** |    **1920 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |     6,977.1 ns |     81.28 ns |     76.03 ns |   12248 B |
| Decompress            | Stream | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |       144.3 ns |      1.01 ns |      0.90 ns |     352 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **3,920.1 ns** |     **74.42 ns** |     **62.14 ns** |   **24368 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     7,132.6 ns |    137.31 ns |    254.51 ns |   45744 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     2,292.9 ns |     22.27 ns |     41.27 ns |   21376 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,684.7 ns** |    **154.48 ns** |    **144.50 ns** |    **1560 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    36,706.6 ns |    184.90 ns |    172.95 ns |   11976 B |
| Decompress            | Stream | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,353.8 ns |     79.82 ns |     74.66 ns |   10416 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **7,834.4 ns** |     **91.16 ns** |     **80.81 ns** |   **11960 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    12,956.2 ns |    229.89 ns |    215.04 ns |   33000 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     3,996.9 ns |     79.04 ns |    134.22 ns |   21040 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |    **43,586.1 ns** |    **345.02 ns** |    **322.73 ns** |    **1136 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |    45,999.0 ns |    261.84 ns |    244.93 ns |   11352 B |
| Decompress            | Stream | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     2,769.5 ns |     54.63 ns |     71.03 ns |   10216 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **14,842.8 ns** |     **46.97 ns** |     **39.22 ns** |    **4768 B** |
| CompressAndDecompress | Stream | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |    25,478.5 ns |     63.65 ns |     59.54 ns |    8512 B |
| Decompress            | Stream | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |     9,901.3 ns |     30.47 ns |     25.44 ns |    2296 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **36,592.2 ns** |    **590.05 ns** |    **551.93 ns** |   **71592 B** |
| CompressAndDecompress | Stream | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    70,276.6 ns |  1,231.32 ns |  1,368.60 ns |  144536 B |
| Decompress            | Stream | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    26,640.5 ns |    340.38 ns |    318.39 ns |   71455 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **DeflateCompressor**                | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **28,266.5 ns** |    **135.66 ns** |    **126.90 ns** |    **1744 B** |
| CompressAndDecompress | Stream | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |    38,084.5 ns |    380.46 ns |    355.88 ns |    4200 B |
| Decompress            | Stream | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |     8,036.9 ns |     68.53 ns |     64.10 ns |    2448 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **GZipCompressor**                   | **Small (2 KB)**   | **1,410 bytes (70.15 %)** |    **29,020.2 ns** |    **131.06 ns** |    **116.18 ns** |    **2088 B** |
| CompressAndDecompress | Stream | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |    39,296.3 ns |    319.36 ns |    298.73 ns |    4568 B |
| Decompress            | Stream | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |     8,236.0 ns |     59.38 ns |     52.64 ns |    2480 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,768 bytes (87.96 %)** |     **5,687.4 ns** |     **37.57 ns** |     **33.30 ns** |    **6272 B** |
| CompressAndDecompress | Stream | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     7,533.8 ns |     82.85 ns |     77.50 ns |   10760 B |
| Decompress            | Stream | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     1,313.5 ns |     25.90 ns |     33.67 ns |    2696 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **LZMACompressor**                   | **Small (2 KB)**   | **1,337 bytes (66.52 %)** | **1,452,452.3 ns** | **19,428.65 ns** | **18,173.57 ns** | **1534970 B** |
| CompressAndDecompress | Stream | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) | 1,758,383.2 ns | 20,149.86 ns | 18,848.20 ns | 1637229 B |
| Decompress            | Stream | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) |   241,164.4 ns |  1,257.07 ns |  1,175.87 ns |  100778 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappierCompressor**               | **Small (2 KB)**   | **1,812 bytes (90.15 %)** |     **2,262.7 ns** |      **9.58 ns** |      **8.00 ns** |    **2440 B** |
| CompressAndDecompress | Stream | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |     3,332.0 ns |     58.39 ns |     54.62 ns |    4840 B |
| Decompress            | Stream | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |       152.3 ns |      1.70 ns |      1.51 ns |     352 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,772 bytes (88.16 %)** |     **3,450.4 ns** |     **68.22 ns** |     **63.81 ns** |    **8160 B** |
| CompressAndDecompress | Stream | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |     4,626.0 ns |     90.74 ns |    100.86 ns |   14160 B |
| Decompress            | Stream | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |       923.7 ns |      8.30 ns |      7.35 ns |    6000 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,398 bytes (69.55 %)** |    **29,594.6 ns** |    **131.04 ns** |    **116.16 ns** |    **2064 B** |
| CompressAndDecompress | Stream | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |    39,190.3 ns |    410.32 ns |    363.73 ns |    4552 B |
| Decompress            | Stream | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |     8,566.0 ns |     82.10 ns |     76.79 ns |    2480 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **7,053.6 ns** |     **20.88 ns** |     **18.51 ns** |    **5672 B** |
| CompressAndDecompress | Stream | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |    10,509.3 ns |     72.23 ns |     67.56 ns |   11664 B |
| Decompress            | Stream | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,862.8 ns |     40.46 ns |     35.87 ns |    5992 B |
|                       |        |                                  |                |                       |                |              |              |           |
| **Compress**              | **Stream** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |    **39,942.6 ns** |    **287.74 ns** |    **255.07 ns** |    **1976 B** |
| CompressAndDecompress | Stream | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |    43,245.3 ns |    291.50 ns |    272.67 ns |    4256 B |
| Decompress            | Stream | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,565.4 ns |     15.42 ns |     14.43 ns |    2280 B |
