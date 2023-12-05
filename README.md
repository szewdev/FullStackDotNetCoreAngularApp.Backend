# FullStackDotNetCoreAngularApp.Backend

*This repository contains backend solution for FullStackDotNetCoreAngularApp project.*

## Description

FullStackDotNetCoreAngularApp.Backend is a modern web application built using **.NET Core**, adhering to Domain-Driven Design (**DDD**) principles and Command Query Responsibility Segregation (**CQRS**) architecture.
This project focuses on providing clean, scalable, and maintainable code while implementing best practices and design patterns.

## Key Technologies & Patterns

-   **.NET Core**: For application platform offering performance, scalability, and cross-platform capabilities.
-   **Entity Framework Core**: For database operations using ORM.
-   **Domain-Driven Design (DDD)**: Approach used for tackling complexity in the heart of the software.
-   **CQRS and MediatR**: For separating read and write logic, ensuring clarity and flexibility.
-   **Repository Pattern**: Used to abstract the data layer, making our application more maintainable.
-   **FluentValidation**: For advanced command validation.
-   **Swagger (Swashbuckle)**: For API documentation.
-   **xUnit, Moq, FluentAssertions**: For unit and integration testing.

## Project Structure

    Backend.sln
    │
    ├── Backend.API
    │   ├── Controllers/
    │   │   └── ProductsController.cs
    │   ├── Properties/
    │   ├── appsettings.json
    │   ├── Startup.cs
    │   └── Program.cs
    │
    ├── Backend.Domain
    │   ├── Entities/
    │   │   └── BaseEntity.cs
    │   │   └── Product.cs
    │   ├── Enums/
    │   ├── Interfaces/
    │   │   └── IProductRepository.cs
    │   ├── Exceptions/
    │   │   └── DomainException.cs
    │   │   └── EntityAlreadyDeletedException.cs
    │   │   └── EntityNotDeletedException.cs
    │   ├── Events/
    │   │   ├── ProductCreatedEvent.cs
    │   │   └── ProductUpdatedEvent.cs
    │   └── ValueObjects/
    │       └── ProductId.cs
    │
    ├── Backend.Infrastructure
    │   ├── Data/
    │   │   ├── Configurations/
    │   │   │   └── BaseEntityConfiguration.cs
    │   │   │   └── ProductConfiguration.cs
    │   │   ├── Migrations/
    │   │   └── AppDbContext.cs
    │   ├── Repositories/
    │   │   └── ProductRepository.cs
    │   └── Services/
    │       └── ProductService.cs
    │
    ├── Backend.Application
    │   ├── Commands/
    │   │   ├── Interfaces/
    │   │   │   ├── IProductCommandHandler.cs
    │   │   ├── Handlers/
    │   │   │   ├── ProductCommandHandler.cs
    │   │   ├── CreateProductCommand.cs
    │   │   └── UpdateProductCommand.cs
    │   ├── Queries/
    │   │   ├── Interfaces/
    │   │   │   └── IProductQueryHandler.cs
    │   │   ├── Handlers/
    │   │   │   └── ProductQueryHandler.cs
    │   │   └── GetProductQuery.cs
    │   ├── DTOs/
    │   │   └── ProductDto.cs
    │   └── Validators/
    │       ├── DomainEntityValidator.cs
    │       ├── CreateProductValidator.cs
    │       └── UpdateProductValidator.cs
    │
    ├── Backend.Common
    │   ├── Exceptions/
    │   │   └── ValidationException.cs
    │   │   └── NotFoundException.cs
    │   ├── Extensions/
    │   │   └── CustomMiddlewareExtensions.cs
    │   ├── Helpers/
    │   │   └── ProductHelper.cs
    │   └── Constants/
    │       └── ExceptionMessagesConstants.cs
    │       └── ProductConstants.cs
    │
    └── Backend.Tests
        ├── UnitTests/
        │   ├── Domain/
        │   │   └── Entities/
        │       │   └── ProductTests.cs
        │   └── Application/
        │       ├── Commands/
        │       │   └── CreateProductCommandTests.cs
        │       │   └── UpdateProductCommandTests.cs
        │       └── Queries/
        │           └── GetAllProductsQueryTests.cs
        │           └── GetProductQueryTests.cs
        ├── IntegrationTests/
        │   └── API/
        │       └── ProductsControllerTests.cs
        └── TestHelpers/
            └── MockProductData.cs

## Getting Started

### Prerequisites

-   .NET Core SDK
-   Any .NET compatible IDE (e.g., Visual Studio, Visual Studio Code)
-   SQL Server (for EF Core)

### Setup

1.  Clone the repository to your local environment.
2.  Open Backend.sln in your chosen IDE.
3.  Update the `appsettings.json` file in the Backend.API project to suit your environment.
4.  Run the database migrations using `dotnet ef database update`.

### Running

1.  Start the Backend.API project.
2.  The application should be available at the default address: `http://localhost:5000/`.

## Contributing

I do welcome contributions to the project.
Feel free to report bugs, propose new features, or submit fixes.

## License

This project is licensed under the MIT License.
