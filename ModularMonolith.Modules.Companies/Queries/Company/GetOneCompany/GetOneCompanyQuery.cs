using MediatR.Demo.Framework;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Companies.Dtos;

namespace ModularMonolith.Modules.Companies.Queries.Company.GetOneCompany;

public record GetOneCompanyQuery(int CompanyId) : IRequest<Response<CompanyDetail>>;
