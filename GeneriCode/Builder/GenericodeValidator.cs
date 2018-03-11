using GeneriCode.Genericode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace GeneriCode.Builder
{
    public class GenericodeValidator
    {
        XmlReaderSettings settingsGC04 = new XmlReaderSettings();
        XmlReaderSettings settingsGC10 = new XmlReaderSettings();
        public ValidationEventHandler validationEventHandler;
        public GenericodeValidator()
        {
            foreach (var schema in CGenericode.GENERICODE_04_XSDS)
            {
                settingsGC04.Schemas.Add(schema);
            }
            settingsGC04.ValidationType = ValidationType.Schema;

            foreach (var schema in CGenericode.GENERICODE_10_XSDS)
            {
                settingsGC10.Schemas.Add(schema);
            }
            settingsGC10.ValidationType = ValidationType.Schema;
        }

        public XmlDocument ValidateGC04CodeList(string xml)
        {
            XmlReader reader = XmlReader.Create(xml, settingsGC04);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);
            return document;
        }
        public XmlDocument ValidateGC10CodeList(string xml)
        {
            XmlReader reader = XmlReader.Create(xml, settingsGC10);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);
            return document;
        }
        /// <summary>
        /// default validation handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            validationEventHandler?.Invoke(sender, e);
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }
    }
}
