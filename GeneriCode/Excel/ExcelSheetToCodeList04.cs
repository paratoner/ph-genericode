using GeneriCode.GeneratedClasses.Genericode.v04;
using GeneriCode.Genericode;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeneriCode.Excel
{
    public class ExcelSheetToCodeList04
    {
        private static XmlQualifiedName QNAME_ANNOTATION = new XmlQualifiedName("info", "urn:www.helger.com:schemas:genericode-ext");

        private ExcelSheetToCodeList04()
        { }

        public static CodeListDocument ConvertToSimpleCodeList(ISheet aExcelSheet,
                                                                ExcelReadOptions<UseType> aReadOptions,
                                                                string sCodeListName,
                                                                string sCodeListVersion,
                                                                Uri aCanonicalUri,
                                                                Uri aCanonicalVersionUri,
                                                                Uri aLocationURI)
        {
            if (aExcelSheet == null)
                throw new ArgumentNullException("ExcelSheet");

            if (aReadOptions == null)
                throw new ArgumentNullException("ReadOptions");

            CodeListDocument ret = new CodeListDocument();
            XmlDocument xmlDocument = new XmlDocument();
            // create annotation
            Annotation aAnnotation = new Annotation();
            AnyOtherContent aContent = new AnyOtherContent();
            XmlElement xmlElement = xmlDocument.CreateElement(QNAME_ANNOTATION.Name, QNAME_ANNOTATION.Namespace);
            xmlElement.InnerText = "Automatically created by ph-genericode-net. Do NOT edit.";
            aContent.Any.Add(xmlElement);
            aAnnotation.AppInfo = aContent;
            ret.Annotation = aAnnotation;

            // create identification
            Identification aIdentification = new Identification();
            aIdentification.ShortName = Genericode04Helper.CreateShortName(sCodeListName);
            aIdentification.Version = sCodeListVersion;
            aIdentification.CanonicalUri = aCanonicalUri.ToString();
            aIdentification.CanonicalVersionUri = aCanonicalVersionUri.ToString();
            if (aLocationURI != null)
                aIdentification.LocationUri.Add(aLocationURI.ToString());
            ret.Identification = aIdentification;

            // create columns
            IList<ExcelReadColumn<UseType>> aExcelColumns = aReadOptions.GetAllColumns();
            ColumnSet aColumnSet = new ColumnSet();
            foreach (ExcelReadColumn<UseType> aExcelColumn in aExcelColumns)
            {
                // Read short name (required)
                string sShortName = aExcelSheet.GetRow(aReadOptions.GetLineIndexShortName())
                                                     .GetCell(aExcelColumn.GetIndex())
                                                     .StringCellValue;

                // Read long name (optional)
                String sLongName = null;
                if (aReadOptions.GetLineIndexLongName() >= 0)
                    sLongName = aExcelSheet.GetRow(aReadOptions.GetLineIndexLongName())
                                           .GetCell(aExcelColumn.GetIndex())
                                           .StringCellValue;

                // Create Genericode column set
                Column aColumn = Genericode04Helper.CreateColumn(aExcelColumn.GetColumnID(),
                                                                      aExcelColumn.GetUseType(),
                                                                      sShortName,
                                                                      sLongName,
                                                                      aExcelColumn.GetDataType());

                // add column
                aColumnSet.Column.Add(aColumn);

                if (aExcelColumn.IsKeyColumn())
                {
                    // Create key definition
                    Key aKey = Genericode04Helper.CreateKey(aExcelColumn.GetColumnID() +
                                                                   "Key",
                                                                   sShortName,
                                                                   sLongName,
                                                                   aColumn);

                    // Add key
                    aColumnSet.Key.Add(aKey);
                }
            }
            ret.ColumnSet = aColumnSet;

            // Read items
            SimpleCodeList aSimpleCodeList = new SimpleCodeList();

            // Determine the row where reading should start
            int nRowIndex = aReadOptions.GetLinesToSkip();
            while (true)
            {
                // Read a single excel row
                IRow aExcelRow = aExcelSheet.GetRow(nRowIndex++);
                if (aExcelRow == null)
                    break;

                // Create Genericode row
                Row aRow = new Row();
                foreach (ExcelReadColumn<UseType> aExcelColumn in aExcelColumns)
                {
                    string sValue = aExcelRow.GetCell(aExcelColumn.GetIndex()).StringCellValue;
                    if (!string.IsNullOrEmpty(sValue) || aExcelColumn.GetUseType() == UseType.required)
                    {
                        // Create a single value in the current row
                        Value aValue = new Value();
                        aValue.ColumnRef = Genericode04Helper.GetColumnOfID(aColumnSet, aExcelColumn.GetColumnID()).Id;
                        aValue.SimpleValue = Genericode04Helper.CreateSimpleValue(sValue);
                        aRow.Value.Add(aValue);
                    }
                }
                aSimpleCodeList.Row.Add(aRow);
            }
            ret.SimpleCodeList = aSimpleCodeList;

            return ret;
        }
    }
}
