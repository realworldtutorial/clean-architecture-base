# Clean Architecture Solution

This is a .NET Core solution following Clean Architecture principles.

## Project Structure

- **src/Core/**
  - **CleanArchitecture.Domain**: Contains enterprise logic and entities
  - **CleanArchitecture.Application**: Contains business logic and interfaces

- **src/Infrastructure/**
  - **CleanArchitecture.Infrastructure**: Contains external services implementation
  - **CleanArchitecture.Persistence**: Contains database contexts and repositories

- **src/Presentation/**
  - **CleanArchitecture.API**: Contains API controllers and configuration

## Getting Started

1. Ensure you have .NET SDK installed
2. Clone the repository
3. Run `dotnet restore`
4. Run `dotnet build`
5. Navigate to `src/Presentation/CleanArchitecture.API` and run `dotnet run`

## Architecture Overview

This solution follows Clean Architecture principles:

1. Domain Layer: Core business entities
2. Application Layer: Business logic and interfaces
3. Infrastructure Layer: Implementation of interfaces, external services
4. Presentation Layer: API endpoints and UI concerns
