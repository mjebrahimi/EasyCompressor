[![NuGet Badge](https://buildstats.info/nuget/EasyCompressor)](https://www.nuget.org/packages/EasyCompressor)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/EasyCompressor/workflows/.NET/badge.svg)](https://github.com/mjebrahimi/EasyCompressor)

# EasyCompressor

An **Easy-to-Use** and **Optimized** compression library for .NET that unified many compression algorithms including **LZ4**, **Snappy**, **Zstd**, **LZMA**, **Brotli**, **GZip**, **ZLib**, and **Deflate**. 

Along with a great [**Performance Benchmark**](#benchmarks) between different compression algorithms.

## Usage

- Compress your BLOB data for archiving or saving storage
- Compress your cache objects for saving memory

## Features

- Supports and implements **many compression algorithms**.
- Supports **async/await and CancellationToken**.
- Supports working with **multiple compressors with specified names**
- Supports **Stream** as most as possible (*depending on the underlying* library)
- Compress/Decompress between **byte[], Stream, StreamReader and StreamWriter**.

## Nuget Packages


| Package      | Description
| ------------ | ----------------------
| [EasyCompressor](https://www.nuget.org/packages/EasyCompressor/) | Including Algorithms :<br/>- Brotli *(**Highest** compression ratio - the **Smallest** size) (**Only** available in .NETCoreApp2.1, .NETStandard2.1 and above)*<br/>- GZip<br/>- Deflate<br/>- ZLib *(**Only** available in .NET6.0 and above)*
| [EasyCompressor.LZ4](https://www.nuget.org/packages/EasyCompressor.LZ4/)⭐️ | Algorithm: LZ4<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.Snappier](https://www.nuget.org/packages/EasyCompressor.Snappier/)⭐️ | Algorithm: Snappy<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.ZstdSharp](https://www.nuget.org/packages/EasyCompressor.ZstdSharp/)⭐️ | Algorithm: Zstd (Zstandard)<br/>Extremely Fast (**Recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.LZMA](https://www.nuget.org/packages/EasyCompressor.LZMA/) | Algorithm: LZMA<br/>High compression ratio (small size) but very Slow (**Not recommended** - see [Benchmarks](#benchmarks))
| [EasyCompressor.Zstd](https://www.nuget.org/packages/EasyCompressor.Zstd/) *(deprecated)* | Instead, use [EasyCompressor.ZstdSharp](https://www.nuget.org/packages/EasyCompressor.ZstdSharp/).
| [EasyCompressor.Snappy](https://www.nuget.org/packages/EasyCompressor.Snappy/) *(deprecated)* | Instead, use [EasyCompressor.Snappier](https://www.nuget.org/packages/EasyCompressor.Snappier/)
| [EasyCompressor.BrotliNET](https://www.nuget.org/packages/EasyCompressor.BrotliNET/) *(deprecated)* | Instead, use BrotliCompressor in [EasyCompressor](https://www.nuget.org/packages/EasyCompressor/) itself (base package)<br/>*(Use **only** if your project targets .NETFramework462 and above or .NETCoreApp2.0)*
| [EasyCaching.Extensions.EasyCompressor](https://www.nuget.org/packages/EasyCaching.Extensions.EasyCompressor/)⭐️ | A **winning combination** by integrating with [EasyCaching](https://github.com/dotnetcore/EasyCaching) to compress your **cache data**. (Recommended)<br/>See [How to use](https://github.com/mjebrahimi/EasyCompressor/tree/master/src/EasyCaching.Extensions.EasyCompressor/README.md)

**Note :**

All of these packages are **cross-platform** except `EasyCompressor.Zstd` and `EasyCompressor.Snappy` which are **not cross-platform** because their underlying library are just a wrapper around the native dlls only for windows.


## Get Started

### 1. Install Package

```bash
PM> Install-Package EasyCompressor.LZ4

PM> # Install-Package EasyCompressor (for Brotli, GZip, Deflate, ZLib)
PM> # Install-Package EasyCompressor.Snappier
PM> # Install-Package EasyCompressor.ZstdSharp
PM> # Install-Package EasyCompressor.LZMA
PM> # Install-Package EasyCompressor.Zstd (deprecated)
PM> # Install-Package EasyCompressor.Snappy (deprecated)
PM> # Install-Package EasyCompressor.BrotliNET (deprecated)
```

### 2. Using New Instance or the Shared Instance

```csharp
public class YourClass
{
    private readonly ICompressor _compressor;

    public YourClass()
    {
        //--------------------------------------- New Instance ---------------------------------------
        _compressor = new LZ4Compressor();            //package : EasyCompressor.LZ4

        //_compressor = new ZstdSharpCompressor();    //package : EasyCompressor.Snappier
        //_compressor = new BrotliCompressor();       //package : EasyCompressor
        //_compressor = new GZipCompressor();         //package : EasyCompressor
        //_compressor = new DeflateCompressor();      //package : EasyCompressor
        //_compressor = new ZLibCompressor();         //package : EasyCompressor
        //_compressor = new LZMACompressor();         //package : EasyCompressor.LZMA
        //_compressor = new ZstdCompressor();         //package : EasyCompressor.Zstd (deprecated)
        //_compressor = new SnappyCompressor();       //package : EasyCompressor.Snappy (deprecated)
        //_compressor = new BrotliNETCompressor();    //package : EasyCompressor.BrotliNET (deprecated)


        //--------------------------------------- Shared Instance ---------------------------------------
        _compressor = LZ4Compressor.Shared;            //package : EasyCompressor.LZ4

        //_compressor = ZstdSharpCompressor.Shared;    //package : EasyCompressor.Snappier
        //_compressor = BrotliCompressor.Shared;       //package : EasyCompressor
        //_compressor = GZipCompressor.Shared;         //package : EasyCompressor
        //_compressor = DeflateCompressor.Shared;      //package : EasyCompressor
        //_compressor = ZLibCompressor.Shared;         //package : EasyCompressor
        //_compressor = LZMACompressor.Shared;         //package : EasyCompressor.LZMA
        //_compressor = ZstdCompressor.Shared;         //package : EasyCompressor.Zstd (deprecated)
        //_compressor = SnappyCompressor.Shared;       //package : EasyCompressor.Snappy (deprecated)
        //_compressor = BrotliNETCompressor.Shared;    //package : EasyCompressor.BrotliNET (deprecated)
    }

    static static void ProcessData(byte[] bytes)
    {
        // Compress your original byte[] and return compressed byte[]
        var compressedBytes = _compressor.Compress(bytes);

        // Decompress compressed byte[] and return uncompressed byte[]
        var uncompressedBytes = _compressor.Decompress(compressedBytes);
    }

    public static void ProcessStream(Stream input, stream output)
    {
        // Read input stream and Compress into output stream
        _compressor.Compress(input, output);

        // Read input stream and Decompress into output stream
        _compressor.Decompress(input, output);
    }
}
```

### 3. Using Dependency Injection

#### Add Services

```csharp
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddLZ4Compressor();            //package : EasyCompressor.LZ4

    //services.AddSnappierCompressor();     //package : EasyCompressor.Snappier
    //services.AddZstdSharpCompressor();    //package : EasyCompressor.ZstdSharp
    //services.AddBrotliCompressor();       //package : EasyCompressor
    //services.AddGZipCompressor();         //package : EasyCompressor
    //services.AddDeflateCompressor();      //package : EasyCompressor
    //services.AddZLibCompressor();         //package : EasyCompressor
    //services.AddLZMACompressor();         //package : EasyCompressor.LZMA
    //services.AddZstdCompressor();         //package : EasyCompressor.Zstd (deprecated)
    //services.AddSnappyCompressor();       //package : EasyCompressor.Snappy (deprecated)
    //services.AddBrotliNETCompressor();    //package : EasyCompressor.BrotliNET (deprecated)
}
```

#### Inject/Resolve it and use it

```csharp
using EasyCompressor;

public class YourClass
{
    private readonly ICompressor _compressor;

    public YourClass(ICompressor compressor) //Inject using dependency injection
    {
        _compressor = compressor;
        //Or resolve it using IServiceProvider
        //_compressor = serviceProvider.GetService<ICompressor>()
    }

    public void ProcessData(byte[] bytes)
    {
        // Compress your original byte[] and return compressed byte[]
        var compressedBytes = _compressor.Compress(bytes);

        // Decompress compressed byte[] and return uncompressed byte[]
        var uncompressedBytes = _compressor.Decompress(compressedBytes);
    }

    public void ProcessStream(Stream input, stream output)
    {
        // Read input stream and Compress into output stream
        _compressor.Compress(input, output);

        // Read input stream and Decompress into output stream
        _compressor.Decompress(input, output);
    }
}
```

### 4. Using Named Instances

#### Register Named compressors

```csharp
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddLZ4Compressor("lz4");                 //package : EasyCompressor.LZ4
    services.AddSnappierCompressor("snappier");       //package : EasyCompressor.Snappier
    services.AddZstdSharpCompressor("zstdsharp");     //package : EasyCompressor.ZstdSharp

    //services.AddBrotliCompressor("brotli");         //package : EasyCompressor
    //services.AddGZipCompressor("gzip");             //package : EasyCompressor
    //services.AddDeflateCompressor("deflate");       //package : EasyCompressor
    //services.AddZLibCompressor("zlib");             //package : EasyCompressor
    //services.AddLZMACompressor("lzma");             //package : EasyCompressor.LZMA
    //services.AddZstdCompressor("zstd");             //package : EasyCompressor.Zstd (deprecated)
    //services.AddSnappyCompressor("snappy");         //package : EasyCompressor.Snappy (deprecated)
    //services.AddBrotliNETCompressor("brotlinet");   //package : EasyCompressor.BrotliNET (deprecated)
}
```

#### Resolve it using ICompressorProvider

```csharp
using EasyCompressor;

public class YourClass
{
    private readonly ICompressor _lz4Compressor;
    private readonly ICompressor _snappierCompressor;
    private readonly ICompressor _zstdsharpCompressor;

    public YourClass(ICompressorProvider compressorProvider)
    {
        _lz4Compressor = compressorProvider.GetCompressor("lz4");
        _snappierCompressor = compressorProvider.GetCompressor("snappier");
        _zstdsharpCompressor = compressor.GetCompressor("zstdsharp");
    }
}
```

## Benchmarks

<!-- ### Tips and Results

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
- Deflate -->

![Benchmark](Benchmark.png)

### Other Benchmarks

#### Using Binary Data (byte[])

- Comparison in terms of **Speed (Mean/Execution Time)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Binary-Mean.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Binary-Mean.png))
- Comparison in terms of **Memory Usage (Allocation Size)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Binary-Allocated.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Binary-Allocated.png))

#### Using Stream Data

- Comparison in terms of **Speed (Mean/Execution Time)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Stream-Mean.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Stream-Mean.png))
- Comparison in terms of **Memory Usage (Allocation Size)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Stream-Allocated.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-Stream-Allocated.png))

#### Using Stream Data (Async)

- Comparison in terms of **Speed (Mean/Execution Time)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-StreamAsync-Mean.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-StreamAsync-Mean.png))
- Comparison in terms of **Memory Usage (Allocation Size)** (visit it's [HTML](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-StreamAsync-Allocated.html) or [Image](https://mjebrahimi.github.io/EasyCompressor/docs/Benchmark-StreamAsync-Allocated.png))

### Key Results and Conclusion

#### Best Compressors based on Overall Performance (Speed and Memory Usage) in each case

| Operation    | Binary    | Stream     | StreamAsync
| ------------ | --------- | ---------- | -----------
| **Compress**     | SnappierCompressor<br/>LZ4Compressor<br/>ZstdSharpCompressor | SnappierCompressor<br/>LZ4Compressor<br/>BrotliCompressor | LZ4Compressor<br/>BrotliCompressor<br/>---
| **Decompress**   | LZ4Compressor<br/>SnappierCompressor<br/>ZstdSharpCompressor | SnappierCompressor<br/>LZ4Compressor<br/>ZstdSharpCompressor | ZstdSharpCompressor<br/>LZ4Compressor<br/>---

#### Best Compressors based on Highest compression (Smallest size)

1. BrotliCompressor (smaller in medium/small data with **moderate** speed and memory usage)
2. LZMACompressor (smaller in large data but **very slow** and memory inefficient)
3. ZstdSharpCompressor (**fastest** meanwhile with acceptable/good enough level of compression)

![Benchmark](docs/Benchmark-HighestCompression.png)

## Contributing

Create an [issue](https://github.com/mjebrahimi/EasyCompressor/issues/new) if you found a **BUG** or have a **Suggestion** or **Question**.

**Or if you want to develop this project :**

1. Fork it
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Give a Star! ⭐️

If you find this repository useful and like it, why not give it a star? if not, never mind! :)

## License

Copyright © 2020 [Mohammd Javad Ebrahimi](https://github.com/mjebrahimi) under the [MIT License](https://github.com/mjebrahimi/EasyCompressor/LICENSE).
