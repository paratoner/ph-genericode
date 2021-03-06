﻿using GeneriCode.Genericode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeneriCode.Builder
{
    public class GenericodeReader
    {
        GenericodeValidator validator = new GenericodeValidator();
        static Genericode04CodeListSerializer genericode04CodeListSerializer = new Genericode04CodeListSerializer();
        static Genericode10CodeListSerializer genericode10CodeListSerializer = new Genericode10CodeListSerializer();
        public GeneratedClasses.Genericode.v04.CodeListDocument ReadGC04CodeList(string xml)
        {
            validator.ValidateGC04CodeList(xml);
            return genericode04CodeListSerializer.Deserialize(xml);
        }

        public GeneratedClasses.Genericode.v10.CodeListDocument ReadGC10CodeList(string xml)
        {
            validator.ValidateGC04CodeList(xml);
            return genericode10CodeListSerializer.Deserialize(xml);
        }
    }
}
