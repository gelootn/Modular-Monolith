namespace ModularMonolith.Modules.Visits.Dtos;

public record VisitDetail(string VisitorName, string VisitorEmail, string VisitorCompany, string VisitingCompany,
    string VisitingEmployee, DateTime StartTime, DateTime? EndTime = null);
