# Medicine Inventory System

Medicine Inventory System is a full-stack application built using **.NET 8 Web API**, **Angular**, **MySQL**, **Entity Framework Core**, and **Layered Architecture**.

The application displays a list of medicines available in the system and highlights medicines based on expiry date and stock quantity.

## Features

* Display medicine list in a grid
* Search medicine by name
* Show medicine attributes:

  * Full Name
  * Expiry Date
  * Quantity
  * Price
  * Brand
* Hide Notes from the grid
* Red background for medicines expiring in less than 30 days
* Yellow background for medicines with quantity less than 10
* MySQL database storage
* Layered architecture
* Unit test coverage using xUnit

## Technology Stack

### Backend

* .NET 8 Web API
* C#
* Entity Framework Core
* MySQL
* Swagger

### Frontend

* Angular
* TypeScript
* HTML
* CSS

## Project Structure

```text
MedicineProject
│
├── MedicineInventory
│   ├── MedicineInventory.Api
│   ├── MedicineInventory.Application
│   ├── MedicineInventory.Domain
│   ├── MedicineInventory.Infrastructure
│   └── MedicineInventory.Tests
│
└── medicine-ui
```

## Architecture

The backend follows layered architecture.

### Domain Layer

Contains core business entities.

Example:

* Medicine entity

### Application Layer

Contains business logic, DTOs, interfaces, and services.

Responsibilities:

* Medicine search logic
* Mapping entity to DTO
* Row color calculation logic

### Infrastructure Layer

Contains database-related logic.

Responsibilities:

* EF Core DbContext
* MySQL repository implementation

### API Layer

Exposes REST APIs for Angular frontend.

Responsibilities:

* Controllers
* Dependency Injection
* CORS configuration
* Swagger configuration

## Business Rules

### Red Color Rule

Medicine row should be red when:

```text
Expiry Date is less than 30 days from today
```

### Yellow Color Rule

Medicine row should be yellow when:

```text
Quantity is less than 10
```

### Priority

If medicine is both near expiry and low stock, red color has higher priority.

## API Endpoints

### Get All Medicines

```http
GET /api/medicines
```

### Search Medicines

```http
GET /api/medicines?searchText=para
```

## Backend Setup

Go to backend folder:

```bash
cd MedicineInventory
```

Restore packages:

```bash
dotnet restore
```

Update MySQL connection string in:

```text
MedicineInventory.Api/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=medicine_inventory_db;user=root;password=your_password;"
  }
}
```

Create database in MySQL:

```sql
CREATE DATABASE medicine_inventory_db;
```

Run migration:

```bash
dotnet ef database update --project MedicineInventory.Infrastructure --startup-project MedicineInventory.Api
```

Run API:

```bash
dotnet run --project MedicineInventory.Api
```

Swagger URL:

```text
https://localhost:7000/swagger
```

## Frontend Setup

Go to Angular folder:

```bash
cd medicine-ui
```

Install packages:

```bash
npm install
```

Run Angular application:

```bash
ng serve
```

Angular URL:

```text
http://localhost:4200
```

## Unit Tests

Run tests from backend solution folder:

```bash
dotnet test
```

Unit tests cover:

* Get all medicines
* Search medicine by name
* Red color rule for near expiry medicine
* Yellow color rule for low stock medicine

## Important Implementation Notes

* Search is executed in MySQL using `IQueryable`.
* Color calculation is done in C# after data is loaded.
* `AsNoTracking()` is used for read-only queries to improve performance.
* Angular consumes the .NET API using `HttpClient`.
* CORS is enabled for Angular frontend.

## Author

Ketan Chauhan
