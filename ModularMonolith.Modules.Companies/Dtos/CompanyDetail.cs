namespace ModularMonolith.Modules.Companies.Dtos;

public record CompanyDetail(int Id, string? Name, ICollection<EmployeeDetail>? Employees);