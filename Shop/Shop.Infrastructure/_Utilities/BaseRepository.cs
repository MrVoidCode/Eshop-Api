using Common.Domain;
using Common.Domain.Repository;
using Shop.Infrastructure.Persistent.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure._Utilities
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ShopContext Context;
        public BaseRepository(ShopContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity?> GetAsync(long id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
        }
        public async Task<TEntity?> GetTracking(long id)
        {
            return await Context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        void IBaseRepository<TEntity>.Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }
        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().AnyAsync(expression);
        }
        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Any(expression);
        }

        public TEntity? Get(long id)
        {
            return Context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
        }
    }
}
