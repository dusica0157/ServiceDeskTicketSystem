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

## Core Modules

### Users and Authentication

Responsible for user registration, login, authentication and role-based authorization.

The system will support three roles:

- User
- Support Agent
- Admin

### Tickets

Responsible for creating, viewing, updating and managing support tickets.

Tickets will support:

- Status management
- Priority management
- Agent assignment
- Search
- Filtering
- Sorting
- Pagination

### Categories

Categories will be used to organize tickets by type of issue.

Examples include Hardware, Software, Network and Account issues.

### Comments

Users and support agents will be able to communicate through comments associated with individual tickets.

### Administration

Administrators will be responsible for managing users, roles, categories and system-level functionality.