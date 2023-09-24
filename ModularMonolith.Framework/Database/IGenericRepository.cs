using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Framework.Database;

public interface IGenericRepository<TEntity, in TKey> where TEntity : Entity<TKey>
{
    Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity? entity);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}