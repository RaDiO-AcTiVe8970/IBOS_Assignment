# Employee Management API

This project is an API for managing employee data using C#, .NET Core, MSSQL, and Entity Framework Core. It provides various endpoints to perform operations related to employee management.

## Used
- ASP.NET 7
- Swagger

## Table of Contents
   - API01: Update an Employee's Information
   - API02: Get Employee with 3rd Highest Salary
   - API03: Get Employees with No Absent Record
   - API04: Get Monthly Attendance Report
   - API05: Get Employee Hierarchy

## API01: Update an Employee's Information
  -  Endpoint:/api/Employee/{id}
  -  Description: Update an employee's Employee Name and Code. Duplicate employee codes are not allowed.

## API02: Get Employee with 3rd Highest Salary
  -  Endpoint:/api/Employee/thirdhighestsalary
  -  Description: Get the employee with the 3rd highest salary.

## API03: Get Employees with No Absent Record
  -  Endpoint:/api/EmployeeAttendance/maxsalarynoabsent
  -  Description: Get all employees based on maximum to minimum salary who have no absent records.

##  API04: Get Monthly Attendance Report
  - Endpoint:/api/EmployeeAttendanceReport/monthlyattendancereport
  - Description: Get the monthly attendance report of all employees.
  Report Columns:

    Employee Name
    Month Name
    Payable Salary
    Total Present
    Total Absent
    Total Offday

## API05: Get Employee Hierarchy
  -  Endpoint:/api/Employee/hierarchy/{employeeId}
  -  Description: Get the hierarchy of employees based on the supervisor of an input employee.
    Example Input Employee Id: 502036
    Example Output Employees:
        Selim Reja
        Rasel Shikder
        Hasan Abdullah
        Ashikur Rahman

## Installation and Usage
Follow these steps to install and run the Employee Management API:
### Prerequisites
  - Install .NET Core 7: You can download and install .NET Core 7 from the official website: https://dotnet.microsoft.com/download

  - Clone this repository:
  ```bash
    git clone https://github.com/your/repo.git
    cd repo-folder
  ```
  - Configure your MSSQL database connection. Open the appsettings.json file and update the connection string to point to your MSSQL database.
  ```
  mysql instructions
  ```
  - Run the database migrations to create the necessary tables:
  ```
    add-migration any identified
    update-database
  ```
  - Build the application:
  ```
    dotnet build
  ```
  - Run the application:
  ```
    dotnet run
  ```

  The API will start, and you can access it at http://localhost:5000 (or https://localhost:5001 for HTTPS). You can use tools like Postman or curl to interact with the API endpoints.

  Feel free to reach out if you have any questions or need further assistance with this project.