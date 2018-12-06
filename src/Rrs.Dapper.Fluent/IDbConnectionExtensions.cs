﻿using System.Data;

namespace Rrs.Dapper.Fluent
{
    public static class IDbConnectionExtensions
    {
        public static DapperWrapper Sql(this IDbConnection c, string command)
        {
            return new DapperWrapper(c, CommandType.Text, command);
        }

        public static DapperWrapper Sproc(this IDbConnection c, string command)
        {
            return new DapperWrapper(c,  CommandType.StoredProcedure, command);
        }

        public static DapperWrapper Sql(this IDbTransaction t, string command)
        {
            return new DapperWrapper(t.Connection, t, CommandType.Text, command);
        }

        public static DapperWrapper Sproc(this IDbTransaction t, string command)
        {
            return new DapperWrapper(t.Connection, t, CommandType.StoredProcedure, command);
        }
    }
}