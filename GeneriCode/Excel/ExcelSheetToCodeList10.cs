using GeneriCode.GeneratedClasses.Genericode.v10;
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
    public class ExcelSheetToCodeList10
    {
        private static XmlQualifiedName QNAME_ANNOTATION = new XmlQualifiedName("info", "urn:www.helger.com:schemas:genericode-ext");

        private ExcelSheetToCodeList10()
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
            XmlElement xmlElement = xmlDocument.CreateElement(QNAME_ANNOTATION.Name, QNAME_ANNOTATION.Namespace);
            xmlElement.InnerText = "Automatically created by ph-genericode-net. Do NOT edit.";
            AnyOtherContent aContent = new AnyOtherContent();
            aContent.Any.Add(xmlElement);

            aAnnotation.AppInfo = aContent;
            ret.Annotation = aAnnotation;

            // create identification
            Identification aIdentification = new Identification();
            aIdentification.ShortName = Genericode10Helper.CreateShortName(sCodeListName);
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
                String sShortName = aExcelSheet.GetRow(aReadOptions.GetLineIndexShortName())
                                                    .GetCell(aExcelColumn.GetIndex())
                                                    .StringCellValue;

                // Read long name (optional)
                String sLongName = null;
                if (aReadOptions.GetLineIndexLongName() >= 0)
                    sLongName = aExcelSheet.GetRow(aReadOptions.GetLineIndexLongName())
                                           .GetCell(aExcelColumn.GetIndex())
                                           .StringCellValue;

                // Create Genericode column set
                Column aColumn = Genericode10Helper.CreateColumn(aExcelColumn.GetColumnID(),
                                                                     aExcelColumn.GetUseType(),
                                                                     sShortName,
                                                                     sLongName,
                                                                     aExcelColumn.GetDataType());

                // add column
                aColumnSet.Items.Add(aColumn);

                if (aExcelColumn.IsKeyColumn())
                {
                    // Create key definition
                    Key aKey = Genericode10Helper.CreateKey(aExcelColumn.GetColumnID() +
                                                                  "Key",
                                                                  sShortName,
                                                                  sLongName,
                                                                  aColumn);

                    // Add key
                    aColumnSet.Items1.Add(aKey);
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
                    //String sValue = aExcelRow.GetCell(aExcelColumn.GetIndex()).StringCellValue;
                    var cell = aExcelRow.GetCell(aExcelColumn.GetIndex());
                    string sValue = "";
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            sValue = cell.NumericCellValue.ToString();
                            break;
                        case CellType.String:
                            sValue = cell.StringCellValue;
                            break;
                        case CellType.Boolean:
                            sValue = cell.BooleanCellValue.ToString();
                            break;
                        case CellType.Error:
                            sValue = cell.ErrorCellValue.ToString();
                            break;
                        case CellType.Blank:
                            sValue = "";
                            break;
                        case CellType.Formula:
                            sValue = cell.CellFormula;
                            break;
                        case CellType.Unknown:
                            sValue = "";
                            break;
                        default:
                            break;

                    }
                    if (!string.IsNullOrEmpty(sValue) || aExcelColumn.GetUseType() == UseType.required)
                    {
                        // Create a single value in the current row
                        Value aValue = new Value();
                        aValue.ColumnRef = Genericode10Helper.GetColumnOfID(aColumnSet, aExcelColumn.GetColumnID()).Id;
                        aValue.SimpleValue = Genericode10Helper.CreateSimpleValue(sValue);
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
