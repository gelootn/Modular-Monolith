using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;


namespace ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

public interface IVisitorRepository : IGenericRepository<Visitor, int>
{
    Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken);
}

