using Microsoft.EntityFrameworkCore;
using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Framework.Database;


public  class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity,TKey > where TEntity : Entity<TKey>
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> Set;

    public GenericRepository(DbContext context)
    {
        Context = context;
        Set = context.Set<TEntity>();
    }
    
    async Task<TEntity> IGenericRepository<TEntity, TKey>.AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity.IsNew)
        {
            await Set.AddAsync(entity, cancellationToken);
        }
        else
        {
            Set.Update(entity);
        }

        return entity;
    }

    void IGenericRepository<TEntity, TKey>.Delete(TEntity? entity)
    {
        SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity, TKey>.DeleteAsync(TKey id, CancellationToken cancellationToken)
    {
        var entity = await Set.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity, TKey>.SaveChangesAsync(CancellationToken cancellationToken)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    private void SetDeleted(TEntity? entity)
    {
        if (entity != null)
        {
            entity.Deleted = true;
        }
    }
}