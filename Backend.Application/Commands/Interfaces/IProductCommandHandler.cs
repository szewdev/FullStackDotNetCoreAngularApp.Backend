namespace Backend.Application.Commands.Interfaces;

public interface IProductCommandHandler
{
    Task<int> Create(CreateProductCommand command);
    Task Update(UpdateProductCommand command);
    Task Delete(DeleteProductCommand command);
    Task Restore(RestoreProductCommand command);
}

