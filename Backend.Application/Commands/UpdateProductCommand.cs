namespace Backend.Application.Commands;

public record UpdateProductCommand(int? Id, string Name, decimal Price);