using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;

using ModularMonolith.Modules.Visits.Database.Repositories.Filters;

namespace ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

public interface IVisitRepository : IGenericRepository<Visit, int>
{
    Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetOpenVisitsAsync(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetVisitsAsync(VisitFilter filter, CancellationToken cancellationToken);
    
    Task<Company?> GetCompanyWithEmployeesAsync(int companyId, CancellationToken cancellationToken);

}