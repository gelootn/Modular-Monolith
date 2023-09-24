using MediatR;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignOut;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Response<bool>>
{
    private readonly IVisitRepository _visitRepository;

    public SignOutCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    public async Task<Response<bool>> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetVisitByVisitorEmail(request.VisitorEmail, cancellationToken);
        if (visit == null)
            return Response<bool>.ErrorResponse("Visit for email not found");
        
        visit.Stop = DateTime.Now;

        await _visitRepository.AddOrUpdateAsync(visit, cancellationToken);
        await _visitRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
    }
}