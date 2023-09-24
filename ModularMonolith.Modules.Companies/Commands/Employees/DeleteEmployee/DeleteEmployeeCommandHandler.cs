﻿using MediatR.Demo.Framework;
using ModularMonolith.Framework.Responses;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;

namespace ModularMonolith.Modules.Companies.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Response<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<Response<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployee(request.Id, cancellationToken);
        if (employee == null)
            return Response<bool>.ErrorResponse("Employee not found");

        await _employeeRepository.DeleteAsync(request.Id, cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
    }
}