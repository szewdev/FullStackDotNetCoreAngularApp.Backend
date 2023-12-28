using Backend.Application.Commands.Interfaces;
using Backend.Application.Validators;
using Backend.Common.Exceptions;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Commands.Handlers;

public class ProductCommandHandler(IProductRepository repository) : IProductCommandHandler
{
    private readonly IProductRepository _repository = repository;

    public async Task<int> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.Price);
        var valid = DomainEntityValidator.Validate(product, out var errors);
        if (!valid) throw new ValidationException(errors);
        await _repository.AddProductAsync(product);
        await _repository.SaveChangesAsync();
        return product.Id;
    }

    public async Task Handle(UpdateProductCommand command)
    {
        var product = await _repository.GetProductByIdAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        var valid = DomainEntityValidator.Validate(product, out var errors);
        if (!valid) throw new ValidationException(errors);
        product.Update(command.Name, command.Price);
        _repository.UpdateProduct(product);
        await _repository.SaveChangesAsync();
    }

    public async Task Handle(DeleteProductCommand command)
    {
        var product = await _repository.GetProductByIdAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        product?.Delete();
        await _repository.SaveChangesAsync();
    }

    public async Task Handle(RestoreProductCommand command)
    {
        var product = await _repository.GetProductByIdAsync(command.Id)
            ?? throw new NotFoundException($"Product with ID {command.Id} not found.");
        product?.Restore();
        await _repository.SaveChangesAsync();
    }
}