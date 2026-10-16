# Service Desk & Ticket Management System - Architecture

## System Overview

The application will use a client-server architecture.

The React frontend will communicate with the ASP.NET Core Web API through HTTP requests.

The backend will handle business logic and communicate with the PostgreSQL database using Entity Framework Core.
## Backend Architecture

The backend will follow a layered architecture with clear separation of responsibilities.

Request flow:

React Client
→ ASP.NET Core Controller
→ Service Layer
→ Entity Framework Core / DbContext
→ PostgreSQL

### Controllers

Controllers will handle HTTP requests and responses. They should remain lightweight and delegate business logic to the service layer.

### Services

Services will contain the application's business logic and coordinate operations between controllers and the data access layer.

### Data Access

Entity Framework Core will be used to access and manipulate data through DbContext.

### Database

PostgreSQL will be used as the relational database for storing application data.