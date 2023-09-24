using MediatR.Demo.Framework;
using ModularMonolith.Framework.Commands.Interfaces;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Companies.Commands.Companies.UpdateCompany;

public class UpdateCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public UpdateCompanyCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get;  }
    public string Name { get; }
}