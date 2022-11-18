
	•	Client
	◦	This is the top most layer, essentially for example a rest service wrapper (lambda function). Instances of the logger, repo, etc... are created here and passed down. It is meant to wire up all of the dependencies for the application layer. Handler is executed by AWS Lambda in the main function. This allows the client layer to easily switched out and used by another consumer.
	•	Application
	◦	Defines the use cases the software is supposed to do and coordinates the domain objects to work out problems. This layer is kept thin and will receive all infra objects via interface based definition. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down. It does not have state reflecting the business situation, but it can have state that reflects the progress of a task for the user or the program.
	•	Domain
	◦	Aggregate responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical stuff is delegated to the infrastructure. This layer is the heart of business software.
	◦	Entity
	▪	Domain “Model” that stores the entities with validation rules, however stored in the Domain layer for this example project.
	•	Infrastructure
	◦	Implementation of tech stack using IRepo, ILogger, etc… you can see in the repo folder, using the IRepo interface, there are multiple data provider examples snowflake, postgres, and parameter store.
	•	DB
	◦	place holder for entity framework, and yaml file for docker postgresql
	•	Common
	◦	Common logic
	•	Unit / Integration Tests
	◦	Will be added where appropriate

