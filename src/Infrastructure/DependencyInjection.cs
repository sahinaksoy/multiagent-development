using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Flywheel.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Register other dependencies here

        return services;
    }
}