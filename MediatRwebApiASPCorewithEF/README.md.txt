# Student Management Web API (.NET 8)

This project is a RESTful ASP.NET Core Web API developed using .NET 8 and Entity Framework Core. It demonstrates real-world backend development practices including DTO-based architecture, entity relationships, soft delete implementation, and automatic database migration.

The application manages students and their addresses using a one-to-many relationship model. The project is designed with clean API principles and can be cloned and executed locally with minimal setup.

## Key Features

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code First Approach)
- DTO Pattern (Create & Response DTOs)
- One-to-Many Relationship (Student → Address)
- Soft Delete Implementation
- Automatic Database Migration on Startup
- Seed Data Initialization
- Swagger API Documentation
- Clean and Maintainable Architecture

## Architecture Highlights

- Separation of Entities and DTOs
- Prevention of circular reference issues
- Repository-ready configuration for easy onboarding
- Database auto-creation using EF Core migrations

This project serves as a foundation for learning advanced concepts such as Microservices Architecture, Dockerization, and Azure Cloud Deployment.

---

## Prerequisites

- .NET 8 SDK
- SQL Server LocalDB (comes with Visual Studio)

---

## How to Run

1. Clone repository

git clone https://github.com/Shubham0417/student-api.git

2. Navigate to project

cd StudentService.API

3. Run project

dotnet run

4. Open Swagger

https://localhost:xxxx/swagger

Database will be created automatically.