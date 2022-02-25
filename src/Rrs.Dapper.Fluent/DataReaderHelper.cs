using System;
using System.Collections.Generic;
using System.Data;

namespace Rrs.Dapper.Fluent
{
    class DataReaderHelper
    {
        public static DataTable ReadTable(IDataReader reader, bool removeReadonly)
        {
            var dataTable = new DataTable();
            dataTable.Load(reader);
            if (removeReadonly)
            {
                foreach (DataColumn c in dataTable.Columns)
                {
                    c.ReadOnly = false;
                }
            }

            return dataTable;
        }

        public static DataSet ReadDataSet(IDataReader reader, bool removeReadonly)
        {
            var ds = new DataSet();
            while (!reader.IsClosed)
            {
                var table = ReadTable(reader, removeReadonly);
                ds.Tables.Add(table);
            }
            return ds;
        }

        public static IEnumerable<T> ReadWithFunction<T>(IDataReader reader, Func<IDataRecord, T> readerFunc)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    yield return readerFunc(reader);
                }
            }
        }
    }
}
