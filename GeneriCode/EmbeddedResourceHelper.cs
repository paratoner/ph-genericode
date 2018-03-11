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
            return GetEmbeddedResourceAsString(assembly, string.Format("{0}.{1}", @namespace, resourceName));
        }
        public static string GetEmbeddedResourceAsString(Assembly assembly,string resourceNameWithNamespace)
        {
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(resourceNameWithNamespace)))
            {
                return reader.ReadToEnd();
            }
        }
        public static Stream GetEmbeddedResourceAsStream(Assembly assembly,string resourceNameWithNamespace)
        {
            return assembly.GetManifestResourceStream(resourceNameWithNamespace);
        }
        public static string[] GetAllResourceNames(Assembly assembly)
        {
            return assembly.GetManifestResourceNames();
        }
    }
}
