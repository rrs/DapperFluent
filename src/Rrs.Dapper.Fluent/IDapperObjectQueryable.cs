using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rrs.Dapper.Fluent
{
    partial interface IDapperObjectQueryable
    {
        Task<T> FirstAsync<T>();
        Task<T> FirstOrDefaultAsync<T>();
        Task<T> SingleAsync<T>();
        Task<T> SingleOrDefaultAsync<T>();
        Task<IEnumerable<T>> QueryAsync<T>();
    }
}
