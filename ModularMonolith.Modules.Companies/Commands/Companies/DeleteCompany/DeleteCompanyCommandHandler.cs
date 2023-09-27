using MediatR.Demo.Framework;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;
using Serilog;

namespace ModularMonolith.Modules.Companies.Commands.Companies.DeleteCompany;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Response<bool>>
{
    private readonly ICompanyRepository _repository;
    private readonly ILogger _logger;

    public DeleteCompanyCommandHandler(ICompanyRepository repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Response<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        _logger.Debug("Deleting company with id: {CompanyId}", request.Id);
        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return new Response<bool>();
    }
}