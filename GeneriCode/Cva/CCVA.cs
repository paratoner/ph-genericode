using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Cva
{
    public sealed class CCVA
    {
        private static Assembly assembly;
        private static Assembly GetAssembly()
        {
            if (assembly != null)
                return assembly;
            assembly = typeof(CCVA).Assembly;
            return assembly;
        }

        public static List<string> CVA_10_XSDS = new List<string>(new string[]{
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "ContextValueAssociation-1.0.xsd"),
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "xml.xsd")
        });
        private static CCVA instance = new CCVA();
        private CCVA()
        { }
    }
}
