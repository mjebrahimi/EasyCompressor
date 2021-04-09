[![NuGet Badge](https://buildstats.info/nuget/EasyCompressor)](https://www.nuget.org/packages/EasyCompressor)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/EasyCompressor/workflows/.NET%20Core/badge.svg)](https://github.com/mjebrahimi/EasyCompressor)

# EasyCompressor

A compression library that implements many compression algorithms such as **LZ4, Zstd, LZMA, Snappy, Brotli, GZip, and Deflate**. It helps you to **improve performance by reducing Memory Usage and Network Traffic** for caching.

## Nuget Packages

| Package Name |  Version  |  Description
| ------------ |  -------  |  -----------
| [EasyCompressor](https://www.nuget.org/packages/EasyCompressor/) | ![](https://img.shields.io/nuget/v/EasyCompressor.svg) | Contains GZip, Deflate and (*Brotli available only in .NETCore2.1, .NETStandard2.1 and above*)
| [EasyCompressor.BrotliNET](https://www.nuget.org/packages/EasyCompressor.BrotliNET/) | ![](https://img.shields.io/nuget/v/EasyCompressor.BrotliNET.svg) | Contains Brotli using [Brotli.NET](https://www.nuget.org/packages/Brotli.NET/) (*for erlier than .NETCore2.1, .NETStandard2.1*)
| [EasyCompressor.LZ4](https://www.nuget.org/packages/EasyCompressor.LZ4/) | ![](https://img.shields.io/nuget/v/EasyCompressor.LZ4.svg) | Contains LZ4 using [K4os.Compression.LZ4](https://www.nuget.org/packages/K4os.Compression.LZ4/)
| [EasyCompressor.LZMA](https://www.nuget.org/packages/EasyCompressor.LZMA/) | ![](https://img.shields.io/nuget/v/EasyCompressor.LZMA.svg) | Contains LZMA using [LZMA-SDK](https://www.nuget.org/packages/LZMA-SDK/)
| [EasyCompressor.Snappy](https://www.nuget.org/packages/EasyCompressor.Snappy/) | ![](https://img.shields.io/nuget/v/EasyCompressor.Snappy.svg) | Contains Snappy using [Snappy.Standard](https://www.nuget.org/packages/Snappy.Standard/)
| [EasyCompressor.Zstd](https://www.nuget.org/packages/EasyCompressor.Zstd/) | ![](https://img.shields.io/nuget/v/EasyCompressor.Zstd.svg) | Contains Zstd (ZStandard) using [ZstdNet](https://www.nuget.org/packages/ZstdNet/)
| [EasyCaching.Extensions.EasyCompressor](https://www.nuget.org/packages/EasyCaching.Extensions.EasyCompressor/) | ![](https://img.shields.io/nuget/v/EasyCaching.Extensions.EasyCompressor.svg) | This integrates [EasyCaching](https://github.com/dotnetcore/EasyCaching) with EasyCompressor. ([How to use](https://github.com/mjebrahimi/EasyCompressor/tree/master/src/EasyCaching.Extensions.EasyCompressor/README.md))

**Note :**

`LZ4`, `GZip`, `Deflate`, `Brotli`, and `LZMA` are **cross-platform** because these are complete implementations with C#.  (also `BrotliNet` too because this is a wrapper of *brotli* native library for win/linux/osx)

But `Zstd` and `Snappy` are **not cross-platform**, because they are just a wrapper of the native library for windows.

## Features

- Supports and Implements **many compression algorithms**.
- Supports **async/await and CancellationToken**.
- Supports woking with **multiple compressor with specified name**
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

//Inject (ICompressor compressor)

//Compress
var compressedBytes = compressor.Compress(inputBytes);

//Decompress
var uncompressedBytes = compressor.Decompress(compressedBytes);
```

## Benchmark

### Tips and Results

**Origial data size is :**
- **89,535 bytes (about ≈ 90 KB)** (binary serialized output of a json file by messagepack).

**Compressed data size (for examle) :**
- **776 bytes for Zstd** (115x compression ratio) that results in **99.13% memory and bandwidth saving.**
- **1,234 bytes for LZ4** (72x compression ratio) that results in **98.62% memory and bandwidth saving.**

**Maximum Compression :**
- Brotli
- Zstd
- LZMA
- LZ4

**Fastest Speed :**
- Zstd
- Snappy
- LZ4

**Most Efficient :**
- Zstd (*windows only package*)
- LZ4 (*cross-platform package*)

**Moderated :**
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
