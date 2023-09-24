using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Database.Repositories;

public class CompanyRepository : GenericRepository<Company, int>, ICompanyRepository
{
    public CompanyRepository(CompanyDbContext context) : base(context)
    {

    }
    async Task<IReadOnlyCollection<Company>> ICompanyRepository.GetCompanies()
    {
        return await Set.Include(x=> x.Employees).ToListAsync();
    }

    async Task<Company?> ICompanyRepository.GetCompany(int id, CancellationToken cancellationToken)
    {
        var company = await Set.Include(x=> x.Employees).FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        return company;
    }
}