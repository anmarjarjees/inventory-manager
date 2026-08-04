# Inventory Manager:
A professional ASP.NET Core MVC (.NET 8) educational project that demonstrates modern MVC architecture and gradually introduces Entity Framework Core, SQL Server, Identity, validation, logging, error handling, and deployment following Microsoft's recommended practices whenever practical.

# The repository folder structure main content:
- inventory-manager <=> GitHub repository root folder
    - InventoryManager <=> Visual Studio solution/project folder
        - Controllers
            - HomeController.cs
        - Models
            - ErrorViewModel.cs
        - Views
            - Home
            - Shared
            - _ViewImports.cshtml
            - _ViewStart.cshtml
        - wwwroot
        - Program.cs
        - appsettings.Development.json
        - appsettings.json
        - *InventoryManager.sln*
        - *InventoryManager.csproj*
- README.md

**NOTE:**
Visual Studio Solution Explorer does not display some project system files by default, such as `.sln` and `.csproj`.
The `.csproj` file is the project definition file. It contains project configuration information and is not considered application source code.

**To open/modify the project file .csproj:**
1. Rightclick the project name
2. Select "Edit Project File
3. Visual Studio will open the .csproj XML content

## Solution vs Project:
In Visual Studio and .NET applications, a solution and a project have different purposes.

**Solution (.sln):**
- A container that organizes one or more projects
- Used by Visual Studio to manage the application structure

**Project (.csproj):**
- Defines how a specific application is built
- Contains framework information, package references, and build settings

---
---

# What ASP.NET Core generates:
## The project file "InventoryManager.csproj":
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project>
```
---

**1. Project SDK:**
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```
This tells .NET: *"This is a web application project"*. Because ASP.NET Core applications need web-specific features like:
    - Kestrel web server
    - Razor support
    - MVC services
    - web-related build tools

Notice that the **"Web SDK"** includes the tools and references required to build ASP.NET Core applications.

**2. Target Framework:**
```xml
<TargetFramework>net8.0</TargetFramework>
```
Specifies the target framework version, which means we are using the .NET 8 runtime.

**3. Nullable reference types:**
```xml
<Nullable>enable</Nullable>
```
Enables nullable reference type analysis. The compiler can warn developers when code may unintentionally use a null value, helping us as developers detect possible null-related problems earlier during development instead of discovering them at runtime..
For more details refer to my C# programming repo ["C# Essentials"](https://github.com/anmarjarjees/csharp-essentials)

**4. Implicit Usings:**
<ImplicitUsings>enable</ImplicitUsings> 
This option reduces unnecessary using statements:

Before:
```C#
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
```
Now the SDK automatically includes common namespaces

---
### The entry-point file "Program.cs":
The Program.cs file is the application entry-point in modern ASP.NET Core applications.

It is responsible for:

- Registering application services using Dependency Injection.
- Configuring the HTTP request pipeline.
- Defining middleware.
- Configuring MVC routing.


## Project Status:
**Currently:**
- ASP.NET Core MVC project created.
- Default MVC structure reviewed.
- Application architecture documentation started.

**To be added:**
- Entity Framework Core integration.
- SQL Server database.
- CRUD functionality.
- Authentication and authorization.
- Logging and error handling.
- Deployment.

# References (Additional References will be added as my other git repos):
- .NET documentation:
    - https://learn.microsoft.com/dotnet
- Microsoft ASP.NET Core documentation:
    - https://learn.microsoft.com/aspnet/core
- Entity Framework Core documentation:
    - https://learn.microsoft.com/ef/core
