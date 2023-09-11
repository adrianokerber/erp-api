# ERP - Enterprise Resource Planning [Back-end]
A simplified Enterprise Resource Planning (A.K.A.: ERP) system.
Created as a **RESTful API** on .NET using **ASP.NET** framework, made to solve day-by-day business management.
We apply the concepts of Clean Architecture and Clean Code as much as possible.

> Warning: Currently this is just a study not a software for production purposes. Feel free to use the system at your own risk. We do not take responsability for any damage caused by this software.

The system has the goal to solve some business issues as:
- Human resources management
- Payroll management
- Audit of company actions on the ERP

## Roadmap
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