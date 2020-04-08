using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;

namespace EasyCompressor
{
    public class SharpZipCompressor
    {
        #region Zip
        public byte[] CompressZip(byte[] bytes, int level = 3)
        {
            using (var outputStream = new MemoryStream())
            using (var zipStream = new ZipOutputStream(outputStream))
            {
                zipStream.SetLevel(level);
                var entry = new ZipEntry(string.Empty) { DateTime = DateTime.Now };

                zipStream.PutNextEntry(entry);
                zipStream.Write(bytes, 0, bytes.Length);
                zipStream.CloseEntry();
                zipStream.Flush();

                return outputStream.ToArray();
            }

            //a bit Larger - a bit Faster
            //using (var outputStream = new MemoryStream())
            //using (var inputStream = new MemoryStream(bytes))
            //using (var zipStream = new ZipOutputStream(outputStream))
            //{
            //    zipStream.SetLevel(level);
            //    var entry = new ZipEntry(string.Empty) { DateTime = DateTime.Now };

            //    zipStream.PutNextEntry(entry);
            //    StreamUtils.Copy(inputStream, zipStream, new byte[4096]);
            //    zipStream.CloseEntry();

            //    return outputStream.ToArray();
            //}
        }

        public byte[] DecompressZip(byte[] compressedBytes)
        {
            using (var outputStream = new MemoryStream())
            using (var inputStream = new MemoryStream(compressedBytes))
            using (var zipStream = new ZipInputStream(inputStream))
            {
                zipStream.GetNextEntry();
                StreamUtils.Copy(zipStream, outputStream, new byte[4096]);
                return outputStream.ToArray();
            }
        }
        #endregion

        //#region GZip
        //public byte[] CompressGZip(byte[] bytes, int level = 3)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(bytes))
        //    using (var zipStream = new GZipOutputStream(outputStream))
        //    {
        //        zipStream.SetLevel(level);
        //        StreamUtils.Copy(inputStream, zipStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }

        //    //using (var outputStream = new MemoryStream())
        //    //using (var zipStream = new GZipOutputStream(outputStream))
        //    //{
        //    //    zipStream.SetLevel(level);

        //    //    zipStream.Write(bytes, 0, bytes.Length);
        //    //    zipStream.Flush();

        //    //    return outputStream.ToArray();
        //    //}
        //}

        //public byte[] DecompressGZip(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipStream = new GZipInputStream(inputStream))
        //    {
        //        //zipStream.Write(bytes, 0, bytes.Length);

        //        StreamUtils.Copy(zipStream, outputStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion

        //#region BZip2
        //public byte[] CompressBZip2(byte[] bytes, int level = 3)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(bytes))
        //    using (var zipStream = new BZip2OutputStream(outputStream))
        //    {
        //        StreamUtils.Copy(inputStream, zipStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}

        //public byte[] DecompressBZip2(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipInputStream = new BZip2InputStream(inputStream))
        //    {
        //        //zipInputStream.CopyToAsync();
        //        StreamUtils.Copy(zipInputStream, outputStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion

        //#region Lzw
        //public byte[] CompressLzw(byte[] bytes, int level = 3)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(bytes))
        //    using (var zipStream = new LzwInputStream(outputStream))
        //    {
        //        StreamUtils.Copy(inputStream, zipStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}

        //public byte[] DecompressLzw(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipInputStream = new LzwInputStream(inputStream))
        //    {
        //        StreamUtils.Copy(zipInputStream, outputStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion

        //#region Tar
        //public byte[] CompressTar(byte[] bytes, int level = 3)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var zipStream = new TarOutputStream(outputStream))
        //    {
        //        var entry = TarEntry.CreateTarEntry(string.Empty);
        //        entry.Size = bytes.Length;

        //        zipStream.PutNextEntry(entry);
        //        zipStream.Write(bytes, 0, bytes.Length);
        //        zipStream.CloseEntry();
        //        zipStream.Flush();

        //        return outputStream.ToArray();
        //    }

        //    //using (var outputStream = new MemoryStream())
        //    //using (var zipStream = new TarOutputStream(outputStream))
        //    //{
        //    //    using (var inputStream = new MemoryStream(bytes))
        //    //    {
        //    //        var entry = TarEntry.CreateTarEntry(string.Empty);
        //    //        entry.Size = inputStream.Length;

        //    //        zipStream.PutNextEntry(entry);

        //    //        // this is copied from TarArchive.WriteEntryCore
        //    //        byte[] localBuffer = new byte[32 * 1024];
        //    //        while (true)
        //    //        {
        //    //            int numRead = inputStream.Read(localBuffer, 0, localBuffer.Length);
        //    //            if (numRead <= 0)
        //    //                break;

        //    //            outputStream.Write(localBuffer, 0, numRead);
        //    //        }
        //    //    }
        //    //    zipStream.CloseEntry();
        //    //    return outputStream.ToArray();
        //    //}
        //}

        //public byte[] DecompressTar(byte[] compressedBytes)
        //{
        //    using (var outputStream = new MemoryStream())
        //    using (var inputStream = new MemoryStream(compressedBytes))
        //    using (var zipStream = new TarInputStream(inputStream))
        //    {
        //        zipStream.GetNextEntry();
        //        StreamUtils.Copy(zipStream, outputStream, new byte[4096]);
        //        return outputStream.ToArray();
        //    }
        //}
        //#endregion
    }
}
