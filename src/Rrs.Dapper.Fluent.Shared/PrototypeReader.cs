using System.Collections.Generic;

namespace Rrs.Dapper.Fluent
{
    public partial class PrototypeReader<T>
    {
        private readonly IDapperObjectQueryable _dapperWrapper;

        internal PrototypeReader(IDapperObjectQueryable dapperWrapper)
        {
            _dapperWrapper = dapperWrapper;
        }

        public T Single()
        {
            return _dapperWrapper.Single<T>();
        }

        public T SingleOrDefault()
        {
            return _dapperWrapper.SingleOrDefault<T>();
        }

        public T First()
        {
            return _dapperWrapper.First<T>();
        }

        public T FirstOrDefault()
        {
            return _dapperWrapper.FirstOrDefault<T>();
        }

        public IEnumerable<T> Query()
        {
            return _dapperWrapper.Query<T>();
        }
    }
}
