using ModularMonolith.Entities;
using ModularMonolith.Modules.Companies.Commands.Employees.AddEmployee;
using ModularMonolith.Modules.Companies.Commands.Employees.UpdateEmployee;
using ModularMonolith.Modules.Companies.Dtos;

namespace ModularMonolith.Modules.Companies.Mappers;

public class EmployeeMap : Profile
{
    public EmployeeMap()
    {
        CreateMap<AddEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDetail>();
    }
}