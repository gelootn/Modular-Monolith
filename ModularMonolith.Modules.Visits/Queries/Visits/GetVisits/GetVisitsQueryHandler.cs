using AutoMapper;
using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Filters;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;
using ModularMonolith.Modules.Visits.Dtos;

namespace ModularMonolith.Modules.Visits.Queries.Visits.GetVisits;

public class GetVisitsQueryHandler : IRequestHandler<GetVisitsQuery, Response<VisitDetail>>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IMapper _mapper;

    public GetVisitsQueryHandler(IVisitRepository visitRepository, IMapper mapper)
    {
        _visitRepository = visitRepository;
        _mapper = mapper;
    }
    public async Task<Response<VisitDetail>> Handle(GetVisitsQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<VisitFilter>(request);
        var visits = await _visitRepository.GetVisitsAsync(filter, cancellationToken);
        return new Response<VisitDetail>(_mapper.Map<ICollection<VisitDetail>>(visits));
    }
}