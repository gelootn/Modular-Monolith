using ModularMonolith.Framework.Dtos;

namespace ModularMonolith.Modules.Companies.Dtos;

public record CompanyRequest(int Id, string Name) : RequestBase(Id);