using ANVR.SampleApp.Repository.Data;

namespace ANVR.SampleApp.Repository;

public interface IRepository<IEntity>
{
    /// <summary>
    /// Get by Id
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public Task<IEntity> Get(int id);

    /// <summary>
    /// Set By Type
    /// </summary>
    /// <param name="entity"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public Task<bool> Set(int id, IEntity entity);

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> Delete(int id);
}
