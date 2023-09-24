using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;
using ModularMonolith.Framework.Database;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Database.Repositories;

public class EmployeeRepository : GenericRepository<Employee, int>, IEmployeeRepository
{
    public EmployeeRepository(CompanyDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken)
    {
        var employees = await Set.Where(x => x.CompanyId == companyId).ToListAsync(cancellationToken: cancellationToken);
        return employees;
    }

    public async Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken)
    {
        var employee = await Set.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return employee;
    }
}