using AutoMapper;
using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;
using ModularMonolith.Modules.Visits.Dtos;

namespace ModularMonolith.Modules.Visits.Queries.Visits.GetOpenVisits;

public class GetOpenVisitsQueryHandler : IRequestHandler<GetOpenVisitsQuery, Response<VisitDetail>>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IMapper _mapper;

    public GetOpenVisitsQueryHandler(IVisitRepository visitRepository, IMapper mapper)
    {
        _visitRepository = visitRepository;
        _mapper = mapper;
    }
    public async Task<Response<VisitDetail>> Handle(GetOpenVisitsQuery request, CancellationToken cancellationToken)
    {
        var visits = await _visitRepository.GetOpenVisitsAsync(cancellationToken);
        return new Response<VisitDetail>(_mapper.Map<ICollection<VisitDetail>>(visits));
    }
}