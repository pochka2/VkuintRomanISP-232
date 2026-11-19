-- Структура базы данных ExpenseTrackerDB

CREATE DATABASE ExpenseTrackerDB;
GO

USE ExpenseTrackerDB;
GO

CREATE TABLE Expenses
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(10,2) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    ExpenseDate DATE NOT NULL
);
GO
