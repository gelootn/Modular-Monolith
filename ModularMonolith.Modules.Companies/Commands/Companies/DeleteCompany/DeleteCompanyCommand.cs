using MediatR.Demo.Framework;
using ModularMonolith.Framework.Commands.Interfaces;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Companies.Commands.Companies.DeleteCompany;

public class DeleteCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
    public int Id { get; }
}