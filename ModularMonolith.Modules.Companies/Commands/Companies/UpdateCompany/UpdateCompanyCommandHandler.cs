using MediatR.Demo.Framework;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Commands.Companies.UpdateCompany;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Response<bool>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCompanyCommandHandler(ICompanyRepository repository, IMapper mapper )
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Response<bool>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetCompany(request.Id, cancellationToken);
        if (company == null)
            return Response<bool>.ErrorResponse("Company Not found");

        _mapper.Map(request, company);

        await _repository.AddOrUpdateAsync(company, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return new Response<bool>();
    }
}