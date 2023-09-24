using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Companies.Database;
using ModularMonolith.Modules.Companies.Database.Repositories;
using ModularMonolith.Modules.Companies.Database.Repositories.Interfaces;
using ModularMonolith.Modules.Companies.Mappers;

namespace ModularMonolith.Modules.Companies.Configuration;

public static class ModuleConfiguration
{
    public static void AddCompanyModule(this IServiceCollection services,
        string? connectionString)
    {
        services.AddDbContext<CompanyDbContext>(
            cfg =>
            {
                cfg.UseSqlServer(connectionString, x=>
                {
                    x.MigrationsHistoryTable("__CompanyMigrationsHistory", "Company");
                });
            });

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CompanyMap>());
        services.AddValidatorsFromAssemblyContaining<CompanyMap>();
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<CompanyMap>();
            cfg.AddProfile<EmployeeMap>();
        });
    }
    
}