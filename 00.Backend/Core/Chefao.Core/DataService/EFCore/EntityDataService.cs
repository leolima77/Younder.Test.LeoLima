using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chefao.Core.DataService.EFCore
{
    public class EntityDataService<TEntity> : IEntityDataService<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext DbContext;

        public EntityDataService(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById<TId>(TId id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicated)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicated);
        }

        public virtual async Task<IList<TEntity>> List(Expression<Func<TEntity, bool>> predicated)
        {
            return await DbContext.Set<TEntity>().Where(predicated).ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            var obj = DbContext.Add(entity);

            await DbContext.SaveChangesAsync();

            return obj.Entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            var local = DbContext.Set<TEntity>().Local.FirstOrDefault();
            if (local != null)
                DbContext.Entry(local).State = EntityState.Detached;

            DbContext.Entry(entity).State = EntityState.Modified;

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            DbContext.Remove(entity);

            return await DbContext.SaveChangesAsync() > 0;
        }
    }
}