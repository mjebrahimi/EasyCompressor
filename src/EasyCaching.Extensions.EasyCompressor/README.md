[![NuGet](https://img.shields.io/nuget/v/EasyCaching.Extensions.EasyCompressor.svg)](https://www.nuget.org/packages/EasyCaching.Extensions.EasyCompressor)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)
[![Build Status](https://github.com/mjebrahimi/EasyCompressor/workflows/.NET%20Core/badge.svg)](https://github.com/mjebrahimi/EasyCompressor)

# EasyCaching.Extensions.EasyCompressor

This library integrates [EasyCaching](https://github.com/dotnetcore/EasyCaching) with [EasyCompressor](https://github.com/mjebrahimi/EasyCompressor) that is **very useful for compressing cache data especially for distributed cache such as Redis to reduce network traffic**.

**EasyCaching** is the best caching abstraction library that supports many providers and serializers.

**EasyCompressor** is an open-source compression abstraction library that supports and implements many compression algorithms such as **Zstd, LZMA, LZ4, Snappy, Brotli, GZip and Deflate**. It is very useful for using along with **distributed caching** or **storing files in database**.

## How to use

### 1. Install Package

```ini
PM> Install-Package EasyCaching.Extensions.EasyCompressor
PM> Install-Package EasyCompressor.Zstd
```

### 2. Add Services

Just add your desired compressor and use `WithCompressor()` *after* serializer.
```cs
services.AddZstdCompressor();

services.AddEasyCaching(options =>
{
	options
		.UseInMemory()
		.WithMessagePack()
		.WithCompressor();
});

```

Also you can use naming for serializer and compressor.

```cs
services.AddZstdCompressor("zstd");
services.AddLZ4Compressor("lz4");

services.AddEasyCaching(options =>
{
	options
		.UseInMemory("memory1")
		.WithMessagePack("msgpack")
		.WithCompressor("msgpack", "zstd");

	options
		.UseInMemory("memory2")
		.WithJson("json")
		.WithCompressor("json", "lz4");
});
```

This will use `zstd` compressor for `msgpack` serializer and `lz4` compressor for `json` serializer.

## Benchmark

You can see benchmark of serializers [here](https://github.com/mjebrahimi/EasyCompressor#benchmark).

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

