
| Method                | Compressor                       | Data           | Compressed   | CompressionRatio | Mean            | Allocated   |
|---------------------- |--------------------------------- |--------------- |------------- |----------------- |----------------:|------------:|
| Compress              | BrotliCompressor-NoCompression   | Large (20 KB)  | 3,908 bytes  | 18.90 %          |     39,569.3 ns |     15904 B |
| Compress              | BrotliCompressor-Fastest         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |     38,485.9 ns |     14880 B |
| Compress              | BrotliCompressor-Optimal         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |    160,620.5 ns |      3352 B |
| Compress              | BrotliCompressor-SmallestSize    | Large (20 KB)  | 2,679 bytes  | 12.96 %          | 35,640,204.4 ns |      2981 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliCompressor-NoCompression   | Large (20 KB)  | 3,908 bytes  | 18.90 %          |     69,350.2 ns |     36866 B |
| CompressAndDecompress | BrotliCompressor-Fastest         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |     69,775.0 ns |     35842 B |
| CompressAndDecompress | BrotliCompressor-Optimal         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |    200,004.1 ns |     24313 B |
| CompressAndDecompress | BrotliCompressor-SmallestSize    | Large (20 KB)  | 2,679 bytes  | 12.96 %          | 35,316,711.9 ns |     23962 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliCompressor-NoCompression   | Large (20 KB)  | 3,908 bytes  | 18.90 %          |     29,639.3 ns |     20961 B |
| Decompress            | BrotliCompressor-Fastest         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |     30,271.9 ns |     20961 B |
| Decompress            | BrotliCompressor-Optimal         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |     26,945.6 ns |     20961 B |
| Decompress            | BrotliCompressor-SmallestSize    | Large (20 KB)  | 2,679 bytes  | 12.96 %          |     36,559.0 ns |     20961 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | BrotliNETCompressor-0-22         | Large (20 KB)  | 3,908 bytes  | 18.90 %          |     66,509.6 ns |     82737 B |
| Compress              | BrotliNETCompressor-1-22         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |     63,448.9 ns |     81713 B |
| Compress              | BrotliNETCompressor-2-22         | Large (20 KB)  | 3,279 bytes  | 15.86 %          |    160,946.5 ns |     70392 B |
| Compress              | BrotliNETCompressor-3-22         | Large (20 KB)  | 3,157 bytes  | 15.27 %          |    197,691.2 ns |     70272 B |
| Compress              | BrotliNETCompressor-4-22         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |    201,806.3 ns |     70192 B |
| Compress              | BrotliNETCompressor-5-22         | Large (20 KB)  | 2,951 bytes  | 14.27 %          |    782,648.3 ns |     70057 B |
| Compress              | BrotliNETCompressor-6-22         | Large (20 KB)  | 2,949 bytes  | 14.26 %          |  1,161,136.9 ns |     70065 B |
| Compress              | BrotliNETCompressor-8-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |  3,194,906.1 ns |     70061 B |
| Compress              | BrotliNETCompressor-7-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |  2,591,440.9 ns |     70061 B |
| Compress              | BrotliNETCompressor-9-22         | Large (20 KB)  | 2,938 bytes  | 14.21 %          |  3,770,460.8 ns |     70058 B |
| Compress              | BrotliNETCompressor-10-22        | Large (20 KB)  | 2,698 bytes  | 13.05 %          |  6,383,009.6 ns |     69811 B |
| Compress              | BrotliNETCompressor-11-22        | Large (20 KB)  | 2,679 bytes  | 12.96 %          | 37,014,569.0 ns |     69889 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliNETCompressor-0-22         | Large (20 KB)  | 3,908 bytes  | 18.90 %          |    130,095.0 ns |    191529 B |
| CompressAndDecompress | BrotliNETCompressor-1-22         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |    126,952.0 ns |    190505 B |
| CompressAndDecompress | BrotliNETCompressor-2-22         | Large (20 KB)  | 3,279 bytes  | 15.86 %          |    244,430.8 ns |    179185 B |
| CompressAndDecompress | BrotliNETCompressor-3-22         | Large (20 KB)  | 3,157 bytes  | 15.27 %          |    264,778.1 ns |    179065 B |
| CompressAndDecompress | BrotliNETCompressor-4-22         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |    287,647.6 ns |    178984 B |
| CompressAndDecompress | BrotliNETCompressor-5-22         | Large (20 KB)  | 2,951 bytes  | 14.27 %          |    881,148.9 ns |    178802 B |
| CompressAndDecompress | BrotliNETCompressor-6-22         | Large (20 KB)  | 2,949 bytes  | 14.26 %          |  1,244,692.9 ns |    178804 B |
| CompressAndDecompress | BrotliNETCompressor-8-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |  3,293,916.4 ns |    178818 B |
| CompressAndDecompress | BrotliNETCompressor-7-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |  2,589,117.4 ns |    178802 B |
| CompressAndDecompress | BrotliNETCompressor-9-22         | Large (20 KB)  | 2,938 bytes  | 14.21 %          |  3,910,334.8 ns |    178802 B |
| CompressAndDecompress | BrotliNETCompressor-10-22        | Large (20 KB)  | 2,698 bytes  | 13.05 %          |  6,579,549.2 ns |    178565 B |
| CompressAndDecompress | BrotliNETCompressor-11-22        | Large (20 KB)  | 2,679 bytes  | 12.96 %          | 37,077,321.4 ns |    178635 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliNETCompressor-0-22         | Large (20 KB)  | 3,908 bytes  | 18.90 %          |     58,167.6 ns |    108793 B |
| Decompress            | BrotliNETCompressor-1-22         | Large (20 KB)  | 3,650 bytes  | 17.66 %          |     59,239.3 ns |    108793 B |
| Decompress            | BrotliNETCompressor-2-22         | Large (20 KB)  | 3,279 bytes  | 15.86 %          |     54,037.2 ns |    108793 B |
| Decompress            | BrotliNETCompressor-3-22         | Large (20 KB)  | 3,157 bytes  | 15.27 %          |     53,508.3 ns |    108793 B |
| Decompress            | BrotliNETCompressor-4-22         | Large (20 KB)  | 3,133 bytes  | 15.16 %          |     56,161.9 ns |    108793 B |
| Decompress            | BrotliNETCompressor-5-22         | Large (20 KB)  | 2,951 bytes  | 14.27 %          |     55,631.1 ns |    108793 B |
| Decompress            | BrotliNETCompressor-6-22         | Large (20 KB)  | 2,949 bytes  | 14.26 %          |     55,456.9 ns |    108793 B |
| Decompress            | BrotliNETCompressor-8-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |     55,891.2 ns |    108793 B |
| Decompress            | BrotliNETCompressor-7-22         | Large (20 KB)  | 2,942 bytes  | 14.23 %          |     56,282.7 ns |    108793 B |
| Decompress            | BrotliNETCompressor-9-22         | Large (20 KB)  | 2,938 bytes  | 14.21 %          |     55,415.9 ns |    108793 B |
| Decompress            | BrotliNETCompressor-10-22        | Large (20 KB)  | 2,698 bytes  | 13.05 %          |     62,110.2 ns |    108793 B |
| Decompress            | BrotliNETCompressor-11-22        | Large (20 KB)  | 2,679 bytes  | 12.96 %          |     65,322.0 ns |    108793 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | DeflateCompressor-NoCompression  | Large (20 KB)  | 20,678 bytes | 100.02 %         |      9,951.8 ns |     78392 B |
| Compress              | DeflateCompressor-Fastest        | Large (20 KB)  | 3,573 bytes  | 17.28 %          |     62,703.9 ns |      3872 B |
| Compress              | DeflateCompressor-Optimal        | Large (20 KB)  | 3,276 bytes  | 15.85 %          |    169,970.4 ns |      3576 B |
| Compress              | DeflateCompressor-SmallestSize   | Large (20 KB)  | 3,217 bytes  | 15.56 %          |    229,006.6 ns |      3521 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | DeflateCompressor-NoCompression  | Large (20 KB)  | 20,678 bytes | 100.02 %         |     13,407.3 ns |     99504 B |
| CompressAndDecompress | DeflateCompressor-Fastest        | Large (20 KB)  | 3,573 bytes  | 17.28 %          |     91,159.8 ns |     24984 B |
| CompressAndDecompress | DeflateCompressor-Optimal        | Large (20 KB)  | 3,276 bytes  | 15.85 %          |    212,076.5 ns |     24688 B |
| CompressAndDecompress | DeflateCompressor-SmallestSize   | Large (20 KB)  | 3,217 bytes  | 15.56 %          |    281,503.0 ns |     24633 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | DeflateCompressor-NoCompression  | Large (20 KB)  | 20,678 bytes | 100.02 %         |      4,130.4 ns |     21112 B |
| Decompress            | DeflateCompressor-Fastest        | Large (20 KB)  | 3,573 bytes  | 17.28 %          |     20,048.2 ns |     21112 B |
| Decompress            | DeflateCompressor-Optimal        | Large (20 KB)  | 3,276 bytes  | 15.85 %          |     19,341.6 ns |     21112 B |
| Decompress            | DeflateCompressor-SmallestSize   | Large (20 KB)  | 3,217 bytes  | 15.56 %          |     19,342.7 ns |     21112 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | GZipCompressor-NoCompression     | Large (20 KB)  | 20,696 bytes | 100.11 %         |      9,405.8 ns |     78800 B |
| Compress              | GZipCompressor-Fastest           | Large (20 KB)  | 3,591 bytes  | 17.37 %          |     64,524.9 ns |      4200 B |
| Compress              | GZipCompressor-Optimal           | Large (20 KB)  | 3,294 bytes  | 15.93 %          |    172,266.6 ns |      3904 B |
| Compress              | GZipCompressor-SmallestSize      | Large (20 KB)  | 3,235 bytes  | 15.65 %          |    232,566.0 ns |      3848 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | GZipCompressor-NoCompression     | Large (20 KB)  | 20,696 bytes | 100.11 %         |     15,582.2 ns |     99944 B |
| CompressAndDecompress | GZipCompressor-Fastest           | Large (20 KB)  | 3,591 bytes  | 17.37 %          |     86,512.7 ns |     25344 B |
| CompressAndDecompress | GZipCompressor-Optimal           | Large (20 KB)  | 3,294 bytes  | 15.93 %          |    212,255.4 ns |     25048 B |
| CompressAndDecompress | GZipCompressor-SmallestSize      | Large (20 KB)  | 3,235 bytes  | 15.65 %          |    278,570.3 ns |     24993 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | GZipCompressor-NoCompression     | Large (20 KB)  | 20,696 bytes | 100.11 %         |      5,002.7 ns |     21144 B |
| Decompress            | GZipCompressor-Fastest           | Large (20 KB)  | 3,591 bytes  | 17.37 %          |     21,414.0 ns |     21144 B |
| Decompress            | GZipCompressor-Optimal           | Large (20 KB)  | 3,294 bytes  | 15.93 %          |     20,656.4 ns |     21144 B |
| Decompress            | GZipCompressor-SmallestSize      | Large (20 KB)  | 3,235 bytes  | 15.65 %          |     20,277.0 ns |     21144 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZ4Compressor-Optimized-L00_FAST | Large (20 KB)  | 4,356 bytes  | 21.07 %          |     12,690.9 ns |      4384 B |
| Compress              | LZ4Compressor-Optimized-L03_HC   | Large (20 KB)  | 3,919 bytes  | 18.96 %          |     64,616.1 ns |      3944 B |
| Compress              | LZ4Compressor-Optimized-L06_HC   | Large (20 KB)  | 3,896 bytes  | 18.85 %          |     83,975.5 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L04_HC   | Large (20 KB)  | 3,897 bytes  | 18.85 %          |     75,718.0 ns |      3928 B |
| Compress              | LZ4Compressor-Optimized-L05_HC   | Large (20 KB)  | 3,895 bytes  | 18.84 %          |     83,008.1 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L07_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |     95,390.6 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L08_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |     98,472.9 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L09_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |     95,089.2 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L10_OPT  | Large (20 KB)  | 3,892 bytes  | 18.83 %          |    205,716.6 ns |      3920 B |
| Compress              | LZ4Compressor-Optimized-L11_OPT  | Large (20 KB)  | 3,888 bytes  | 18.81 %          |    243,355.6 ns |      3913 B |
| Compress              | LZ4Compressor-Optimized-L12_MAX  | Large (20 KB)  | 3,882 bytes  | 18.78 %          |    470,492.7 ns |      3913 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZ4Compressor-Optimized-L00_FAST | Large (20 KB)  | 4,356 bytes  | 21.07 %          |     16,187.7 ns |     25088 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L03_HC   | Large (20 KB)  | 3,919 bytes  | 18.96 %          |     70,414.2 ns |     24648 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L06_HC   | Large (20 KB)  | 3,896 bytes  | 18.85 %          |     97,513.3 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L04_HC   | Large (20 KB)  | 3,897 bytes  | 18.85 %          |     78,887.1 ns |     24632 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L05_HC   | Large (20 KB)  | 3,895 bytes  | 18.84 %          |     88,469.0 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L09_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |     99,631.3 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L08_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |    100,389.7 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L07_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |     99,601.0 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L10_OPT  | Large (20 KB)  | 3,892 bytes  | 18.83 %          |    215,421.2 ns |     24624 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L11_OPT  | Large (20 KB)  | 3,888 bytes  | 18.81 %          |    252,212.4 ns |     24617 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L12_MAX  | Large (20 KB)  | 3,882 bytes  | 18.78 %          |    495,630.5 ns |     24617 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZ4Compressor-Optimized-L00_FAST | Large (20 KB)  | 4,356 bytes  | 21.07 %          |      4,262.4 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L03_HC   | Large (20 KB)  | 3,919 bytes  | 18.96 %          |      3,819.6 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L06_HC   | Large (20 KB)  | 3,896 bytes  | 18.85 %          |      3,883.0 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L04_HC   | Large (20 KB)  | 3,897 bytes  | 18.85 %          |      3,894.5 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L05_HC   | Large (20 KB)  | 3,895 bytes  | 18.84 %          |      3,867.3 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L09_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |      3,884.9 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L08_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |      3,961.2 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L07_HC   | Large (20 KB)  | 3,892 bytes  | 18.83 %          |      4,040.2 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L10_OPT  | Large (20 KB)  | 3,892 bytes  | 18.83 %          |      3,990.6 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L11_OPT  | Large (20 KB)  | 3,888 bytes  | 18.81 %          |      3,577.1 ns |     20704 B |
| Decompress            | LZ4Compressor-Optimized-L12_MAX  | Large (20 KB)  | 3,882 bytes  | 18.78 %          |      3,969.0 ns |     20704 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes  | 13.89 %          | 19,599,262.5 ns |  97126804 B |
| Compress              | LZMACompressor-VeryFast-Large    | Large (20 KB)  | 2,765 bytes  | 13.37 %          | 21,258,981.2 ns |  97126700 B |
| Compress              | LZMACompressor-Fast-Large        | Large (20 KB)  | 2,699 bytes  | 13.06 %          | 22,333,428.1 ns |  97126652 B |
| Compress              | LZMACompressor-Medium-Large      | Large (20 KB)  | 2,637 bytes  | 12.76 %          | 25,363,764.6 ns |  97126612 B |
| Compress              | LZMACompressor-Slow-Large        | Large (20 KB)  | 2,618 bytes  | 12.66 %          | 33,190,217.9 ns |  97126591 B |
| Compress              | LZMACompressor-VerySlow-Large    | Large (20 KB)  | 2,612 bytes  | 12.63 %          | 42,916,830.6 ns |  97126671 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes  | 13.89 %          | 21,517,053.1 ns | 105569316 B |
| CompressAndDecompress | LZMACompressor-VeryFast-Large    | Large (20 KB)  | 2,765 bytes  | 13.37 %          | 22,603,454.7 ns | 105569212 B |
| CompressAndDecompress | LZMACompressor-Fast-Large        | Large (20 KB)  | 2,699 bytes  | 13.06 %          | 24,502,238.5 ns | 105569164 B |
| CompressAndDecompress | LZMACompressor-Medium-Large      | Large (20 KB)  | 2,637 bytes  | 12.76 %          | 27,291,127.6 ns | 105569124 B |
| CompressAndDecompress | LZMACompressor-Slow-Large        | Large (20 KB)  | 2,618 bytes  | 12.66 %          | 33,829,753.3 ns | 105569115 B |
| CompressAndDecompress | LZMACompressor-VerySlow-Large    | Large (20 KB)  | 2,612 bytes  | 12.63 %          | 43,141,616.7 ns | 105569183 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes  | 13.89 %          |  1,533,899.0 ns |   8444792 B |
| Decompress            | LZMACompressor-VeryFast-Large    | Large (20 KB)  | 2,765 bytes  | 13.37 %          |  1,571,463.7 ns |   8444844 B |
| Decompress            | LZMACompressor-Fast-Large        | Large (20 KB)  | 2,699 bytes  | 13.06 %          |  1,681,256.8 ns |   8444660 B |
| Decompress            | LZMACompressor-Medium-Large      | Large (20 KB)  | 2,637 bytes  | 12.76 %          |  1,632,846.5 ns |   8444931 B |
| Decompress            | LZMACompressor-Slow-Large        | Large (20 KB)  | 2,618 bytes  | 12.66 %          |  1,572,808.2 ns |   8444756 B |
| Decompress            | LZMACompressor-VerySlow-Large    | Large (20 KB)  | 2,612 bytes  | 12.63 %          |  1,596,144.5 ns |   8444841 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZLibCompressor-NoCompression     | Large (20 KB)  | 20,684 bytes | 100.05 %         |     15,907.5 ns |     78736 B |
| Compress              | ZLibCompressor-Fastest           | Large (20 KB)  | 3,579 bytes  | 17.31 %          |     67,083.6 ns |      4192 B |
| Compress              | ZLibCompressor-Optimal           | Large (20 KB)  | 3,282 bytes  | 15.88 %          |    174,011.5 ns |      3896 B |
| Compress              | ZLibCompressor-SmallestSize      | Large (20 KB)  | 3,223 bytes  | 15.59 %          |    251,568.2 ns |      3833 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZLibCompressor-NoCompression     | Large (20 KB)  | 20,684 bytes | 100.05 %         |     25,768.0 ns |     99880 B |
| CompressAndDecompress | ZLibCompressor-Fastest           | Large (20 KB)  | 3,579 bytes  | 17.31 %          |     96,453.3 ns |     25336 B |
| CompressAndDecompress | ZLibCompressor-Optimal           | Large (20 KB)  | 3,282 bytes  | 15.88 %          |    233,095.4 ns |     25040 B |
| CompressAndDecompress | ZLibCompressor-SmallestSize      | Large (20 KB)  | 3,223 bytes  | 15.59 %          |    285,156.9 ns |     24977 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZLibCompressor-NoCompression     | Large (20 KB)  | 20,684 bytes | 100.05 %         |     10,290.3 ns |     21144 B |
| Decompress            | ZLibCompressor-Fastest           | Large (20 KB)  | 3,579 bytes  | 17.31 %          |     25,087.9 ns |     21144 B |
| Decompress            | ZLibCompressor-Optimal           | Large (20 KB)  | 3,282 bytes  | 15.88 %          |     25,102.1 ns |     21144 B |
| Decompress            | ZLibCompressor-SmallestSize      | Large (20 KB)  | 3,223 bytes  | 15.59 %          |     25,239.5 ns |     21144 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdCompressor--131072           | Large (20 KB)  | 20,683 bytes | 100.05 %         |      5,653.2 ns |     20792 B |
| Compress              | ZstdCompressor--1000             | Large (20 KB)  | 20,683 bytes | 100.05 %         |      6,660.0 ns |     20792 B |
| Compress              | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes  | 37.86 %          |     13,333.7 ns |      7248 B |
| Compress              | ZstdCompressor-0                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     38,978.7 ns |      3328 B |
| Compress              | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     26,965.0 ns |      3384 B |
| Compress              | ZstdCompressor-2                 | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     31,262.8 ns |      3376 B |
| Compress              | ZstdCompressor-3                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     38,297.8 ns |      3328 B |
| Compress              | ZstdCompressor-4                 | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     41,234.8 ns |      3336 B |
| Compress              | ZstdCompressor-5                 | Large (20 KB)  | 3,126 bytes  | 15.12 %          |     60,139.3 ns |      3232 B |
| Compress              | ZstdCompressor-6                 | Large (20 KB)  | 3,091 bytes  | 14.95 %          |     76,801.6 ns |      3192 B |
| Compress              | ZstdCompressor-7                 | Large (20 KB)  | 3,058 bytes  | 14.79 %          |     86,946.6 ns |      3160 B |
| Compress              | ZstdCompressor-8                 | Large (20 KB)  | 3,054 bytes  | 14.77 %          |     99,266.5 ns |      3152 B |
| Compress              | ZstdCompressor-9                 | Large (20 KB)  | 3,051 bytes  | 14.76 %          |    112,639.7 ns |      3152 B |
| Compress              | ZstdCompressor-10                | Large (20 KB)  | 3,050 bytes  | 14.75 %          |    121,762.2 ns |      3152 B |
| Compress              | ZstdCompressor-11                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |    313,147.9 ns |      3145 B |
| Compress              | ZstdCompressor-12                | Large (20 KB)  | 3,043 bytes  | 14.72 %          |    330,772.3 ns |      3145 B |
| Compress              | ZstdCompressor-13                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |  1,012,154.9 ns |      3147 B |
| Compress              | ZstdCompressor-14                | Large (20 KB)  | 2,929 bytes  | 14.17 %          |  1,226,989.3 ns |      3043 B |
| Compress              | ZstdCompressor-15                | Large (20 KB)  | 2,901 bytes  | 14.03 %          |  1,553,594.9 ns |      3027 B |
| Compress              | ZstdCompressor-16                | Large (20 KB)  | 2,900 bytes  | 14.03 %          |  2,454,792.6 ns |      3005 B |
| Compress              | ZstdCompressor-17                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  4,873,787.5 ns |      3011 B |
| Compress              | ZstdCompressor-18                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  7,735,685.4 ns |      3021 B |
| Compress              | ZstdCompressor-19                | Large (20 KB)  | 2,886 bytes  | 13.96 %          |  9,794,264.6 ns |      3005 B |
| Compress              | ZstdCompressor-20                | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 15,023,670.8 ns |      3005 B |
| Compress              | ZstdCompressor-22                | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 15,055,054.7 ns |      3005 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--131072           | Large (20 KB)  | 20,683 bytes | 100.05 %         |      9,752.2 ns |     41568 B |
| CompressAndDecompress | ZstdCompressor--1000             | Large (20 KB)  | 20,683 bytes | 100.05 %         |     10,744.4 ns |     41568 B |
| CompressAndDecompress | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes  | 37.86 %          |     21,418.1 ns |     28024 B |
| CompressAndDecompress | ZstdCompressor-0                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     56,820.4 ns |     24104 B |
| CompressAndDecompress | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     43,482.9 ns |     24160 B |
| CompressAndDecompress | ZstdCompressor-2                 | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     46,821.0 ns |     24152 B |
| CompressAndDecompress | ZstdCompressor-3                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     56,916.6 ns |     24104 B |
| CompressAndDecompress | ZstdCompressor-4                 | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     59,725.6 ns |     24112 B |
| CompressAndDecompress | ZstdCompressor-5                 | Large (20 KB)  | 3,126 bytes  | 15.12 %          |     79,088.1 ns |     24008 B |
| CompressAndDecompress | ZstdCompressor-6                 | Large (20 KB)  | 3,091 bytes  | 14.95 %          |     96,273.8 ns |     23968 B |
| CompressAndDecompress | ZstdCompressor-7                 | Large (20 KB)  | 3,058 bytes  | 14.79 %          |    104,548.8 ns |     23936 B |
| CompressAndDecompress | ZstdCompressor-8                 | Large (20 KB)  | 3,054 bytes  | 14.77 %          |    118,033.4 ns |     23928 B |
| CompressAndDecompress | ZstdCompressor-9                 | Large (20 KB)  | 3,051 bytes  | 14.76 %          |    136,412.1 ns |     23928 B |
| CompressAndDecompress | ZstdCompressor-10                | Large (20 KB)  | 3,050 bytes  | 14.75 %          |    144,973.1 ns |     23928 B |
| CompressAndDecompress | ZstdCompressor-11                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |    339,789.4 ns |     23921 B |
| CompressAndDecompress | ZstdCompressor-12                | Large (20 KB)  | 3,043 bytes  | 14.72 %          |    362,257.4 ns |     23921 B |
| CompressAndDecompress | ZstdCompressor-13                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |  1,119,179.0 ns |     23923 B |
| CompressAndDecompress | ZstdCompressor-14                | Large (20 KB)  | 2,929 bytes  | 14.17 %          |  1,354,703.9 ns |     23819 B |
| CompressAndDecompress | ZstdCompressor-15                | Large (20 KB)  | 2,901 bytes  | 14.03 %          |  1,663,571.9 ns |     23803 B |
| CompressAndDecompress | ZstdCompressor-16                | Large (20 KB)  | 2,900 bytes  | 14.03 %          |  2,537,439.1 ns |     23781 B |
| CompressAndDecompress | ZstdCompressor-17                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  5,153,001.3 ns |     23787 B |
| CompressAndDecompress | ZstdCompressor-18                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  7,983,652.6 ns |     23797 B |
| CompressAndDecompress | ZstdCompressor-19                | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 10,081,881.5 ns |     23781 B |
| CompressAndDecompress | ZstdCompressor-20                | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 15,799,469.8 ns |     23802 B |
| CompressAndDecompress | ZstdCompressor-22                | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 15,477,678.1 ns |     23802 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdCompressor--131072           | Large (20 KB)  | 20,683 bytes | 100.05 %         |      3,267.1 ns |     20776 B |
| Decompress            | ZstdCompressor--1000             | Large (20 KB)  | 20,683 bytes | 100.05 %         |      3,297.7 ns |     20776 B |
| Decompress            | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes  | 37.86 %          |      7,080.6 ns |     20776 B |
| Decompress            | ZstdCompressor-0                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     13,589.2 ns |     20776 B |
| Decompress            | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     13,191.4 ns |     20776 B |
| Decompress            | ZstdCompressor-2                 | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     13,566.8 ns |     20776 B |
| Decompress            | ZstdCompressor-4                 | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     14,034.0 ns |     20776 B |
| Decompress            | ZstdCompressor-3                 | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     13,547.4 ns |     20776 B |
| Decompress            | ZstdCompressor-5                 | Large (20 KB)  | 3,126 bytes  | 15.12 %          |     13,927.3 ns |     20776 B |
| Decompress            | ZstdCompressor-6                 | Large (20 KB)  | 3,091 bytes  | 14.95 %          |     13,675.8 ns |     20776 B |
| Decompress            | ZstdCompressor-7                 | Large (20 KB)  | 3,058 bytes  | 14.79 %          |     13,570.5 ns |     20776 B |
| Decompress            | ZstdCompressor-8                 | Large (20 KB)  | 3,054 bytes  | 14.77 %          |     13,387.5 ns |     20776 B |
| Decompress            | ZstdCompressor-9                 | Large (20 KB)  | 3,051 bytes  | 14.76 %          |     13,691.1 ns |     20776 B |
| Decompress            | ZstdCompressor-10                | Large (20 KB)  | 3,050 bytes  | 14.75 %          |     13,387.9 ns |     20776 B |
| Decompress            | ZstdCompressor-13                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |     13,261.1 ns |     20776 B |
| Decompress            | ZstdCompressor-12                | Large (20 KB)  | 3,043 bytes  | 14.72 %          |     13,657.1 ns |     20776 B |
| Decompress            | ZstdCompressor-11                | Large (20 KB)  | 3,044 bytes  | 14.72 %          |     13,660.0 ns |     20776 B |
| Decompress            | ZstdCompressor-14                | Large (20 KB)  | 2,929 bytes  | 14.17 %          |     13,502.3 ns |     20776 B |
| Decompress            | ZstdCompressor-16                | Large (20 KB)  | 2,900 bytes  | 14.03 %          |     13,917.9 ns |     20776 B |
| Decompress            | ZstdCompressor-15                | Large (20 KB)  | 2,901 bytes  | 14.03 %          |     13,658.0 ns |     20776 B |
| Decompress            | ZstdCompressor-18                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |     14,144.1 ns |     20776 B |
| Decompress            | ZstdCompressor-17                | Large (20 KB)  | 2,896 bytes  | 14.01 %          |     14,107.8 ns |     20776 B |
| Decompress            | ZstdCompressor-22                | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     14,069.1 ns |     20776 B |
| Decompress            | ZstdCompressor-20                | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     14,258.7 ns |     20776 B |
| Decompress            | ZstdCompressor-19                | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     14,032.1 ns |     20776 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdSharpCompressor--131072      | Large (20 KB)  | 20,683 bytes | 100.05 %         |      4,736.8 ns |     41576 B |
| Compress              | ZstdSharpCompressor--1000        | Large (20 KB)  | 20,683 bytes | 100.05 %         |      5,985.6 ns |     41576 B |
| Compress              | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes  | 37.86 %          |     10,502.8 ns |     28720 B |
| Compress              | ZstdSharpCompressor-0            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     42,283.2 ns |     24120 B |
| Compress              | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     30,976.4 ns |     24168 B |
| Compress              | ZstdSharpCompressor-2            | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     33,276.7 ns |     24160 B |
| Compress              | ZstdSharpCompressor-3            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     42,589.5 ns |     24120 B |
| Compress              | ZstdSharpCompressor-4            | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     42,268.2 ns |     24120 B |
| Compress              | ZstdSharpCompressor-5            | Large (20 KB)  | 3,126 bytes  | 15.12 %          |    118,741.5 ns |     24016 B |
| Compress              | ZstdSharpCompressor-6            | Large (20 KB)  | 3,091 bytes  | 14.95 %          |    150,807.1 ns |     23984 B |
| Compress              | ZstdSharpCompressor-7            | Large (20 KB)  | 3,058 bytes  | 14.79 %          |    171,979.9 ns |     23952 B |
| Compress              | ZstdSharpCompressor-8            | Large (20 KB)  | 3,054 bytes  | 14.77 %          |    227,196.5 ns |     23944 B |
| Compress              | ZstdSharpCompressor-9            | Large (20 KB)  | 3,051 bytes  | 14.76 %          |    240,737.1 ns |     23944 B |
| Compress              | ZstdSharpCompressor-10           | Large (20 KB)  | 3,050 bytes  | 14.75 %          |    220,830.3 ns |     23944 B |
| Compress              | ZstdSharpCompressor-11           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |    380,456.6 ns |     23937 B |
| Compress              | ZstdSharpCompressor-12           | Large (20 KB)  | 3,043 bytes  | 14.72 %          |    448,504.6 ns |     23937 B |
| Compress              | ZstdSharpCompressor-13           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |  1,111,971.3 ns |     23939 B |
| Compress              | ZstdSharpCompressor-14           | Large (20 KB)  | 2,929 bytes  | 14.17 %          |  1,366,297.9 ns |     23827 B |
| Compress              | ZstdSharpCompressor-15           | Large (20 KB)  | 2,901 bytes  | 14.03 %          |  1,709,165.5 ns |     23795 B |
| Compress              | ZstdSharpCompressor-16           | Large (20 KB)  | 2,900 bytes  | 14.03 %          |  2,800,262.6 ns |     23797 B |
| Compress              | ZstdSharpCompressor-17           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  5,047,314.3 ns |     23795 B |
| Compress              | ZstdSharpCompressor-18           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  7,292,984.2 ns |     23795 B |
| Compress              | ZstdSharpCompressor-19           | Large (20 KB)  | 2,886 bytes  | 13.96 %          |  9,900,190.9 ns |     23797 B |
| Compress              | ZstdSharpCompressor-20           | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 14,754,724.5 ns |     23797 B |
| Compress              | ZstdSharpCompressor-22           | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 14,129,819.8 ns |     23797 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--131072      | Large (20 KB)  | 20,683 bytes | 100.05 %         |      6,767.2 ns |     62304 B |
| CompressAndDecompress | ZstdSharpCompressor--1000        | Large (20 KB)  | 20,683 bytes | 100.05 %         |      8,054.4 ns |     62304 B |
| CompressAndDecompress | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes  | 37.86 %          |     17,424.2 ns |     49448 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     45,769.3 ns |     44896 B |
| CompressAndDecompress | ZstdSharpCompressor-2            | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     47,915.5 ns |     44888 B |
| CompressAndDecompress | ZstdSharpCompressor-4            | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     58,719.5 ns |     44848 B |
| CompressAndDecompress | ZstdSharpCompressor-3            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     57,466.4 ns |     44848 B |
| CompressAndDecompress | ZstdSharpCompressor-0            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     59,202.6 ns |     44848 B |
| CompressAndDecompress | ZstdSharpCompressor-5            | Large (20 KB)  | 3,126 bytes  | 15.12 %          |    137,890.5 ns |     44744 B |
| CompressAndDecompress | ZstdSharpCompressor-6            | Large (20 KB)  | 3,091 bytes  | 14.95 %          |    165,654.6 ns |     44712 B |
| CompressAndDecompress | ZstdSharpCompressor-7            | Large (20 KB)  | 3,058 bytes  | 14.79 %          |    192,444.4 ns |     44680 B |
| CompressAndDecompress | ZstdSharpCompressor-8            | Large (20 KB)  | 3,054 bytes  | 14.77 %          |    206,980.4 ns |     44672 B |
| CompressAndDecompress | ZstdSharpCompressor-9            | Large (20 KB)  | 3,051 bytes  | 14.76 %          |    222,393.2 ns |     44672 B |
| CompressAndDecompress | ZstdSharpCompressor-10           | Large (20 KB)  | 3,050 bytes  | 14.75 %          |    242,540.4 ns |     44673 B |
| CompressAndDecompress | ZstdSharpCompressor-13           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |  1,190,981.2 ns |     44667 B |
| CompressAndDecompress | ZstdSharpCompressor-12           | Large (20 KB)  | 3,043 bytes  | 14.72 %          |    413,291.8 ns |     44665 B |
| CompressAndDecompress | ZstdSharpCompressor-11           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |    402,552.3 ns |     44665 B |
| CompressAndDecompress | ZstdSharpCompressor-14           | Large (20 KB)  | 2,929 bytes  | 14.17 %          |  1,327,684.6 ns |     44555 B |
| CompressAndDecompress | ZstdSharpCompressor-16           | Large (20 KB)  | 2,900 bytes  | 14.03 %          |  2,808,720.1 ns |     44525 B |
| CompressAndDecompress | ZstdSharpCompressor-15           | Large (20 KB)  | 2,901 bytes  | 14.03 %          |  1,871,211.7 ns |     44525 B |
| CompressAndDecompress | ZstdSharpCompressor-18           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  7,969,469.8 ns |     44533 B |
| CompressAndDecompress | ZstdSharpCompressor-17           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |  5,142,330.2 ns |     44523 B |
| CompressAndDecompress | ZstdSharpCompressor-22           | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 14,216,586.5 ns |     44525 B |
| CompressAndDecompress | ZstdSharpCompressor-20           | Large (20 KB)  | 2,886 bytes  | 13.96 %          | 14,575,799.0 ns |     44525 B |
| CompressAndDecompress | ZstdSharpCompressor-19           | Large (20 KB)  | 2,886 bytes  | 13.96 %          |  9,827,704.4 ns |     44525 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdSharpCompressor--131072      | Large (20 KB)  | 20,683 bytes | 100.05 %         |      1,660.9 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--1000        | Large (20 KB)  | 20,683 bytes | 100.05 %         |      1,661.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes  | 37.86 %          |      6,510.9 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes  | 15.87 %          |     13,723.9 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-2            | Large (20 KB)  | 3,271 bytes  | 15.82 %          |     14,704.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-4            | Large (20 KB)  | 3,230 bytes  | 15.62 %          |     15,113.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-3            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     14,724.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-0            | Large (20 KB)  | 3,228 bytes  | 15.61 %          |     14,962.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-5            | Large (20 KB)  | 3,126 bytes  | 15.12 %          |     14,980.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-6            | Large (20 KB)  | 3,091 bytes  | 14.95 %          |     14,915.2 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-7            | Large (20 KB)  | 3,058 bytes  | 14.79 %          |     14,616.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-8            | Large (20 KB)  | 3,054 bytes  | 14.77 %          |     14,773.6 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-9            | Large (20 KB)  | 3,051 bytes  | 14.76 %          |     14,532.2 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-10           | Large (20 KB)  | 3,050 bytes  | 14.75 %          |     14,895.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-13           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |     14,722.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-12           | Large (20 KB)  | 3,043 bytes  | 14.72 %          |     14,758.3 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-11           | Large (20 KB)  | 3,044 bytes  | 14.72 %          |     14,841.7 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-14           | Large (20 KB)  | 2,929 bytes  | 14.17 %          |     15,444.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-16           | Large (20 KB)  | 2,900 bytes  | 14.03 %          |     15,589.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-15           | Large (20 KB)  | 2,901 bytes  | 14.03 %          |     15,317.7 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-18           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |     15,655.9 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-17           | Large (20 KB)  | 2,896 bytes  | 14.01 %          |     15,817.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-22           | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     15,443.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-20           | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     15,506.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-19           | Large (20 KB)  | 2,886 bytes  | 13.96 %          |     15,571.0 ns |     20728 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | BrotliCompressor-NoCompression   | Medium (10 KB) | 876 bytes    | 8.80 %           |     16,803.1 ns |      3776 B |
| Compress              | BrotliCompressor-Fastest         | Medium (10 KB) | 794 bytes    | 7.98 %           |     12,020.6 ns |      3456 B |
| Compress              | BrotliCompressor-Optimal         | Medium (10 KB) | 742 bytes    | 7.46 %           |     70,401.6 ns |       960 B |
| Compress              | BrotliCompressor-SmallestSize    | Medium (10 KB) | 652 bytes    | 6.55 %           |  2,425,590.0 ns |       877 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliCompressor-NoCompression   | Medium (10 KB) | 876 bytes    | 8.80 %           |     35,001.7 ns |     14009 B |
| CompressAndDecompress | BrotliCompressor-Fastest         | Medium (10 KB) | 794 bytes    | 7.98 %           |     28,926.1 ns |     13689 B |
| CompressAndDecompress | BrotliCompressor-Optimal         | Medium (10 KB) | 742 bytes    | 7.46 %           |     93,289.1 ns |     11193 B |
| CompressAndDecompress | BrotliCompressor-SmallestSize    | Medium (10 KB) | 652 bytes    | 6.55 %           |  2,438,217.4 ns |     11110 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliCompressor-NoCompression   | Medium (10 KB) | 876 bytes    | 8.80 %           |     17,150.7 ns |     10232 B |
| Decompress            | BrotliCompressor-Fastest         | Medium (10 KB) | 794 bytes    | 7.98 %           |     16,237.6 ns |     10232 B |
| Decompress            | BrotliCompressor-Optimal         | Medium (10 KB) | 742 bytes    | 7.46 %           |     16,485.4 ns |     10232 B |
| Decompress            | BrotliCompressor-SmallestSize    | Medium (10 KB) | 652 bytes    | 6.55 %           |     18,843.0 ns |     10232 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | BrotliNETCompressor-0-22         | Medium (10 KB) | 876 bytes    | 8.80 %           |     41,315.7 ns |     70608 B |
| Compress              | BrotliNETCompressor-1-22         | Medium (10 KB) | 794 bytes    | 7.98 %           |     30,935.9 ns |     70286 B |
| Compress              | BrotliNETCompressor-2-22         | Medium (10 KB) | 779 bytes    | 7.83 %           |     56,416.1 ns |     67838 B |
| Compress              | BrotliNETCompressor-3-22         | Medium (10 KB) | 754 bytes    | 7.58 %           |     69,357.9 ns |     67815 B |
| Compress              | BrotliNETCompressor-4-22         | Medium (10 KB) | 742 bytes    | 7.46 %           |     95,456.9 ns |     67797 B |
| Compress              | BrotliNETCompressor-5-22         | Medium (10 KB) | 716 bytes    | 7.20 %           |    521,247.1 ns |     67793 B |
| Compress              | BrotliNETCompressor-6-22         | Medium (10 KB) | 714 bytes    | 7.18 %           |    739,400.6 ns |     67794 B |
| Compress              | BrotliNETCompressor-9-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,322,656.8 ns |     67802 B |
| Compress              | BrotliNETCompressor-8-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,231,038.9 ns |     67805 B |
| Compress              | BrotliNETCompressor-7-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,095,300.6 ns |     67812 B |
| Compress              | BrotliNETCompressor-10-22        | Medium (10 KB) | 683 bytes    | 6.86 %           |  1,969,633.3 ns |     67767 B |
| Compress              | BrotliNETCompressor-11-22        | Medium (10 KB) | 652 bytes    | 6.55 %           |  2,649,882.5 ns |     67728 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliNETCompressor-0-22         | Medium (10 KB) | 876 bytes    | 8.80 %           |     87,536.8 ns |    157945 B |
| CompressAndDecompress | BrotliNETCompressor-1-22         | Medium (10 KB) | 794 bytes    | 7.98 %           |     76,876.9 ns |    157625 B |
| CompressAndDecompress | BrotliNETCompressor-2-22         | Medium (10 KB) | 779 bytes    | 7.83 %           |    109,219.9 ns |    155169 B |
| CompressAndDecompress | BrotliNETCompressor-3-22         | Medium (10 KB) | 754 bytes    | 7.58 %           |    120,736.9 ns |    155145 B |
| CompressAndDecompress | BrotliNETCompressor-4-22         | Medium (10 KB) | 742 bytes    | 7.46 %           |    153,599.0 ns |    155130 B |
| CompressAndDecompress | BrotliNETCompressor-5-22         | Medium (10 KB) | 716 bytes    | 7.20 %           |    575,728.8 ns |    155108 B |
| CompressAndDecompress | BrotliNETCompressor-6-22         | Medium (10 KB) | 714 bytes    | 7.18 %           |    807,490.2 ns |    155107 B |
| CompressAndDecompress | BrotliNETCompressor-9-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,401,650.7 ns |    155100 B |
| CompressAndDecompress | BrotliNETCompressor-8-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,299,034.8 ns |    155101 B |
| CompressAndDecompress | BrotliNETCompressor-7-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |  1,170,302.1 ns |    155100 B |
| CompressAndDecompress | BrotliNETCompressor-10-22        | Medium (10 KB) | 683 bytes    | 6.86 %           |  1,999,569.4 ns |    155085 B |
| CompressAndDecompress | BrotliNETCompressor-11-22        | Medium (10 KB) | 652 bytes    | 6.55 %           |  2,588,060.0 ns |    155051 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliNETCompressor-0-22         | Medium (10 KB) | 876 bytes    | 8.80 %           |     43,098.7 ns |     87337 B |
| Decompress            | BrotliNETCompressor-1-22         | Medium (10 KB) | 794 bytes    | 7.98 %           |     42,467.3 ns |     87337 B |
| Decompress            | BrotliNETCompressor-2-22         | Medium (10 KB) | 779 bytes    | 7.83 %           |     49,415.1 ns |     87337 B |
| Decompress            | BrotliNETCompressor-3-22         | Medium (10 KB) | 754 bytes    | 7.58 %           |     42,822.5 ns |     87337 B |
| Decompress            | BrotliNETCompressor-4-22         | Medium (10 KB) | 742 bytes    | 7.46 %           |     42,992.9 ns |     87336 B |
| Decompress            | BrotliNETCompressor-5-22         | Medium (10 KB) | 716 bytes    | 7.20 %           |     42,643.4 ns |     87337 B |
| Decompress            | BrotliNETCompressor-6-22         | Medium (10 KB) | 714 bytes    | 7.18 %           |     42,732.2 ns |     87336 B |
| Decompress            | BrotliNETCompressor-9-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |     45,406.7 ns |     87336 B |
| Decompress            | BrotliNETCompressor-8-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |     42,671.9 ns |     87337 B |
| Decompress            | BrotliNETCompressor-7-22         | Medium (10 KB) | 709 bytes    | 7.12 %           |     43,162.7 ns |     87336 B |
| Decompress            | BrotliNETCompressor-10-22        | Medium (10 KB) | 683 bytes    | 6.86 %           |     45,681.8 ns |     87336 B |
| Decompress            | BrotliNETCompressor-11-22        | Medium (10 KB) | 652 bytes    | 6.55 %           |     45,585.9 ns |     87336 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | DeflateCompressor-NoCompression  | Medium (10 KB) | 9,956 bytes  | 100.05 %         |      5,156.3 ns |     34880 B |
| Compress              | DeflateCompressor-Fastest        | Medium (10 KB) | 875 bytes    | 8.79 %           |     21,005.2 ns |      1176 B |
| Compress              | DeflateCompressor-Optimal        | Medium (10 KB) | 810 bytes    | 8.14 %           |     35,381.8 ns |      1112 B |
| Compress              | DeflateCompressor-SmallestSize   | Medium (10 KB) | 792 bytes    | 7.96 %           |     54,785.1 ns |      1088 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | DeflateCompressor-NoCompression  | Medium (10 KB) | 9,956 bytes  | 100.05 %         |     10,900.3 ns |     45264 B |
| CompressAndDecompress | DeflateCompressor-Fastest        | Medium (10 KB) | 875 bytes    | 8.79 %           |     32,807.5 ns |     11560 B |
| CompressAndDecompress | DeflateCompressor-Optimal        | Medium (10 KB) | 810 bytes    | 8.14 %           |     44,390.0 ns |     11496 B |
| CompressAndDecompress | DeflateCompressor-SmallestSize   | Medium (10 KB) | 792 bytes    | 7.96 %           |     67,263.0 ns |     11472 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | DeflateCompressor-NoCompression  | Medium (10 KB) | 9,956 bytes  | 100.05 %         |      2,457.6 ns |     10384 B |
| Decompress            | DeflateCompressor-Fastest        | Medium (10 KB) | 875 bytes    | 8.79 %           |      7,696.7 ns |     10384 B |
| Decompress            | DeflateCompressor-Optimal        | Medium (10 KB) | 810 bytes    | 8.14 %           |      7,477.8 ns |     10384 B |
| Decompress            | DeflateCompressor-SmallestSize   | Medium (10 KB) | 792 bytes    | 7.96 %           |      7,740.1 ns |     10384 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | GZipCompressor-NoCompression     | Medium (10 KB) | 9,974 bytes  | 100.23 %         |      5,137.4 ns |     35248 B |
| Compress              | GZipCompressor-Fastest           | Medium (10 KB) | 893 bytes    | 8.97 %           |     22,014.1 ns |      1504 B |
| Compress              | GZipCompressor-Optimal           | Medium (10 KB) | 828 bytes    | 8.32 %           |     36,163.8 ns |      1440 B |
| Compress              | GZipCompressor-SmallestSize      | Medium (10 KB) | 810 bytes    | 8.14 %           |     56,238.2 ns |      1424 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | GZipCompressor-NoCompression     | Medium (10 KB) | 9,974 bytes  | 100.23 %         |      9,080.4 ns |     45664 B |
| CompressAndDecompress | GZipCompressor-Fastest           | Medium (10 KB) | 893 bytes    | 8.97 %           |     30,846.4 ns |     11920 B |
| CompressAndDecompress | GZipCompressor-Optimal           | Medium (10 KB) | 828 bytes    | 8.32 %           |     45,041.3 ns |     11856 B |
| CompressAndDecompress | GZipCompressor-SmallestSize      | Medium (10 KB) | 810 bytes    | 8.14 %           |     68,455.1 ns |     11840 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | GZipCompressor-NoCompression     | Medium (10 KB) | 9,974 bytes  | 100.23 %         |      2,948.9 ns |     10416 B |
| Decompress            | GZipCompressor-Fastest           | Medium (10 KB) | 893 bytes    | 8.97 %           |      8,385.4 ns |     10416 B |
| Decompress            | GZipCompressor-Optimal           | Medium (10 KB) | 828 bytes    | 8.32 %           |      8,098.1 ns |     10416 B |
| Decompress            | GZipCompressor-SmallestSize      | Medium (10 KB) | 810 bytes    | 8.14 %           |      8,240.4 ns |     10416 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZ4Compressor-Optimized-L00_FAST | Medium (10 KB) | 914 bytes    | 9.19 %           |      3,380.8 ns |       944 B |
| Compress              | LZ4Compressor-Optimized-L03_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     20,704.1 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L04_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     21,314.8 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L05_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     20,740.7 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L06_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     22,110.7 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L07_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     20,831.2 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L08_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     21,055.7 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L09_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     20,928.3 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L10_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |     28,633.9 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L11_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |     28,310.5 ns |       936 B |
| Compress              | LZ4Compressor-Optimized-L12_MAX  | Medium (10 KB) | 905 bytes    | 9.09 %           |     79,859.4 ns |       936 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZ4Compressor-Optimized-L00_FAST | Medium (10 KB) | 914 bytes    | 9.19 %           |      3,745.9 ns |     10920 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L12_MAX  | Medium (10 KB) | 905 bytes    | 9.09 %           |     82,393.6 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L11_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |     30,716.3 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L10_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |     30,110.2 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L09_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     21,218.7 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L08_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     22,254.9 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L07_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     22,401.1 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L06_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     23,134.7 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L05_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     22,219.0 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L04_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     23,139.8 ns |     10912 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L03_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |     22,333.8 ns |     10912 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZ4Compressor-Optimized-L00_FAST | Medium (10 KB) | 914 bytes    | 9.19 %           |      1,070.6 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L12_MAX  | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,072.7 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L11_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,068.8 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L10_OPT  | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,059.7 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L09_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,057.7 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L08_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,063.3 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L07_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,083.0 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L06_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |        943.2 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L05_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,049.6 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L04_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,052.1 ns |      9976 B |
| Decompress            | LZ4Compressor-Optimized-L03_HC   | Medium (10 KB) | 905 bytes    | 9.09 %           |      1,081.8 ns |      9976 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes    | 7.50 %           | 16,080,901.0 ns |  97118492 B |
| Compress              | LZMACompressor-VeryFast-Large    | Medium (10 KB) | 745 bytes    | 7.49 %           | 16,665,325.0 ns |  97118492 B |
| Compress              | LZMACompressor-VerySlow-Large    | Medium (10 KB) | 743 bytes    | 7.47 %           | 21,224,803.1 ns |  97118668 B |
| Compress              | LZMACompressor-Slow-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           | 19,223,542.2 ns |  97118572 B |
| Compress              | LZMACompressor-Medium-Large      | Medium (10 KB) | 743 bytes    | 7.47 %           | 17,749,468.2 ns |  97118524 B |
| Compress              | LZMACompressor-Fast-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           | 16,549,029.2 ns |  97118500 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes    | 7.50 %           | 18,814,845.8 ns | 105550276 B |
| CompressAndDecompress | LZMACompressor-VeryFast-Large    | Medium (10 KB) | 745 bytes    | 7.49 %           | 18,843,947.9 ns | 105550276 B |
| CompressAndDecompress | LZMACompressor-VerySlow-Large    | Medium (10 KB) | 743 bytes    | 7.47 %           | 22,446,106.8 ns | 105550452 B |
| CompressAndDecompress | LZMACompressor-Slow-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           | 20,972,139.6 ns | 105550356 B |
| CompressAndDecompress | LZMACompressor-Medium-Large      | Medium (10 KB) | 743 bytes    | 7.47 %           | 20,162,777.1 ns | 105550308 B |
| CompressAndDecompress | LZMACompressor-Fast-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           | 19,106,516.1 ns | 105550284 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes    | 7.50 %           |  1,280,218.4 ns |   8432719 B |
| Decompress            | LZMACompressor-VeryFast-Large    | Medium (10 KB) | 745 bytes    | 7.49 %           |  1,428,788.6 ns |   8432594 B |
| Decompress            | LZMACompressor-VerySlow-Large    | Medium (10 KB) | 743 bytes    | 7.47 %           |  1,251,142.2 ns |   8432594 B |
| Decompress            | LZMACompressor-Slow-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           |  1,288,767.8 ns |   8432580 B |
| Decompress            | LZMACompressor-Medium-Large      | Medium (10 KB) | 743 bytes    | 7.47 %           |  1,383,656.2 ns |   8432526 B |
| Decompress            | LZMACompressor-Fast-Large        | Medium (10 KB) | 743 bytes    | 7.47 %           |  1,370,540.2 ns |   8432552 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZLibCompressor-NoCompression     | Medium (10 KB) | 9,962 bytes  | 100.11 %         |      8,495.0 ns |     35216 B |
| Compress              | ZLibCompressor-Fastest           | Medium (10 KB) | 881 bytes    | 8.85 %           |     23,712.1 ns |      1496 B |
| Compress              | ZLibCompressor-Optimal           | Medium (10 KB) | 816 bytes    | 8.20 %           |     37,426.7 ns |      1424 B |
| Compress              | ZLibCompressor-SmallestSize      | Medium (10 KB) | 798 bytes    | 8.02 %           |     57,959.0 ns |      1408 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZLibCompressor-NoCompression     | Medium (10 KB) | 9,962 bytes  | 100.11 %         |     13,383.1 ns |     45632 B |
| CompressAndDecompress | ZLibCompressor-Fastest           | Medium (10 KB) | 881 bytes    | 8.85 %           |     35,342.6 ns |     11912 B |
| CompressAndDecompress | ZLibCompressor-Optimal           | Medium (10 KB) | 816 bytes    | 8.20 %           |     49,397.9 ns |     11840 B |
| CompressAndDecompress | ZLibCompressor-SmallestSize      | Medium (10 KB) | 798 bytes    | 8.02 %           |     70,810.8 ns |     11824 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZLibCompressor-NoCompression     | Medium (10 KB) | 9,962 bytes  | 100.11 %         |      5,303.9 ns |     10416 B |
| Decompress            | ZLibCompressor-Fastest           | Medium (10 KB) | 881 bytes    | 8.85 %           |     10,381.2 ns |     10416 B |
| Decompress            | ZLibCompressor-Optimal           | Medium (10 KB) | 816 bytes    | 8.20 %           |     10,061.4 ns |     10416 B |
| Decompress            | ZLibCompressor-SmallestSize      | Medium (10 KB) | 798 bytes    | 8.02 %           |     10,326.7 ns |     10416 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdCompressor--131072           | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      4,030.5 ns |     10072 B |
| Compress              | ZstdCompressor--1000             | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      4,663.9 ns |      9672 B |
| Compress              | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      4,703.2 ns |      1808 B |
| Compress              | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes    | 7.71 %           |     11,581.4 ns |       872 B |
| Compress              | ZstdCompressor-3                 | Medium (10 KB) | 765 bytes    | 7.69 %           |     12,949.6 ns |       872 B |
| Compress              | ZstdCompressor-0                 | Medium (10 KB) | 765 bytes    | 7.69 %           |     12,901.0 ns |       872 B |
| Compress              | ZstdCompressor-2                 | Medium (10 KB) | 763 bytes    | 7.67 %           |     11,502.3 ns |       872 B |
| Compress              | ZstdCompressor-5                 | Medium (10 KB) | 757 bytes    | 7.61 %           |     22,536.6 ns |       864 B |
| Compress              | ZstdCompressor-8                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     24,629.4 ns |       864 B |
| Compress              | ZstdCompressor-7                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     24,484.2 ns |       864 B |
| Compress              | ZstdCompressor-6                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     23,632.0 ns |       864 B |
| Compress              | ZstdCompressor-4                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     19,434.2 ns |       864 B |
| Compress              | ZstdCompressor-12                | Medium (10 KB) | 755 bytes    | 7.59 %           |     85,138.3 ns |       864 B |
| Compress              | ZstdCompressor-11                | Medium (10 KB) | 754 bytes    | 7.58 %           |     72,407.6 ns |       864 B |
| Compress              | ZstdCompressor-9                 | Medium (10 KB) | 753 bytes    | 7.57 %           |     42,890.2 ns |       864 B |
| Compress              | ZstdCompressor-10                | Medium (10 KB) | 753 bytes    | 7.57 %           |     42,544.4 ns |       864 B |
| Compress              | ZstdCompressor-15                | Medium (10 KB) | 750 bytes    | 7.54 %           |    265,045.6 ns |       865 B |
| Compress              | ZstdCompressor-14                | Medium (10 KB) | 750 bytes    | 7.54 %           |    123,928.9 ns |       864 B |
| Compress              | ZstdCompressor-13                | Medium (10 KB) | 750 bytes    | 7.54 %           |    111,278.1 ns |       864 B |
| Compress              | ZstdCompressor-16                | Medium (10 KB) | 749 bytes    | 7.53 %           |    209,008.9 ns |       864 B |
| Compress              | ZstdCompressor-17                | Medium (10 KB) | 749 bytes    | 7.53 %           |    226,321.4 ns |       864 B |
| Compress              | ZstdCompressor-18                | Medium (10 KB) | 749 bytes    | 7.53 %           |    522,161.5 ns |       865 B |
| Compress              | ZstdCompressor-19                | Medium (10 KB) | 749 bytes    | 7.53 %           |    517,394.9 ns |       865 B |
| Compress              | ZstdCompressor-20                | Medium (10 KB) | 749 bytes    | 7.53 %           |    506,721.5 ns |       865 B |
| Compress              | ZstdCompressor-22                | Medium (10 KB) | 749 bytes    | 7.53 %           |  1,051,077.7 ns |       867 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--131072           | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      7,102.4 ns |     20120 B |
| CompressAndDecompress | ZstdCompressor--1000             | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      8,242.2 ns |     19720 B |
| CompressAndDecompress | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      8,210.8 ns |     11856 B |
| CompressAndDecompress | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes    | 7.71 %           |     18,413.6 ns |     10920 B |
| CompressAndDecompress | ZstdCompressor-3                 | Medium (10 KB) | 765 bytes    | 7.69 %           |     20,618.8 ns |     10920 B |
| CompressAndDecompress | ZstdCompressor-0                 | Medium (10 KB) | 765 bytes    | 7.69 %           |     20,716.3 ns |     10920 B |
| CompressAndDecompress | ZstdCompressor-2                 | Medium (10 KB) | 763 bytes    | 7.67 %           |     18,304.7 ns |     10920 B |
| CompressAndDecompress | ZstdCompressor-5                 | Medium (10 KB) | 757 bytes    | 7.61 %           |     30,183.1 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-8                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     32,139.5 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-7                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     31,681.9 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-6                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     30,847.8 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-4                 | Medium (10 KB) | 755 bytes    | 7.59 %           |     27,766.0 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-12                | Medium (10 KB) | 755 bytes    | 7.59 %           |     96,304.5 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-11                | Medium (10 KB) | 754 bytes    | 7.58 %           |     80,177.7 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-9                 | Medium (10 KB) | 753 bytes    | 7.57 %           |     50,522.4 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-10                | Medium (10 KB) | 753 bytes    | 7.57 %           |     49,986.7 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-15                | Medium (10 KB) | 750 bytes    | 7.54 %           |    281,561.9 ns |     10913 B |
| CompressAndDecompress | ZstdCompressor-14                | Medium (10 KB) | 750 bytes    | 7.54 %           |    138,080.6 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-13                | Medium (10 KB) | 750 bytes    | 7.54 %           |    122,522.9 ns |     10912 B |
| CompressAndDecompress | ZstdCompressor-22                | Medium (10 KB) | 749 bytes    | 7.53 %           |  1,100,159.5 ns |     10915 B |
| CompressAndDecompress | ZstdCompressor-20                | Medium (10 KB) | 749 bytes    | 7.53 %           |    553,297.9 ns |     10913 B |
| CompressAndDecompress | ZstdCompressor-19                | Medium (10 KB) | 749 bytes    | 7.53 %           |    545,149.2 ns |     10913 B |
| CompressAndDecompress | ZstdCompressor-18                | Medium (10 KB) | 749 bytes    | 7.53 %           |    540,296.8 ns |     10913 B |
| CompressAndDecompress | ZstdCompressor-17                | Medium (10 KB) | 749 bytes    | 7.53 %           |    242,573.7 ns |     10913 B |
| CompressAndDecompress | ZstdCompressor-16                | Medium (10 KB) | 749 bytes    | 7.53 %           |    227,006.4 ns |     10913 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdCompressor--131072           | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      2,495.2 ns |     10048 B |
| Decompress            | ZstdCompressor--1000             | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      2,866.3 ns |     10048 B |
| Decompress            | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      2,868.7 ns |     10048 B |
| Decompress            | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes    | 7.71 %           |      5,408.7 ns |     10048 B |
| Decompress            | ZstdCompressor-3                 | Medium (10 KB) | 765 bytes    | 7.69 %           |      5,367.4 ns |     10048 B |
| Decompress            | ZstdCompressor-0                 | Medium (10 KB) | 765 bytes    | 7.69 %           |      5,398.7 ns |     10048 B |
| Decompress            | ZstdCompressor-2                 | Medium (10 KB) | 763 bytes    | 7.67 %           |      5,434.6 ns |     10048 B |
| Decompress            | ZstdCompressor-5                 | Medium (10 KB) | 757 bytes    | 7.61 %           |      5,446.6 ns |     10048 B |
| Decompress            | ZstdCompressor-8                 | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,333.6 ns |     10048 B |
| Decompress            | ZstdCompressor-7                 | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,377.2 ns |     10048 B |
| Decompress            | ZstdCompressor-6                 | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,323.6 ns |     10048 B |
| Decompress            | ZstdCompressor-4                 | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,422.1 ns |     10048 B |
| Decompress            | ZstdCompressor-12                | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,306.6 ns |     10048 B |
| Decompress            | ZstdCompressor-11                | Medium (10 KB) | 754 bytes    | 7.58 %           |      5,363.8 ns |     10048 B |
| Decompress            | ZstdCompressor-9                 | Medium (10 KB) | 753 bytes    | 7.57 %           |      5,399.1 ns |     10048 B |
| Decompress            | ZstdCompressor-10                | Medium (10 KB) | 753 bytes    | 7.57 %           |      5,384.4 ns |     10048 B |
| Decompress            | ZstdCompressor-15                | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,373.9 ns |     10048 B |
| Decompress            | ZstdCompressor-14                | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,337.8 ns |     10048 B |
| Decompress            | ZstdCompressor-13                | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,397.4 ns |     10048 B |
| Decompress            | ZstdCompressor-22                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,378.9 ns |     10048 B |
| Decompress            | ZstdCompressor-20                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,446.9 ns |     10048 B |
| Decompress            | ZstdCompressor-19                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,428.9 ns |     10048 B |
| Decompress            | ZstdCompressor-18                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,433.7 ns |     10048 B |
| Decompress            | ZstdCompressor-17                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,388.9 ns |     10048 B |
| Decompress            | ZstdCompressor-16                | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,540.9 ns |     10048 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdSharpCompressor--131072      | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      3,116.2 ns |     20096 B |
| Compress              | ZstdSharpCompressor--1000        | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      4,462.0 ns |     20096 B |
| Compress              | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      4,147.6 ns |     11824 B |
| Compress              | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes    | 7.71 %           |     12,428.9 ns |     10896 B |
| Compress              | ZstdSharpCompressor-3            | Medium (10 KB) | 765 bytes    | 7.69 %           |     14,579.0 ns |     10896 B |
| Compress              | ZstdSharpCompressor-0            | Medium (10 KB) | 765 bytes    | 7.69 %           |     14,720.7 ns |     10896 B |
| Compress              | ZstdSharpCompressor-2            | Medium (10 KB) | 763 bytes    | 7.67 %           |     12,131.3 ns |     10896 B |
| Compress              | ZstdSharpCompressor-5            | Medium (10 KB) | 757 bytes    | 7.61 %           |     37,905.0 ns |     10888 B |
| Compress              | ZstdSharpCompressor-8            | Medium (10 KB) | 755 bytes    | 7.59 %           |     37,482.2 ns |     10888 B |
| Compress              | ZstdSharpCompressor-7            | Medium (10 KB) | 755 bytes    | 7.59 %           |     38,522.0 ns |     10888 B |
| Compress              | ZstdSharpCompressor-6            | Medium (10 KB) | 755 bytes    | 7.59 %           |     37,276.3 ns |     10888 B |
| Compress              | ZstdSharpCompressor-4            | Medium (10 KB) | 755 bytes    | 7.59 %           |     30,170.8 ns |     10888 B |
| Compress              | ZstdSharpCompressor-12           | Medium (10 KB) | 755 bytes    | 7.59 %           |    116,042.9 ns |     10888 B |
| Compress              | ZstdSharpCompressor-11           | Medium (10 KB) | 754 bytes    | 7.58 %           |    114,445.6 ns |     10888 B |
| Compress              | ZstdSharpCompressor-9            | Medium (10 KB) | 753 bytes    | 7.57 %           |     44,701.0 ns |     10888 B |
| Compress              | ZstdSharpCompressor-10           | Medium (10 KB) | 753 bytes    | 7.57 %           |     43,348.5 ns |     10888 B |
| Compress              | ZstdSharpCompressor-15           | Medium (10 KB) | 750 bytes    | 7.54 %           |    369,096.0 ns |     10881 B |
| Compress              | ZstdSharpCompressor-14           | Medium (10 KB) | 750 bytes    | 7.54 %           |    190,674.0 ns |     10880 B |
| Compress              | ZstdSharpCompressor-13           | Medium (10 KB) | 750 bytes    | 7.54 %           |    154,658.3 ns |     10880 B |
| Compress              | ZstdSharpCompressor-22           | Medium (10 KB) | 749 bytes    | 7.53 %           |  1,082,163.7 ns |     10883 B |
| Compress              | ZstdSharpCompressor-20           | Medium (10 KB) | 749 bytes    | 7.53 %           |    574,385.4 ns |     10881 B |
| Compress              | ZstdSharpCompressor-19           | Medium (10 KB) | 749 bytes    | 7.53 %           |    628,226.8 ns |     10881 B |
| Compress              | ZstdSharpCompressor-18           | Medium (10 KB) | 749 bytes    | 7.53 %           |    600,127.0 ns |     10881 B |
| Compress              | ZstdSharpCompressor-17           | Medium (10 KB) | 749 bytes    | 7.53 %           |    290,649.0 ns |     10881 B |
| Compress              | ZstdSharpCompressor-16           | Medium (10 KB) | 749 bytes    | 7.53 %           |    278,685.1 ns |     10881 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--131072      | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      4,429.6 ns |     30096 B |
| CompressAndDecompress | ZstdSharpCompressor--1000        | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      5,353.9 ns |     30096 B |
| CompressAndDecompress | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      6,049.9 ns |     21824 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes    | 7.71 %           |     18,043.9 ns |     20896 B |
| CompressAndDecompress | ZstdSharpCompressor-3            | Medium (10 KB) | 765 bytes    | 7.69 %           |     20,405.3 ns |     20896 B |
| CompressAndDecompress | ZstdSharpCompressor-0            | Medium (10 KB) | 765 bytes    | 7.69 %           |     20,690.5 ns |     20896 B |
| CompressAndDecompress | ZstdSharpCompressor-2            | Medium (10 KB) | 763 bytes    | 7.67 %           |     18,114.4 ns |     20896 B |
| CompressAndDecompress | ZstdSharpCompressor-5            | Medium (10 KB) | 757 bytes    | 7.61 %           |     42,070.0 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-8            | Medium (10 KB) | 755 bytes    | 7.59 %           |     44,493.0 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-7            | Medium (10 KB) | 755 bytes    | 7.59 %           |     44,186.4 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-6            | Medium (10 KB) | 755 bytes    | 7.59 %           |     43,651.5 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-4            | Medium (10 KB) | 755 bytes    | 7.59 %           |     44,386.6 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-12           | Medium (10 KB) | 755 bytes    | 7.59 %           |    124,000.7 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-11           | Medium (10 KB) | 754 bytes    | 7.58 %           |    111,461.8 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-9            | Medium (10 KB) | 753 bytes    | 7.57 %           |     50,606.1 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-10           | Medium (10 KB) | 753 bytes    | 7.57 %           |     51,060.7 ns |     20888 B |
| CompressAndDecompress | ZstdSharpCompressor-15           | Medium (10 KB) | 750 bytes    | 7.54 %           |    300,775.8 ns |     20881 B |
| CompressAndDecompress | ZstdSharpCompressor-14           | Medium (10 KB) | 750 bytes    | 7.54 %           |    186,102.7 ns |     20880 B |
| CompressAndDecompress | ZstdSharpCompressor-13           | Medium (10 KB) | 750 bytes    | 7.54 %           |    155,065.7 ns |     20880 B |
| CompressAndDecompress | ZstdSharpCompressor-22           | Medium (10 KB) | 749 bytes    | 7.53 %           |  1,146,612.8 ns |     20883 B |
| CompressAndDecompress | ZstdSharpCompressor-20           | Medium (10 KB) | 749 bytes    | 7.53 %           |    602,844.1 ns |     20881 B |
| CompressAndDecompress | ZstdSharpCompressor-19           | Medium (10 KB) | 749 bytes    | 7.53 %           |    571,414.2 ns |     20881 B |
| CompressAndDecompress | ZstdSharpCompressor-18           | Medium (10 KB) | 749 bytes    | 7.53 %           |    690,778.1 ns |     20881 B |
| CompressAndDecompress | ZstdSharpCompressor-17           | Medium (10 KB) | 749 bytes    | 7.53 %           |    299,047.3 ns |     20881 B |
| CompressAndDecompress | ZstdSharpCompressor-16           | Medium (10 KB) | 749 bytes    | 7.53 %           |    297,573.6 ns |     20881 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdSharpCompressor--131072      | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      1,046.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--1000        | Medium (10 KB) | 9,961 bytes  | 100.10 %         |      1,074.4 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes  | 17.03 %          |      1,476.4 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes    | 7.71 %           |      5,226.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-3            | Medium (10 KB) | 765 bytes    | 7.69 %           |      5,294.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-0            | Medium (10 KB) | 765 bytes    | 7.69 %           |      5,222.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-2            | Medium (10 KB) | 763 bytes    | 7.67 %           |      5,304.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-5            | Medium (10 KB) | 757 bytes    | 7.61 %           |      5,211.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-8            | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,411.7 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-7            | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,237.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-6            | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,273.7 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-4            | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,279.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-12           | Medium (10 KB) | 755 bytes    | 7.59 %           |      5,402.2 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-11           | Medium (10 KB) | 754 bytes    | 7.58 %           |      5,397.2 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-9            | Medium (10 KB) | 753 bytes    | 7.57 %           |      5,469.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-10           | Medium (10 KB) | 753 bytes    | 7.57 %           |      5,337.3 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-15           | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,370.9 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-14           | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,404.7 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-13           | Medium (10 KB) | 750 bytes    | 7.54 %           |      5,506.2 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-22           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,463.4 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-20           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,371.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-19           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,399.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-18           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,301.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-17           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,345.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-16           | Medium (10 KB) | 749 bytes    | 7.53 %           |      5,384.9 ns |     10000 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | BrotliCompressor-NoCompression   | Small (190 B)  | 194 bytes    | 102.11 %         |      6,992.7 ns |       696 B |
| Compress              | BrotliCompressor-Fastest         | Small (190 B)  | 194 bytes    | 102.11 %         |      5,095.5 ns |       696 B |
| Compress              | BrotliCompressor-Optimal         | Small (190 B)  | 167 bytes    | 87.89 %          |     18,788.5 ns |       664 B |
| Compress              | BrotliCompressor-SmallestSize    | Small (190 B)  | 145 bytes    | 76.32 %          |    561,592.2 ns |       649 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliCompressor-NoCompression   | Small (190 B)  | 194 bytes    | 102.11 %         |      8,046.5 ns |      1448 B |
| CompressAndDecompress | BrotliCompressor-Fastest         | Small (190 B)  | 194 bytes    | 102.11 %         |      5,922.0 ns |      1448 B |
| CompressAndDecompress | BrotliCompressor-Optimal         | Small (190 B)  | 167 bytes    | 87.89 %          |     19,759.3 ns |      1416 B |
| CompressAndDecompress | BrotliCompressor-SmallestSize    | Small (190 B)  | 145 bytes    | 76.32 %          |    577,884.4 ns |      1401 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliCompressor-NoCompression   | Small (190 B)  | 194 bytes    | 102.11 %         |        675.1 ns |       752 B |
| Decompress            | BrotliCompressor-Fastest         | Small (190 B)  | 194 bytes    | 102.11 %         |        670.0 ns |       752 B |
| Decompress            | BrotliCompressor-Optimal         | Small (190 B)  | 167 bytes    | 87.89 %          |      3,121.9 ns |       752 B |
| Decompress            | BrotliCompressor-SmallestSize    | Small (190 B)  | 145 bytes    | 76.32 %          |      3,131.9 ns |       752 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | BrotliNETCompressor-2-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     12,418.4 ns |     67465 B |
| Compress              | BrotliNETCompressor-1-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     13,468.5 ns |     67466 B |
| Compress              | BrotliNETCompressor-0-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     16,615.1 ns |     67470 B |
| Compress              | BrotliNETCompressor-3-22         | Small (190 B)  | 178 bytes    | 93.68 %          |     31,939.2 ns |     67507 B |
| Compress              | BrotliNETCompressor-4-22         | Small (190 B)  | 167 bytes    | 87.89 %          |     47,666.1 ns |     67498 B |
| Compress              | BrotliNETCompressor-9-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    386,072.6 ns |     67509 B |
| Compress              | BrotliNETCompressor-8-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    356,323.3 ns |     67514 B |
| Compress              | BrotliNETCompressor-7-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    330,879.5 ns |     67508 B |
| Compress              | BrotliNETCompressor-6-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    291,752.2 ns |     67511 B |
| Compress              | BrotliNETCompressor-5-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    262,591.5 ns |     67519 B |
| Compress              | BrotliNETCompressor-10-22        | Small (190 B)  | 146 bytes    | 76.84 %          |    534,476.5 ns |     67486 B |
| Compress              | BrotliNETCompressor-11-22        | Small (190 B)  | 145 bytes    | 76.32 %          |    595,552.1 ns |     67488 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | BrotliNETCompressor-2-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     21,174.3 ns |    135561 B |
| CompressAndDecompress | BrotliNETCompressor-1-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     21,850.8 ns |    135563 B |
| CompressAndDecompress | BrotliNETCompressor-0-22         | Small (190 B)  | 194 bytes    | 102.11 %         |     25,423.9 ns |    135566 B |
| CompressAndDecompress | BrotliNETCompressor-3-22         | Small (190 B)  | 178 bytes    | 93.68 %          |     43,320.7 ns |    135601 B |
| CompressAndDecompress | BrotliNETCompressor-4-22         | Small (190 B)  | 167 bytes    | 87.89 %          |     67,754.6 ns |    135600 B |
| CompressAndDecompress | BrotliNETCompressor-9-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    407,986.9 ns |    135658 B |
| CompressAndDecompress | BrotliNETCompressor-8-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    386,785.7 ns |    135657 B |
| CompressAndDecompress | BrotliNETCompressor-7-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    360,450.0 ns |    135657 B |
| CompressAndDecompress | BrotliNETCompressor-6-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    329,155.5 ns |    135658 B |
| CompressAndDecompress | BrotliNETCompressor-5-22         | Small (190 B)  | 165 bytes    | 86.84 %          |    286,584.2 ns |    135658 B |
| CompressAndDecompress | BrotliNETCompressor-10-22        | Small (190 B)  | 146 bytes    | 76.84 %          |    624,663.4 ns |    135605 B |
| CompressAndDecompress | BrotliNETCompressor-11-22        | Small (190 B)  | 145 bytes    | 76.32 %          |    718,449.7 ns |    135604 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | BrotliNETCompressor-2-22         | Small (190 B)  | 194 bytes    | 102.11 %         |      7,274.3 ns |     68096 B |
| Decompress            | BrotliNETCompressor-1-22         | Small (190 B)  | 194 bytes    | 102.11 %         |      7,184.8 ns |     68096 B |
| Decompress            | BrotliNETCompressor-0-22         | Small (190 B)  | 194 bytes    | 102.11 %         |      7,241.6 ns |     68096 B |
| Decompress            | BrotliNETCompressor-3-22         | Small (190 B)  | 178 bytes    | 93.68 %          |     11,035.8 ns |     68097 B |
| Decompress            | BrotliNETCompressor-4-22         | Small (190 B)  | 167 bytes    | 87.89 %          |     10,951.0 ns |     68097 B |
| Decompress            | BrotliNETCompressor-9-22         | Small (190 B)  | 165 bytes    | 86.84 %          |     11,225.6 ns |     68097 B |
| Decompress            | BrotliNETCompressor-8-22         | Small (190 B)  | 165 bytes    | 86.84 %          |     11,335.3 ns |     68097 B |
| Decompress            | BrotliNETCompressor-7-22         | Small (190 B)  | 165 bytes    | 86.84 %          |     11,432.1 ns |     68097 B |
| Decompress            | BrotliNETCompressor-6-22         | Small (190 B)  | 165 bytes    | 86.84 %          |     11,313.8 ns |     68097 B |
| Decompress            | BrotliNETCompressor-5-22         | Small (190 B)  | 165 bytes    | 86.84 %          |     11,292.6 ns |     68097 B |
| Decompress            | BrotliNETCompressor-10-22        | Small (190 B)  | 146 bytes    | 76.84 %          |     11,225.6 ns |     68097 B |
| Decompress            | BrotliNETCompressor-11-22        | Small (190 B)  | 145 bytes    | 76.32 %          |     11,039.7 ns |     68096 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | DeflateCompressor-NoCompression  | Small (190 B)  | 195 bytes    | 102.63 %         |      2,038.2 ns |       776 B |
| Compress              | DeflateCompressor-Fastest        | Small (190 B)  | 163 bytes    | 85.79 %          |      7,850.8 ns |       744 B |
| Compress              | DeflateCompressor-SmallestSize   | Small (190 B)  | 162 bytes    | 85.26 %          |      8,166.8 ns |       744 B |
| Compress              | DeflateCompressor-Optimal        | Small (190 B)  | 162 bytes    | 85.26 %          |      9,088.7 ns |       744 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | DeflateCompressor-NoCompression  | Small (190 B)  | 195 bytes    | 102.63 %         |      3,065.1 ns |      1680 B |
| CompressAndDecompress | DeflateCompressor-Fastest        | Small (190 B)  | 163 bytes    | 85.79 %          |      9,540.8 ns |      1648 B |
| CompressAndDecompress | DeflateCompressor-SmallestSize   | Small (190 B)  | 162 bytes    | 85.26 %          |     10,151.2 ns |      1648 B |
| CompressAndDecompress | DeflateCompressor-Optimal        | Small (190 B)  | 162 bytes    | 85.26 %          |     10,936.2 ns |      1648 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | DeflateCompressor-NoCompression  | Small (190 B)  | 195 bytes    | 102.63 %         |      1,030.1 ns |       904 B |
| Decompress            | DeflateCompressor-Fastest        | Small (190 B)  | 163 bytes    | 85.79 %          |      1,549.2 ns |       904 B |
| Decompress            | DeflateCompressor-SmallestSize   | Small (190 B)  | 162 bytes    | 85.26 %          |      1,531.5 ns |       904 B |
| Decompress            | DeflateCompressor-Optimal        | Small (190 B)  | 162 bytes    | 85.26 %          |      1,540.1 ns |       904 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | GZipCompressor-NoCompression     | Small (190 B)  | 213 bytes    | 112.11 %         |      1,876.6 ns |       824 B |
| Compress              | GZipCompressor-Fastest           | Small (190 B)  | 181 bytes    | 95.26 %          |      8,280.3 ns |       792 B |
| Compress              | GZipCompressor-SmallestSize      | Small (190 B)  | 180 bytes    | 94.74 %          |      8,300.5 ns |       792 B |
| Compress              | GZipCompressor-Optimal           | Small (190 B)  | 180 bytes    | 94.74 %          |      9,347.3 ns |       792 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | GZipCompressor-NoCompression     | Small (190 B)  | 213 bytes    | 112.11 %         |      3,261.7 ns |      1760 B |
| CompressAndDecompress | GZipCompressor-Fastest           | Small (190 B)  | 181 bytes    | 95.26 %          |      9,676.1 ns |      1728 B |
| CompressAndDecompress | GZipCompressor-SmallestSize      | Small (190 B)  | 180 bytes    | 94.74 %          |     10,201.3 ns |      1728 B |
| CompressAndDecompress | GZipCompressor-Optimal           | Small (190 B)  | 180 bytes    | 94.74 %          |     11,254.3 ns |      1728 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | GZipCompressor-NoCompression     | Small (190 B)  | 213 bytes    | 112.11 %         |      1,077.1 ns |       936 B |
| Decompress            | GZipCompressor-Fastest           | Small (190 B)  | 181 bytes    | 95.26 %          |      1,503.6 ns |       936 B |
| Decompress            | GZipCompressor-SmallestSize      | Small (190 B)  | 180 bytes    | 94.74 %          |      1,559.3 ns |       936 B |
| Decompress            | GZipCompressor-Optimal           | Small (190 B)  | 180 bytes    | 94.74 %          |      1,593.0 ns |       936 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZ4Compressor-Optimized-L00_FAST | Small (190 B)  | 174 bytes    | 91.58 %          |      1,083.7 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L03_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,762.5 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L04_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,067.7 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L05_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,148.0 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L06_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,966.9 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L07_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,116.1 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L08_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,940.8 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L09_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,955.9 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L10_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |      5,488.4 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L11_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |      5,370.4 ns |       200 B |
| Compress              | LZ4Compressor-Optimized-L12_MAX  | Small (190 B)  | 173 bytes    | 91.05 %          |      5,708.6 ns |       200 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZ4Compressor-Optimized-L00_FAST | Small (190 B)  | 174 bytes    | 91.58 %          |      1,156.4 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L12_MAX  | Small (190 B)  | 173 bytes    | 91.05 %          |      6,124.4 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L11_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |      5,804.0 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L10_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |      5,587.9 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L09_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,179.9 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L08_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,145.5 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L07_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,941.5 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L06_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,952.1 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L05_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,098.0 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L04_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      3,913.2 ns |       416 B |
| CompressAndDecompress | LZ4Compressor-Optimized-L03_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |      4,200.3 ns |       416 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZ4Compressor-Optimized-L00_FAST | Small (190 B)  | 174 bytes    | 91.58 %          |        125.0 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L12_MAX  | Small (190 B)  | 173 bytes    | 91.05 %          |        129.4 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L11_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |        128.6 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L10_OPT  | Small (190 B)  | 173 bytes    | 91.05 %          |        129.3 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L09_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        117.2 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L08_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        117.9 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L07_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        117.8 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L06_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        118.1 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L05_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        120.0 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L04_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        120.5 ns |       216 B |
| Decompress            | LZ4Compressor-Optimized-L03_HC   | Small (190 B)  | 173 bytes    | 91.05 %          |        119.9 ns |       216 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | LZMACompressor-VerySlow-Large    | Small (190 B)  | 175 bytes    | 92.11 %          | 18,202,191.7 ns |  97116158 B |
| Compress              | LZMACompressor-VeryFast-Large    | Small (190 B)  | 175 bytes    | 92.11 %          | 19,074,529.2 ns |  97115777 B |
| Compress              | LZMACompressor-Slow-Large        | Small (190 B)  | 175 bytes    | 92.11 %          | 18,616,106.2 ns |  97115824 B |
| Compress              | LZMACompressor-Medium-Large      | Small (190 B)  | 175 bytes    | 92.11 %          | 17,884,384.4 ns |  97115934 B |
| Compress              | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes    | 92.11 %          | 19,026,057.3 ns |  97115816 B |
| Compress              | LZMACompressor-Fast-Large        | Small (190 B)  | 175 bytes    | 92.11 %          | 18,559,552.1 ns |  97115951 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | LZMACompressor-VerySlow-Large    | Small (190 B)  | 175 bytes    | 92.11 %          | 20,482,825.0 ns | 105538265 B |
| CompressAndDecompress | LZMACompressor-VeryFast-Large    | Small (190 B)  | 175 bytes    | 92.11 %          | 18,593,541.7 ns | 105538200 B |
| CompressAndDecompress | LZMACompressor-Slow-Large        | Small (190 B)  | 175 bytes    | 92.11 %          | 20,342,276.0 ns | 105538407 B |
| CompressAndDecompress | LZMACompressor-Medium-Large      | Small (190 B)  | 175 bytes    | 92.11 %          | 20,397,004.2 ns | 105538359 B |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes    | 92.11 %          | 18,496,581.2 ns | 105538121 B |
| CompressAndDecompress | LZMACompressor-Fast-Large        | Small (190 B)  | 175 bytes    | 92.11 %          | 17,646,578.1 ns | 105538471 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | LZMACompressor-VerySlow-Large    | Small (190 B)  | 175 bytes    | 92.11 %          |  1,005,820.5 ns |   8422715 B |
| Decompress            | LZMACompressor-VeryFast-Large    | Small (190 B)  | 175 bytes    | 92.11 %          |    791,090.2 ns |   8422702 B |
| Decompress            | LZMACompressor-Slow-Large        | Small (190 B)  | 175 bytes    | 92.11 %          |  1,105,880.1 ns |   8422723 B |
| Decompress            | LZMACompressor-Medium-Large      | Small (190 B)  | 175 bytes    | 92.11 %          |    857,043.4 ns |   8422690 B |
| Decompress            | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes    | 92.11 %          |    834,581.8 ns |   8422713 B |
| Decompress            | LZMACompressor-Fast-Large        | Small (190 B)  | 175 bytes    | 92.11 %          |    844,371.4 ns |   8422730 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZLibCompressor-NoCompression     | Small (190 B)  | 201 bytes    | 105.79 %         |      2,087.6 ns |       816 B |
| Compress              | ZLibCompressor-Fastest           | Small (190 B)  | 169 bytes    | 88.95 %          |      7,988.4 ns |       784 B |
| Compress              | ZLibCompressor-SmallestSize      | Small (190 B)  | 168 bytes    | 88.42 %          |      8,316.4 ns |       776 B |
| Compress              | ZLibCompressor-Optimal           | Small (190 B)  | 168 bytes    | 88.42 %          |      9,227.5 ns |       776 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZLibCompressor-NoCompression     | Small (190 B)  | 201 bytes    | 105.79 %         |      3,229.7 ns |      1752 B |
| CompressAndDecompress | ZLibCompressor-Fastest           | Small (190 B)  | 169 bytes    | 88.95 %          |     10,021.3 ns |      1720 B |
| CompressAndDecompress | ZLibCompressor-SmallestSize      | Small (190 B)  | 168 bytes    | 88.42 %          |     10,085.9 ns |      1712 B |
| CompressAndDecompress | ZLibCompressor-Optimal           | Small (190 B)  | 168 bytes    | 88.42 %          |     11,022.2 ns |      1712 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZLibCompressor-NoCompression     | Small (190 B)  | 201 bytes    | 105.79 %         |      1,124.3 ns |       936 B |
| Decompress            | ZLibCompressor-Fastest           | Small (190 B)  | 169 bytes    | 88.95 %          |      1,720.4 ns |       936 B |
| Decompress            | ZLibCompressor-SmallestSize      | Small (190 B)  | 168 bytes    | 88.42 %          |      1,568.8 ns |       936 B |
| Decompress            | ZLibCompressor-Optimal           | Small (190 B)  | 168 bytes    | 88.42 %          |      1,569.8 ns |       936 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdCompressor--131072           | Small (190 B)  | 199 bytes    | 104.74 %         |      1,970.9 ns |       304 B |
| Compress              | ZstdCompressor--1000             | Small (190 B)  | 199 bytes    | 104.74 %         |      1,940.4 ns |       304 B |
| Compress              | ZstdCompressor--22               | Small (190 B)  | 199 bytes    | 104.74 %         |      2,000.4 ns |       304 B |
| Compress              | ZstdCompressor-0                 | Small (190 B)  | 176 bytes    | 92.63 %          |      6,807.9 ns |       280 B |
| Compress              | ZstdCompressor-1                 | Small (190 B)  | 178 bytes    | 93.68 %          |      6,458.9 ns |       288 B |
| Compress              | ZstdCompressor-2                 | Small (190 B)  | 176 bytes    | 92.63 %          |      6,444.0 ns |       288 B |
| Compress              | ZstdCompressor-3                 | Small (190 B)  | 176 bytes    | 92.63 %          |      6,654.8 ns |       280 B |
| Compress              | ZstdCompressor-4                 | Small (190 B)  | 176 bytes    | 92.63 %          |      6,947.2 ns |       280 B |
| Compress              | ZstdCompressor-5                 | Small (190 B)  | 176 bytes    | 92.63 %          |      7,483.2 ns |       280 B |
| Compress              | ZstdCompressor-6                 | Small (190 B)  | 176 bytes    | 92.63 %          |      7,484.5 ns |       280 B |
| Compress              | ZstdCompressor-7                 | Small (190 B)  | 176 bytes    | 92.63 %          |      7,357.6 ns |       280 B |
| Compress              | ZstdCompressor-8                 | Small (190 B)  | 176 bytes    | 92.63 %          |      7,356.4 ns |       280 B |
| Compress              | ZstdCompressor-9                 | Small (190 B)  | 176 bytes    | 92.63 %          |      8,899.1 ns |       280 B |
| Compress              | ZstdCompressor-10                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,076.5 ns |       280 B |
| Compress              | ZstdCompressor-11                | Small (190 B)  | 176 bytes    | 92.63 %          |      8,853.7 ns |       280 B |
| Compress              | ZstdCompressor-12                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,507.0 ns |       280 B |
| Compress              | ZstdCompressor-13                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,813.7 ns |       280 B |
| Compress              | ZstdCompressor-14                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,727.5 ns |       280 B |
| Compress              | ZstdCompressor-15                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,846.5 ns |       280 B |
| Compress              | ZstdCompressor-16                | Small (190 B)  | 176 bytes    | 92.63 %          |     10,055.7 ns |       280 B |
| Compress              | ZstdCompressor-17                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,998.0 ns |       280 B |
| Compress              | ZstdCompressor-18                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,850.7 ns |       280 B |
| Compress              | ZstdCompressor-19                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,672.0 ns |       280 B |
| Compress              | ZstdCompressor-20                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,859.3 ns |       280 B |
| Compress              | ZstdCompressor-22                | Small (190 B)  | 176 bytes    | 92.63 %          |      9,963.6 ns |       280 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--22               | Small (190 B)  | 199 bytes    | 104.74 %         |      3,926.5 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--131072           | Small (190 B)  | 199 bytes    | 104.74 %         |      3,847.2 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--1000             | Small (190 B)  | 199 bytes    | 104.74 %         |      3,802.7 ns |       592 B |
| CompressAndDecompress | ZstdCompressor-1                 | Small (190 B)  | 178 bytes    | 93.68 %          |      8,979.7 ns |       576 B |
| CompressAndDecompress | ZstdCompressor-9                 | Small (190 B)  | 176 bytes    | 92.63 %          |     11,413.3 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-8                 | Small (190 B)  | 176 bytes    | 92.63 %          |      9,818.6 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-7                 | Small (190 B)  | 176 bytes    | 92.63 %          |      9,948.4 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-6                 | Small (190 B)  | 176 bytes    | 92.63 %          |      9,836.0 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-5                 | Small (190 B)  | 176 bytes    | 92.63 %          |      9,929.3 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-4                 | Small (190 B)  | 176 bytes    | 92.63 %          |      9,230.3 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-3                 | Small (190 B)  | 176 bytes    | 92.63 %          |      8,933.9 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-22                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,433.4 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-20                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,620.3 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-2                 | Small (190 B)  | 176 bytes    | 92.63 %          |      8,715.3 ns |       576 B |
| CompressAndDecompress | ZstdCompressor-19                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,824.5 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-18                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,487.5 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-17                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,586.5 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-16                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,561.1 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-15                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,555.1 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-14                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,402.8 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-13                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,555.9 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-12                | Small (190 B)  | 176 bytes    | 92.63 %          |     12,288.6 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-11                | Small (190 B)  | 176 bytes    | 92.63 %          |     11,439.0 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-10                | Small (190 B)  | 176 bytes    | 92.63 %          |     11,471.4 ns |       568 B |
| CompressAndDecompress | ZstdCompressor-0                 | Small (190 B)  | 176 bytes    | 92.63 %          |      8,903.5 ns |       568 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdCompressor--22               | Small (190 B)  | 199 bytes    | 104.74 %         |      1,520.4 ns |       288 B |
| Decompress            | ZstdCompressor--131072           | Small (190 B)  | 199 bytes    | 104.74 %         |      1,530.5 ns |       288 B |
| Decompress            | ZstdCompressor--1000             | Small (190 B)  | 199 bytes    | 104.74 %         |      1,532.3 ns |       288 B |
| Decompress            | ZstdCompressor-1                 | Small (190 B)  | 178 bytes    | 93.68 %          |      1,668.8 ns |       288 B |
| Decompress            | ZstdCompressor-9                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,658.4 ns |       288 B |
| Decompress            | ZstdCompressor-8                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,654.9 ns |       288 B |
| Decompress            | ZstdCompressor-7                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,649.0 ns |       288 B |
| Decompress            | ZstdCompressor-6                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,659.6 ns |       288 B |
| Decompress            | ZstdCompressor-5                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,667.3 ns |       288 B |
| Decompress            | ZstdCompressor-4                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,659.9 ns |       288 B |
| Decompress            | ZstdCompressor-3                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,658.2 ns |       288 B |
| Decompress            | ZstdCompressor-22                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,657.5 ns |       288 B |
| Decompress            | ZstdCompressor-20                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,647.2 ns |       288 B |
| Decompress            | ZstdCompressor-2                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,675.8 ns |       288 B |
| Decompress            | ZstdCompressor-19                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,634.5 ns |       288 B |
| Decompress            | ZstdCompressor-18                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,669.6 ns |       288 B |
| Decompress            | ZstdCompressor-17                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,666.9 ns |       288 B |
| Decompress            | ZstdCompressor-16                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,647.2 ns |       288 B |
| Decompress            | ZstdCompressor-15                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,664.1 ns |       288 B |
| Decompress            | ZstdCompressor-14                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,690.4 ns |       288 B |
| Decompress            | ZstdCompressor-13                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,650.9 ns |       288 B |
| Decompress            | ZstdCompressor-12                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,656.2 ns |       288 B |
| Decompress            | ZstdCompressor-11                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,655.1 ns |       288 B |
| Decompress            | ZstdCompressor-10                | Small (190 B)  | 176 bytes    | 92.63 %          |      1,653.5 ns |       288 B |
| Decompress            | ZstdCompressor-0                 | Small (190 B)  | 176 bytes    | 92.63 %          |      1,665.0 ns |       288 B |
|                       |                                  |                |              |                  |                 |             |
| Compress              | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes    | 104.74 %         |      1,492.5 ns |       536 B |
| Compress              | ZstdSharpCompressor--131072      | Small (190 B)  | 199 bytes    | 104.74 %         |        782.2 ns |       536 B |
| Compress              | ZstdSharpCompressor--1000        | Small (190 B)  | 199 bytes    | 104.74 %         |        684.3 ns |       536 B |
| Compress              | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes    | 93.68 %          |      5,651.1 ns |       520 B |
| Compress              | ZstdSharpCompressor-9            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,558.4 ns |       512 B |
| Compress              | ZstdSharpCompressor-8            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,024.4 ns |       512 B |
| Compress              | ZstdSharpCompressor-7            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,177.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-6            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,035.0 ns |       512 B |
| Compress              | ZstdSharpCompressor-5            | Small (190 B)  | 176 bytes    | 92.63 %          |      7,915.8 ns |       512 B |
| Compress              | ZstdSharpCompressor-4            | Small (190 B)  | 176 bytes    | 92.63 %          |      7,532.2 ns |       512 B |
| Compress              | ZstdSharpCompressor-3            | Small (190 B)  | 176 bytes    | 92.63 %          |      5,831.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-22           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,878.3 ns |       512 B |
| Compress              | ZstdSharpCompressor-20           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,381.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-2            | Small (190 B)  | 176 bytes    | 92.63 %          |      5,616.3 ns |       512 B |
| Compress              | ZstdSharpCompressor-19           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,567.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-18           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,347.5 ns |       512 B |
| Compress              | ZstdSharpCompressor-17           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,228.4 ns |       512 B |
| Compress              | ZstdSharpCompressor-16           | Small (190 B)  | 176 bytes    | 92.63 %          |     26,730.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-15           | Small (190 B)  | 176 bytes    | 92.63 %          |     19,973.2 ns |       512 B |
| Compress              | ZstdSharpCompressor-14           | Small (190 B)  | 176 bytes    | 92.63 %          |     20,528.8 ns |       512 B |
| Compress              | ZstdSharpCompressor-13           | Small (190 B)  | 176 bytes    | 92.63 %          |     20,088.6 ns |       512 B |
| Compress              | ZstdSharpCompressor-12           | Small (190 B)  | 176 bytes    | 92.63 %          |     11,924.9 ns |       512 B |
| Compress              | ZstdSharpCompressor-11           | Small (190 B)  | 176 bytes    | 92.63 %          |     11,313.1 ns |       512 B |
| Compress              | ZstdSharpCompressor-10           | Small (190 B)  | 176 bytes    | 92.63 %          |      8,809.3 ns |       512 B |
| Compress              | ZstdSharpCompressor-0            | Small (190 B)  | 176 bytes    | 92.63 %          |      5,968.9 ns |       512 B |
|                       |                                  |                |              |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes    | 104.74 %         |      1,898.0 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--131072      | Small (190 B)  | 199 bytes    | 104.74 %         |        987.7 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--1000        | Small (190 B)  | 199 bytes    | 104.74 %         |      1,086.8 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes    | 93.68 %          |      6,247.6 ns |       760 B |
| CompressAndDecompress | ZstdSharpCompressor-9            | Small (190 B)  | 176 bytes    | 92.63 %          |      9,236.0 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-8            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,882.0 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-7            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,917.8 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-6            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,927.1 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-5            | Small (190 B)  | 176 bytes    | 92.63 %          |      8,936.8 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-4            | Small (190 B)  | 176 bytes    | 92.63 %          |      7,956.6 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-3            | Small (190 B)  | 176 bytes    | 92.63 %          |      6,794.5 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-22           | Small (190 B)  | 176 bytes    | 92.63 %          |     28,066.3 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-20           | Small (190 B)  | 176 bytes    | 92.63 %          |     28,318.3 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-2            | Small (190 B)  | 176 bytes    | 92.63 %          |      6,349.0 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-19           | Small (190 B)  | 176 bytes    | 92.63 %          |     28,810.4 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-18           | Small (190 B)  | 176 bytes    | 92.63 %          |     28,049.1 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-17           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,577.7 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-16           | Small (190 B)  | 176 bytes    | 92.63 %          |     27,353.0 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-15           | Small (190 B)  | 176 bytes    | 92.63 %          |     21,666.2 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-14           | Small (190 B)  | 176 bytes    | 92.63 %          |     21,175.5 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-13           | Small (190 B)  | 176 bytes    | 92.63 %          |     21,304.7 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-12           | Small (190 B)  | 176 bytes    | 92.63 %          |     12,866.1 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-11           | Small (190 B)  | 176 bytes    | 92.63 %          |     12,142.8 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-10           | Small (190 B)  | 176 bytes    | 92.63 %          |      9,325.6 ns |       752 B |
| CompressAndDecompress | ZstdSharpCompressor-0            | Small (190 B)  | 176 bytes    | 92.63 %          |      6,566.7 ns |       752 B |
|                       |                                  |                |              |                  |                 |             |
| Decompress            | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes    | 104.74 %         |        283.7 ns |       240 B |
| Decompress            | ZstdSharpCompressor--131072      | Small (190 B)  | 199 bytes    | 104.74 %         |        276.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor--1000        | Small (190 B)  | 199 bytes    | 104.74 %         |        258.1 ns |       240 B |
| Decompress            | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes    | 93.68 %          |        436.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor-9            | Small (190 B)  | 176 bytes    | 92.63 %          |        495.0 ns |       240 B |
| Decompress            | ZstdSharpCompressor-8            | Small (190 B)  | 176 bytes    | 92.63 %          |        460.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor-7            | Small (190 B)  | 176 bytes    | 92.63 %          |        477.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor-6            | Small (190 B)  | 176 bytes    | 92.63 %          |        449.1 ns |       240 B |
| Decompress            | ZstdSharpCompressor-5            | Small (190 B)  | 176 bytes    | 92.63 %          |        465.2 ns |       240 B |
| Decompress            | ZstdSharpCompressor-4            | Small (190 B)  | 176 bytes    | 92.63 %          |        465.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor-3            | Small (190 B)  | 176 bytes    | 92.63 %          |        457.7 ns |       240 B |
| Decompress            | ZstdSharpCompressor-22           | Small (190 B)  | 176 bytes    | 92.63 %          |        474.7 ns |       240 B |
| Decompress            | ZstdSharpCompressor-20           | Small (190 B)  | 176 bytes    | 92.63 %          |        425.5 ns |       240 B |
| Decompress            | ZstdSharpCompressor-2            | Small (190 B)  | 176 bytes    | 92.63 %          |        433.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor-19           | Small (190 B)  | 176 bytes    | 92.63 %          |        461.0 ns |       240 B |
| Decompress            | ZstdSharpCompressor-18           | Small (190 B)  | 176 bytes    | 92.63 %          |        419.2 ns |       240 B |
| Decompress            | ZstdSharpCompressor-17           | Small (190 B)  | 176 bytes    | 92.63 %          |        514.5 ns |       240 B |
| Decompress            | ZstdSharpCompressor-16           | Small (190 B)  | 176 bytes    | 92.63 %          |        459.6 ns |       240 B |
| Decompress            | ZstdSharpCompressor-15           | Small (190 B)  | 176 bytes    | 92.63 %          |        434.2 ns |       240 B |
| Decompress            | ZstdSharpCompressor-14           | Small (190 B)  | 176 bytes    | 92.63 %          |        444.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor-13           | Small (190 B)  | 176 bytes    | 92.63 %          |        428.1 ns |       240 B |
| Decompress            | ZstdSharpCompressor-12           | Small (190 B)  | 176 bytes    | 92.63 %          |        471.5 ns |       240 B |
| Decompress            | ZstdSharpCompressor-11           | Small (190 B)  | 176 bytes    | 92.63 %          |        457.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor-10           | Small (190 B)  | 176 bytes    | 92.63 %          |        445.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor-0            | Small (190 B)  | 176 bytes    | 92.63 %          |        456.9 ns |       240 B |


TODO:
fix sorting issue - LZMACompressor - BrotliNETCompressor - LZ4Compressor, ...
test zstd with 21 and brotli with 0 
ZstdSharpCompressor most not be too slower than ZstdCompressor in compress

Key Results:
BrotliCompressor-NoCompression	Instead, use Fastest
BrotliCompressor-Fastest	Fast-GCInefficient **BEST**
BrotliCompressor-Optimal	Slow-GCEfficient
BrotliCompressor-SmallestSize	Slowest
Decompress 			No difference
Use BrotliCompressor for medium or large objects (>= 10,000)
DO NOT use BrotliCompressor for small object (<= 190)


BrotliNETCompressor-0		Instead, use 1
BrotliNETCompressor-1		Fast-GCInefficient **BEST**
BrotliNETCompressor-2..4	Optimal
BrotliNETCompressor-5..11	Getting Worse
Decompress 			No difference
Use BrotliNETCompressor for medium or large objects (>= 10,000)
DO NOT use BrotliNETCompressor for small object (<= 190)


DeflateCompressor-NoCompression	Fastest with NO compress and GCInefficient (does not worth)
DeflateCompressor-Fastest      	Moderate Speed (**BEST**)
DeflateCompressor-Optimal      	Slow (does not worth)
DeflateCompressor-SmallestSize 	Slowest (does not worth)
DeflateCompressor is OK event for small objects


GZipCompressor same as DeflateCompressor - DeflateCompressor is better for small objects (due to lack of extra header bytes)
ZLibCompressor same as DeflateCompressor - DeflateCompressor is a bit better for small objects (due to lack of extra header bytes)
BrotliCompressor is faster but not GC efficient than GZip/ZLib/Deflate with Fastest option


LZ4Compressor-Optimized-L00_FAST	Fastest - **BEST**
LZ4Compressor-Optimized-L03..L09	Slow
LZ4Compressor-Optimized-L10..L12	Very Slow


LZMACompressor-Fastest			**BEST** option
LZMACompressor-VerySlow			Worst
NOT good for small objects (due to low compression Ratio because of extra header bytes and also bad performance/allocation)
In general LZMACompressor is the Slowest and worst in memory allocation 
BUT the stongest in compression (highest Ratio: 12.63)
Not much difference between compression level/speed



ZstdCompressor--1000..-~		Fastest with NO compress and GCInefficient (does not worth)
ZstdCompressor--22			Fast with low compression Ratio (37.86)
ZstdCompressor--5(about)		**BEST** moderated between Ratio/Speed/Allocation
ZstdCompressor-0(Bad),2,3,4		Instead, use 1 (0 is equal to 3 in zstd)
ZstdCompressor-1			A bit low compression Ratio than average (15.87 - avg: 17~18)
ZstdCompressor-5~21			Getting slow without sensible difference
ZstdCompressor-16~19			Slow but top 2nd in compression Ratio (13.96) 
ZstdCompressor-22			Slowest, Instead use ZstdCompressor-19  
ZstdCompressor levels also effect in Decompress
Decompress ZstdCompressor-0..22	is Slow but ZstdCompressor--22..-~ is Fast

ZstdSharpCompressor is the same as ZstdCompressor







| Method                | Compressor                       | Data           | Compressed  | CompressionRatio | Mean            | Allocated   |
|---------------------- |--------------------------------- |--------------- |------------ |----------------- |----------------:|------------:|
| Compress              | ZstdCompressor--19               | Large (20 KB)  | 7,998 bytes | 38.69 %          |     13,576.5 ns |      6304 B |
| Compress              | ZstdCompressor--21               | Large (20 KB)  | 7,980 bytes | 38.60 %          |     12,883.3 ns |      6912 B |
| Compress              | ZstdCompressor--18               | Large (20 KB)  | 7,911 bytes | 38.27 %          |     13,531.1 ns |      6640 B |
| Compress              | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes | 37.86 %          |     13,232.6 ns |      7248 B |
| Compress              | ZstdCompressor--20               | Large (20 KB)  | 7,785 bytes | 37.66 %          |     13,451.6 ns |      6896 B |
| Compress              | ZstdCompressor--17               | Large (20 KB)  | 7,333 bytes | 35.47 %          |     13,460.4 ns |      6192 B |
| Compress              | ZstdCompressor--13               | Large (20 KB)  | 6,901 bytes | 33.38 %          |     14,308.3 ns |      5680 B |
| Compress              | ZstdCompressor--14               | Large (20 KB)  | 6,867 bytes | 33.22 %          |     13,681.5 ns |      5808 B |
| Compress              | ZstdCompressor--16               | Large (20 KB)  | 6,852 bytes | 33.14 %          |     14,061.1 ns |      5880 B |
| Compress              | ZstdCompressor--15               | Large (20 KB)  | 6,835 bytes | 33.06 %          |     13,731.7 ns |      6016 B |
| Compress              | ZstdCompressor--11               | Large (20 KB)  | 6,620 bytes | 32.02 %          |     14,735.7 ns |      5648 B |
| Compress              | ZstdCompressor--12               | Large (20 KB)  | 6,554 bytes | 31.70 %          |     13,918.3 ns |      5376 B |
| Compress              | ZstdCompressor--10               | Large (20 KB)  | 6,389 bytes | 30.91 %          |     14,468.4 ns |      5488 B |
| Compress              | ZstdCompressor--9                | Large (20 KB)  | 6,111 bytes | 29.56 %          |     14,733.8 ns |      5168 B |
| Compress              | ZstdCompressor--8                | Large (20 KB)  | 5,806 bytes | 28.08 %          |     15,254.5 ns |      5032 B |
| Compress              | ZstdCompressor--7                | Large (20 KB)  | 5,546 bytes | 26.83 %          |     15,464.6 ns |      4864 B |
| Compress              | ZstdCompressor--6                | Large (20 KB)  | 5,233 bytes | 25.31 %          |     16,388.0 ns |      4624 B |
| Compress              | ZstdCompressor--5                | Large (20 KB)  | 5,021 bytes | 24.29 %          |     16,163.1 ns |      4448 B |
| Compress              | ZstdCompressor--4                | Large (20 KB)  | 4,547 bytes | 21.99 %          |     17,173.4 ns |      4304 B |
| Compress              | ZstdCompressor--3                | Large (20 KB)  | 4,258 bytes | 20.60 %          |     18,127.6 ns |      4192 B |
| Compress              | ZstdCompressor--2                | Large (20 KB)  | 3,852 bytes | 18.63 %          |     18,499.5 ns |      3896 B |
| Compress              | ZstdCompressor--1                | Large (20 KB)  | 3,622 bytes | 17.52 %          |     19,910.4 ns |      3752 B |
| Compress              | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes | 15.87 %          |     26,965.0 ns |      3384 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--19               | Large (20 KB)  | 7,998 bytes | 38.69 %          |     21,530.8 ns |     27080 B |
| CompressAndDecompress | ZstdCompressor--21               | Large (20 KB)  | 7,980 bytes | 38.60 %          |     21,066.7 ns |     27688 B |
| CompressAndDecompress | ZstdCompressor--18               | Large (20 KB)  | 7,911 bytes | 38.27 %          |     22,354.2 ns |     27416 B |
| CompressAndDecompress | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes | 37.86 %          |     21,610.0 ns |     28024 B |
| CompressAndDecompress | ZstdCompressor--20               | Large (20 KB)  | 7,785 bytes | 37.66 %          |     21,395.0 ns |     27672 B |
| CompressAndDecompress | ZstdCompressor--17               | Large (20 KB)  | 7,333 bytes | 35.47 %          |     21,718.0 ns |     26968 B |
| CompressAndDecompress | ZstdCompressor--13               | Large (20 KB)  | 6,901 bytes | 33.38 %          |     22,340.6 ns |     26456 B |
| CompressAndDecompress | ZstdCompressor--14               | Large (20 KB)  | 6,867 bytes | 33.22 %          |     21,827.7 ns |     26584 B |
| CompressAndDecompress | ZstdCompressor--16               | Large (20 KB)  | 6,852 bytes | 33.14 %          |     21,868.8 ns |     26656 B |
| CompressAndDecompress | ZstdCompressor--15               | Large (20 KB)  | 6,835 bytes | 33.06 %          |     21,640.3 ns |     26792 B |
| CompressAndDecompress | ZstdCompressor--11               | Large (20 KB)  | 6,620 bytes | 32.02 %          |     22,723.8 ns |     26424 B |
| CompressAndDecompress | ZstdCompressor--12               | Large (20 KB)  | 6,554 bytes | 31.70 %          |     22,409.3 ns |     26152 B |
| CompressAndDecompress | ZstdCompressor--10               | Large (20 KB)  | 6,389 bytes | 30.91 %          |     23,187.0 ns |     26264 B |
| CompressAndDecompress | ZstdCompressor--9                | Large (20 KB)  | 6,111 bytes | 29.56 %          |     23,290.2 ns |     25944 B |
| CompressAndDecompress | ZstdCompressor--8                | Large (20 KB)  | 5,806 bytes | 28.08 %          |     24,209.4 ns |     25808 B |
| CompressAndDecompress | ZstdCompressor--7                | Large (20 KB)  | 5,546 bytes | 26.83 %          |     24,660.2 ns |     25640 B |
| CompressAndDecompress | ZstdCompressor--6                | Large (20 KB)  | 5,233 bytes | 25.31 %          |     25,409.1 ns |     25400 B |
| CompressAndDecompress | ZstdCompressor--5                | Large (20 KB)  | 5,021 bytes | 24.29 %          |     25,044.7 ns |     25224 B |
| CompressAndDecompress | ZstdCompressor--4                | Large (20 KB)  | 4,547 bytes | 21.99 %          |     27,403.6 ns |     25080 B |
| CompressAndDecompress | ZstdCompressor--3                | Large (20 KB)  | 4,258 bytes | 20.60 %          |     28,215.4 ns |     24968 B |
| CompressAndDecompress | ZstdCompressor--2                | Large (20 KB)  | 3,852 bytes | 18.63 %          |     29,196.9 ns |     24672 B |
| CompressAndDecompress | ZstdCompressor--1                | Large (20 KB)  | 3,622 bytes | 17.52 %          |     31,315.0 ns |     24528 B |
| CompressAndDecompress | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes | 15.87 %          |     43,482.9 ns |     24160 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdCompressor--19               | Large (20 KB)  | 7,998 bytes | 38.69 %          |      6,926.3 ns |     20776 B |
| Decompress            | ZstdCompressor--21               | Large (20 KB)  | 7,980 bytes | 38.60 %          |      6,812.4 ns |     20776 B |
| Decompress            | ZstdCompressor--18               | Large (20 KB)  | 7,911 bytes | 38.27 %          |      7,153.0 ns |     20776 B |
| Decompress            | ZstdCompressor--22               | Large (20 KB)  | 7,826 bytes | 37.86 %          |      6,969.1 ns |     20776 B |
| Decompress            | ZstdCompressor--20               | Large (20 KB)  | 7,785 bytes | 37.66 %          |      6,960.0 ns |     20776 B |
| Decompress            | ZstdCompressor--17               | Large (20 KB)  | 7,333 bytes | 35.47 %          |      7,015.6 ns |     20776 B |
| Decompress            | ZstdCompressor--13               | Large (20 KB)  | 6,901 bytes | 33.38 %          |      7,189.1 ns |     20776 B |
| Decompress            | ZstdCompressor--14               | Large (20 KB)  | 6,867 bytes | 33.22 %          |      7,181.4 ns |     20776 B |
| Decompress            | ZstdCompressor--16               | Large (20 KB)  | 6,852 bytes | 33.14 %          |      7,143.0 ns |     20776 B |
| Decompress            | ZstdCompressor--15               | Large (20 KB)  | 6,835 bytes | 33.06 %          |      7,122.5 ns |     20776 B |
| Decompress            | ZstdCompressor--11               | Large (20 KB)  | 6,620 bytes | 32.02 %          |      7,289.4 ns |     20776 B |
| Decompress            | ZstdCompressor--12               | Large (20 KB)  | 6,554 bytes | 31.70 %          |      7,208.4 ns |     20776 B |
| Decompress            | ZstdCompressor--10               | Large (20 KB)  | 6,389 bytes | 30.91 %          |      7,425.5 ns |     20776 B |
| Decompress            | ZstdCompressor--9                | Large (20 KB)  | 6,111 bytes | 29.56 %          |      7,328.5 ns |     20776 B |
| Decompress            | ZstdCompressor--8                | Large (20 KB)  | 5,806 bytes | 28.08 %          |      7,638.4 ns |     20776 B |
| Decompress            | ZstdCompressor--7                | Large (20 KB)  | 5,546 bytes | 26.83 %          |      7,742.6 ns |     20776 B |
| Decompress            | ZstdCompressor--6                | Large (20 KB)  | 5,233 bytes | 25.31 %          |      7,900.3 ns |     20776 B |
| Decompress            | ZstdCompressor--5                | Large (20 KB)  | 5,021 bytes | 24.29 %          |      7,839.3 ns |     20776 B |
| Decompress            | ZstdCompressor--4                | Large (20 KB)  | 4,547 bytes | 21.99 %          |      8,581.0 ns |     20776 B |
| Decompress            | ZstdCompressor--3                | Large (20 KB)  | 4,258 bytes | 20.60 %          |      8,558.6 ns |     20776 B |
| Decompress            | ZstdCompressor--2                | Large (20 KB)  | 3,852 bytes | 18.63 %          |      9,000.2 ns |     20776 B |
| Decompress            | ZstdCompressor--1                | Large (20 KB)  | 3,622 bytes | 17.52 %          |      9,331.5 ns |     20776 B |
| Decompress            | ZstdCompressor-1                 | Large (20 KB)  | 3,280 bytes | 15.87 %          |     13,191.4 ns |     20776 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes | 17.03 %          |      4,639.8 ns |      1808 B |
| Compress              | ZstdCompressor--19               | Medium (10 KB) | 1,627 bytes | 16.35 %          |      4,977.6 ns |      1768 B |
| Compress              | ZstdCompressor--21               | Medium (10 KB) | 1,603 bytes | 16.11 %          |      4,735.5 ns |      1648 B |
| Compress              | ZstdCompressor--20               | Medium (10 KB) | 1,512 bytes | 15.19 %          |      4,845.8 ns |      1632 B |
| Compress              | ZstdCompressor--18               | Medium (10 KB) | 1,496 bytes | 15.03 %          |      4,667.6 ns |      1584 B |
| Compress              | ZstdCompressor--15               | Medium (10 KB) | 1,375 bytes | 13.82 %          |      4,951.7 ns |      1416 B |
| Compress              | ZstdCompressor--17               | Medium (10 KB) | 1,373 bytes | 13.80 %          |      4,796.4 ns |      1504 B |
| Compress              | ZstdCompressor--16               | Medium (10 KB) | 1,330 bytes | 13.37 %          |      4,837.6 ns |      1424 B |
| Compress              | ZstdCompressor--13               | Medium (10 KB) | 1,303 bytes | 13.09 %          |      4,766.4 ns |      1360 B |
| Compress              | ZstdCompressor--12               | Medium (10 KB) | 1,302 bytes | 13.08 %          |      5,331.4 ns |      1352 B |
| Compress              | ZstdCompressor--14               | Medium (10 KB) | 1,294 bytes | 13.00 %          |      4,913.4 ns |      1384 B |
| Compress              | ZstdCompressor--11               | Medium (10 KB) | 1,251 bytes | 12.57 %          |      4,699.1 ns |      1360 B |
| Compress              | ZstdCompressor--10               | Medium (10 KB) | 1,228 bytes | 12.34 %          |      5,527.9 ns |      1320 B |
| Compress              | ZstdCompressor--9                | Medium (10 KB) | 1,110 bytes | 11.15 %          |      4,955.4 ns |      1256 B |
| Compress              | ZstdCompressor--5                | Medium (10 KB) | 1,105 bytes | 11.10 %          |      5,505.2 ns |      1256 B |
| Compress              | ZstdCompressor--6                | Medium (10 KB) | 1,066 bytes | 10.71 %          |      5,027.7 ns |      1176 B |
| Compress              | ZstdCompressor--8                | Medium (10 KB) | 1,058 bytes | 10.63 %          |      5,019.6 ns |      1144 B |
| Compress              | ZstdCompressor--7                | Medium (10 KB) | 995 bytes   | 10.00 %          |      4,987.6 ns |      1096 B |
| Compress              | ZstdCompressor--4                | Medium (10 KB) | 921 bytes   | 9.26 %           |      5,668.4 ns |      1024 B |
| Compress              | ZstdCompressor--3                | Medium (10 KB) | 876 bytes   | 8.80 %           |      5,462.5 ns |       984 B |
| Compress              | ZstdCompressor--2                | Medium (10 KB) | 860 bytes   | 8.64 %           |      5,894.8 ns |       968 B |
| Compress              | ZstdCompressor--1                | Medium (10 KB) | 860 bytes   | 8.64 %           |      6,101.0 ns |       968 B |
| Compress              | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes   | 7.71 %           |     11,581.4 ns |       872 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes | 17.03 %          |      8,330.0 ns |     11856 B |
| CompressAndDecompress | ZstdCompressor--19               | Medium (10 KB) | 1,627 bytes | 16.35 %          |      8,674.4 ns |     11816 B |
| CompressAndDecompress | ZstdCompressor--21               | Medium (10 KB) | 1,603 bytes | 16.11 %          |      8,491.7 ns |     11696 B |
| CompressAndDecompress | ZstdCompressor--20               | Medium (10 KB) | 1,512 bytes | 15.19 %          |      8,735.2 ns |     11680 B |
| CompressAndDecompress | ZstdCompressor--18               | Medium (10 KB) | 1,496 bytes | 15.03 %          |      8,426.0 ns |     11632 B |
| CompressAndDecompress | ZstdCompressor--15               | Medium (10 KB) | 1,375 bytes | 13.82 %          |      8,583.9 ns |     11464 B |
| CompressAndDecompress | ZstdCompressor--17               | Medium (10 KB) | 1,373 bytes | 13.80 %          |      8,707.4 ns |     11552 B |
| CompressAndDecompress | ZstdCompressor--16               | Medium (10 KB) | 1,330 bytes | 13.37 %          |      8,313.8 ns |     11472 B |
| CompressAndDecompress | ZstdCompressor--13               | Medium (10 KB) | 1,303 bytes | 13.09 %          |      8,539.2 ns |     11408 B |
| CompressAndDecompress | ZstdCompressor--12               | Medium (10 KB) | 1,302 bytes | 13.08 %          |      9,304.1 ns |     11400 B |
| CompressAndDecompress | ZstdCompressor--14               | Medium (10 KB) | 1,294 bytes | 13.00 %          |      8,743.3 ns |     11432 B |
| CompressAndDecompress | ZstdCompressor--11               | Medium (10 KB) | 1,251 bytes | 12.57 %          |      8,426.4 ns |     11408 B |
| CompressAndDecompress | ZstdCompressor--10               | Medium (10 KB) | 1,228 bytes | 12.34 %          |      9,269.1 ns |     11368 B |
| CompressAndDecompress | ZstdCompressor--9                | Medium (10 KB) | 1,110 bytes | 11.15 %          |      8,761.9 ns |     11304 B |
| CompressAndDecompress | ZstdCompressor--5                | Medium (10 KB) | 1,105 bytes | 11.10 %          |      9,722.8 ns |     11304 B |
| CompressAndDecompress | ZstdCompressor--6                | Medium (10 KB) | 1,066 bytes | 10.71 %          |      8,935.0 ns |     11224 B |
| CompressAndDecompress | ZstdCompressor--8                | Medium (10 KB) | 1,058 bytes | 10.63 %          |      8,824.6 ns |     11192 B |
| CompressAndDecompress | ZstdCompressor--7                | Medium (10 KB) | 995 bytes   | 10.00 %          |      8,875.5 ns |     11144 B |
| CompressAndDecompress | ZstdCompressor--4                | Medium (10 KB) | 921 bytes   | 9.26 %           |      9,691.8 ns |     11072 B |
| CompressAndDecompress | ZstdCompressor--3                | Medium (10 KB) | 876 bytes   | 8.80 %           |      9,568.5 ns |     11032 B |
| CompressAndDecompress | ZstdCompressor--2                | Medium (10 KB) | 860 bytes   | 8.64 %           |     10,147.7 ns |     11016 B |
| CompressAndDecompress | ZstdCompressor--1                | Medium (10 KB) | 860 bytes   | 8.64 %           |     10,407.4 ns |     11016 B |
| CompressAndDecompress | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes   | 7.71 %           |     18,413.6 ns |     10920 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdCompressor--22               | Medium (10 KB) | 1,695 bytes | 17.03 %          |      2,675.9 ns |     10048 B |
| Decompress            | ZstdCompressor--19               | Medium (10 KB) | 1,627 bytes | 16.35 %          |      2,752.9 ns |     10048 B |
| Decompress            | ZstdCompressor--21               | Medium (10 KB) | 1,603 bytes | 16.11 %          |      2,638.0 ns |     10048 B |
| Decompress            | ZstdCompressor--20               | Medium (10 KB) | 1,512 bytes | 15.19 %          |      2,797.6 ns |     10048 B |
| Decompress            | ZstdCompressor--18               | Medium (10 KB) | 1,496 bytes | 15.03 %          |      2,722.8 ns |     10048 B |
| Decompress            | ZstdCompressor--15               | Medium (10 KB) | 1,375 bytes | 13.82 %          |      2,868.7 ns |     10048 B |
| Decompress            | ZstdCompressor--17               | Medium (10 KB) | 1,373 bytes | 13.80 %          |      2,707.3 ns |     10048 B |
| Decompress            | ZstdCompressor--16               | Medium (10 KB) | 1,330 bytes | 13.37 %          |      2,694.0 ns |     10048 B |
| Decompress            | ZstdCompressor--13               | Medium (10 KB) | 1,303 bytes | 13.09 %          |      2,810.6 ns |     10048 B |
| Decompress            | ZstdCompressor--12               | Medium (10 KB) | 1,302 bytes | 13.08 %          |      2,998.0 ns |     10048 B |
| Decompress            | ZstdCompressor--14               | Medium (10 KB) | 1,294 bytes | 13.00 %          |      2,822.4 ns |     10048 B |
| Decompress            | ZstdCompressor--11               | Medium (10 KB) | 1,251 bytes | 12.57 %          |      2,662.5 ns |     10048 B |
| Decompress            | ZstdCompressor--10               | Medium (10 KB) | 1,228 bytes | 12.34 %          |      2,928.0 ns |     10048 B |
| Decompress            | ZstdCompressor--9                | Medium (10 KB) | 1,110 bytes | 11.15 %          |      2,937.9 ns |     10048 B |
| Decompress            | ZstdCompressor--5                | Medium (10 KB) | 1,105 bytes | 11.10 %          |      3,085.6 ns |     10048 B |
| Decompress            | ZstdCompressor--6                | Medium (10 KB) | 1,066 bytes | 10.71 %          |      2,812.1 ns |     10048 B |
| Decompress            | ZstdCompressor--8                | Medium (10 KB) | 1,058 bytes | 10.63 %          |      2,832.0 ns |     10048 B |
| Decompress            | ZstdCompressor--7                | Medium (10 KB) | 995 bytes   | 10.00 %          |      2,785.5 ns |     10048 B |
| Decompress            | ZstdCompressor--4                | Medium (10 KB) | 921 bytes   | 9.26 %           |      3,134.5 ns |     10048 B |
| Decompress            | ZstdCompressor--3                | Medium (10 KB) | 876 bytes   | 8.80 %           |      3,070.2 ns |     10048 B |
| Decompress            | ZstdCompressor--2                | Medium (10 KB) | 860 bytes   | 8.64 %           |      3,074.1 ns |     10048 B |
| Decompress            | ZstdCompressor--1                | Medium (10 KB) | 860 bytes   | 8.64 %           |      3,096.5 ns |     10048 B |
| Decompress            | ZstdCompressor-1                 | Medium (10 KB) | 767 bytes   | 7.71 %           |      5,408.7 ns |     10048 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | ZstdCompressor--9                | Small (190 B)  | 199 bytes   | 104.74 %         |      2,606.3 ns |       304 B |
| Compress              | ZstdCompressor--6                | Small (190 B)  | 199 bytes   | 104.74 %         |      2,621.8 ns |       304 B |
| Compress              | ZstdCompressor--5                | Small (190 B)  | 199 bytes   | 104.74 %         |      2,044.4 ns |       304 B |
| Compress              | ZstdCompressor--4                | Small (190 B)  | 199 bytes   | 104.74 %         |      2,598.6 ns |       304 B |
| Compress              | ZstdCompressor--22               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,981.4 ns |       304 B |
| Compress              | ZstdCompressor--21               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,934.3 ns |       304 B |
| Compress              | ZstdCompressor--20               | Small (190 B)  | 199 bytes   | 104.74 %         |      2,007.4 ns |       304 B |
| Compress              | ZstdCompressor--19               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,952.5 ns |       304 B |
| Compress              | ZstdCompressor--18               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,972.0 ns |       304 B |
| Compress              | ZstdCompressor--17               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,953.7 ns |       304 B |
| Compress              | ZstdCompressor--16               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,946.1 ns |       304 B |
| Compress              | ZstdCompressor--15               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,954.6 ns |       304 B |
| Compress              | ZstdCompressor--14               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,963.6 ns |       304 B |
| Compress              | ZstdCompressor--13               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,987.1 ns |       304 B |
| Compress              | ZstdCompressor--12               | Small (190 B)  | 199 bytes   | 104.74 %         |      2,028.2 ns |       304 B |
| Compress              | ZstdCompressor--11               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,979.1 ns |       304 B |
| Compress              | ZstdCompressor--10               | Small (190 B)  | 199 bytes   | 104.74 %         |      2,624.6 ns |       304 B |
| Compress              | ZstdCompressor--7                | Small (190 B)  | 194 bytes   | 102.11 %         |      2,653.4 ns |       296 B |
| Compress              | ZstdCompressor--3                | Small (190 B)  | 194 bytes   | 102.11 %         |      2,658.6 ns |       296 B |
| Compress              | ZstdCompressor--8                | Small (190 B)  | 191 bytes   | 100.53 %         |      2,512.9 ns |       296 B |
| Compress              | ZstdCompressor--2                | Small (190 B)  | 182 bytes   | 95.79 %          |      2,761.5 ns |       288 B |
| Compress              | ZstdCompressor--1                | Small (190 B)  | 178 bytes   | 93.68 %          |      2,841.2 ns |       288 B |
| Compress              | ZstdCompressor-1                 | Small (190 B)  | 178 bytes   | 93.68 %          |      6,458.9 ns |       288 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdCompressor--9                | Small (190 B)  | 199 bytes   | 104.74 %         |      4,648.3 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--6                | Small (190 B)  | 199 bytes   | 104.74 %         |      4,558.0 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--5                | Small (190 B)  | 199 bytes   | 104.74 %         |      3,920.7 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--4                | Small (190 B)  | 199 bytes   | 104.74 %         |      4,738.8 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--22               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,847.6 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--21               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,821.4 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--20               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,812.2 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--19               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,821.7 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--18               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,841.6 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--17               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,770.2 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--16               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,781.3 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--15               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,812.8 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--14               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,871.6 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--13               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,829.6 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--12               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,894.4 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--11               | Small (190 B)  | 199 bytes   | 104.74 %         |      3,823.4 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--10               | Small (190 B)  | 199 bytes   | 104.74 %         |      4,598.8 ns |       592 B |
| CompressAndDecompress | ZstdCompressor--7                | Small (190 B)  | 194 bytes   | 102.11 %         |      4,667.8 ns |       584 B |
| CompressAndDecompress | ZstdCompressor--3                | Small (190 B)  | 194 bytes   | 102.11 %         |      4,754.3 ns |       584 B |
| CompressAndDecompress | ZstdCompressor--8                | Small (190 B)  | 191 bytes   | 100.53 %         |      4,711.1 ns |       584 B |
| CompressAndDecompress | ZstdCompressor--2                | Small (190 B)  | 182 bytes   | 95.79 %          |      4,977.4 ns |       576 B |
| CompressAndDecompress | ZstdCompressor--1                | Small (190 B)  | 178 bytes   | 93.68 %          |      5,033.3 ns |       576 B |
| CompressAndDecompress | ZstdCompressor-1                 | Small (190 B)  | 178 bytes   | 93.68 %          |      8,979.7 ns |       576 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdCompressor--9                | Small (190 B)  | 199 bytes   | 104.74 %         |      1,507.6 ns |       288 B |
| Decompress            | ZstdCompressor--6                | Small (190 B)  | 199 bytes   | 104.74 %         |      1,512.2 ns |       288 B |
| Decompress            | ZstdCompressor--5                | Small (190 B)  | 199 bytes   | 104.74 %         |      1,504.3 ns |       288 B |
| Decompress            | ZstdCompressor--4                | Small (190 B)  | 199 bytes   | 104.74 %         |      1,627.4 ns |       288 B |
| Decompress            | ZstdCompressor--22               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,503.9 ns |       288 B |
| Decompress            | ZstdCompressor--21               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,494.5 ns |       288 B |
| Decompress            | ZstdCompressor--20               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,510.5 ns |       288 B |
| Decompress            | ZstdCompressor--19               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,500.2 ns |       288 B |
| Decompress            | ZstdCompressor--18               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,508.4 ns |       288 B |
| Decompress            | ZstdCompressor--17               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,492.4 ns |       288 B |
| Decompress            | ZstdCompressor--16               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,498.1 ns |       288 B |
| Decompress            | ZstdCompressor--15               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,527.0 ns |       288 B |
| Decompress            | ZstdCompressor--14               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,493.9 ns |       288 B |
| Decompress            | ZstdCompressor--13               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,507.4 ns |       288 B |
| Decompress            | ZstdCompressor--12               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,531.0 ns |       288 B |
| Decompress            | ZstdCompressor--11               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,501.3 ns |       288 B |
| Decompress            | ZstdCompressor--10               | Small (190 B)  | 199 bytes   | 104.74 %         |      1,512.9 ns |       288 B |
| Decompress            | ZstdCompressor--7                | Small (190 B)  | 194 bytes   | 102.11 %         |      1,607.6 ns |       288 B |
| Decompress            | ZstdCompressor--3                | Small (190 B)  | 194 bytes   | 102.11 %         |      1,630.2 ns |       288 B |
| Decompress            | ZstdCompressor--8                | Small (190 B)  | 191 bytes   | 100.53 %         |      1,598.3 ns |       288 B |
| Decompress            | ZstdCompressor--2                | Small (190 B)  | 182 bytes   | 95.79 %          |      1,639.8 ns |       288 B |
| Decompress            | ZstdCompressor--1                | Small (190 B)  | 178 bytes   | 93.68 %          |      1,648.1 ns |       288 B |
| Decompress            | ZstdCompressor-1                 | Small (190 B)  | 178 bytes   | 93.68 %          |      1,668.8 ns |       288 B |
|                       |                                  |                |             |                  |                 |             |






| Compress              | ZstdSharpCompressor--19          | Large (20 KB)  | 7,998 bytes | 38.69 %          |     11,081.6 ns |     28888 B |
| Compress              | ZstdSharpCompressor--21          | Large (20 KB)  | 7,980 bytes | 38.60 %          |     10,374.3 ns |     28872 B |
| Compress              | ZstdSharpCompressor--18          | Large (20 KB)  | 7,911 bytes | 38.27 %          |     11,345.9 ns |     28800 B |
| Compress              | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes | 37.86 %          |     10,497.4 ns |     28720 B |
| Compress              | ZstdSharpCompressor--20          | Large (20 KB)  | 7,785 bytes | 37.66 %          |     11,047.4 ns |     28680 B |
| Compress              | ZstdSharpCompressor--17          | Large (20 KB)  | 7,333 bytes | 35.47 %          |     12,192.4 ns |     28224 B |
| Compress              | ZstdSharpCompressor--13          | Large (20 KB)  | 6,901 bytes | 33.38 %          |     12,045.6 ns |     27792 B |
| Compress              | ZstdSharpCompressor--14          | Large (20 KB)  | 6,867 bytes | 33.22 %          |     11,770.6 ns |     27760 B |
| Compress              | ZstdSharpCompressor--16          | Large (20 KB)  | 6,852 bytes | 33.14 %          |     11,709.2 ns |     27744 B |
| Compress              | ZstdSharpCompressor--15          | Large (20 KB)  | 6,835 bytes | 33.06 %          |     11,334.6 ns |     27728 B |
| Compress              | ZstdSharpCompressor--11          | Large (20 KB)  | 6,620 bytes | 32.02 %          |     12,537.4 ns |     27512 B |
| Compress              | ZstdSharpCompressor--12          | Large (20 KB)  | 6,554 bytes | 31.70 %          |     13,095.6 ns |     27448 B |
| Compress              | ZstdSharpCompressor--10          | Large (20 KB)  | 6,389 bytes | 30.91 %          |     12,497.3 ns |     27280 B |
| Compress              | ZstdSharpCompressor--9           | Large (20 KB)  | 6,111 bytes | 29.56 %          |     13,470.2 ns |     27000 B |
| Compress              | ZstdSharpCompressor--8           | Large (20 KB)  | 5,806 bytes | 28.08 %          |     13,797.6 ns |     26696 B |
| Compress              | ZstdSharpCompressor--7           | Large (20 KB)  | 5,546 bytes | 26.83 %          |     13,943.1 ns |     26440 B |
| Compress              | ZstdSharpCompressor--6           | Large (20 KB)  | 5,233 bytes | 25.31 %          |     14,251.4 ns |     26128 B |
| Compress              | ZstdSharpCompressor--5           | Large (20 KB)  | 5,021 bytes | 24.29 %          |     14,666.7 ns |     25912 B |
| Compress              | ZstdSharpCompressor--4           | Large (20 KB)  | 4,547 bytes | 21.99 %          |     14,971.9 ns |     25440 B |
| Compress              | ZstdSharpCompressor--3           | Large (20 KB)  | 4,258 bytes | 20.60 %          |     16,618.4 ns |     25152 B |
| Compress              | ZstdSharpCompressor--2           | Large (20 KB)  | 3,852 bytes | 18.63 %          |     17,540.5 ns |     24744 B |
| Compress              | ZstdSharpCompressor--1           | Large (20 KB)  | 3,622 bytes | 17.52 %          |     20,137.4 ns |     24512 B |
| Compress              | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes | 15.87 %          |     30,976.4 ns |     24168 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--19          | Large (20 KB)  | 7,998 bytes | 38.69 %          |     17,969.2 ns |     49616 B |
| CompressAndDecompress | ZstdSharpCompressor--21          | Large (20 KB)  | 7,980 bytes | 38.60 %          |     16,446.9 ns |     49600 B |
| CompressAndDecompress | ZstdSharpCompressor--18          | Large (20 KB)  | 7,911 bytes | 38.27 %          |     18,409.5 ns |     49528 B |
| CompressAndDecompress | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes | 37.86 %          |     17,589.5 ns |     49448 B |
| CompressAndDecompress | ZstdSharpCompressor--20          | Large (20 KB)  | 7,785 bytes | 37.66 %          |     17,271.3 ns |     49408 B |
| CompressAndDecompress | ZstdSharpCompressor--17          | Large (20 KB)  | 7,333 bytes | 35.47 %          |     18,424.3 ns |     48952 B |
| CompressAndDecompress | ZstdSharpCompressor--13          | Large (20 KB)  | 6,901 bytes | 33.38 %          |     20,114.4 ns |     48520 B |
| CompressAndDecompress | ZstdSharpCompressor--14          | Large (20 KB)  | 6,867 bytes | 33.22 %          |     18,591.5 ns |     48488 B |
| CompressAndDecompress | ZstdSharpCompressor--16          | Large (20 KB)  | 6,852 bytes | 33.14 %          |     18,588.4 ns |     48472 B |
| CompressAndDecompress | ZstdSharpCompressor--15          | Large (20 KB)  | 6,835 bytes | 33.06 %          |     18,119.8 ns |     48456 B |
| CompressAndDecompress | ZstdSharpCompressor--11          | Large (20 KB)  | 6,620 bytes | 32.02 %          |     19,982.4 ns |     48240 B |
| CompressAndDecompress | ZstdSharpCompressor--12          | Large (20 KB)  | 6,554 bytes | 31.70 %          |     19,532.4 ns |     48176 B |
| CompressAndDecompress | ZstdSharpCompressor--10          | Large (20 KB)  | 6,389 bytes | 30.91 %          |     19,730.2 ns |     48008 B |
| CompressAndDecompress | ZstdSharpCompressor--9           | Large (20 KB)  | 6,111 bytes | 29.56 %          |     21,140.4 ns |     47728 B |
| CompressAndDecompress | ZstdSharpCompressor--8           | Large (20 KB)  | 5,806 bytes | 28.08 %          |     21,586.6 ns |     47424 B |
| CompressAndDecompress | ZstdSharpCompressor--7           | Large (20 KB)  | 5,546 bytes | 26.83 %          |     22,028.3 ns |     47168 B |
| CompressAndDecompress | ZstdSharpCompressor--6           | Large (20 KB)  | 5,233 bytes | 25.31 %          |     22,310.0 ns |     46856 B |
| CompressAndDecompress | ZstdSharpCompressor--5           | Large (20 KB)  | 5,021 bytes | 24.29 %          |     23,333.7 ns |     46640 B |
| CompressAndDecompress | ZstdSharpCompressor--4           | Large (20 KB)  | 4,547 bytes | 21.99 %          |     25,001.7 ns |     46168 B |
| CompressAndDecompress | ZstdSharpCompressor--3           | Large (20 KB)  | 4,258 bytes | 20.60 %          |     26,718.9 ns |     45880 B |
| CompressAndDecompress | ZstdSharpCompressor--2           | Large (20 KB)  | 3,852 bytes | 18.63 %          |     27,486.0 ns |     45472 B |
| CompressAndDecompress | ZstdSharpCompressor--1           | Large (20 KB)  | 3,622 bytes | 17.52 %          |     29,964.6 ns |     45240 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes | 15.87 %          |     45,769.3 ns |     44896 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdSharpCompressor--19          | Large (20 KB)  | 7,998 bytes | 38.69 %          |      6,512.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--21          | Large (20 KB)  | 7,980 bytes | 38.60 %          |      5,990.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--18          | Large (20 KB)  | 7,911 bytes | 38.27 %          |      6,811.7 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--22          | Large (20 KB)  | 7,826 bytes | 37.86 %          |      6,045.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--20          | Large (20 KB)  | 7,785 bytes | 37.66 %          |      6,051.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--17          | Large (20 KB)  | 7,333 bytes | 35.47 %          |      6,478.2 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--13          | Large (20 KB)  | 6,901 bytes | 33.38 %          |      6,728.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--14          | Large (20 KB)  | 6,867 bytes | 33.22 %          |      6,376.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--16          | Large (20 KB)  | 6,852 bytes | 33.14 %          |      6,316.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--15          | Large (20 KB)  | 6,835 bytes | 33.06 %          |      6,393.0 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--11          | Large (20 KB)  | 6,620 bytes | 32.02 %          |      6,869.9 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--12          | Large (20 KB)  | 6,554 bytes | 31.70 %          |      6,867.5 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--10          | Large (20 KB)  | 6,389 bytes | 30.91 %          |      6,723.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--9           | Large (20 KB)  | 6,111 bytes | 29.56 %          |      7,168.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--8           | Large (20 KB)  | 5,806 bytes | 28.08 %          |      7,288.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--7           | Large (20 KB)  | 5,546 bytes | 26.83 %          |      7,416.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--6           | Large (20 KB)  | 5,233 bytes | 25.31 %          |      7,467.8 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--5           | Large (20 KB)  | 5,021 bytes | 24.29 %          |      7,793.6 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--4           | Large (20 KB)  | 4,547 bytes | 21.99 %          |      7,921.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--3           | Large (20 KB)  | 4,258 bytes | 20.60 %          |      9,683.3 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--2           | Large (20 KB)  | 3,852 bytes | 18.63 %          |      9,283.1 ns |     20728 B |
| Decompress            | ZstdSharpCompressor--1           | Large (20 KB)  | 3,622 bytes | 17.52 %          |      9,827.4 ns |     20728 B |
| Decompress            | ZstdSharpCompressor-1            | Large (20 KB)  | 3,280 bytes | 15.87 %          |     13,723.9 ns |     20728 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes | 17.03 %          |      4,022.0 ns |     11824 B |
| Compress              | ZstdSharpCompressor--19          | Medium (10 KB) | 1,627 bytes | 16.35 %          |      4,691.7 ns |     11760 B |
| Compress              | ZstdSharpCompressor--21          | Medium (10 KB) | 1,603 bytes | 16.11 %          |      4,006.8 ns |     11736 B |
| Compress              | ZstdSharpCompressor--20          | Medium (10 KB) | 1,512 bytes | 15.19 %          |      4,687.9 ns |     11640 B |
| Compress              | ZstdSharpCompressor--18          | Medium (10 KB) | 1,496 bytes | 15.03 %          |      4,740.4 ns |     11624 B |
| Compress              | ZstdSharpCompressor--15          | Medium (10 KB) | 1,375 bytes | 13.82 %          |      4,381.8 ns |     11504 B |
| Compress              | ZstdSharpCompressor--17          | Medium (10 KB) | 1,373 bytes | 13.80 %          |      4,671.3 ns |     11504 B |
| Compress              | ZstdSharpCompressor--16          | Medium (10 KB) | 1,330 bytes | 13.37 %          |      4,497.4 ns |     11464 B |
| Compress              | ZstdSharpCompressor--13          | Medium (10 KB) | 1,303 bytes | 13.09 %          |      4,117.9 ns |     11432 B |
| Compress              | ZstdSharpCompressor--12          | Medium (10 KB) | 1,302 bytes | 13.08 %          |      4,529.7 ns |     11432 B |
| Compress              | ZstdSharpCompressor--14          | Medium (10 KB) | 1,294 bytes | 13.00 %          |      4,404.0 ns |     11424 B |
| Compress              | ZstdSharpCompressor--11          | Medium (10 KB) | 1,251 bytes | 12.57 %          |      4,190.4 ns |     11384 B |
| Compress              | ZstdSharpCompressor--10          | Medium (10 KB) | 1,228 bytes | 12.34 %          |      5,046.3 ns |     11360 B |
| Compress              | ZstdSharpCompressor--9           | Medium (10 KB) | 1,110 bytes | 11.15 %          |      4,489.8 ns |     11240 B |
| Compress              | ZstdSharpCompressor--5           | Medium (10 KB) | 1,105 bytes | 11.10 %          |      5,242.7 ns |     11240 B |
| Compress              | ZstdSharpCompressor--6           | Medium (10 KB) | 1,066 bytes | 10.71 %          |      4,826.8 ns |     11200 B |
| Compress              | ZstdSharpCompressor--8           | Medium (10 KB) | 1,058 bytes | 10.63 %          |      4,676.0 ns |     11192 B |
| Compress              | ZstdSharpCompressor--7           | Medium (10 KB) | 995 bytes   | 10.00 %          |      4,486.1 ns |     11128 B |
| Compress              | ZstdSharpCompressor--4           | Medium (10 KB) | 921 bytes   | 9.26 %           |      5,489.2 ns |     11056 B |
| Compress              | ZstdSharpCompressor--3           | Medium (10 KB) | 876 bytes   | 8.80 %           |      4,930.8 ns |     11008 B |
| Compress              | ZstdSharpCompressor--2           | Medium (10 KB) | 860 bytes   | 8.64 %           |      5,722.9 ns |     10992 B |
| Compress              | ZstdSharpCompressor--1           | Medium (10 KB) | 860 bytes   | 8.64 %           |      5,580.3 ns |     10992 B |
| Compress              | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes   | 7.71 %           |     12,428.9 ns |     10896 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes | 17.03 %          |      6,212.3 ns |     21824 B |
| CompressAndDecompress | ZstdSharpCompressor--19          | Medium (10 KB) | 1,627 bytes | 16.35 %          |      6,553.1 ns |     21760 B |
| CompressAndDecompress | ZstdSharpCompressor--21          | Medium (10 KB) | 1,603 bytes | 16.11 %          |      5,950.9 ns |     21736 B |
| CompressAndDecompress | ZstdSharpCompressor--20          | Medium (10 KB) | 1,512 bytes | 15.19 %          |      6,376.3 ns |     21640 B |
| CompressAndDecompress | ZstdSharpCompressor--18          | Medium (10 KB) | 1,496 bytes | 15.03 %          |      6,350.3 ns |     21624 B |
| CompressAndDecompress | ZstdSharpCompressor--15          | Medium (10 KB) | 1,375 bytes | 13.82 %          |      6,252.2 ns |     21504 B |
| CompressAndDecompress | ZstdSharpCompressor--17          | Medium (10 KB) | 1,373 bytes | 13.80 %          |      6,471.2 ns |     21504 B |
| CompressAndDecompress | ZstdSharpCompressor--16          | Medium (10 KB) | 1,330 bytes | 13.37 %          |      6,500.8 ns |     21464 B |
| CompressAndDecompress | ZstdSharpCompressor--13          | Medium (10 KB) | 1,303 bytes | 13.09 %          |      6,167.1 ns |     21432 B |
| CompressAndDecompress | ZstdSharpCompressor--12          | Medium (10 KB) | 1,302 bytes | 13.08 %          |      6,439.2 ns |     21432 B |
| CompressAndDecompress | ZstdSharpCompressor--14          | Medium (10 KB) | 1,294 bytes | 13.00 %          |      6,322.0 ns |     21424 B |
| CompressAndDecompress | ZstdSharpCompressor--11          | Medium (10 KB) | 1,251 bytes | 12.57 %          |      6,206.2 ns |     21384 B |
| CompressAndDecompress | ZstdSharpCompressor--10          | Medium (10 KB) | 1,228 bytes | 12.34 %          |      7,175.5 ns |     21360 B |
| CompressAndDecompress | ZstdSharpCompressor--9           | Medium (10 KB) | 1,110 bytes | 11.15 %          |      6,601.9 ns |     21240 B |
| CompressAndDecompress | ZstdSharpCompressor--5           | Medium (10 KB) | 1,105 bytes | 11.10 %          |      7,345.9 ns |     21240 B |
| CompressAndDecompress | ZstdSharpCompressor--6           | Medium (10 KB) | 1,066 bytes | 10.71 %          |      7,075.6 ns |     21200 B |
| CompressAndDecompress | ZstdSharpCompressor--8           | Medium (10 KB) | 1,058 bytes | 10.63 %          |      6,888.5 ns |     21192 B |
| CompressAndDecompress | ZstdSharpCompressor--7           | Medium (10 KB) | 995 bytes   | 10.00 %          |      6,508.7 ns |     21128 B |
| CompressAndDecompress | ZstdSharpCompressor--4           | Medium (10 KB) | 921 bytes   | 9.26 %           |      8,258.6 ns |     21056 B |
| CompressAndDecompress | ZstdSharpCompressor--3           | Medium (10 KB) | 876 bytes   | 8.80 %           |      7,553.5 ns |     21008 B |
| CompressAndDecompress | ZstdSharpCompressor--2           | Medium (10 KB) | 860 bytes   | 8.64 %           |      7,598.2 ns |     20992 B |
| CompressAndDecompress | ZstdSharpCompressor--1           | Medium (10 KB) | 860 bytes   | 8.64 %           |      7,927.4 ns |     20992 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes   | 7.71 %           |     18,043.9 ns |     20896 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdSharpCompressor--22          | Medium (10 KB) | 1,695 bytes | 17.03 %          |      1,392.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--19          | Medium (10 KB) | 1,627 bytes | 16.35 %          |      1,622.4 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--21          | Medium (10 KB) | 1,603 bytes | 16.11 %          |      1,441.9 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--20          | Medium (10 KB) | 1,512 bytes | 15.19 %          |      1,621.9 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--18          | Medium (10 KB) | 1,496 bytes | 15.03 %          |      1,510.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--15          | Medium (10 KB) | 1,375 bytes | 13.82 %          |      1,501.9 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--17          | Medium (10 KB) | 1,373 bytes | 13.80 %          |      1,554.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--16          | Medium (10 KB) | 1,330 bytes | 13.37 %          |      1,496.3 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--13          | Medium (10 KB) | 1,303 bytes | 13.09 %          |      1,526.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--12          | Medium (10 KB) | 1,302 bytes | 13.08 %          |      1,596.6 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--14          | Medium (10 KB) | 1,294 bytes | 13.00 %          |      1,605.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--11          | Medium (10 KB) | 1,251 bytes | 12.57 %          |      1,414.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--10          | Medium (10 KB) | 1,228 bytes | 12.34 %          |      1,869.8 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--9           | Medium (10 KB) | 1,110 bytes | 11.15 %          |      1,623.2 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--5           | Medium (10 KB) | 1,105 bytes | 11.10 %          |      1,926.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--6           | Medium (10 KB) | 1,066 bytes | 10.71 %          |      1,815.5 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--8           | Medium (10 KB) | 1,058 bytes | 10.63 %          |      1,473.1 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--7           | Medium (10 KB) | 995 bytes   | 10.00 %          |      1,645.3 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--4           | Medium (10 KB) | 921 bytes   | 9.26 %           |      1,952.3 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--3           | Medium (10 KB) | 876 bytes   | 8.80 %           |      1,864.7 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--2           | Medium (10 KB) | 860 bytes   | 8.64 %           |      1,951.0 ns |     10000 B |
| Decompress            | ZstdSharpCompressor--1           | Medium (10 KB) | 860 bytes   | 8.64 %           |      2,020.4 ns |     10000 B |
| Decompress            | ZstdSharpCompressor-1            | Medium (10 KB) | 767 bytes   | 7.71 %           |      5,226.6 ns |     10000 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | ZstdSharpCompressor--9           | Small (190 B)  | 199 bytes   | 104.74 %         |      1,593.0 ns |       536 B |
| Compress              | ZstdSharpCompressor--6           | Small (190 B)  | 199 bytes   | 104.74 %         |      1,596.7 ns |       536 B |
| Compress              | ZstdSharpCompressor--5           | Small (190 B)  | 199 bytes   | 104.74 %         |        753.8 ns |       536 B |
| Compress              | ZstdSharpCompressor--4           | Small (190 B)  | 199 bytes   | 104.74 %         |      1,631.9 ns |       536 B |
| Compress              | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,518.8 ns |       536 B |
| Compress              | ZstdSharpCompressor--21          | Small (190 B)  | 199 bytes   | 104.74 %         |        753.3 ns |       536 B |
| Compress              | ZstdSharpCompressor--20          | Small (190 B)  | 199 bytes   | 104.74 %         |        735.9 ns |       536 B |
| Compress              | ZstdSharpCompressor--19          | Small (190 B)  | 199 bytes   | 104.74 %         |        691.7 ns |       536 B |
| Compress              | ZstdSharpCompressor--18          | Small (190 B)  | 199 bytes   | 104.74 %         |        767.7 ns |       536 B |
| Compress              | ZstdSharpCompressor--17          | Small (190 B)  | 199 bytes   | 104.74 %         |        719.7 ns |       536 B |
| Compress              | ZstdSharpCompressor--16          | Small (190 B)  | 199 bytes   | 104.74 %         |        765.4 ns |       536 B |
| Compress              | ZstdSharpCompressor--15          | Small (190 B)  | 199 bytes   | 104.74 %         |        755.3 ns |       536 B |
| Compress              | ZstdSharpCompressor--14          | Small (190 B)  | 199 bytes   | 104.74 %         |        751.2 ns |       536 B |
| Compress              | ZstdSharpCompressor--13          | Small (190 B)  | 199 bytes   | 104.74 %         |        761.6 ns |       536 B |
| Compress              | ZstdSharpCompressor--12          | Small (190 B)  | 199 bytes   | 104.74 %         |        758.0 ns |       536 B |
| Compress              | ZstdSharpCompressor--11          | Small (190 B)  | 199 bytes   | 104.74 %         |        745.9 ns |       536 B |
| Compress              | ZstdSharpCompressor--10          | Small (190 B)  | 199 bytes   | 104.74 %         |        743.2 ns |       536 B |
| Compress              | ZstdSharpCompressor--7           | Small (190 B)  | 194 bytes   | 102.11 %         |      1,587.7 ns |       536 B |
| Compress              | ZstdSharpCompressor--3           | Small (190 B)  | 194 bytes   | 102.11 %         |      1,695.3 ns |       536 B |
| Compress              | ZstdSharpCompressor--8           | Small (190 B)  | 191 bytes   | 100.53 %         |      1,670.3 ns |       528 B |
| Compress              | ZstdSharpCompressor--2           | Small (190 B)  | 182 bytes   | 95.79 %          |      1,765.3 ns |       520 B |
| Compress              | ZstdSharpCompressor--1           | Small (190 B)  | 178 bytes   | 93.68 %          |      1,852.1 ns |       520 B |
| Compress              | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes   | 93.68 %          |      5,651.1 ns |       520 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | ZstdSharpCompressor--9           | Small (190 B)  | 199 bytes   | 104.74 %         |      2,060.6 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--6           | Small (190 B)  | 199 bytes   | 104.74 %         |      1,966.6 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--5           | Small (190 B)  | 199 bytes   | 104.74 %         |      1,159.6 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--4           | Small (190 B)  | 199 bytes   | 104.74 %         |      2,083.7 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,885.4 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--21          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,098.3 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--20          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,097.6 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--19          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,061.1 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--18          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,056.8 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--17          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,053.2 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--16          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,117.8 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--15          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,054.0 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--14          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,150.4 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--13          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,069.1 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--12          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,104.8 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--11          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,148.0 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--10          | Small (190 B)  | 199 bytes   | 104.74 %         |      1,294.0 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--7           | Small (190 B)  | 194 bytes   | 102.11 %         |      2,073.1 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--3           | Small (190 B)  | 194 bytes   | 102.11 %         |      2,171.2 ns |       776 B |
| CompressAndDecompress | ZstdSharpCompressor--8           | Small (190 B)  | 191 bytes   | 100.53 %         |      2,252.7 ns |       768 B |
| CompressAndDecompress | ZstdSharpCompressor--2           | Small (190 B)  | 182 bytes   | 95.79 %          |      2,293.7 ns |       760 B |
| CompressAndDecompress | ZstdSharpCompressor--1           | Small (190 B)  | 178 bytes   | 93.68 %          |      2,432.5 ns |       760 B |
| CompressAndDecompress | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes   | 93.68 %          |      6,247.6 ns |       760 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | ZstdSharpCompressor--9           | Small (190 B)  | 199 bytes   | 104.74 %         |        258.6 ns |       240 B |
| Decompress            | ZstdSharpCompressor--6           | Small (190 B)  | 199 bytes   | 104.74 %         |        262.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor--5           | Small (190 B)  | 199 bytes   | 104.74 %         |        286.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor--4           | Small (190 B)  | 199 bytes   | 104.74 %         |        273.3 ns |       240 B |
| Decompress            | ZstdSharpCompressor--22          | Small (190 B)  | 199 bytes   | 104.74 %         |        267.1 ns |       240 B |
| Decompress            | ZstdSharpCompressor--21          | Small (190 B)  | 199 bytes   | 104.74 %         |        239.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor--20          | Small (190 B)  | 199 bytes   | 104.74 %         |        282.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor--19          | Small (190 B)  | 199 bytes   | 104.74 %         |        272.5 ns |       240 B |
| Decompress            | ZstdSharpCompressor--18          | Small (190 B)  | 199 bytes   | 104.74 %         |        236.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor--17          | Small (190 B)  | 199 bytes   | 104.74 %         |        270.3 ns |       240 B |
| Decompress            | ZstdSharpCompressor--16          | Small (190 B)  | 199 bytes   | 104.74 %         |        269.2 ns |       240 B |
| Decompress            | ZstdSharpCompressor--15          | Small (190 B)  | 199 bytes   | 104.74 %         |        270.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor--14          | Small (190 B)  | 199 bytes   | 104.74 %         |        285.6 ns |       240 B |
| Decompress            | ZstdSharpCompressor--13          | Small (190 B)  | 199 bytes   | 104.74 %         |        281.3 ns |       240 B |
| Decompress            | ZstdSharpCompressor--12          | Small (190 B)  | 199 bytes   | 104.74 %         |        277.8 ns |       240 B |
| Decompress            | ZstdSharpCompressor--11          | Small (190 B)  | 199 bytes   | 104.74 %         |        267.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor--10          | Small (190 B)  | 199 bytes   | 104.74 %         |        289.5 ns |       240 B |
| Decompress            | ZstdSharpCompressor--7           | Small (190 B)  | 194 bytes   | 102.11 %         |        367.3 ns |       240 B |
| Decompress            | ZstdSharpCompressor--3           | Small (190 B)  | 194 bytes   | 102.11 %         |        354.9 ns |       240 B |
| Decompress            | ZstdSharpCompressor--8           | Small (190 B)  | 191 bytes   | 100.53 %         |        358.4 ns |       240 B |
| Decompress            | ZstdSharpCompressor--2           | Small (190 B)  | 182 bytes   | 95.79 %          |        451.3 ns |       240 B |
| Decompress            | ZstdSharpCompressor--1           | Small (190 B)  | 178 bytes   | 93.68 %          |        420.7 ns |       240 B |
| Decompress            | ZstdSharpCompressor-1            | Small (190 B)  | 178 bytes   | 93.68 %          |        436.4 ns |       240 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | LZMACompressor-Fastest-VerySmall | Large (20 KB)  | 2,872 bytes | 13.89 %          |  4,551,908.2 ns |   1541651 B |
| Compress              | LZMACompressor-Fastest-Small     | Large (20 KB)  | 2,872 bytes | 13.89 %          |  6,564,358.5 ns |  12716282 B |
| Compress              | LZMACompressor-Fastest-Medium    | Large (20 KB)  | 2,872 bytes | 13.89 %          | 14,910,623.4 ns |  48892042 B |
| Compress              | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes | 13.89 %          | 19,119,154.2 ns |  97126525 B |
| Compress              | LZMACompressor-Fastest-Larger    | Large (20 KB)  | 2,872 bytes | 13.89 %          | 34,334,893.8 ns | 193595490 B |
| Compress              | LZMACompressor-Fastest-VeryLarge | Large (20 KB)  | 2,872 bytes | 13.89 %          | 65,254,700.0 ns | 705300420 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | LZMACompressor-Fastest-VerySmall | Large (20 KB)  | 2,872 bytes | 13.89 %          |  5,138,184.4 ns |   1661091 B |
| CompressAndDecompress | LZMACompressor-Fastest-Small     | Large (20 KB)  | 2,872 bytes | 13.89 %          |  6,572,118.0 ns |  13818701 B |
| CompressAndDecompress | LZMACompressor-Fastest-Medium    | Large (20 KB)  | 2,872 bytes | 13.89 %          | 14,070,513.5 ns |  53140250 B |
| CompressAndDecompress | LZMACompressor-Fastest-Larger    | Large (20 KB)  | 2,872 bytes | 13.89 %          | 34,821,835.4 ns | 210426610 B |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes | 13.89 %          | 20,475,256.2 ns | 105569037 B |
| CompressAndDecompress | LZMACompressor-Fastest-VeryLarge | Large (20 KB)  | 2,872 bytes | 13.89 %          | 68,489,858.3 ns | 772463440 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | LZMACompressor-Fastest-VerySmall | Large (20 KB)  | 2,872 bytes | 13.89 %          |    582,715.9 ns |    119441 B |
| Decompress            | LZMACompressor-Fastest-Small     | Large (20 KB)  | 2,872 bytes | 13.89 %          |    902,625.2 ns |   1102817 B |
| Decompress            | LZMACompressor-Fastest-Medium    | Large (20 KB)  | 2,872 bytes | 13.89 %          |    906,151.3 ns |   4251673 B |
| Decompress            | LZMACompressor-Fastest-Large     | Large (20 KB)  | 2,872 bytes | 13.89 %          |  1,468,876.8 ns |   8444750 B |
| Decompress            | LZMACompressor-Fastest-Larger    | Large (20 KB)  | 2,872 bytes | 13.89 %          |  2,637,867.2 ns |  16831625 B |
| Decompress            | LZMACompressor-Fastest-VeryLarge | Large (20 KB)  | 2,872 bytes | 13.89 %          |  3,933,400.1 ns |  67163806 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | LZMACompressor-Fastest-VerySmall | Medium (10 KB) | 746 bytes   | 7.50 %           |  2,138,672.1 ns |   1533339 B |
| Compress              | LZMACompressor-Fastest-Small     | Medium (10 KB) | 746 bytes   | 7.50 %           |  4,310,536.8 ns |  12707849 B |
| Compress              | LZMACompressor-Fastest-Medium    | Medium (10 KB) | 746 bytes   | 7.50 %           | 12,547,745.3 ns |  48883730 B |
| Compress              | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes   | 7.50 %           | 15,781,609.9 ns |  97118213 B |
| Compress              | LZMACompressor-Fastest-Larger    | Medium (10 KB) | 746 bytes   | 7.50 %           | 31,266,256.2 ns | 193587178 B |
| Compress              | LZMACompressor-Fastest-VeryLarge | Medium (10 KB) | 746 bytes   | 7.50 %           | 60,266,090.5 ns | 705292065 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | LZMACompressor-Fastest-VerySmall | Medium (10 KB) | 746 bytes   | 7.50 %           |  2,345,179.0 ns |   1642051 B |
| CompressAndDecompress | LZMACompressor-Fastest-Small     | Medium (10 KB) | 746 bytes   | 7.50 %           |  4,092,442.6 ns |  13799642 B |
| CompressAndDecompress | LZMACompressor-Fastest-Medium    | Medium (10 KB) | 746 bytes   | 7.50 %           | 11,434,698.2 ns |  53121210 B |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes   | 7.50 %           | 17,945,415.1 ns | 105549997 B |
| CompressAndDecompress | LZMACompressor-Fastest-Larger    | Medium (10 KB) | 746 bytes   | 7.50 %           | 34,998,617.7 ns | 210407597 B |
| CompressAndDecompress | LZMACompressor-Fastest-VeryLarge | Medium (10 KB) | 746 bytes   | 7.50 %           | 59,181,829.2 ns | 772444380 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | LZMACompressor-Fastest-VerySmall | Medium (10 KB) | 746 bytes   | 7.50 %           |    170,740.0 ns |    108712 B |
| Decompress            | LZMACompressor-Fastest-Small     | Medium (10 KB) | 746 bytes   | 7.50 %           |    447,339.3 ns |   1092088 B |
| Decompress            | LZMACompressor-Fastest-Medium    | Medium (10 KB) | 746 bytes   | 7.50 %           |    626,725.4 ns |   4238520 B |
| Decompress            | LZMACompressor-Fastest-Large     | Medium (10 KB) | 746 bytes   | 7.50 %           |  1,326,003.8 ns |   8432519 B |
| Decompress            | LZMACompressor-Fastest-Larger    | Medium (10 KB) | 746 bytes   | 7.50 %           |  1,435,560.6 ns |  16820810 B |
| Decompress            | LZMACompressor-Fastest-VeryLarge | Medium (10 KB) | 746 bytes   | 7.50 %           |  3,399,474.0 ns |  67153048 B |
|                       |                                  |                |             |                  |                 |             |
| Compress              | LZMACompressor-Fastest-VerySmall | Small (190 B)  | 175 bytes   | 92.11 %          |  1,068,326.5 ns |   1531177 B |
| Compress              | LZMACompressor-Fastest-Small     | Small (190 B)  | 175 bytes   | 92.11 %          |  3,195,762.1 ns |  12705136 B |
| Compress              | LZMACompressor-Fastest-Medium    | Small (190 B)  | 175 bytes   | 92.11 %          | 10,537,196.4 ns |  48881249 B |
| Compress              | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes   | 92.11 %          | 18,131,015.6 ns |  97115930 B |
| Compress              | LZMACompressor-Fastest-Larger    | Small (190 B)  | 175 bytes   | 92.11 %          | 30,221,053.1 ns | 193584707 B |
| Compress              | LZMACompressor-Fastest-VeryLarge | Small (190 B)  | 175 bytes   | 92.11 %          | 64,401,316.7 ns | 705290027 B |
|                       |                                  |                |             |                  |                 |             |
| CompressAndDecompress | LZMACompressor-Fastest-VerySmall | Small (190 B)  | 175 bytes   | 92.11 %          |  1,114,980.6 ns |   1630409 B |
| CompressAndDecompress | LZMACompressor-Fastest-Small     | Small (190 B)  | 175 bytes   | 92.11 %          |  2,812,954.4 ns |  13787830 B |
| CompressAndDecompress | LZMACompressor-Fastest-Medium    | Small (190 B)  | 175 bytes   | 92.11 %          | 10,831,634.4 ns |  53109329 B |
| CompressAndDecompress | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes   | 92.11 %          | 18,840,866.7 ns | 105537927 B |
| CompressAndDecompress | LZMACompressor-Fastest-Larger    | Small (190 B)  | 175 bytes   | 92.11 %          | 31,001,399.0 ns | 210395744 B |
| CompressAndDecompress | LZMACompressor-Fastest-VeryLarge | Small (190 B)  | 175 bytes   | 92.11 %          | 67,399,186.7 ns | 772432752 B |
|                       |                                  |                |             |                  |                 |             |
| Decompress            | LZMACompressor-Fastest-VerySmall | Small (190 B)  | 175 bytes   | 92.11 %          |     52,341.4 ns |     99232 B |
| Decompress            | LZMACompressor-Fastest-Small     | Small (190 B)  | 175 bytes   | 92.11 %          |    292,166.7 ns |   1082608 B |
| Decompress            | LZMACompressor-Fastest-Medium    | Small (190 B)  | 175 bytes   | 92.11 %          |    390,212.4 ns |   4228602 B |
| Decompress            | LZMACompressor-Fastest-Large     | Small (190 B)  | 175 bytes   | 92.11 %          |  1,105,775.1 ns |   8422788 B |
| Decompress            | LZMACompressor-Fastest-Larger    | Small (190 B)  | 175 bytes   | 92.11 %          |  1,500,846.4 ns |  16811243 B |
| Decompress            | LZMACompressor-Fastest-VeryLarge | Small (190 B)  | 175 bytes   | 92.11 %          |  3,312,432.7 ns |  67143582 B |


LZMACompressor-Fastest-VerySmall    Faster and More GC Efficient
LZMACompressor-Fastest-VeryLarge    Slower and Less GC Efficient

