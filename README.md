This is a simple Restful service that consumes a third party API (https://superheroapi.com)

## Architecture
The architecture makes use of a watered down CQRS design to remove a lot of complexity and layers and is developed with SOLID Principles in mind. I made use of the MediatR Pattern. I wanted to ensures that we have loose coupling and that there is no direct communication between components. All components have a single responsibility and are open for extension.

## Project Structure
Application entry is via the WebHost project. All API stuff, requests and responses sit in the Contracts project. In the Domain projects we have shared components such as the database layer, models and services making calls to third party APIs.
 
## Endpoints
There are 3 functional endpoints, 2 GET endpoints and 1 POST endpoint. The two GET end points internally make direct calls to a third party endpoint to retrieve data. The POST end point retireves data from the third party API and stores that data locally into a Mongo database.
 
## Tech Debt
 * Unit tests.
 * Validation to prevent dirty or invalid inputs.
 * Security (Oauth2)

## Deployment
A pipleline can be configured to pull the code from the repository, compile it and deploy the artifacts to instances.
The service is scalable and can be placed behind a load balancer.

## Notes
A Swagger page is available to assist in the documentation of the API. 
