using GeneriCode.Genericode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Builder
{
    public class GenericodeWriter
    {

        GenericodeValidator validator = new GenericodeValidator();
        static Genericode04CodeListSerializer genericode04CodeListSerializer = new Genericode04CodeListSerializer();
        static Genericode10CodeListSerializer genericode10CodeListSerializer = new Genericode10CodeListSerializer();
        public string ReadGC04CodeList(GeneratedClasses.Genericode.v04.CodeListDocument codeList)
        {
            return genericode04CodeListSerializer.Serialize(codeList);
        }

        public string WriteGC10CodeList(GeneratedClasses.Genericode.v10.CodeListDocument codeList)
        {
            return genericode10CodeListSerializer.Serialize(codeList);
        }
    }
}
