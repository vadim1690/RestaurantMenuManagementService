# Restaurant Menu Management Service

A .NET Core RESTful API project for practicing modern .NET architecture and best practices. This service enables restaurant partners to manage their menu offerings, including categories, items, and availability settings.

## 🚀 Purpose

This project was created as a practice exercise to demonstrate implementation of architectural patterns and best practices in .NET Core development. It is structured as a realistic business application for restaurant menu management but is intended as a learning resource rather than a production-ready application.

## ✨ Key Features

- **Menu Structure Management**: Create, update, and delete menu categories and items
- **Availability Control**: Configure time-based availability for menu items
- **Dietary Information**: Track allergens, calories, and special dietary attributes
- **Bulk Operations**: Efficiently process multiple menu items at once
- **Audit Logging**: Track all changes to menu data with detailed change history
- **Resilient Error Handling**: Comprehensive exception management with friendly API responses

## 🛠️ Technologies & Patterns

- **.NET 8.0** - Latest framework features
- **Entity Framework Core** - ORM with In-Memory database for demonstration
- **Repository Pattern** - For data access abstraction
- **Unit of Work** - For transaction management
- **CQRS-inspired architecture** - Separation of command and query operations
- **Dependency Injection** - For loose coupling and testability
- **AutoMapper** - For object-to-object mapping
- **JSON Storage** - Complex types stored as JSON for flexibility
- **RESTful API Design** - Proper use of HTTP methods and status codes

## 📐 Architecture Overview

The application follows a clean, layered architecture:

1. **API Layer**: Controllers, request/response models, and middleware
2. **Service Layer**: Business logic and orchestration
3. **Repository Layer**: Data access abstraction
4. **Data Layer**: Entity models and database context
5. **Cross-Cutting Concerns**: Logging, exception handling, and validation

## 📂 Project Structure

```
RestaurantMenuManagementService/
├── Controllers/                  # API endpoints
├── Data/
│   ├── Entities/                 # Data models
│   ├── AppDbContext.cs           # EF Core DB context
│   └── SeedData.cs               # Initial data setup
├── DTOs/                         # Data transfer objects
├── Exceptions/                   # Custom exception types
├── Extensions/                   # Helper extension methods
├── MappingProfiles/              # AutoMapper configuration
├── Middlewares/                  # Custom middleware components
├── Models/                       # Domain models and shared types
├── Repositories/                 # Data access implementations
├── Services/                     # Business logic
└── Program.cs                    # Application startup and configuration
```

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code

### Setup and Run

1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/RestaurantMenuManagementService.git
   ```

2. Navigate to the project directory
   ```bash
   cd RestaurantMenuManagementService
   ```

3. Build the solution
   ```bash
   dotnet build
   ```

4. Run the application
   ```bash
   dotnet run
   ```

5. Access the Swagger UI
   ```
   https://localhost:7065/swagger
   ```

## 🔍 API Highlights

### Key Endpoints

- `GET /api/resturants` - List all restaurants
- `GET /api/resturants/{resturantId}/categories` - Get menu categories
- `POST /api/resturants/{resturantId}/categories` - Create a new category
- `GET /api/resturants/{resturantId}/categories/{categoryId}/items` - Get menu items
- `POST /api/resturants/{resturantId}/categories/{categoryId}/items` - Create a menu item
- `POST /api/resturants/{resturantId}/items/bulk` - Bulk create menu items
- `GET /api/resturants/{resturantId}/audit-logs` - View audit history

## 📚 Learning Outcomes & Best Practices

This project demonstrates:

1. **Clean Architecture Principles**: Separation of concerns with clearly defined layers
2. **Repository Pattern**: Abstraction of data access logic
3. **API Design**: RESTful endpoint design with proper resource naming
4. **Error Handling**: Global exception middleware with appropriate status codes
5. **Data Transfer Objects**: Separation of API contracts from domain models
6. **Entity Framework Core**: ORM for data access with code-first approach
7. **JSON Storage**: Handling complex types in a relational database
8. **Audit Logging**: Tracking changes to entities
9. **Domain-Driven Design Concepts**: Focus on business domain in models and services

## 🔮 Future Improvements

- Implement caching strategy for frequently accessed data
- Add authentication and authorization
- Integrate with external image storage service
- Implement full-text search for menu items
- Add unit and integration tests
- Add pagination for large result sets
- Implement real-time notifications for menu changes

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

**Note:** This is a practice project designed to showcase .NET architectural patterns and best practices. It is not intended for production use.
