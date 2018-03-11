using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GeneriCode.Genericode
{
    public sealed class CGenericode
    {
        private static Assembly assembly;
        private Assembly GetAssembly()
        {
            if (assembly != null)
                return assembly;
            assembly = typeof(CGenericode).Assembly;
            return assembly;
        }

        /** 0.4 XSD resources */
        public List<XmlSchema> GENERICODE_04_XSDS = null;

        /** 1.0 XSD resources */

        public List<XmlSchema> GENERICODE_10_XSDS = null;


        public CGenericode()
        {
            GetAssembly();
            GENERICODE_04_XSDS = new List<XmlSchema>(new XmlSchema[]{
           XmlSchema.Read( EmbeddedResourceHelper.GetEmbeddedResourceAsStream(assembly, "GeneriCode.Schemas.genericode-code-list-0.4.xsd"),null),
            XmlSchema.Read( EmbeddedResourceHelper.GetEmbeddedResourceAsStream(assembly, "GeneriCode.Schemas.xml.xsd"),null           ) });
            GENERICODE_10_XSDS = new List<XmlSchema>(new XmlSchema[]{
           XmlSchema.Read( EmbeddedResourceHelper.GetEmbeddedResourceAsStream(assembly, "GeneriCode.Schemas.genericode-1.0.xsd"),null),
            XmlSchema.Read(EmbeddedResourceHelper.GetEmbeddedResourceAsStream(assembly, "GeneriCode.Schemas.xml.xsd"),null) });
        }
    }
}
