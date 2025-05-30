# InvoiceServiceProvider

A testing solution to explore and validate microservice architecture concepts learned in class, including gRPC communication, Azure Service Bus messaging, and backend orchestration.

## Purpose

This project serves as a sandbox for:

- **Learning Microservice Patterns**: Building independent services that collaborate via RPC and messaging.  
- **gRPC Communication**: Implementing bidirectional streaming and unary calls between services.  
- **Azure Service Bus Integration**: Publishing and subscribing to domain events (e.g., `InvoiceCreated`, `BookingRequested`).  

## Solution Overview

The `InvoiceServiceProvider.sln` brings together three example services:

1. **InvoiceServiceProvider** (Web API)  
   - CRUD endpoints for invoices.  
   - Integrates Azure Service Bus for event publishing.  

2. **Mock_Booking** (gRPC Service)  
   - Simulates booking operations via gRPC.  
   - Showcases unary and streaming RPC patterns.  

3. **Ventixe_Backend** (Orchestration Service)  
   - Aggregates data and coordinates workflows across the invoice and booking services.  
   - Consumes gRPC and HTTP endpoints, re-publishes events to Service Bus.

## Key Concepts Tested

- **Service Isolation**: Each service has its own data store, project structure, and deployment boundary.  
- **Inter-Service Communication**: gRPC for synchronous calls; Azure Service Bus for asynchronous messaging.  
- **Event-Driven Workflows**: Publishing, subscribing, and processing domain events reliably.  
- **Authentication & Authorization**: Testing both API key headers and JWT tokens across services.

## Technologies

- ASP.NET Core Web API & MVC  
- gRPC for .NET  
- Azure Service Bus (Queues & Topics)  
- Entity Framework Core (Code-first Migrations)  
- Swagger/OpenAPI for API documentation  

## Conclusion

This testing project provides hands-on experience with core microservice architecture principles, enabling experimentation with gRPC, messaging, and security patterns in a controlled environment.
