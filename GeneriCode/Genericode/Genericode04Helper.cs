using GeneriCode.GeneratedClasses.Genericode.v04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Genericode
{
    public sealed class Genericode04Helper
    {
        private Genericode04Helper()
        { }

        /**
         * Get the ID of the passed column element.
         *
         * @param aColumnElement
         *        The column element to use. Must be either a {@link ColumnRef} or a
         *        {@link Column}.
         * @return The ID of the object
         */
        public static string GetColumnElementID(Object columnElement)
        {
            if (columnElement is ColumnRef)
                return ((ColumnRef)columnElement).Id;
            if (columnElement is Column)
                return ((Column)columnElement).Id;
            if (columnElement is Key)
            {
                List<KeyColumnRef> keyColumnRefs = ((Key)columnElement).ColumnRef;
                KeyColumnRef keyColumnRef = keyColumnRefs.First();
                if (keyColumnRef == null)
                    throw new ArgumentException("Key contains not KeyColumnRef!!");
                Object aRef = keyColumnRef.Ref;
                if (aRef is Column)
                    return ((Column)aRef).Id;
                throw new ArgumentException("Unsupported referenced object: " +
                                                    aRef +
                                                    " - " +
                                                    aRef.GetType().Name);
            }
            throw new ArgumentException("Illegal column element: " +
                                                columnElement +
                                                " - " +
                                                columnElement.GetType().Name);
        }

        /**
         * Get the value of a column identified by an ID within a specified row. This
         * method only handles simple values.
         *
         * @param aRow
         *        The row to scan. May not be <code>null</code>.
         * @param sColumnID
         *        The ID of the column to search. May not be <code>null</code>.
         * @return <code>null</code> if no such column is contained
         */
        public static string GetRowValue(Row aRow, string columnID)
        {
            foreach (Value value in aRow.Value)
            {
                string id = GetColumnElementID(value.ColumnRef);
                if (id.Equals(columnID))
                {
                    SimpleValue simpleValue = value.SimpleValue;
                    return simpleValue != null ? simpleValue.Value : null;
                }
            }
            return null;
        }

        /**
         * Get all contained columns
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @return A non-<code>null</code> list of all columns. Never
         *         <code>null</code> but maybe empty.
         */
        public static IList<Column> GetAllColumns(ColumnSet columnSet)
        {
            return columnSet.Column.Where(c => c != null).ToList();
        }

        /**
         * Get the IDs of all contained columns
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @return A non-<code>null</code> list of all column IDs. Never
         *         <code>null</code> but maybe empty.
         */
        public static IList<string> GetAllColumnIDs(ColumnSet columnSet)
        {
            return columnSet.Column.Where(c => c != null).Select(c => c.Id).ToList();
        }

        /**
         * Get the column with the specified ID.
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @param sID
         *        The ID to search. May be <code>null</code>.
         * @return <code>null</code> if no such column exists.
         */
        public static Column GetColumnOfID(ColumnSet columnSet, string id)
        {
            return columnSet.Column.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        /**
         * Get all contained keys
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @return A non-<code>null</code> list of all keys. Never <code>null</code>
         *         but maybe empty.
         */
        public static IList<Key> GetAllKeys(ColumnSet columnSet)
        {
            return columnSet.Key.Where(k => k != null).ToList();
        }

        /**
   * Get the IDs of all contained keys
   *
   * @param aColumnSet
   *        The column set to scan. May not be <code>null</code>.
   * @return A non-<code>null</code> list of all key IDs. Never
   *         <code>null</code> but maybe empty.
   */
        public static IList<string> GetAllKeyIDs(ColumnSet columnSet)
        {
            return columnSet.Key.Where(k => k != null).Select(k => k.Id).ToList();
        }

        /**
         * Get the key with the specified ID.
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @param sID
         *        The ID to search. May be <code>null</code>.
         * @return <code>null</code> if no such key exists.
         */
        public static Key GetKeyOfID(ColumnSet columnSet, string id)
        {
            return columnSet.Key.Where(k => k != null && k.Id.Equals(id)).FirstOrDefault();
        }

        /**
         * Check if the passed column ID is a key column in the specified column set
         *
         * @param aColumnSet
         *        The column set to scan. May not be <code>null</code>.
         * @param sColumnID
         *        The column ID to search. May be <code>null</code>.
         * @return <code>true</code> if the passed column ID is a key column
         */
        public static bool IsKeyColumn(ColumnSet columnSet, string columnID)
        {
            if (columnID != null)
                foreach (Key key in GetAllKeys(columnSet))
                    foreach (KeyColumnRef columnRef in key.ColumnRef)
                        if (columnRef.Ref.Equals(columnID))
                            return true;
            return false;
        }

        /**
         * Create a {@link ShortName} object
         *
         * @param sValue
         *        The value to assign
         * @return Never <code>null</code>.
         */
        public static ShortName CreateShortName(string value)
        {
            ShortName shortName = new ShortName();
            shortName.Value = value;
            return shortName;
        }

        /**
         * Create a {@link LongName} object
         *
         * @param sValue
         *        The value to assign
         * @return Never <code>null</code>.
         */
        public static LongName CreateLongName(string value)
        {
            LongName longName = new LongName();
            longName.Value = value;
            return longName;
        }

        /**
         * Create a {@link SimpleValue} object
         *
         * @param sValue
         *        The value to assign
         * @return Never <code>null</code>.
         */
        public static SimpleValue CreateSimpleValue(string value)
        {
            SimpleValue simpleValue = new SimpleValue();
            simpleValue.Value = value;
            return simpleValue;
        }

        /**
         * Create a {@link KeyColumnRef} object
         *
         * @param aColumn
         *        The column to reference
         * @return Never <code>null</code>.
         */
        public static KeyColumnRef CreateKeyColumnRef(Column column)
        {
            KeyColumnRef columnRef = new KeyColumnRef();
            // Important: reference the object itself and not just the ID!!!
            columnRef.Ref = column.Id;
            return columnRef;
        }

        /**
         * Create a new column to be added to a column set
         *
         * @param sColumnID
         *        The ID of the column
         * @param eUseType
         *        The usage type (optional or required)
         * @param sShortName
         *        The short name of the column
         * @param sLongName
         *        The long name of the column
         * @param sDataType
         *        The data type to use
         * @return Never <code>null</code>.
         */
        public static Column CreateColumn(string columnID,
                                           UseType useType,
                                           string shortName,
                                           string longName,
                                           string dataType)
        {
            if (string.IsNullOrEmpty(columnID))
                throw new ArgumentNullException("columnID");
            if (string.IsNullOrEmpty(shortName))
                throw new ArgumentNullException("shortName");
            if (string.IsNullOrEmpty(dataType))
                throw new ArgumentNullException("dataType");

            Column aColumn = new Column();
            aColumn.Id = columnID;
            aColumn.Use = useType;
            aColumn.ShortName = CreateShortName(shortName);
            if (!string.IsNullOrEmpty(longName))
            {
                if (aColumn.LongName == null)
                    aColumn.LongName = new List<LongName>();
                aColumn.LongName.Add(CreateLongName(longName));
            }
            Data aData = new Data();
            aData.Type = dataType;
            aColumn.Data = aData;
            return aColumn;
        }

        /**
         * Create a new key to be added to a column set
         *
         * @param sColumnID
         *        The ID of the column
         * @param sShortName
         *        The short name of the column
         * @param sLongName
         *        The long name of the column
         * @param aColumn
         *        The referenced column. May not be <code>null</code>.
         * @return Never <code>null</code>.
         */
        public static Key CreateKey(string sColumnID,
                                     string sShortName,
                                     string sLongName,
                                     Column aColumn)
        {
            if (string.IsNullOrEmpty(sColumnID))
                throw new ArgumentNullException("sColumnID");
            if (string.IsNullOrEmpty(sShortName))
                throw new ArgumentNullException("sShortName");
            if (aColumn == null)
                throw new ArgumentNullException("aColumn");

            Key aKey = new Key();
            aKey.Id = sColumnID;
            aKey.ShortName = CreateShortName(sShortName);
            if (!string.IsNullOrEmpty(sLongName))
            {
                if (aKey.LongName == null)
                    aKey.LongName = new List<LongName>();
                aKey.LongName.Add(CreateLongName(sLongName));
            }
            if (aKey.ColumnRef == null)
                aKey.ColumnRef = new List<KeyColumnRef>();
            aKey.ColumnRef.Add(CreateKeyColumnRef(aColumn));
            return aKey;
        }
    }
}
