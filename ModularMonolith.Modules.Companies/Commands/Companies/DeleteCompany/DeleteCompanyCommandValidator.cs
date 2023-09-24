using FluentValidation;

namespace ModularMonolith.Modules.Companies.Commands.Companies.DeleteCompany;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}