using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GeneriCode
{
    public class GenericXmlSerializer<T> : XmlSerializer where T : class
    {
        //, new XmlRootAttribute("ContextValueAssociation") { Namespace = "http://docs.oasis-open.org/codelist/ns/ContextValueAssociation/1.0/" }
        public GenericXmlSerializer() : base(typeof(T))
        {
            
        }
        public virtual T Deserialize(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                return base.Deserialize(reader) as T;
            }
        }

        public virtual string Serialize(T obj)
        {
            using (var sWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sWriter))
                {
                    base.Serialize(writer, obj);
                    return sWriter.ToString();
                }
            }
        }
        protected override XmlSerializationReader CreateReader()
        {
            return base.CreateReader();
        }
    }
}
