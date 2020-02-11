using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rrs.Dapper.Fluent
{
    public partial class DapperWrapper
    {
        private readonly IDbConnection _c;
        private readonly IDbTransaction _t;
        private readonly CommandType _commandType;
        private readonly string _command;
        private object _params;
        private int? _timeout;

        internal DapperWrapper(IDbConnection c, IDbTransaction t, CommandType commandType, string command)
        {
            _c = c;
            _t = t;
            _commandType = commandType;
            _command = command;
        }

        internal DapperWrapper(IDbConnection c, CommandType commandType, string command)
        {
            _c = c;
            _commandType = commandType;
            _command = command;
        }

        public DapperWrapper Parameters(object @params)
        {
            _params = @params;
            return this;
        }

        public DapperWrapper Timeout(int timeout)
        {
            _timeout = timeout;
            return this;
        }

        public int Execute()
        {
            return _c.Execute(_command, _params, _t, _timeout, _commandType);
        }

        public dynamic ExecuteScalar()
        {
            return _c.ExecuteScalar(_command, _params, _t, _timeout, _commandType);
        }

        public T ExecuteScalar<T>()
        {
            return _c.ExecuteScalar<T>(_command, _params, _t, _timeout, _commandType);
        }

        public DataTable ToDataTable(bool removeReadonly = true)
        {
            var reader = _c.ExecuteReader(_command, _params, _t, _timeout, _commandType);
            return DataReaderHelper.ReadTable(reader, removeReadonly);
        }

        public DataRow ToDataRow(bool removeReadonly = true)
        {
            return ToDataTable(removeReadonly).Rows[0];
        }

        public IEnumerable<dynamic> Query(bool buffered = true)
        {
            return _c.Query(_command, _params, _t, buffered, _timeout, _commandType);
        }

        public IEnumerable<T> Query<T>(bool buffered = true)
        {
            return _c.Query<T>(_command, _params, _t, buffered, _timeout, _commandType);
        }

        public dynamic First()
        {
            return _c.QueryFirst(_command, _params, _t, _timeout, _commandType);
        }

        public T First<T>()
        {
            return _c.QueryFirst<T>(_command, _params, _t, _timeout, _commandType);
        }

        public dynamic FirstOrDefault()
        {
            return _c.QueryFirstOrDefault(_command, _params, _t, _timeout, _commandType);
        }

        public T FirstOrDefault<T>()
        {
            return _c.QueryFirstOrDefault<T>(_command, _params, _t, _timeout, _commandType);
        }

        public dynamic Single()
        {
            return _c.QuerySingle(_command, _params, _t, _timeout, _commandType);
        }

        public T Single<T>()
        {
            return _c.QuerySingle<T>(_command, _params, _t, _timeout, _commandType);
        }
        
        public dynamic SingleOrDefault()
        {
            return _c.QuerySingleOrDefault(_command, _params, _t, _timeout, _commandType);
        }

        public T SingleOrDefault<T>()
        {
            return _c.QuerySingleOrDefault<T>(_command, _params, _t, _timeout, _commandType);
        }

        public SqlMapper.GridReader QueryMultiple()
        {
            return _c.QueryMultiple(_command, _params, _t, _timeout, _commandType);
        }

        public IDataReader ExecuteReader()
        {
            return _c.ExecuteReader(_command, _params, _t, _timeout, _commandType);
        }

        public IEnumerable<T> ExecuteReader<T>(Func<IDataRecord, T> readerFunc)
        {
            var reader = ExecuteReader();
            return DataReaderHelper.ReadWithFunction(reader, readerFunc);
        }
    }
}
