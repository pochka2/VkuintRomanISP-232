# SQL notes

Учебная база: `PracticeDB`. Скрипт создания и заполнения: `database/init.sql`.
SQL-запросы предназначены для Microsoft SQL Server (SSMS).

## Task 01 — Создание базы и таблиц

### SQL

Создание базы, таблиц, первичных и внешних ключей находится в `init.sql`.
После запуска скрипта:

```sql
USE PracticeDB;
GO

-- Проверка четырёх таблиц.
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
  AND TABLE_NAME IN ('Departments', 'Employees', 'Projects', 'EmployeeProjects')
ORDER BY TABLE_NAME;

-- Проверка внешних ключей.
SELECT name
FROM sys.foreign_keys
ORDER BY name;
```

### Результат

Ожидаются четыре таблицы: `Departments`, `Employees`, `Projects`, `EmployeeProjects`.

Внешних ключей четыре: `FK_Employees_Departments`, `FK_Employees_Manager`, `FK_EP_Employees`, `FK_EP_Projects`.

### Вывод

Созданы четыре таблицы. В `Employees` есть ссылка на отдел и ссылка на руководителя из той же таблицы. `EmployeeProjects` связывает сотрудников с проектами.

