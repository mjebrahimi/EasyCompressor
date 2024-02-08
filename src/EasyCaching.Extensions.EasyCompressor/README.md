[![NuGet Badge](https://buildstats.info/nuget/EasyCaching.Extensions.EasyCompressor)](https://www.nuget.org/packages/EasyCaching.Extensions.EasyCompressor)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/EasyCompressor/workflows/.NET/badge.svg)](https://github.com/mjebrahimi/EasyCaching.Extensions.EasyCompressor)

# EasyCaching.Extensions.EasyCompressor

<img src="https://raw.githubusercontent.com/mjebrahimi/EasyCompressor/master/src/EasyCompressor.png" width="100" height="100" align="left"/>A nice integration between [EasyCaching](https://github.com/dotnetcore/EasyCaching) and [EasyCompressor](https://github.com/mjebrahimi/EasyCompressor).

This library aids in **Improving Performance** by **Reducing Memory Usage** and **Bandwidth Usage** by compressing your cache data, especially for distributed cache (such as Redis).

[EasyCaching](https://github.com/dotnetcore/EasyCaching) is an Easy-to-Use caching library that offers many features and supports many providers and serializers.

[EasyCompressor](https://github.com/mjebrahimi/EasyCompressor) is an **Easy-to-Use** and **Optimized** compression library for .NET that unified several compression algorithms including **LZ4**, **Snappy**, **Zstd**, **LZMA**, **Brotli**, **GZip**, **ZLib**, and **Deflate**.

## How to use

### 1. Install Package

```bash
PM> Install-Package EasyCaching.Extensions.EasyCompressor
PM> Install-Package EasyCompressor.LZ4

PM> # Install-Package EasyCompressor.Snappier
PM> # Install-Package EasyCompressor.ZstdSharp
PM> # Install-Package EasyCompressor (for Brotli, GZip, Deflate, ZLib)
```


### 2. Add Services


#### Basic Using

Just add your desired compressor and use the `WithCompressor()` method *just after* the serializer.

```csharp
services.AddLZ4Compressor();

services.AddEasyCaching(options =>
{
	options.UseRedis(config =>
	{
		config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
		config.SerializerName = "msgpack";
	})
	.WithMessagePack("msgpack")
	.WithCompressor();
});
```

#### Using a specific Compressor for each Serializer.

It assigns `lz4` compressor to `msgpack` serializer and `snappier` compressor to `protobuf` serializer.

```csharp
services.AddLZ4Compressor("lz4");
services.AddSnappierCompressor("snappier");

services.AddEasyCaching(options =>
{
	options.UseRedis(config =>
	{
		config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
		config.SerializerName = "msgpack";
	}, "redis1")
	.WithMessagePack("msgpack")
	.WithCompressor("msgpack", "lz4");

	options.UseRedis(config =>
	{
		config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
		config.SerializerName = "protobuf";
	}, "redis2")
	.WithProtobuf("protobuf")
	.WithCompressor("protobuf", "snappier");
});
```

## Benchmarks

You can see the benchmark of compressors [here](https://github.com/mjebrahimi/EasyCompressor#benchmarks).

## Contributing

Create an [issue](https://github.com/mjebrahimi/EasyCompressor/issues/new) or [discussion](https://github.com/mjebrahimi/EasyCompressor/discussions/new/choose) if you found a **BUG** or have a **Suggestion** or **Question**.

**Or if you want to develop this project:**

1. Fork it
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Give a Star! ⭐️

If you find this repository useful and like it, why not give it a star? if not, never mind! :)

## License

Copyright © 2020 [Mohammad Javad Ebrahimi](https://github.com/mjebrahimi) under the [MIT License](https://github.com/mjebrahimi/EasyCompressor/LICENSE).
