# BG .NET Web API

## Getting Started

This project use Postgres database and EF to the operations on the database.


## Clean architecture structure
    .
    ├── BLA.UserFlow.API                # presentation layer
    ├── BLA.UserFlow.Application        # use cases (services), requests and responses
    ├── BLA.UserFlow.Core               # core domain (entities, value objects)
    ├── BLA.UserFlow.Infrastructure     # interaction with external dependencies (Database, IoC)
    └── BLA.UserFlow.Tests              # unit test

Other folder

    .
    ├── init-scripts                    # database scripts

### Run tests

1. Ensure you have Docker running (https://docs.docker.com/engine/install/)

```
dotnet test
```

### Prerequisites

1. Docker (https://docs.docker.com/engine/install/)

2. Start up all services
```
docker-compose up
```
3. Navigate to
```
http://localhost:8080/swagger/index.html
```
4. Stop services
```
docker-compose down -v
```