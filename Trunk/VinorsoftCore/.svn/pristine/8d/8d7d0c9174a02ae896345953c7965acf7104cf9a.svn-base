using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace KTApps.Core.Utils
{
    public static class WordUtils
    {
        public static string ExportXMLData(string path, string entryName)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = ZipFile.Open(path, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.GetEntry(entryName);
                    if (entry != null)
                    {
                        using (var entryStream = entry.Open())
                        {
                            StreamReader reader = new StreamReader(entryStream);
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static void ImportXMLData(string path, string xmlData)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = ZipFile.Open(path, ZipArchiveMode.Update))
                {
                    var document = archive.GetEntry("word/document.xml");
                    if (document != null)
                    {
                        document.Delete();
                    }
                    document = archive.CreateEntry("word/document.xml");

                    using (var entryStream = document.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            streamWriter.Write(xmlData);
                        }
                    }
                }
            }
        }

        public static void ImportImage(string path, byte[] image, string entryName)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = ZipFile.Open(path, ZipArchiveMode.Update))
                {
                    var media = archive.GetEntry(entryName);
                    using (MemoryStream imageStream = new MemoryStream(image))
                    {
                        using (Stream entryStream = media.Open())
                        {
                            imageStream.CopyTo(entryStream);
                        }
                    }
                }
            }
        }
    }
}
