# Modular-Monolith
## Introduction
This solution contains a reference architecture for a modular monolith. This architecture exposes 1 API that contains all modules. Each module is a self contained unit of functionality that can be deployed independently. The solution also contains a reference implementation of a module that can be used as a starting point for new modules.

## Getting Started
The Api project has no own logic. It simply acts as an entry point that contains the registerd modules. 
Each module has its own logic, commands, queries, handlers and data access.

## Projects in the solution
### ModularMonolith.Framework
This is a supporting project. It contains classes and code that is used by the rest of the application.
All other projects have a reference to this project, this project can reference no other projects.
### ModularMonolith.Entities
This project contains all entities that are used in the application. This project has a reference to the ModularMonolith.Framework project.
This project also contains the DbContext for the readonly part of the applications. This context knows all entities and can be used to query data between that is controlled by other modules. 
### ModularMonolith.Api
This is the entry point of the application. It contains the startup class and the link to all modules that are available in the application.

## Modules
### References
Each module has a reference to the following projects:
- ModularMonolith.Framework
- ModularMonolith.Entities


### Structure
A module contains the following folders:

|Folder| Description                                               |
|---|-----------------------------------------------------------|
|Commands| Contains all commands that can be executed on the module  |
|Configuration| Contains the DI configuration for the module              |
|Controllers| Contains the controllers for the module                   |
|Database| Contains the DbContext of the module and the repositories |
|Dtos| Contains the Dtos for the module                          |
|Mappers| Contains the automapper profiles for the module           |
|Queries| Contains all queries that can be executed on the module   |

### Handling data

