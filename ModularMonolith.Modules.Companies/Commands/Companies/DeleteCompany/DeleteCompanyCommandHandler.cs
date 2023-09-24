using MediatR.Demo.Framework;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Commands.Companies.DeleteCompany;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Response<bool>>
{
    private readonly ICompanyRepository _repository;

    public DeleteCompanyCommandHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }
    public async Task<Response<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new Response<bool>();
    }
}