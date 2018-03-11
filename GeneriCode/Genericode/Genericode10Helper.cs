using GeneriCode.GeneratedClasses.Genericode.v10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriCode.Genericode
{
    public sealed class Genericode10Helper
    {
        private Genericode10Helper()
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
                KeyColumnRef aKeyColumnRef = keyColumnRefs.First();
                if (aKeyColumnRef == null)
                    throw new ArgumentException("Key contains not KeyColumnRef!!");
                Object rref = aKeyColumnRef.Ref;
                if (rref is Column)
                    return ((Column)rref).Id;
                throw new ArgumentException("Unsupported referenced object: " +
                                                    rref +
                                                    " - " +
                                                     rref.GetType().Name);
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
        public static String GetRowValue(Row row, string columnID)
        {
            foreach (Value value in row.Value)
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
            return columnSet.Items.Where(c => c.GetType() == typeof(Column)).Select(c => (Column)c).ToList();
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
            return columnSet.Items.Where(c => c.GetType() == typeof(Column)).Select(c => (Column)c)
                .Select(c => c.Id).ToList();
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
            return columnSet.Items.Where(c => c.GetType() == typeof(Column)).Select(c => (Column)c).Where(c => c.Id.Equals(id)).FirstOrDefault();
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
            return columnSet.Items1.Where(k => k.GetType() == typeof(Key)).Select(k => (Key)k).ToList();
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
            return columnSet.Items1.Where(k => k.GetType() == typeof(Key)).Select(k => (Key)k).Select(k => k.Id).ToList();
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
            return columnSet.Items1.Where(k => k.GetType() == typeof(Key)).Select(k => (Key)k).Where(k => k.Id.Equals(id)).FirstOrDefault();
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
            if (!string.IsNullOrEmpty(columnID))
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

            Column column = new Column();
            column.Id = columnID;
            column.Use = useType;
            column.ShortName = CreateShortName(shortName);
            if (!string.IsNullOrEmpty(longName))
            {
                if (column.LongName == null)
                    column.LongName = new List<LongName>();
                column.LongName.Add(CreateLongName(longName));
            }
            Data data = new Data();
            data.Type = dataType;
            column.Data = data;
            return column;
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
        public static Key CreateKey(string columnID,
                                     string shortName,
                                     string longName,
                                     Column column)
        {
            if (string.IsNullOrEmpty(columnID))
                throw new ArgumentNullException("columnID");
            if (string.IsNullOrEmpty(shortName))
                throw new ArgumentNullException("shortName");
            if (column == null)
                throw new ArgumentNullException("column");

            Key key = new Key();
            key.Id = columnID;
            key.ShortName = CreateShortName(shortName);
            if (!string.IsNullOrEmpty(longName))
            {
                if (key.LongName == null)
                    key.LongName = new List<LongName>();
                key.LongName.Add(CreateLongName(longName));
            }
            if (key.ColumnRef == null)
                key.ColumnRef = new List<KeyColumnRef>();
            key.ColumnRef.Add(CreateKeyColumnRef(column));
            return key;
        }
    }
}
