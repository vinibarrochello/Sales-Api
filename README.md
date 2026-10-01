# Developer Evaluation Project - Sales API

This project was developed as part of a backend developer technical assessment.

The application provides a complete Sales Management API following Domain-Driven Design (DDD) principles and Clean Architecture patterns. It allows creating, retrieving, updating, and canceling sales while enforcing business rules related to discounts and quantity restrictions.

## Features

- Create sales
- Retrieve sales by identifier
- Update sales
- Cancel sales
- Manage products and sale items
- Automatic discount calculation
- Business rules validation
- Domain-driven design
- Entity Framework Core persistence
- PostgreSQL database
- MediatR command handling
- AutoMapper mappings
- FluentValidation request validation
- Swagger/OpenAPI documentation

## Business Rules

- Purchases of 4 to 9 identical items receive a 10% discount
- Purchases of 10 to 20 identical items receive a 20% discount
- Purchases above 20 identical items are not allowed
- Purchases below 4 items do not receive discounts

## Architecture

The solution follows a layered architecture:

- Domain
  - Entities
  - Business Rules
  - Validators
  - Repositories Contracts

- Application
  - Commands
  - Handlers
  - Validators
  - Results
  - AutoMapper Profiles

- Infrastructure
  - Entity Framework Core
  - Repository Implementations
  - Database Mappings

- Web API
  - Controllers
  - Requests
  - Responses
  - Swagger Documentation

## Technologies

- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- MediatR
- AutoMapper
- FluentValidation
- Swagger/OpenAPI

## Optional Domain Events

The application also supports the following domain events through application logging:

- SaleCreated
- SaleModified
- SaleCancelled
- ItemCancelled
``
