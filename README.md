## Architecture Overview

### Client
- This is the top-most layer, essentially a REST service wrapper (e.g., an AWS Lambda function). Instances of the logger, repository, etc., are created here and passed down. It is designed to wire up all the dependencies for the application layer. The handler is executed by AWS Lambda in the main function. This allows the client layer to be easily switched out and used by another consumer.

### Application
- Defines the use cases the software is supposed to handle and coordinates the domain objects to solve problems. This layer is kept thin and receives all infrastructure objects via interface-based definitions. It does not contain business rules or knowledge but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down. It does not have state reflecting the business situation but can have state that reflects the progress of a task for the user or the program.

### Domain
- **Aggregate**: Responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical stuff is delegated to the infrastructure. This layer is the heart of business software.
- **Entity**: Domain "Model" that stores the entities with validation rules, however stored in the Domain layer for this example project.

### Infrastructure
- Implementation of the tech stack using interfaces like `IRepo`, `ILogger`, etc. You can see in the repo folder, using the `IRepo` interface, there are multiple data provider examples: Snowflake, PostgreSQL, and Parameter Store.

### DB
- Placeholder for Entity Framework, and YAML file for Docker PostgreSQL.

### Common
- Common logic shared across different parts of the application.

### Unit / Integration Tests
- Will be added where appropriate to ensure quality and functionality.
