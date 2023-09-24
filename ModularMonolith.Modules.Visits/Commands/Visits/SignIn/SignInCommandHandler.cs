using MediatR;
using ModularMonolith.Entities;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<bool>>
{
    private readonly IVisitorRepository _visitorRepository;
    private readonly IVisitRepository _visitRepository;

    public SignInCommandHandler(IVisitorRepository visitorRepository, IVisitRepository visitRepository)
    {
        _visitorRepository = visitorRepository;
        _visitRepository = visitRepository;
    }
    
    public async Task<Response<bool>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var visitor = await _visitorRepository.GetVisitorByEmail(request.VisitorEmail, cancellationToken);
        if (visitor == null)
            visitor = new Visitor
            {
                Email = request.VisitorEmail,
                Name = request.VisitorName,
                Company = request.VisitorCompany
            };

        var company = await _visitRepository.GetCompanyWithEmployeesAsync(request.CompanyId, cancellationToken);
        if (company == null)
            return Response<bool>.ErrorResponse("Company not found");
    
        var employee = company.Employees.FirstOrDefault(x => x.Id == request.EmployeeId);
        if (employee == null)
            return Response<bool>.ErrorResponse("Employee not found");
        
        
        var visit = new Visit
        {
            Visitor = visitor,
            Company = company,
            Employee = employee,
            Start = DateTime.Now
        };

        await _visitRepository.AddOrUpdateAsync(visit, cancellationToken);
        await _visitRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
        
    }
}