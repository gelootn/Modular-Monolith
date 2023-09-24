using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;
using ModularMonolith.Entities.Database;
using ModularMonolith.Framework.Database;
using ModularMonolith.Framework.Extensions;

using ModularMonolith.Modules.Visits.Database.Repositories.Filters;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Database.Repositories;

public class VisitRepository : GenericRepository<Visit, int>, IVisitRepository
{
    private readonly ReadOnlyDbContext _roContext;

    public VisitRepository(EmployeeDbContext context, ReadOnlyDbContext roContext) : base(context)
    {
        _roContext = roContext;
    }

    public async Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken)
    {
        var visit = await Set.FirstOrDefaultAsync(x =>  x.Visitor.Email == email, cancellationToken);
        return visit;
    }

    public async Task<IReadOnlyCollection<Visit>> GetOpenVisitsAsync(CancellationToken cancellationToken)
    {
        var visits = await _roContext.DbSet<Visit>()
            .Include(x=>x.Visitor)
            .Include(x=> x.Company)
            .Include(x=> x.Employee)
            .Where(x => x.Stop == null).ToListAsync(cancellationToken);
        return visits;
    }
    

    public async Task<IReadOnlyCollection<Visit>> GetVisitsAsync(VisitFilter filter, CancellationToken cancellationToken)
    {
        var query = _roContext.DbSet<Visit>()
            .Include(x => x.Company)
            .Include(x => x.Employee)
            .Include(x => x.Visitor)
            .AsQueryable();

        if (!filter.VisitorName.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Name != null && x.Visitor.Name.Contains(filter.VisitorName));
        if (!filter.VisitorEmail.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Email != null && x.Visitor.Email.Contains(filter.VisitorEmail));
        if (!filter.VisitorCompany.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Company != null && x.Visitor.Company.Contains(filter.VisitorCompany));
        if (!filter.Company.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Company.Name != null && x.Company.Name.Contains(filter.Company));
        if (!filter.Employee.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Employee.Name != null && x.Employee.Name.Contains(filter.Employee));



        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Company?> GetCompanyWithEmployeesAsync(int companyId, CancellationToken cancellationToken)
    {
        var company = await _roContext.DbSet<Company>()
            .Include(x => x.Employees)
            .FirstOrDefaultAsync(x => x.Id == companyId, cancellationToken);
        return company;
    }
}