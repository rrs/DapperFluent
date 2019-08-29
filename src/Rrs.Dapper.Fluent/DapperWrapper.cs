using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Rrs.Dapper.Fluent
{
    public partial class DapperWrapper
    {
        public Task<int> ExecuteAsync()
        {
            return _c.ExecuteAsync(_command, _params, _t, _timeout, _commandType);
        }

        public Task<T> ExecuteScalarAsync<T>()
        {
            return _c.ExecuteScalarAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public async Task<DataTable> ToDataTableAsync(bool removeReadonly = true)
        {
            var reader = await _c.ExecuteReaderAsync(_command, _params, _t, _timeout, _commandType);
            return DataReaderHelper.ReadTable(reader, removeReadonly);
        }

        public async Task<DataRow> ToDataRowAsync(bool removeReadonly = true)
        {
            var table = await ToDataTableAsync(removeReadonly);
            return table.Rows[0];
        }

        public Task<IEnumerable<T>> QueryAsync<T>()
        {
            return _c.QueryAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public Task<T> FirstAsync<T>()
        {
            return _c.QueryFirstAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public Task<T> FirstOrDefaultAsync<T>()
        {
            return _c.QueryFirstOrDefaultAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public Task<T> SingleAsync<T>()
        {
            return _c.QuerySingleAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public Task<T> SingleOrDefaultAsync<T>()
        {
            return _c.QuerySingleOrDefaultAsync<T>(_command, _params, _t, _timeout, _commandType);
        }

        public Task<SqlMapper.GridReader> QueryMultipleAsync()
        {
            return _c.QueryMultipleAsync(_command, _params, _t, _timeout, _commandType);
        }

        public Task<IDataReader> ExecuteReaderAsync()
        {
            return _c.ExecuteReaderAsync(_command, _params, _t, _timeout, _commandType);
        }

        public async Task<IEnumerable<T>> ExecuteReaderAsync<T>(Func<IDataRecord, T> readerFunc)
        {
            var reader = await ExecuteReaderAsync();
            return DataReaderHelper.ReadWithFunction(reader, readerFunc);
        }

        public PrototypeReader<T> PrototypeAsync<T>(T _)
        {
            return new PrototypeReader<T>(this);
        }
    }
}
