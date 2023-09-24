using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Visits.Commands.Visits.SignIn;
using ModularMonolith.Modules.Visits.Commands.Visits.SignOut;
using ModularMonolith.Modules.Visits.Dtos;
using ModularMonolith.Modules.Visits.Queries.Visits.GetOpenVisits;
using ModularMonolith.Modules.Visits.Queries.Visits.GetVisits;

namespace ModularMonolith.Modules.Visits.Controllers;

[Route("api/visits")]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitController(IMediator mediator )
    {
        _mediator = mediator;

    }

    [HttpGet("open")]
    [ProducesResponseType(typeof(Response<VisitDetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> OpenVisits()
    {
        var command = new GetOpenVisitsQuery();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpGet]
    [ProducesResponseType(typeof(Response<VisitDetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Visits()
    {
        var command = new GetVisitsQuery();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
        
    [HttpPost("signin")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterVisit([FromBody]StartVisitRequest startVisit)
    {
        var command = new SignInCommand(startVisit.VisitorName, startVisit.VisitorEmail, startVisit.VisitorCompany, startVisit.CompanyId, startVisit.EmployeeId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpPost("signout")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> StopVisit(StopVisitRequest stopVisit)
    {
        var command = new SignOutCommand(stopVisit.VisitorEmail);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}