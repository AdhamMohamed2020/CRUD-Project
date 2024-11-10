
# CRUD Project

## Description
**CRUD Project** is a simple application designed to manage employee and department information, enabling efficient creation, modification, deletion, and retrieval of employee records. With secure login and user management handled by Identity, the system offers a streamlined approach to organizing employee data and linking them to their respective departments.

## Prerequisites
- **.NET SDK 8.0.**
* **Database:** set up a database server (SSMS) to store product data, user information, and orders.
- **Code Editor:** Use an IDE like Visual Studio to edit and run the code.

## Features
- **Employee Management:** allows adding, updating, and deleting employee records.
- **Department Management:** manage employee department assignments and department details.
- **Data Retrieval (Searching):** users can search for and retrieve employee and department data easily.
- **Database Integration:** the app uses Entity Framework Core to interact with the database.
- **Secure Login:** provides secure login and authentication using ASP.NET Identity.
  
## Used technologies:
* **Dependency Injection.**
- **Entity Framework Core (EF Core).**
* **SQL Server.** 
- **Authentication and Authorization.**

## Used Patterns
- **Repository Pattern.** 
* **Unit of Work Pattern.**
- **N-Tears Pattern.**

## Packages
* **Microsoft.EntityFrameworkCore.**
- **Microsoft.AspNetCore.Identity.**

## Installation
**1- Install Git (if not already installed):** 
Before you begin, make sure you have Git installed on your machine.

**2- Clone the Repository from GitHub:**
- Find the "Clone or download" button and click it.
- Copy the HTTPS URL link provided (link).
- Now, open your terminal (Command Prompt, PowerShell, or Git Bash on Windows, or Terminal on macOS/Linux) and run the following command to clone the repository:

```bash
git clone (link)
```
This will download the entire repository to your local machine.


**3- Navigate to the Project Directory:**
Once the project is cloned, move into the project directory by running:

```bash
cd repository
```
Replace repository with the actual name of the project folder that was created after cloning.

**4- Open the Project in Visual Studio (or your preferred IDE)**

If you're using Visual Studio, you can open the project by navigating to the .sln file and double-clicking it, or you can run:

```bash
start MyProject.sln
```

**5- Install Dependencies (if applicable):**
If the project has external dependencies specified in a .csproj file or a NuGet.config file, you can restore them by running the following command in the terminal within the project directory:

```bash
dotnet restore
```

This will download all the necessary packages and dependencies for the project.

**6- Build the Project:**
To ensure the project builds correctly, use the following command:

```bash
dotnet build
```

This command will compile the project and show you if there are any errors or warnings.

**7- Run the Project:**
Finally, to run the project, use the following command:

```bash
dotnet run
```
