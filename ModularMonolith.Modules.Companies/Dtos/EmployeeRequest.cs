using ModularMonolith.Framework.Dtos;

namespace ModularMonolith.Modules.Companies.Dtos;

public record EmployeeRequest(int Id, string Name, string Email, string Function, int CompanyId) : RequestBase(Id);