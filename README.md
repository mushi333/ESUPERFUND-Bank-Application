# ESUPERFUND-Bank-Application

## Table of Contents

- [Background](#Background)
- [Documentation](#Documentation)
- [Getting Started](#Getting-Started)

## Background
This GitHub page is for the take-home assessment for the ESUPERFUND C# Junior Developer position. The goal was to develop a small banking transaction back-end.  

I have developed a .NET CORE Web API-based back-end solution for the assessment. The documentation details are in the documentation page. The solution itself is in the HTTP-API folder.  

## Documentation
The documentation folder contains the requirements, the ERD diagram and the CSV file containing the initial data. The ERD diagram looks like this:

![ERD Diagram](Documents/ERD.drawio.png)

This design was chosen because the RAW_BANK_TRANSACTION table and the BANK_TRANSACTION table will contain identical information. Hence, it is a one-to-one relationship. The reason is that after the balances are closed successfully in the raw table, that information is transferred to the normal table.

For the database, Azure SQL Server was chosen, and a free-tier application was used alongside the development of the back end. Please feel free to replace this with another SQL Server.

## Getting Started
Before starting, have **.NET Core 7** installed and running in your application. The installation guide can be found [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

You can follow these installation steps to run the application.

1. Install the .NET Entity Framework CLI
- ```dotnet tool install --global dotnet-ef```
2. Update the appsettings.json file in the HTTP-API folder with your database connection string.
3. Change directory to the "HTTP-API" folder.
4. Run these migration instructions to set up the database
- ```dotnet ef migrations add Initialization```
- ```dotnet ef database update```
5. Run the following command to start the server. Go to your "localhost:PORT_NUMBER/index.html" URL to view the generated Swagger page.
- ```dotnet run```
6. Interact with the back-end application by using the Swagger page.

## Feedback
This is the following feedback from ESUPERFUND:
- default logging
- partial exception handling
- sync/async mixed
- db savechange in loop
