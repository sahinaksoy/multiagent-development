using MediatR;
using System.Collections.Generic;

namespace Flywheel.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }
}