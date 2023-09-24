using MediatR.Demo.Framework;
using ModularMonolith.Framework.Commands.Interfaces;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Companies.Commands.Employees.AddEmployee;

public class AddEmployeeCommand : IRequest<Response<bool>>, IValidatable
{
    public AddEmployeeCommand(int companyId, string name, string email, string function)
    {
        CompanyId = companyId;
        Name = name;
        Email = email;
        Function = function;
    }
    public int CompanyId { get; }
    public string Name { get; }
    public string Email { get; }
    public string Function { get; }
}