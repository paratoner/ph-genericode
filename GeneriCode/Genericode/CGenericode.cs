using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Genericode
{
    public sealed class CGenericode
    {
        private static Assembly assembly;
        private static Assembly GetAssembly()
        {
            if (assembly != null)
                return assembly;
            assembly = typeof(CGenericode).Assembly;
            return assembly;
        }

        /** 0.4 XSD resources */
        public static List<string> GENERICODE_04_XSDS = new List<string>(new string[]{
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "genericode-code-list-0.4.xsd"),
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "xml.xsd") });

        /** 1.0 XSD resources */

        public static List<string> GENERICODE_10_XSDS = new List<string>(new string[]{
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "genericode-1.0.xsd"),
            EmbeddedResourceHelper.GetEmbeddedResourceAsString(assembly, "GeneriCode.Schemas", "xml.xsd") });

        private static CGenericode instance = new CGenericode();

        private CGenericode()
        { }
    }
}
