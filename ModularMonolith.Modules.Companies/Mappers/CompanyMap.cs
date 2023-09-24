using ModularMonolith.Entities;
using ModularMonolith.Modules.Companies.Commands.Companies.AddCompany;
using ModularMonolith.Modules.Companies.Commands.Companies.UpdateCompany;
using ModularMonolith.Modules.Companies.Dtos;

namespace ModularMonolith.Modules.Companies.Mappers;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
        CreateMap<Company, CompanyDetail>().ReverseMap();
    }
}