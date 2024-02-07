```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3085/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  Job-KKQZIR : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

RunStrategy=Throughput  Compressed=EasyCompressor.Benchmarks.BaseBenchmark+CompressedArg  

```
| Method                | Type        | Compressor                       | Data           | CompressedSize        | Mean           | Error        | StdDev       | Median         | Allocated |
|---------------------- |------------ |--------------------------------- |--------------- |---------------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **37,848.9 ns** |    **196.71 ns** |    **184.00 ns** |    **37,830.6 ns** |   **11264 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    70,597.4 ns |    755.06 ns |    706.29 ns |    70,756.3 ns |   35907 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Large (20 KB)  | 3,650 bytes (17.66 %) |    30,131.8 ns |    143.12 ns |    126.88 ns |    30,153.6 ns |   20961 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Large (20 KB)**  | **3,650 bytes (17.66 %)** |    **60,426.2 ns** |    **879.68 ns** |    **734.57 ns** |    **60,542.5 ns** |   **77453 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |   122,280.9 ns |  2,445.44 ns |  6,937.31 ns |   125,270.3 ns |  188625 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Large (20 KB)  | 3,650 bytes (17.66 %) |    38,928.8 ns |    278.12 ns |    246.54 ns |    38,954.1 ns |  107488 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Large (20 KB)**  | **3,573 bytes (17.28 %)** |    **63,622.2 ns** |    **270.02 ns** |    **239.36 ns** |    **63,680.1 ns** |    **3936 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    87,821.8 ns |    462.34 ns |    409.86 ns |    87,654.1 ns |   25049 B |
| Decompress            | StreamAsync | DeflateCompressor                | Large (20 KB)  | 3,573 bytes (17.28 %) |    19,362.8 ns |    170.76 ns |    159.73 ns |    19,283.6 ns |   21112 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Large (20 KB)**  | **3,591 bytes (17.37 %)** |    **64,580.8 ns** |    **554.97 ns** |    **519.12 ns** |    **64,654.8 ns** |    **4265 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    90,733.8 ns |    657.38 ns |    582.75 ns |    90,678.6 ns |   25409 B |
| Decompress            | StreamAsync | GZipCompressor                   | Large (20 KB)  | 3,591 bytes (17.37 %) |    20,610.5 ns |     81.85 ns |     72.56 ns |    20,616.5 ns |   21144 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Large (20 KB)**  | **4,386 bytes (21.22 %)** |    **16,010.6 ns** |     **78.72 ns** |     **69.78 ns** |    **16,006.8 ns** |   **14128 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    27,745.1 ns |    390.07 ns |    345.78 ns |    27,675.6 ns |   41272 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Large (20 KB)  | 4,386 bytes (21.22 %) |    11,154.2 ns |    222.06 ns |    218.09 ns |    11,045.7 ns |   22728 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Large (20 KB)**  | **2,866 bytes (13.86 %)** | **3,971,263.3 ns** | **38,412.57 ns** | **35,931.14 ns** | **3,978,408.2 ns** | **1539532 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) | 4,643,702.3 ns | 36,293.69 ns | 33,949.14 ns | 4,632,387.5 ns | 1661952 B |
| Decompress            | StreamAsync | LZMACompressor                   | Large (20 KB)  | 2,866 bytes (13.86 %) |   579,658.3 ns |  2,456.61 ns |  2,177.72 ns |   579,159.9 ns |  119473 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Large (20 KB)**  | **4,751 bytes (22.98 %)** |   **228,411.8 ns** |  **2,726.90 ns** |  **2,550.75 ns** |   **228,869.5 ns** |  **234846 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |   253,606.3 ns |  4,565.92 ns |  4,270.96 ns |   254,634.4 ns |  256036 B |
| Decompress            | StreamAsync | SnappierCompressor               | Large (20 KB)  | 4,751 bytes (22.98 %) |       282.1 ns |      3.11 ns |      2.91 ns |       282.0 ns |     352 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Large (20 KB)**  | **4,755 bytes (23.00 %)** |    **14,644.8 ns** |    **220.79 ns** |    **195.73 ns** |    **14,618.9 ns** |   **54648 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |    23,656.0 ns |    413.80 ns |    656.33 ns |    23,413.8 ns |  101040 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Large (20 KB)  | 4,755 bytes (23.00 %) |     8,574.4 ns |     88.77 ns |     78.69 ns |     8,582.8 ns |   46392 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Large (20 KB)**  | **3,579 bytes (17.31 %)** |    **69,111.9 ns** |    **250.62 ns** |    **222.17 ns** |    **69,098.3 ns** |    **4256 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    99,154.5 ns |    440.40 ns |    390.41 ns |    99,206.6 ns |   25401 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Large (20 KB)  | 3,579 bytes (17.31 %) |    25,603.6 ns |    140.69 ns |    131.60 ns |    25,615.9 ns |   21144 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **24,120.7 ns** |    **285.13 ns** |    **266.71 ns** |    **24,178.1 ns** |   **28328 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    36,962.8 ns |    394.57 ns |    349.78 ns |    36,923.9 ns |   73680 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,361.8 ns |    199.72 ns |    245.27 ns |    11,339.4 ns |   45352 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Large (20 KB)**  | **3,622 bytes (17.52 %)** |    **65,526.4 ns** |    **946.32 ns** |    **885.19 ns** |    **65,724.1 ns** |    **4169 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    88,174.1 ns |    424.83 ns |    397.39 ns |    88,118.3 ns |   25185 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Large (20 KB)  | 3,622 bytes (17.52 %) |    11,459.7 ns |    226.21 ns |    309.64 ns |    11,300.4 ns |   21016 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **11,557.1 ns** |    **103.15 ns** |     **96.49 ns** |    **11,563.8 ns** |    **2696 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    29,384.2 ns |    216.53 ns |    191.95 ns |    29,351.8 ns |   13753 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Medium (10 KB) | 794 bytes (7.98 %)    |    16,380.9 ns |    149.64 ns |    139.98 ns |    16,394.8 ns |   10232 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Medium (10 KB)** | **794 bytes (7.98 %)**    |    **21,560.9 ns** |    **341.48 ns** |    **285.15 ns** |    **21,701.3 ns** |   **68881 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    58,671.1 ns |  1,131.78 ns |  1,303.36 ns |    58,719.6 ns |  155743 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Medium (10 KB) | 794 bytes (7.98 %)    |    22,569.1 ns |    137.13 ns |    128.27 ns |    22,519.9 ns |   86032 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Medium (10 KB)** | **875 bytes (8.79 %)**    |    **21,555.7 ns** |    **103.88 ns** |     **97.17 ns** |    **21,566.0 ns** |    **1240 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |    31,896.0 ns |    215.71 ns |    201.78 ns |    31,905.7 ns |   11624 B |
| Decompress            | StreamAsync | DeflateCompressor                | Medium (10 KB) | 875 bytes (8.79 %)    |     7,762.2 ns |    145.16 ns |    128.68 ns |     7,774.3 ns |   10384 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Medium (10 KB)** | **893 bytes (8.97 %)**    |    **22,367.1 ns** |    **137.47 ns** |    **121.86 ns** |    **22,331.4 ns** |    **1568 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |    32,976.6 ns |    324.35 ns |    287.53 ns |    32,890.3 ns |   11984 B |
| Decompress            | StreamAsync | GZipCompressor                   | Medium (10 KB) | 893 bytes (8.97 %)    |     8,376.4 ns |     67.02 ns |     62.69 ns |     8,361.9 ns |   10416 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Medium (10 KB)** | **928 bytes (9.33 %)**    |     **4,228.8 ns** |     **47.65 ns** |     **44.57 ns** |     **4,241.8 ns** |    **3752 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     9,767.7 ns |    129.03 ns |    120.70 ns |     9,802.8 ns |   16704 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Medium (10 KB) | 928 bytes (9.33 %)    |     4,579.8 ns |     40.83 ns |     36.19 ns |     4,578.4 ns |   12000 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Medium (10 KB)** | **741 bytes (7.45 %)**    | **1,680,814.5 ns** | **17,659.77 ns** | **16,518.96 ns** | **1,680,753.2 ns** | **1533254 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    | 1,876,086.2 ns | 17,186.51 ns | 16,076.27 ns | 1,875,243.8 ns | 1642730 B |
| Decompress            | StreamAsync | LZMACompressor                   | Medium (10 KB) | 741 bytes (7.45 %)    |   172,353.0 ns |  1,449.76 ns |  1,356.11 ns |   171,641.4 ns |  108744 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Medium (10 KB)** | **1,289 bytes (12.95 %)** |   **229,299.3 ns** |  **2,634.07 ns** |  **2,463.91 ns** |   **229,863.0 ns** |  **231385 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |   255,903.0 ns |  2,035.71 ns |  1,804.60 ns |   255,751.5 ns |  241839 B |
| Decompress            | StreamAsync | SnappierCompressor               | Medium (10 KB) | 1,289 bytes (12.95 %) |       261.9 ns |      3.57 ns |      3.34 ns |       262.3 ns |     352 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Medium (10 KB)** | **1,270 bytes (12.76 %)** |     **4,463.6 ns** |     **86.26 ns** |    **185.68 ns** |     **4,399.2 ns** |   **24440 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     7,299.5 ns |    144.36 ns |    160.45 ns |     7,340.5 ns |   45888 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Medium (10 KB) | 1,270 bytes (12.76 %) |     2,409.3 ns |     45.97 ns |     51.09 ns |     2,385.1 ns |   21448 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Medium (10 KB)** | **881 bytes (8.85 %)**    |    **24,375.6 ns** |    **112.70 ns** |     **99.91 ns** |    **24,387.3 ns** |    **1560 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    37,014.9 ns |    228.79 ns |    214.01 ns |    36,990.0 ns |   11976 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Medium (10 KB) | 881 bytes (8.85 %)    |    10,504.6 ns |     99.52 ns |     93.09 ns |    10,525.3 ns |   10416 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Medium (10 KB)** | **860 bytes (8.64 %)**    |     **8,001.1 ns** |     **57.01 ns** |     **50.54 ns** |     **7,996.3 ns** |   **12032 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |    12,634.0 ns |    108.42 ns |     84.65 ns |    12,656.5 ns |   33144 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Medium (10 KB) | 860 bytes (8.64 %)    |     4,100.2 ns |     81.95 ns |    213.00 ns |     4,017.0 ns |   21112 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Medium (10 KB)** | **860 bytes (8.64 %)**    |    **43,693.7 ns** |    **457.59 ns** |    **428.03 ns** |    **43,582.0 ns** |    **1136 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |    51,139.5 ns |    996.36 ns |    978.56 ns |    51,398.2 ns |   11424 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Medium (10 KB) | 860 bytes (8.64 %)    |     2,539.8 ns |     34.90 ns |     71.30 ns |     2,533.9 ns |   10288 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **BrotliCompressor**                 | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **14,793.3 ns** |     **42.88 ns** |     **40.11 ns** |    **14,802.2 ns** |    **4736 B** |
| CompressAndDecompress | StreamAsync | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |    25,898.0 ns |     72.32 ns |     64.11 ns |    25,899.4 ns |    8545 B |
| Decompress            | StreamAsync | BrotliCompressor                 | Small (2 KB)   | 1,494 bytes (74.33 %) |     9,933.5 ns |     77.96 ns |     72.92 ns |     9,940.5 ns |    2296 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **BrotliNETCompressor (deprecated)** | **Small (2 KB)**   | **1,494 bytes (74.33 %)** |    **26,960.8 ns** |    **509.65 ns** |    **523.38 ns** |    **27,087.1 ns** |   **70947 B** |
| CompressAndDecompress | StreamAsync | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    52,526.5 ns |  1,037.68 ns |  1,454.69 ns |    52,121.8 ns |  142597 B |
| Decompress            | StreamAsync | BrotliNETCompressor (deprecated) | Small (2 KB)   | 1,494 bytes (74.33 %) |    15,195.7 ns |    283.18 ns |    278.12 ns |    15,129.3 ns |   70160 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **DeflateCompressor**                | **Small (2 KB)**   | **1,392 bytes (69.25 %)** |    **29,095.4 ns** |     **87.03 ns** |     **81.41 ns** |    **29,090.6 ns** |    **1752 B** |
| CompressAndDecompress | StreamAsync | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |    38,987.3 ns |    186.01 ns |    174.00 ns |    39,034.1 ns |    4200 B |
| Decompress            | StreamAsync | DeflateCompressor                | Small (2 KB)   | 1,392 bytes (69.25 %) |     8,278.8 ns |     69.21 ns |     64.74 ns |     8,283.0 ns |    2448 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **GZipCompressor**                   | **Small (2 KB)**   | **1,410 bytes (70.15 %)** |    **29,584.2 ns** |    **108.58 ns** |    **101.57 ns** |    **29,619.2 ns** |    **2080 B** |
| CompressAndDecompress | StreamAsync | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |    39,802.9 ns |    192.11 ns |    160.42 ns |    39,834.2 ns |    4568 B |
| Decompress            | StreamAsync | GZipCompressor                   | Small (2 KB)   | 1,410 bytes (70.15 %) |     8,341.8 ns |     47.41 ns |     42.03 ns |     8,324.6 ns |    2480 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZ4Compressor**                    | **Small (2 KB)**   | **1,768 bytes (87.96 %)** |     **6,084.0 ns** |     **68.29 ns** |     **63.87 ns** |     **6,096.5 ns** |    **6272 B** |
| CompressAndDecompress | StreamAsync | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     8,759.5 ns |     51.28 ns |     45.46 ns |     8,753.0 ns |   12128 B |
| Decompress            | StreamAsync | LZ4Compressor                    | Small (2 KB)   | 1,768 bytes (87.96 %) |     2,347.1 ns |     16.10 ns |     15.06 ns |     2,349.3 ns |    4064 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **LZMACompressor**                   | **Small (2 KB)**   | **1,337 bytes (66.52 %)** | **1,444,927.8 ns** | **15,306.53 ns** | **13,568.84 ns** | **1,443,735.9 ns** | **1535018 B** |
| CompressAndDecompress | StreamAsync | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) | 1,745,869.1 ns | 14,798.54 ns | 13,842.56 ns | 1,743,001.0 ns | 1637314 B |
| Decompress            | StreamAsync | LZMACompressor                   | Small (2 KB)   | 1,337 bytes (66.52 %) |   240,482.2 ns |  1,577.53 ns |  1,475.62 ns |   240,284.1 ns |  100810 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappierCompressor**               | **Small (2 KB)**   | **1,812 bytes (90.15 %)** |   **147,274.3 ns** |  **1,551.92 ns** |  **1,451.67 ns** |   **146,609.6 ns** |  **203222 B** |
| CompressAndDecompress | StreamAsync | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |   192,026.9 ns |  1,470.43 ns |  1,227.88 ns |   192,408.1 ns |  205683 B |
| Decompress            | StreamAsync | SnappierCompressor               | Small (2 KB)   | 1,812 bytes (90.15 %) |       248.1 ns |      1.87 ns |      1.74 ns |       247.8 ns |     352 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **SnappyCompressor (deprecated)**    | **Small (2 KB)**   | **1,772 bytes (88.16 %)** |     **3,431.3 ns** |     **40.34 ns** |     **35.76 ns** |     **3,421.4 ns** |    **8232 B** |
| CompressAndDecompress | StreamAsync | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |     4,590.8 ns |     87.79 ns |     90.15 ns |     4,576.6 ns |   14304 B |
| Decompress            | StreamAsync | SnappyCompressor (deprecated)    | Small (2 KB)   | 1,772 bytes (88.16 %) |     1,071.3 ns |     20.44 ns |     20.07 ns |     1,066.7 ns |    6080 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZLibCompressor**                   | **Small (2 KB)**   | **1,398 bytes (69.55 %)** |    **29,807.0 ns** |     **94.03 ns** |     **87.96 ns** |    **29,805.2 ns** |    **2072 B** |
| CompressAndDecompress | StreamAsync | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |    40,293.0 ns |    567.84 ns |    503.38 ns |    40,392.8 ns |    4552 B |
| Decompress            | StreamAsync | ZLibCompressor                   | Small (2 KB)   | 1,398 bytes (69.55 %) |     8,654.5 ns |     42.49 ns |     37.66 ns |     8,649.8 ns |    2480 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdCompressor (deprecated)**      | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |     **7,193.7 ns** |     **29.91 ns** |     **26.51 ns** |     **7,201.1 ns** |    **5744 B** |
| CompressAndDecompress | StreamAsync | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |    10,878.5 ns |     62.25 ns |     58.23 ns |    10,894.8 ns |   11808 B |
| Decompress            | StreamAsync | ZstdCompressor (deprecated)      | Small (2 KB)   | 1,687 bytes (83.93 %) |     2,879.3 ns |     16.27 ns |     14.43 ns |     2,883.1 ns |    6064 B |
|                       |             |                                  |                |                       |                |              |              |                |           |
| **Compress**              | **StreamAsync** | **ZstdSharpCompressor**              | **Small (2 KB)**   | **1,687 bytes (83.93 %)** |    **41,063.8 ns** |    **343.96 ns** |    **321.74 ns** |    **41,094.4 ns** |    **1976 B** |
| CompressAndDecompress | StreamAsync | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |    41,129.0 ns |    194.54 ns |    181.98 ns |    41,170.4 ns |    4328 B |
| Decompress            | StreamAsync | ZstdSharpCompressor              | Small (2 KB)   | 1,687 bytes (83.93 %) |     1,880.7 ns |     12.12 ns |     10.74 ns |     1,881.2 ns |    2352 B |
