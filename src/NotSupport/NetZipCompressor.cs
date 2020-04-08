using Ionic.Zlib;

namespace EasyCompressor
{
    public class NetZipCompressor
    {
        #region GZipStream
        public byte[] CompressGZipStream(byte[] bytes, CompressionLevel level = CompressionLevel.Default)
        {
            return GZipStream.CompressBuffer(bytes);

            //using (var outputStream = new MemoryStream())
            //{
            //    byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);
            //    outputStream.Write(lengthBytes, 0, 4);
            //    using (var zipStream = new GZipStream(outputStream, CompressionMode.Compress, level))
            //    {
            //        zipStream.Write(bytes, 0, bytes.Length);
            //        //zipStream.Flush();
            //    }
            //    return outputStream.ToArray();
            //}

            //using (var outputStream = new MemoryStream())
            //{
            //    byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);
            //    outputStream.Write(lengthBytes, 0, 4);

            //    using (var inputStream = new MemoryStream(bytes))
            //    using (var zipStream = new GZipStream(outputStream, CompressionMode.Compress, level))
            //    {
            //        inputStream.CopyTo(zipStream);
            //        //zipStream.Flush();
            //    }
            //    return outputStream.ToArray();
            //}

            //using (var result = new MemoryStream())
            //{
            //    byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);
            //    result.Write(lengthBytes, 0, 4);

            //    using (var compressionStream = new GZipStream(result, CompressionMode.Compress, level))
            //    {
            //        compressionStream.Write(bytes, 0, bytes.Length);
            //        //compressionStream.Flush();
            //    }
            //    return result.ToArray();
            //}
        }

        public byte[] DecompressGZipStream(byte[] compressedBytes)
        {
            return GZipStream.UncompressBuffer(compressedBytes);

            //using (var source = new MemoryStream(compressedBytes))
            //{
            //    var lengthBytes = new byte[4];
            //    source.Read(lengthBytes, 0, 4);

            //    int length = BitConverter.ToInt32(lengthBytes, 0);
            //    using (var decompressionStream = new GZipStream(source, CompressionMode.Decompress))
            //    {
            //        var result = new byte[length];
            //        decompressionStream.Read(result, 0, length);
            //        //decompressionStream.Flush();
            //        return result;
            //    }
            //}
        }
        #endregion

        #region DeflateStream
        public byte[] CompressDeflateStream(byte[] bytes, CompressionLevel level = CompressionLevel.Default)
        {
            return DeflateStream.CompressBuffer(bytes);
        }

        public byte[] DecompressDeflateStream(byte[] compressedBytes)
        {
            return DeflateStream.UncompressBuffer(compressedBytes);
        }
        #endregion

        #region ZlibStream
        public byte[] CompressZlibStream(byte[] bytes, CompressionLevel level = CompressionLevel.Default)
        {
            return ZlibStream.CompressBuffer(bytes);
        }

        public byte[] DecompressZlibStream(byte[] compressedBytes)
        {
            return ZlibStream.UncompressBuffer(compressedBytes);
        }
        #endregion

        //#region Zip
        //public byte[] CompressZip(byte[] bytes, CompressionLevel level = CompressionLevel.Default, CompressionMethod method = CompressionMethod.None)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var zipStream = new ZipOutputStream(outputStream))
        //    {
        //        zipStream.CompressionLevel = level;
        //        zipStream.CompressionMethod = method;

        //        zipStream.PutNextEntry(string.Empty);
        //        zipStream.Write(bytes, 0, bytes.Length);
        //        zipStream.Flush();

        //        return outputStream.ToArray();
        //    }

        //    //using (var outputStream = new MemoryStream())
        //    //using (var inputStream = new MemoryStream(bytes))
        //    //using (var zipStream = new ZipOutputStream(outputStream))
        //    //{
        //    //    zipStream.CompressionLevel = level;
        //    //    zipStream.CompressionMethod = method;

        //    //    zipStream.PutNextEntry(string.Empty);
        //    //    inputStream.CopyTo(zipStream);
        //    //    zipStream.Flush();

        //    //    return outputStream.ToArray();
        //    //}
        //}

        //public byte[] DecompressZip(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipStream = new ZipInputStream(inputStream))
        //    {
        //        //zipStream.GetNextEntry();
        //        zipStream.CopyTo(outputStream);
        //        zipStream.Flush();
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion

        //#region GZip
        //public byte[] CompressGZip(byte[] bytes, CompressionLevel level = CompressionLevel.Default, CompressionMethod method = CompressionMethod.None)
        //{
        //    //using (var outputStream = new MemoryStream())
        //    //using (var zipStream = new GZipOutputStream(outputStream))
        //    //{
        //    //    zipStream.Write(bytes, 0, bytes.Length);
        //    //    zipStream.Flush();
        //    //    return outputStream.ToArray();
        //    //}

        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(bytes))
        //    using (var zipStream = new GZipOutputStream(outputStream))
        //    {
        //        inputStream.CopyTo(zipStream);
        //        zipStream.Flush();
        //        return outputStream.ToArray();
        //    }
        //}

        //public byte[] DecompressGZip(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipStream = new GZipInputStream(inputStream))
        //    {
        //        zipStream.CopyTo(outputStream);
        //        zipStream.Flush();
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion

        //#region BZip2
        //public byte[] CompressBZip2(byte[] bytes, CompressionLevel level = CompressionLevel.Default, CompressionMethod method = CompressionMethod.None)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var zipStream = new BZip2OutputStream(outputStream))
        //    {
        //        zipStream.Write(bytes, 0, bytes.Length);
        //        zipStream.Flush();
        //        return outputStream.ToArray();
        //    }

        //    //using (var outputStream = new MemoryStream())
        //    //using (var inputStream = new MemoryStream(bytes))
        //    //using (var zipStream = new BZip2OutputStream(outputStream))
        //    //{
        //    //    inputStream.CopyTo(zipStream);
        //    //    zipStream.Flush();
        //    //    return outputStream.ToArray();
        //    //}
        //}

        //public byte[] DecompressBZip2(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipStream = new BZip2InputStream(inputStream))
        //    {
        //        zipStream.CopyTo(outputStream);
        //        zipStream.Flush();
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion
    }
}
