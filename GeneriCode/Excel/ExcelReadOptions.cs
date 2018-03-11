using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Excel
{
    [Serializable]
    public class ExcelReadOptions<USE_TYPE>
    {
        /** Default lines to skip */
        public static int DEFAULT_LINES_TO_SKIP = 0;
        public static int DEFAULT_LINEINDEX_SHORTNAME = 0;
        public static int DEFAULT_LINEINDEX_LONGNAME = -1;

        private int m_nLinesToSkip = DEFAULT_LINES_TO_SKIP;
        private int m_nLineIndexShortName = DEFAULT_LINEINDEX_SHORTNAME;
        private int m_nLineIndexLongName = DEFAULT_LINEINDEX_LONGNAME;
        private IDictionary<int, ExcelReadColumn<USE_TYPE>> m_aColumns = new Dictionary<int, ExcelReadColumn<USE_TYPE>>();

        /**
         * Constructor
         */
        public ExcelReadOptions()
        { }

        /**
         * Set the number of lines to skip before the header row starts
         *
         * @param nLinesToSkip
         *        Must be &ge; 0.
         * @return this
         */
        public ExcelReadOptions<USE_TYPE> SetLinesToSkip(int nLinesToSkip)
        {
            if (nLinesToSkip < 0)
                throw new ArgumentException("nLinesToSkip");
            m_nLinesToSkip = nLinesToSkip;
            return this;
        }

        /**
         * @return The number of lines to skip before the header row starts. Default
         *         is {@value #DEFAULT_LINES_TO_SKIP}.
         */
        public int GetLinesToSkip()
        {
            return m_nLinesToSkip;
        }

        public ExcelReadOptions<USE_TYPE> SetLineIndexShortName(int nLineIndexShortName)
        {
            if (nLineIndexShortName < 0)
                throw new ArgumentException("nLineIndexShortName");
            m_nLineIndexShortName = nLineIndexShortName;
            return this;
        }

        public int GetLineIndexShortName()
        {
            return m_nLineIndexShortName;
        }

        public ExcelReadOptions<USE_TYPE> SetLineIndexLongName(int nLineIndexLongName)
        {
            m_nLineIndexLongName = nLineIndexLongName;
            return this;
        }

        /**
         * @return The line index, where the long names reside. If this value is &lt;
         *         0 than no long name is used.
         */
        public int GetLineIndexLongName()
        {
            return m_nLineIndexLongName;
        }

        /**
         * Add a single column definition.
         *
         * @param nIndex
         *        The 0-based index of the column in Excel.
         * @param sColumnID
         *        The ID of the column in Genericode.
         * @param eUseType
         *        Optional or required?
         * @param sDataType
         *        The XSD data type to be used in Genericode. Use "string" if you're
         *        unsure.
         * @param bKeyColumn
         *        <code>true</code> if this is a key column, <code>false</code>
         *        otherwise. Only required columns can be key columns.
         * @return this
         */
        public ExcelReadOptions<USE_TYPE> AddColumn(int nIndex,
                                                      string sColumnID,
                                                      USE_TYPE eUseType,
                                                      string sDataType,
                                                      bool bKeyColumn)
        {
            if (nIndex < 0)
                throw new ArgumentException("nIndex");
            if (m_aColumns.ContainsKey(nIndex))
                throw new ArgumentException("The column at index " + nIndex + " is already mapped!");
            m_aColumns.Add(nIndex, new ExcelReadColumn<USE_TYPE>(nIndex, sColumnID, eUseType, sDataType, bKeyColumn));
            return this;
        }

        /**
         * @return A list of all defined columns, sorted ascending by index.
         */
        public IList<ExcelReadColumn<USE_TYPE>> GetAllColumns()
        {
            // Create a copy. Values are sorted ascending because of the CommonsTreeMap
            // usage
            return m_aColumns.Values.ToList();
        }
    }
}
