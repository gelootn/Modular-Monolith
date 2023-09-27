using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Framework.Behaviors;
using ModularMonolith.Framework.Database;

namespace ModularMonolith.Framework.Configuration;

public static class FrameworkConfiguration
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}