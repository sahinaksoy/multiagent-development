using Flywheel.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flywheel.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            })
            .ToListAsync(cancellationToken);
    }
}