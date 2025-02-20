using LHJ.SqlSugarCore.Entities;
using SqlSugar;

namespace LHJ.Repository;

public class DbContext<T> where T : class, new()
{
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConfigId = "0",
            ConnectionString = BaseDBConfig.ConnectionString,
            DbType = DbType.SqlServer,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式
        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }

    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
    public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

    //public SimpleClient<Users> UserDb { get { return new SimpleClient<Users>(Db); } }
}
