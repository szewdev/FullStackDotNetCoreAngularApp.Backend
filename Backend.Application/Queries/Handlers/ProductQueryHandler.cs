using Backend.Application.DTOs;
using Backend.Application.Queries.Interfaces;
using Backend.Domain.Interfaces;

namespace Backend.Application.Queries.Handlers;

public class ProductQueryHandler(IProductRepository context) : IProductQueryHandler
{
    private readonly IProductRepository _repository = context;

    public async Task<ProductDto?> Handle(GetProductQuery query)
    {
        var p = await _repository.GetProductByIdAsync(query.Id);
        return p != null ? new ProductDto(p.Id, p.Name, p.Price) : null;
    }

    public async Task<List<ProductDto>> Handle()
    {
        var products = await _repository.GetAllProducts();
        return products.Select(x => new ProductDto(x.Id, x.Name, x.Price)).ToList();
    }
}
