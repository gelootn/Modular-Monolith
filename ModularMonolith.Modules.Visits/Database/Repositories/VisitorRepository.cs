using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;
using ModularMonolith.Entities.Database;
using ModularMonolith.Framework.Database;

using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Database.Repositories;

public class VisitorRepository : GenericRepository<Visitor, int>, IVisitorRepository 
{
    private readonly ReadOnlyDbContext _roContext;

    public VisitorRepository(EmployeeDbContext context, ReadOnlyDbContext roContext) : base(context)
    {
        _roContext = roContext;
    }

    public async Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken)
    {
       var visitor = await _roContext.Set<Visitor>().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
       return visitor;
    }
}