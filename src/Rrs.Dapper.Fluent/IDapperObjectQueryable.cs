using System.Collections.Generic;

namespace Rrs.Dapper.Fluent
{
    interface IDapperObjectQueryable
    {
        T First<T>();
        T FirstOrDefault<T>();
        T Single<T>();
        T SingleOrDefault<T>();
        IEnumerable<T> Query<T>(bool buffered = true);
    }
}
