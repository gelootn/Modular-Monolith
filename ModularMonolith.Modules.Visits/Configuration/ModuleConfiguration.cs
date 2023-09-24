using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Entities.Database;
using ModularMonolith.Modules.Visits.Database;
using ModularMonolith.Modules.Visits.Database.Repositories;
using ModularMonolith.Modules.Visits.Database.Repositories.Interfaces;
using ModularMonolith.Modules.Visits.Mappers;

namespace ModularMonolith.Modules.Visits.Configuration;

public static class ModuleConfiguration
{
    public static void AddVisitModule(this IServiceCollection services,
        string? connectionString)
    {
        services.AddDbContext<EmployeeDbContext>(cfg => cfg.UseSqlServer(connectionString));
        services.AddDbContext<ReadOnlyDbContext>(cfg => cfg.UseSqlServer(connectionString));
        
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IVisitorRepository, VisitorRepository>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<VisitMap>());
        services.AddValidatorsFromAssemblyContaining<VisitMap>();
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<VisitMap>();
        });
    }
    
}