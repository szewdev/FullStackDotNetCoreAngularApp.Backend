namespace Backend.Application.Commands;

public record CreateProductCommand(int? Id, string Name, decimal Price, string? Description);