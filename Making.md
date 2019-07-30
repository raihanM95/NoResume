# Processes of Making NoResume

In this document, I'll be making some notes on how I have developed this application for 
future overview of managing relevant processes.

## Procedure

+ Firstly, I've created the project using a command. The command is:
    - ``` $ dotnet new mvc -o NoResume ```
+ Then I have created two markdown files, named as Making.md and README.md
+ I have added materialize css to the design library
+ After making Register, Login and ApplicationDbContext models I have added this nuget packages:
    - ``` dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 2.2.0 ```
    - ``` dotnet add package Microsoft.AspNetCore.Identity --version 2.2.0 ```
    - ``` dotnet add package Microsoft.EntityFrameworkCore.Design --version 2.2.6 ```
    - ``` dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 2.2.6 ```
    - ``` dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.6 ```
    - ``` dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 2.2.3 ```
    - ``` dotnet add package Microsoft.AspNetCore.StaticFiles --version 2.2.0 ```