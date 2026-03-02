-- Create Database
CREATE DATABASE CompanyDB;
USE CompanyDB;

-- Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    DepartmentID INT,
    Salary DECIMAL(10,2)
);

-- Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100)
);

-- Projects Table
CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100),
    EmployeeID INT
);

INSERT INTO Departments (DepartmentName) VALUES ('HR'), ('IT'), ('Finance');

INSERT INTO Employees (Name, Email, DepartmentID, Salary)
VALUES ('Alice', 'alice@example.com', 1, 50000),
       ('Bob', 'bob@example.com', 2, 60000),
       ('Charlie', 'charlie@example.com', 3, 55000);

INSERT INTO Projects (ProjectName, EmployeeID)
VALUES ('Website Redesign', 2),
       ('Payroll System', 3);
________________________________________


-- Create
CREATE PROCEDURE AddEmployee
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @DepartmentID INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Employees (Name, Email, DepartmentID, Salary)
    VALUES (@Name, @Email, @DepartmentID, @Salary);
END;

-- Read
CREATE PROCEDURE GetEmployees
AS
BEGIN
    SELECT E.EmployeeID, E.Name, E.Email, D.DepartmentName, E.Salary
    FROM Employees E
    JOIN Departments D ON E.DepartmentID = D.DepartmentID;
END;

-- Update
CREATE PROCEDURE UpdateEmployee
    @EmployeeID INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @DepartmentID INT,
    @Salary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Name=@Name, Email=@Email, DepartmentID=@DepartmentID, Salary=@Salary
    WHERE EmployeeID=@EmployeeID;
END;

-- Delete
CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employees WHERE EmployeeID=@EmployeeID;
END;

-- Search
CREATE PROCEDURE SearchEmployee
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Employees
    WHERE Name LIKE '%' + @Keyword + '%'
       OR Email LIKE '%' + @Keyword + '%';
END;
