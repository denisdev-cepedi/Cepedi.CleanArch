using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Cepedi.Domain;
public static class ServiceExtensions
{
    public static void ConfigureHandlersApp(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
