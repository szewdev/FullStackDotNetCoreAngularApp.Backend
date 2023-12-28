namespace Backend.Application.Commands.Interfaces;

public interface IProductCommandHandler
{
    Task<int> Handle(CreateProductCommand command);
    Task Handle(UpdateProductCommand command);
    Task Handle(DeleteProductCommand command);
    Task Handle(RestoreProductCommand command);
}
