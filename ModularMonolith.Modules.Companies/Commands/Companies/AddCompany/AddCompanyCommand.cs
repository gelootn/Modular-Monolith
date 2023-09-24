using MediatR.Demo.Framework;
using ModularMonolith.Framework.Commands.Interfaces;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Companies.Commands.Companies.AddCompany;

public class AddCompanyCommand : IRequest<Response<int>>, IValidatable
{
    public AddCompanyCommand(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
