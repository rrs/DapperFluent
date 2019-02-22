DapperFluent
============
A simple fluent style wrapper around Dapper giving a few extra little functions like ToDataTable() or ExecuteReader<T>(Func<IDataRecord, T> readerFunc)

Usage
-----

Firstly selection text or stored procedure mode then you can call the different finishing methods

```
private void Example(IDbConnection c)
{
    var datetime = c.Sql("select getdate()").Scalar<DateTime>();
}

```

```
private void Example(IDbConnection c)
{
    c.Sproc("queryDoSomethingUsefull").Execute();
}

```

works off IDbTransaction

```
private void Example(IDbTransaction t)
{
    t.Sproc("queryDoSomethingUsefull").Execute();
}

```

pass parameters 

```
private void Example(IDbConnection c)
{
    c.Sproc("queryDoSomethingUsefull").Parameters(parameterObject).Execute();
}

```

set timeout

```
private void Example(IDbConnection c)
{
    c.Sproc("queryDoSomethingUsefull").Timeout(1000).Execute();
}

```