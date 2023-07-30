# ERP - Enterprise Resource Planning [Back-end]
A simplified Enterprise Resource Planning (A.K.A.: ERP) system.
Created as a **RESTful API** on .NET using **ASP.NET** framework, made to solve day-by-day business management.

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

## Technical Requirements
- [x] Add [Serilog](https://serilog.net/)
- [X] Add dependency injection
- [X] Use SQL database
    - [] Use MySql database or connect to sqlite3
    - Start SQL server on local machine to start connecting and running the initial migrations... - ex: https://code-maze.com/using-dapper-with-asp-net-core-web-api/
- [X] Use ORM framework: Dapper
- [X] Use SOLID principles
- [X] Use design patterns for clean code
- [ ] Use migrations for SQL