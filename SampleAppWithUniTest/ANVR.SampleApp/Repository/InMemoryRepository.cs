using ANVR.SampleApp.Repository.Data;
using System;
namespace ANVR.SampleApp.Repository;

internal sealed class InMemoryRepository<IEntity> : IRepository<IEntity>
{
    #region  Private variables

    private readonly InMemoryDataSource<IEntity> _inMemoryDataSource;
    #endregion

    #region  constructor
    /// <summary>
    /// 
    /// </summary>
    /// <param name="inMemoryDataSource"></param>
    public InMemoryRepository(InMemoryDataSource<IEntity> inMemoryDataSource)
    {
        _inMemoryDataSource = inMemoryDataSource;
    }
    #endregion

    #region  IRepository Members
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> Delete(int id)
    {
        try
        {
            _inMemoryDataSource.DeleEntiry(id);
        }
        catch
        {
            throw new RepositoryException("Delete Entity Failed");
        }

        return Task.FromResult(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public Task<IEntity> Get(int id)
    {
        try
        {
            return Task.FromResult(_inMemoryDataSource.GetEntity(id));
        }
        catch 
        {
            throw new RepositoryException("Get Entity Failed");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>

    public async Task<bool> Set(int id, IEntity entity)  
    {
        try
        {
            _inMemoryDataSource.AddEntity(id, entity);
        }
        catch
        {
             throw new RepositoryException("Set Entity Failed");
        }

        return true;
    }
    #endregion
}