using Flywheel.Application.Products.Commands.CreateProduct;
using Flywheel.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Flywheel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // MediatR Handlers
            services.AddMediatR(typeof(CreateProductCommandHandler).Assembly);
            services.AddMediatR(typeof(GetProductsQueryHandler).Assembly);

            // Other dependencies can be added here

            return services;
        }
    }
}