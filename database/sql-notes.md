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

## Task 02 — INSERT: заполнение данными

### SQL

Вставка тестовых данных в четыре таблицы выполнена в `init.sql` через `INSERT INTO ... VALUES`. Проверка количества записей:

```sql
USE PracticeDB;
GO

SELECT COUNT(*) AS DepartmentsCount FROM Departments;
SELECT COUNT(*) AS EmployeesCount FROM Employees;
SELECT COUNT(*) AS ProjectsCount FROM Projects;
SELECT COUNT(*) AS EmployeeProjectsCount FROM EmployeeProjects;
```

### Результат

Ожидаемые значения по данным `init.sql`:

| Таблица | Записей |
| --- | ---: |
| Departments | 4 |
| Employees | 10 |
| Projects | 5 |
| EmployeeProjects | 14 |

### Вывод

В таблицах есть отделы, сотрудники, проекты и назначения сотрудников на проекты. Руководители указаны через `ManagerId`.

## Task 03 — SELECT + WHERE

### SQL

Пять запросов по условиям методички.

```sql
USE PracticeDB;
GO

-- 1. Зарплата больше 50000.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY EmployeeId;

-- 2. Принятые на работу в 2023 году.
SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE YEAR(HireDate) = 2023
ORDER BY EmployeeId;

-- 3. Имя начинается на букву «А».
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE EmployeeName LIKE N'А%'
ORDER BY EmployeeId;

-- 4. Сотрудники второго отдела.
SELECT EmployeeId, EmployeeName, DepartmentId
FROM Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;

-- 5. Зарплата от 40000 до 60000 включительно.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE Salary BETWEEN 40000 AND 60000
ORDER BY EmployeeId;
```

### Результат

Ожидаемые выборки на тестовых данных из `init.sql`:

| Запрос | Сотрудники | Количество |
| --- | --- | ---: |
| Зарплата > 50000 | Анна, Пётр, Мария, Ольга, Дмитрий, Елена, Алексей | 7 |
| Приняты в 2023 году | Иван, Елена | 2 |
| Имя начинается на «А» | Анна, Алексей | 2 |
| Отдел №2 | Ольга, Дмитрий, Елена | 3 |
| Зарплата от 40000 до 60000 | Мария, Иван, Дмитрий, Елена, Сергей, Наталья | 6 |

### Вывод

`WHERE` выбирает строки по условию, `YEAR()` помогает отобрать записи по году, `LIKE` ищет по началу имени, а `BETWEEN` проверяет диапазон с включёнными границами.
