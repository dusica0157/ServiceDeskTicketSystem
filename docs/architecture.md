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
## Roles and Permissions

### User

Users can:

- Register and log in
- Create support tickets
- View their own tickets
- Update allowed fields on their own tickets
- Add comments to their tickets

### Support Agent

Support agents can:

- View assigned tickets
- Update ticket status
- Update ticket priority
- Add comments
- Resolve tickets

### Admin

Administrators can:

- View all tickets
- Manage users
- Manage roles
- Manage categories
- Assign tickets to support agents
- Perform administrative operations
## Ticket Lifecycle

Tickets will move through the following statuses:

Open
→ In Progress
→ Resolved
→ Closed

A newly created ticket will have the Open status.

A support agent can start working on the ticket and change its status to In Progress.

When the issue has been solved, the support agent can mark the ticket as Resolved.

A resolved ticket can then be closed after the issue has been confirmed as completed.

## Request Flow

Example flow for creating a ticket:

React Client
→ POST /api/tickets
→ TicketController
→ TicketService
→ Entity Framework Core
→ PostgreSQL

The created ticket is then returned through the same layers back to the React client.