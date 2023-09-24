
using MediatR;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignIn;

public class SignInCommand : IRequest<Response<bool>>, IValidatable
{
    public SignInCommand(string visitorName, string visitorEmail, string visitorCompany, int companyId, int employeeId)
    {
        VisitorName = visitorName;
        VisitorEmail = visitorEmail;
        VisitorCompany = visitorCompany;
        CompanyId = companyId;
        EmployeeId = employeeId;
    }

    public string VisitorName { get;  }
    public string VisitorEmail { get;  }
    public string VisitorCompany { get;  }
    public int CompanyId { get;  }
    public int EmployeeId { get;  }
}