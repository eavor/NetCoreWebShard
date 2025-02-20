using LHJ.IRepository;
using SqlSugar;

namespace LHJ.Repository;

/// <summary>
/// 基类实现
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseRepository<TEntity> : DbContext<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
{
    /// <summary>
    /// 写入实体数据
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<bool> Add(TEntity model)
    {
        //这里需要注意的是，如果使用了Task.Run()就会导致 sql语句日志无法记录改成下面的
        //var i = await Task.Run(() => Db.Insertable(model).ExecuteCommand());
        var i = await Db.Insertable(model).ExecuteCommandAsync();
        return i > 0;
    }

    /// <summary>
    /// 根据ID删除
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<bool> DeleteByIds(object[] ids)
    {
        var i = await Db.Deleteable<TEntity>().In(ids).ExecuteCommandAsync();
        return i > 0;
    }

    /// <summary>
    /// 根据ID查询一条数据
    /// </summary>
    /// <param name="objId"></param>
    /// <returns></returns>
    public async Task<TEntity> QueryByID(object objId)
    {
        return await Db.Queryable<TEntity>().InSingleAsync(objId);
    }

    /// <summary>
    /// 更新实体数据
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<bool> Update(TEntity model)
    {
        //这种方式会以主键为条件
        var i = await Db.Updateable(model).ExecuteCommandAsync();
        return i > 0;
    }

    public SqlSugarClient GetDb(string configId) => Db;
}
