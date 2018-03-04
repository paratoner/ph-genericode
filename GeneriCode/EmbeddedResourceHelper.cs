using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode
{
    public class EmbeddedResourceHelper
    {
        public static string GetEmbeddedResourceAsString(Assembly assembly, string @namespace, string resourceName)
        {
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(string.Format("{0}.{1}", @namespace, resourceName))))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
