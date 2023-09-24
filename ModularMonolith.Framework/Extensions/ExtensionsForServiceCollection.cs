using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Framework.Database;

namespace ModularMonolith.Framework.Extensions;

public static class ExtensionsForServiceCollection
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
    }
}