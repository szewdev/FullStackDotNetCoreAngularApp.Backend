﻿using Backend.Application.Commands.Interfaces;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;

namespace Backend.Application.Commands.Handlers;

public class ProductCommandHandler(AppDbContext context) : IProductCommandHandler
{
    private readonly AppDbContext _context = context;

    public async Task<int> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.Price);
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var product = await _context.Set<Product>().FindAsync(command.Id);
        product?.Update(command.Name, command.Price);
        await _context.SaveChangesAsync();
    }
}