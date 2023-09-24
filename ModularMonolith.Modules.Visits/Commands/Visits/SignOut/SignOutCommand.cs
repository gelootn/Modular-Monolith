using MediatR;
using ModularMonolith.Framework.Responses;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignOut;

public class SignOutCommand : IRequest<Response<bool>>
{
    public SignOutCommand(string visitorEmail)
    {
        VisitorEmail = visitorEmail;
    }

    public string VisitorEmail { get; }
}