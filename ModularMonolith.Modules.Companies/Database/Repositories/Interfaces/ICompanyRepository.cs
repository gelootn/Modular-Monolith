using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;

namespace ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

public interface ICompanyRepository : IGenericRepository<Company, int>
{
    Task<IReadOnlyCollection<Company>> GetCompanies();
    Task<Company?> GetCompany(int id, CancellationToken cancellationToken);
}