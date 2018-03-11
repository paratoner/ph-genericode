using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Excel
{
    [Serializable]
    public class ExcelReadColumn<USE_TYPE>
    {
        private int m_nIndex;
        private string m_sColumnID;
        private USE_TYPE m_eUseType;
        private string m_sDataType;
        private bool m_bKeyColumn;

        public ExcelReadColumn(int nIndex,
                          string sColumnID,
                          USE_TYPE eUseType,
                          string sDataType,
                          bool bKeyColumn)
        {
            if (nIndex < 0)
                throw new ArgumentException("Index");
            if (string.IsNullOrEmpty(sColumnID))
                throw new ArgumentException("ColumnID");

            if (eUseType.Equals(default(USE_TYPE)))
                throw new ArgumentException("eUseType");
            // if (bKeyColumn && eUseType == UseType.OPTIONAL)
            // throw new IllegalArgumentException
            // ("Optional columns cannot be key columns!");
            if (string.IsNullOrEmpty(sDataType))
                throw new ArgumentException("sDataType");
            m_nIndex = nIndex;
            m_sColumnID = sColumnID;
            m_eUseType = eUseType;
            m_sDataType = sDataType;
            m_bKeyColumn = bKeyColumn;
        }

        /**
         * @return The 0-based index of this column.
         */
        public int GetIndex()
        {
            return m_nIndex;
        }

        /**
         * @return The ID of this column to be used in the Genericode file.
         */
        public string GetColumnID()
        {
            return m_sColumnID;
        }

        /**
         * @return optional or required?
         */
        public USE_TYPE GetUseType()
        {
            return m_eUseType;
        }

        /**
         * @return The data type for this column.
         */
        public string GetDataType()
        {
            return m_sDataType;
        }

        /**
         * @return <code>true</code> if this is a key column, <code>false</code>
         *         otherwise. Only required columns can be key columns.
         */
        public bool IsKeyColumn()
        {
            return m_bKeyColumn;
        }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("index={0}", m_nIndex)
                                               .AppendFormat("columnID={0}", m_sColumnID)
                                               .AppendFormat("use={0}", m_eUseType)
                                               .AppendFormat("dataType={0}", m_sDataType)
                                               .AppendFormat("keyColumn={0}", m_bKeyColumn)
                                               .ToString();
        }
    }
}
