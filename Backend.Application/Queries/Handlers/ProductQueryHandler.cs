using Backend.Application.DTOs;
using Backend.Application.Queries.Interfaces;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Queries.Handlers;

public class ProductQueryHandler(AppDbContext context) : IProductQueryHandler
{
    private readonly AppDbContext _context = context;

    public async Task<ProductDto?> Handle(GetProductQuery query)
    {
        var p = await _context.Set<Product>().FindAsync(query.Id);
        return p != null ? new ProductDto(p.Id, p.Name, p.Price) : null;
    }

    public async Task<List<ProductDto>> Handle()
    {
        return await _context.Set<Product>().Select(x => new ProductDto(x.Id, x.Name, x.Price)).ToListAsync();
    }
}
