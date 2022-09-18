using SberbankDbContext;
using DbContextEntities.Base;

namespace DbRepositories.Base
{
    public abstract class BaseDbRepository<TEntity> where TEntity : BaseEntity
    {
        protected SberbankDbContextСonnector Context { get; }

        public BaseDbRepository(SberbankDbContextСonnector context)
        {
            Context = context;
        }

        protected async Task<TEntity?> GetEntityAsync(int id)
        {
            return await Context.FindAsync<TEntity>(id);
        }

        protected async Task AddEntityAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        protected async Task UpdateEntityAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        protected async Task RemoveEntityAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
