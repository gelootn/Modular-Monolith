using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;

namespace ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee, int>
{
    Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken);
    Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken);
}