using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Companies.Commands.Companies.AddCompany;
using ModularMonolith.Modules.Companies.Commands.Companies.DeleteCompany;
using ModularMonolith.Modules.Companies.Commands.Companies.UpdateCompany;
using ModularMonolith.Modules.Companies.Commands.Employees.AddEmployee;
using ModularMonolith.Modules.Companies.Commands.Employees.DeleteEmployee;
using ModularMonolith.Modules.Companies.Commands.Employees.UpdateEmployee;
using ModularMonolith.Modules.Companies.Dtos;
using ModularMonolith.Modules.Companies.Queries.Company.GetAllCompanies;
using ModularMonolith.Modules.Companies.Queries.Company.GetOneCompany;

namespace ModularMonolith.Modules.Companies.Controllers;

[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllCompaniesQueryResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var command = new GetAllCompaniesQuery();
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var command = new GetOneCompanyQuery(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CompanyRequest model)
    {
        var command = new AddCompanyCommand(model.Name);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]CompanyRequest model)
    {
        if (id != model.Id)
            return BadRequest("route id and body id do not match");
        var command = new UpdateCompanyCommand(model.Id, model.Name);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        var command = new DeleteCompanyCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/employee")]
    public async Task<IActionResult> AddEmployeeToCompany([FromRoute] int id,[FromBody]EmployeeRequest employee)
    {
        if(id != employee.CompanyId)
            return BadRequest("route id and body id do not match");
        var command = new AddEmployeeCommand(id, employee.Name, employee.Email, employee.Function);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
        
    [HttpPut("{id}/employee/{employeeId}")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromRoute] int employeeId,[FromBody]EmployeeRequest employee)
    {
        if(id != employee.CompanyId)
            return BadRequest("company route id and body id do not match");
        if(employeeId != employee.Id)
            return BadRequest("employee route id and body id do not match");
        
        var command = new UpdateEmployeeCommand(id, employee.CompanyId, employee.Name, employee.Email, employee.Function);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpDelete("{id}/employee/{employeeId}")]
    public async Task<IActionResult> RemoveEmployee([FromRoute] int id, [FromRoute] int employeeId)
    {
        var command = new DeleteEmployeeCommand(employeeId, id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}