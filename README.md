# ImagesTask
Web application for viewing, adding, and deleting images. It is loosely based on clean architecture and consists of 3 projects, Core, Infrastructure and App(UI). The communication between the projects happends only via Core's interfaces.
## App
ASP.net 6.0 MVC. References Core and Infrastructure. (Infrastructure is used only for Dependency Injection)

1. Receives ImageDTO from Core
2. Validates input
3. calls core's service for viewing, creating and deleting images

## Core
Contains the business logic, entities and DTOs of the application. 
It implements IImageService with the help of MediatR queries. 
It contains configuration for mapping between image entity and imageDTO.
It contains interfaces for Infrastructure (sql server and azure blob storage) and App (queries).
### Uses
- AutoMapper
- Mediator & CQRS

## Infrastructure
Contains implementation of Core interfaces related to data. It references Core. Consists of:
- AzureBlobStorage service
- SQLServer service.

### Uses
- Azure Storage Blobs, with azurite simulator. 
- Configuration Binder (for depency injections).
- EntityFrameworkCore.SqlServer.

# Requires
- Azurite or Azure Blob Storage (settings must be inserted at appsetings.json)
- Database at SQLServer (settings must also be inserted at appsetings.json)


