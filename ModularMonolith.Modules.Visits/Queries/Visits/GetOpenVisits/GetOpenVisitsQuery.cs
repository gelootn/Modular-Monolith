using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Dtos;

namespace ModularMonolith.Modules.Visits.Queries.Visits.GetOpenVisits;

public class GetOpenVisitsQuery : IRequest<Response<VisitDetail>>
{
    
}