# BookingSystem.Api

A .NET 8 Web API for managing room bookings with JWT authentication, role-based authorization, and SQLite persistence.

## Features
- Minimal API structure
- Entity Framework Core with SQLite
- JWT authentication and role-based authorization (Admin/User)
- RESTful endpoints for bookings and authentication
- Swagger/OpenAPI documentation
- Unit and integration tests with xUnit and Moq

## Project Structure
- `Models/` — Entity models
- `DTOs/` — Data transfer objects
- `Services/` — Business logic and interfaces
- `Controllers/` — API endpoints
- `Configurations/` — App and service configuration
- `Middleware/` — Custom middleware (e.g., error handling)

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Running the API Locally
```sh
dotnet build
dotnet run
```
The API will be available at `https://localhost:5001` or `http://localhost:5000`.

### Applying Migrations
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### JWT Setup
- The JWT secret and settings are in `appsettings.json` under the `Jwt` section.
- Default admin user: `admin@bookingsystem.com` / `Admin123!`

### Example Requests
#### Register
```sh
curl -X POST https://localhost:5001/api/auth/register -H "Content-Type: application/json" -d '{"email":"user@example.com","password":"User123!","role":"User"}'
```
#### Login
```sh
curl -X POST https://localhost:5001/api/auth/login -H "Content-Type: application/json" -d '{"email":"user@example.com","password":"User123!"}'
```
#### Create Booking (JWT required)
```sh
curl -X POST https://localhost:5001/api/bookings -H "Authorization: Bearer {token}" -H "Content-Type: application/json" -d '{"roomId":1,"startTime":"2025-07-01T09:00:00","endTime":"2025-07-01T10:00:00"}'
```

### Testing
```sh
dotnet test
```

---

For more, see Swagger UI at `/swagger` when running the API.
