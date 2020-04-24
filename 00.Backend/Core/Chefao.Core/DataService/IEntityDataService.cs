using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chefao.Core.DataService
{
    public interface IEntityDataService<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetById<TId>(TId id);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria);
        Task<IList<TEntity>> List(Expression<Func<TEntity, bool>> criteria);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}