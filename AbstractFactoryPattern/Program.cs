/*
简单工厂，工厂模式，抽象工厂
目的：隐藏创建对象的细节，根据条件创建想要的实例
*/
using System.Data;

var dao = Factory.Create("SQL");
using (var conn = dao.GetConnection())
{
    conn.Open();
}

var factory = new SqlServerFactory();
factory.Create();

var factory2 = new ERP();
var dao2 = factory2.CreateSqlite();



interface IDAO
{
    IDbConnection GetConnection();
}

class SqlServerDAO : IDAO
{
    public IDbConnection GetConnection()
    {
        throw new NotImplementedException();
    }
}

class MySqlDAO : IDAO
{
    public IDbConnection GetConnection()
    {
        throw new NotImplementedException();
    }
}

// 简单工厂
static class Factory
{
    public static IDAO Create(string name)
    {
        if (name.Equals("SQL"))
        {
            return new SqlServerDAO();
        }

        if (name.Equals("MySql"))
        {
            return new MySqlDAO();
        }

        return null!;
    }
}

// 抽象工厂
abstract class AbstractFactory
{
    public abstract IDAO Create();
}

class SqlServerFactory : AbstractFactory
{
    public override IDAO Create()
    {
        return new SqlServerDAO();
    }
}

class MySqlFactory : AbstractFactory
{
    public override IDAO Create()
    {
        return new MySqlDAO();
    }
}

abstract class AbsFactory
{
    public abstract IDAO CreateSqlServer();
    public abstract IDAO CreateMySql();
    public abstract IDAO CreateSqlite();
}

class ERP : AbsFactory
{
    public override IDAO CreateSqlServer()
    {
        throw new NotImplementedException();
    }

    public override IDAO CreateMySql()
    {
        throw new NotImplementedException();
    }

    public override IDAO CreateSqlite()
    {
        throw new NotImplementedException();
    }
}