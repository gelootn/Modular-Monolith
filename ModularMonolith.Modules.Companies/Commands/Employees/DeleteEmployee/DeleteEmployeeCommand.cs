using MediatR.Demo.Framework;
using ModularMonolith.Framework.Commands.Interfaces;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Companies.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteEmployeeCommand(int id, int companyId)
    {
        Id = id;
        CompanyId = companyId;
    }
    public int Id { get; }
    public int CompanyId { get; }
}