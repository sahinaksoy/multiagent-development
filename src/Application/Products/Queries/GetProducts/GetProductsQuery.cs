using MediatR;
using Flywheel.Application.Products.Queries.GetProducts;

namespace Flywheel.Application.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
}

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}