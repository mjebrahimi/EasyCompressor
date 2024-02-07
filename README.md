[![NuGet Badge](https://buildstats.info/nuget/EasyCompressor)](https://www.nuget.org/packages/EasyCompressor)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/EasyCompressor/workflows/.NET/badge.svg)](https://github.com/mjebrahimi/EasyCompressor)

# EasyCompressor

An **Easy-to-Use** and **Optimized** compression library for .NET that unified many compression algorithms including **LZ4**, **Snappy**, **Zstd**, **LZMA**, **Brotli**, **GZip**, **ZLib**, and **Deflate**. 

Along with a great [**Performance Benchmark**](#benchmarks) between different compression algorithms.

## Nuget Packages


| Package      | Description
| ------------ | ----------------------
| [EasyCompressor](https://www.nuget.org/packages/EasyCompressor/) | Including Algorithms :<br/>- Brotli *(Highest compression ratio - the **Smallest** size) (**Only** available in .NETCoreApp2.1, .NETStandard2.1 and above)*<br/>- ZLib *(**Only** available in .NET6.0 and above)*<br/>- GZip<br/>- Deflate<br/>
| [EasyCompressor.LZ4](https://www.nuget.org/packages/EasyCompressor.LZ4/)⭐️ | Algorithm: LZ4<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.Snappier](https://www.nuget.org/packages/EasyCompressor.Snappier/)⭐️ | Algorithm: Snappy<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.ZstdSharp](https://www.nuget.org/packages/EasyCompressor.ZstdSharp/)⭐️ | Algorithm: Zstd (Zstandard)<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.LZMA](https://www.nuget.org/packages/EasyCompressor.LZMA/) | Algorithm: LZMA<br/>High compression ratio (small size) but very Slow (**Not recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.Zstd](https://www.nuget.org/packages/EasyCompressor.Zstd/) *(deprecated)* | Instead, use [EasyCompressor.ZstdSharp](https://www.nuget.org/packages/EasyCompressor.ZstdSharp/).
| [EasyCompressor.Snappy](https://www.nuget.org/packages/EasyCompressor.Snappy/) *(deprecated)* | Instead, use [EasyCompressor.Snappier](https://www.nuget.org/packages/EasyCompressor.Snappier/)
| [EasyCompressor.BrotliNET](https://www.nuget.org/packages/EasyCompressor.BrotliNET/) *(deprecated)* | Instead, use BrotliCompressor in [EasyCompressor](https://www.nuget.org/packages/EasyCompressor/) itself (base package)<br/>*(Use **only** if your project targets .NETFramework462 and above or .NETCoreApp2.0)*
| [EasyCaching.Extensions.EasyCompressor](https://www.nuget.org/packages/EasyCaching.Extensions.EasyCompressor/)⭐️ | A **winning combination** by integrating with [EasyCaching](https://github.com/dotnetcore/EasyCaching) to compress your **cache data**. (Recommended)<br/>See [How to use](https://github.com/mjebrahimi/EasyCompressor/tree/master/src/EasyCaching.Extensions.EasyCompressor/README.md)

**Note :**

`LZ4`, `GZip`, `Deflate`, `Brotli`, and `LZMA` are **cross-platform** because these are complete implementations with C#.  (also `BrotliNet` too because this is a wrapper of *brotli* native library for win/linux/osx)

`Zstd` and `Snappy` are **not cross-platform**, because they are just a wrapper of the native library for windows.

## Features

- Supports and implements **many compression algorithms**.
- Supports **async/await and CancellationToken**.
- Supports woking with **multiple compressors with specified names**
- Supports **Stream** as most as possible (*depending on the underlying* library)
- Compress/Decompress between **byte[], Stream, StreamReader and StreamWriter**.

## Get Started

### 1. Install Package

```ini
PM> Install-Package EasyCompressor.LZ4
```

### 2. Add Services

```csharp
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddLZ4Compressor();

    //or services.AddGZipCompressor();      package : EasyCompressor
    //or services.AddDeflateCompressor();   package : EasyCompressor
    //or services.AddBrotliCompressor();    package : EasyCompressor
    //or services.AddBrotliNetCompressor(); package : EasyCompressor.BrotliNET
    //or services.AddZstdCompressor();      package : EasyCompressor.Zstd
    //or services.AddLZMACompressor();      package : EasyCompressor.LZMA
    //or services.AddSnappyCompressor();    package : EasyCompressor.Snappy
}
```

### 3. Use it

```csharp
using EasyCompressor;

// Inject (ICompressor compressor)

// Compress
var compressedBytes = compressor.Compress(inputBytes);

// Decompress
var uncompressedBytes = compressor.Decompress(compressedBytes);
```

## Benchmarks

### Tips and Results

**Original data size is:**
- **89,535 bytes (about ≈ 90 KB)** (binary serialized output of a json file by messagepack).

**Compressed data size (for example):**
- **776 bytes for Zstd** (115x compression ratio) that results in **99.13% memory and bandwidth saving.**
- **1,234 bytes for LZ4** (72x compression ratio) that results in **98.62% memory and bandwidth saving.**

**Maximum Compression:**
- Brotli
- Zstd
- LZMA
- LZ4

**Fastest Speed:**
- Zstd
- Snappy
- LZ4

**Most Efficient:**
- Zstd (*windows only package*)
- LZ4 (*cross-platform package*)

**Moderated:**
- GZip
- Deflate

Compression Ratio : higher is better
![Benchmark](Benchmark.png)

## Contributing

Create an [issue](https://github.com/mjebrahimi/EasyCompressor/issues/new) if you find a BUG or have a Suggestion or Question. If you want to develop this project :

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Give a Star! ⭐️

If you find this repository useful, please give it a star. Thanks!

## License

EasyCompressor is Copyright © 2020 [Mohammd Javad Ebrahimi](https://github.com/mjebrahimi) under the [MIT License](https://github.com/mjebrahimi/EasyCompressor/LICENSE).
