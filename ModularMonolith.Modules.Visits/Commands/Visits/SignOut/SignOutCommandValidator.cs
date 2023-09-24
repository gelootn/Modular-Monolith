using FluentValidation;

namespace ModularMonolith.Modules.Visits.Commands.Visits.SignOut;

public class SignOutCommandValidator : AbstractValidator<SignOutCommand>, IValidatable
{
    public SignOutCommandValidator()
    {
        RuleFor(x => x.VisitorEmail).NotEmpty().EmailAddress();
    }
}