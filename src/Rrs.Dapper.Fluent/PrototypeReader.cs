using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Dapper.Fluent
{
    public partial class PrototypeReader<T>
    {
        public Task<T> SingleAsync()
        {
            return _dapperWrapper.SingleAsync<T>();
        }

        public Task<T> SingleOrDefaultAsync()
        {
            return _dapperWrapper.SingleOrDefaultAsync<T>();
        }

        public Task<T> FirstAsync()
        {
            return _dapperWrapper.FirstAsync<T>();
        }

        public Task<T> FirstOrDefaultAsync()
        {
            return _dapperWrapper.FirstOrDefaultAsync<T>();
        }

        public Task<IEnumerable<T>>  QueryAsync()
        {
            return _dapperWrapper.QueryAsync<T>();
        }
    }
}
