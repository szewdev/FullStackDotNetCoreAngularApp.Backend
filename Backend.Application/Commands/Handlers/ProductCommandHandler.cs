using Backend.Application.Commands.Interfaces;
using Backend.Application.Validators;
using Backend.Common.Exceptions;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;

namespace Backend.Application.Commands.Handlers;

public class ProductCommandHandler(AppDbContext context) : IProductCommandHandler
{
    private readonly AppDbContext _context = context;

    public async Task<int> Create(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.Price);
        var valid = DomainEntityValidator.Validate(product, out var errors);
        if (!valid) throw new ValidationException(errors);
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }

    public async Task Update(UpdateProductCommand command)
    {
        var product = await _context.Set<Product>().FindAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        var valid = DomainEntityValidator.Validate(product, out var errors);
        if (!valid) throw new ValidationException(errors);
        product?.Update(command.Name, command.Price);
        await _context.SaveChangesAsync();
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var product = await _context.Set<Product>().FindAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        product?.Update(command.Name, command.Price);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(DeleteProductCommand command)
    {
        var product = await _context.Set<Product>().FindAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        product?.Delete();
        await _context.SaveChangesAsync();
    }

    public async Task Restore(RestoreProductCommand command)
    {
        var product = await _context.Set<Product>().FindAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        product?.Restore();
        await _context.SaveChangesAsync();
    }
}