namespace ModularMonolith.Modules.Visits.Dtos;

public record StartVisitRequest(string VisitorName, string VisitorEmail, string VisitorCompany, int EmployeeId, int CompanyId);