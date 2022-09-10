using System;
using System.IO;
using System.Reflection;

namespace SpectrumApp.Data
{
    public static class FileManager
    {
        public static string ReadEmbeddedFile(string resourceId)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SpectrumApp.Data.FileManager)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(resourceId);
            using (var reader = new System.IO.StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

