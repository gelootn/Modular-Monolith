# Introduction
This solution contains a reference architecture for a modular monolith. This architecture exposes 1 API that contains all modules. Each module is a self contained unit of functionality that can be deployed independently. The solution also contains a reference implementation of a module that can be used as a starting point for new modules.

The purpose is to provide a 'Microservice' like approach to a monolith. This way you can start with a monolith and later on split it up into microservices.

# Getting Started
The Api project has no own logic. It simply acts as an entry point that contains the registered modules. 
Each module has its own logic, commands, queries, handlers and data access.

## Nuget Packages
The following nuget packages are used in this solution:
### General
- MediatR (https://github.com/jbogard/MediatR)
- AutoMapper (https://automapper.org/)
- FluentValidation (https://docs.fluentvalidation.net/en/latest/)
- SeriLog (https://serilog.net/)
### unit testing
- Xunit
### Database
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer


# Projects in the solution
## ModularMonolith.Framework
This is a supporting project. It contains classes and code that is used by the rest of the application.
All other projects have a reference to this project, this project can reference no other projects.
In this project you can find the following items:
- Behaviors for the mediatr pipeline
- flag interface for validation
- Base classes for commands and queries
- Base classes for generic repositories
- Extensions for String, ValidationResult and the Response class
- The Response class that is used to return data from commands and queries

## ModularMonolith.Entities
This project contains all entities that are used in the application. This project has a reference to the ModularMonolith.Framework project.

This project also contains the DbContext for the readonly part of the applications. This context knows all entities and can be used to query data between that is controlled by other modules. 

The DbContext does not have any DbSets defined. All Entities are added through configurations. This way the DbContext can not directly be used to write data to the database. The ```SaveChanges ``` methods are overridden to throw an exception when they are called. This way the DbContext can only be used to query data.

### ModularMonolith.Api
This is the entry point of the application. It contains the startup class and the link to all modules that are available in the application.

# Modules
## References
Each module has a reference to the following projects:
- ModularMonolith.Framework
- ModularMonolith.Entities

## Principles
Each module has the following principles: \
**Single Responsibility** \
Each module has a single responsibility. This means that each module has a single functional purpose. \
**Self Contained** \
Each module is self contained. This means that each module has its own logic, commands, queries, handlers and data access and does not depend on other modules. \
**No direct references** \
Each module has no direct references to other modules. This means that each module can not communicate with other modules. \
**No shared code** \
Each module has no shared code. All shared code is found in other non module project \
**CQRS** \
Each module uses the CQRS pattern. This means that each module has commands and queries. 

## Structure
A module contains the following folders:

| Folder        | Description                                               |
|---------------|-----------------------------------------------------------|
| Commands      | Contains all commands that can be executed on the module  |
| Configuration | Contains the DI configuration for the module              |
| Controllers   | Contains the controllers for the module                   |
| Database      | Contains the DbContext of the module and the repositories |
| Dto's         | Contains the Dto's for the module                         |
| Mappers       | Contains the automapper profiles for the module           |
| Queries       | Contains all queries that can be executed on the module   |

## Handling data
Each module has its own DbContext. This DbContext is used to handle all write operations for the module. The read operations are handled by the readonly DbContext in the ModularMonolith.Entities project. This DbContext knows all entities and can be used to query data that is controlled by other modules.
## Configuration
Each module has its own configuration. The `ModuleConfiguration` Class in the Configuration folder of the module contains the DI config for the module. This configuration is registered in the Api project. The Api project is responsible for registering all modules and their configuration.
## Commands and Queries
To execute commands and queries this solution uses the MediatR library. This library is used to execute commands and queries. Each module has its own commands and queries. These commands and queries are registered in the `ModuleConfiguration` class. This class is responsible for registering all commands and queries for the module.

## Command Validation
Commands are by default not validated. To flag a command for validation you can add the `IValidatable` interface to the command. This will make sure that the command is validated before it is executed.
The validation itself is done by a command validator that is registered in the `ModuleConfiguration` class. 

``` csharp
public class SignInCommand : IRequest<Response<bool>>, IValidatable
{
    
}
```
The execution of the validator is handled by the mediatR pipeline. The `ValidationBehavior` class is responsible for executing the validator. This class inherits from the `IPipelineBehavior` that is provided by the mediatR packages and is registered in the framework project configuration.

# Starting a new module
To start a new module you can use the reference implementation. This implementation contains all the basic building blocks that are needed to start a new module.
## Project structure
```
Project
|--- Commands
|----- Command
|------- Command.cs
|------- CommandHandler.cs
|------- CommandValidator.cs
|--- Configuration
|----- ModuleConfiguration.cs
|--- Controllers
|----- Controller.cs
|--- Database
|----- Repositories
|------- Interfaces
|--------- IRepository.cs
|------- Repository.cs
|----- DbContext.cs
|--- Dto's
|----- Dto.cs
|--- Mappers
|----- MapperProfile.cs
|--- Queries
|----- Query
|------- Query.cs
|------- QueryHandler.cs
|------- QueryResult.cs
|   GlobalUsings.cs
```

# Tools
## Nswag studio
Nswag studio is a tool that can be used to generate code from an API. This can be used to generate the client code for the API. 

https://github.com/RicoSuter/NSwag/wiki/NSwagStudio


