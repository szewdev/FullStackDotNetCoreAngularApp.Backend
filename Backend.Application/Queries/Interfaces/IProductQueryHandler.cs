using Backend.Application.DTOs;

namespace Backend.Application.Queries.Interfaces;

public interface IProductQueryHandler
{
    Task<ProductDto?> Handle(GetProductQuery query);
    Task<List<ProductDto>> Handle();
}