using ModularMonolith.Modules.Companies.Dtos;

namespace ModularMonolith.Modules.Companies.Queries.Company.GetAllCompanies;

public class GetAllCompaniesQueryResult
{
    public ICollection<CompanyDetail> Companies { get; set; }
}