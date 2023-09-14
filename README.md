# ERP.API - A simplified Enterprise Resource Planning solution
This project is a study that aims to put together back-end technologies in an applied context that is the Enterprise Resource Planning (A.K.A.: ERP) solution. We are going to apply the concepts of Clean Architecture and Clean Code as much as possible.
The final expected result is a **RESTful API** on .NET using **ASP.NET** framework, made to solve day-by-day business management.

> Warning: Currently this is just a study not a software for production purposes. Feel free to use the system at your own risk. We do not take responsability for any damage caused by this software.

The system has the goal to solve some business issues as:
- Human resources management
- Payroll management
- Audit of company actions on the ERP

### Technologies applied to the project
- .NET
- ASP.NET framework
- Dapper
- SQL Server
- Docker

## 1. Setup and running the API
We recommend the usage of Docker for running our project. For debbuging prefer installing the .NET directly on your machine and using Visual Studio or VSCode IDEs.

> Note: in order to run the project on Docker you must install Docker first! As for running .NET you must install it on your machine too.

### Setup
First you will need to install one or all options bellow
- [Visual Studio or VSCode](https://visualstudio.microsoft.com/) IDE, along with the [.NET6](https://dotnet.microsoft.com/en-us/) framework.
- Containerization: [Docker](https://www.docker.com/) or [Podman](https://podman.io/)

Use the embedded SQL Server of the Visual Studio for local debug or the server on the Docker container (Through docker-compose) and run the following script `./utl/DatabaseInitializationAndUsefulQueries.sql`. This script will setup the database and the initial data.

NOTE: once we enable migrations this step will be replaced.

### Run API locally
Using the Visual Studio IDE or run via CLI using
```ps
dotnet run --project src/ErpApi.WebAPI/ErpApi.WebAPI.csproj
```

### Run API as Docker container
Container docker
```dockerfile
# Build
docker build -t web-api .
# Run
docker run -d -p 8080:80 web-api
```
### Build your environment via docker-compose

Initialize all containers
```bash
docker-compose up -d
```
Initialize and build all containers (Important to rebuild if needed!)
```bash
docker-compose up -d --build
```
Shutdown all containers
```bash
docker-compose down
```
> Tip: use `docker-compose` or `docker compose` without dash.

Access the aplication with the browser using `localhost:8080`.

## 2. Roadmap
The planned features for this system are:
* Hire collaborators
    * Set collaborator salary
* Increase collaborators' salary
* Fire collaborators
* Audit of system changes through database (SQL)
* View cash flow throught specific and global payroll

### Tasks accomplished
List of tasks accomplished that enable us to follow the readmap:
- [x] Create base project
- [x] Create WebAPI with Collaborator's initial logic
- [ ] Create Test project
    - [x] Create base project
    - [x] Create test framework for SQL database tests
    - [ ] Improve test framework to allow multiple tests to work with same database schema and or data
    - [ ] Cover initial functionalities with tests

## Technical Goals
- [x] Add [Serilog](https://serilog.net/)
- [X] Add dependency injection
- [X] Use SQL database (SQL Server)
    - Initial tutorial followed https://code-maze.com/using-dapper-with-asp-net-core-web-api/
- [X] Use ORM framework: Dapper
- [ ] Use [Dommel](https://github.com/henkmollema/Dommel) with Dapper
- [X] Use SOLID principles
- [X] Use design patterns for clean code
- [X] Add externalId for database
- [X] Add UnitTests
    - Issues:
        - DatabaseName not set on IConfiguration for the Repository being tested.
    - Solutions:
        - Only one DB for TestClass and the DBName should be injected on the IConfiguration for the repository
        - ~~Multiple DBs for each test case (More dificult to create and manage). Also the DBName must be injected on the IConfiguration~~
- [X] Add middleware to handle exceptions on API
- [X] Add Automapper
- [X] Add Validation via Filters
- [ ] Add Fluentvalidation
- [X] Create Services to decouple presentation from Domain
- [ ] Add UnitOfWork/Transactions for Database keeping the architecture clean
- [ ] Split tests in two projects: 1. Unit Tests; 2. Integration Tests;
- [ ] Use migrations for SQL. Ex: [Liquibase](https://www.liquibase.org/).
- [X] Configure docker-compose to build dev environment with SQLServer.
    - References:
        - https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-docker-container-deployment?view=sql-server-ver15&pivots=cs1-bash#persist
        - https://stackoverflow.com/questions/63133630/is-it-possible-to-create-a-volume-with-microsoft-sql-server-docker-container
        - https://hub.docker.com/_/microsoft-mssql-server


#back-end; #dotnet6; #dapper; #docker; #docker-compose; #sqlserver;