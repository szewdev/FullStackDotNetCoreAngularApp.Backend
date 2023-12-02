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

## Getting Started

### Prerequisites

-   .NET Core SDK
-   Any .NET compatible IDE (e.g., Visual Studio, Visual Studio Code)
-   SQL Server (for EF Core)

### Setup

1.  Clone the repository to your local environment.
2.  Open SolutionName.sln in your chosen IDE.
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
