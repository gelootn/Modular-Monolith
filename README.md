# Modular-Monolith
## Introduction
This solution contains a reference architecture for a modular monolith. This architecture exposes 1 API that contains all modules. Each module is a self contained unit of functionality that can be deployed independently. The solution also contains a reference implementation of a module that can be used as a starting point for new modules.

## Getting Started
The Api project has no own logic. It simply acts as an entry point that contains the registerd modules. 
Each module has its own logic, commands, queries, handlers and data access.
## Modules
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


