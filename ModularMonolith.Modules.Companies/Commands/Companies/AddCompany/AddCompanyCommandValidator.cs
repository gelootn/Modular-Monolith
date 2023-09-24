using FluentValidation;

namespace ModularMonolith.Modules.Companies.Commands.Companies.AddCompany;

public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
{
    public AddCompanyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
    }
}