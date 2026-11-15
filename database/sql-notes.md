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

## Task 04 — ORDER BY + TOP

### SQL

```sql
USE PracticeDB;
GO

-- Три самых высоких зарплаты.
SELECT TOP 3 EmployeeName, Salary
FROM Employees
ORDER BY Salary DESC;

-- Пять сотрудников с самой ранней датой найма.
SELECT TOP 5 EmployeeName, HireDate
FROM Employees
ORDER BY HireDate ASC;

-- Сначала по отделу, затем по зарплате.
SELECT DepartmentId, EmployeeName, Salary
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;
```

### Результат

Топ-3 по зарплате:

| Сотрудник | Зарплата |
| --- | ---: |
| Алексей Лебедев | 90000 |
| Пётр Сидоров | 72000 |
| Анна Иванова | 65000 |

Топ-5 по дате найма (от самой ранней):

| Сотрудник | HireDate |
| --- | --- |
| Алексей Лебедев | 2018-05-25 |
| Пётр Сидоров | 2019-07-01 |
| Анна Иванова | 2020-03-15 |
| Ольга Смирнова | 2020-09-05 |
| Мария Кузнецова | 2021-11-20 |

По отделам: №1 — Пётр, Анна, Мария, Иван; №2 — Ольга, Дмитрий, Елена; №3 — Сергей, Наталья; №4 — Алексей. Внутри отделов зарплаты идут по убыванию.

### Вывод

`TOP` ограничивает количество строк, `ORDER BY` задаёт сортировку. При нескольких столбцах сортировка идёт по порядку их перечисления.

## Task 05 — Агрегация: COUNT, SUM, AVG, MIN, MAX

### SQL

```sql
USE PracticeDB;
GO

-- Количество, сумма, средняя, минимум и максимум.
SELECT
    COUNT(*) AS EmployeesCount,
    SUM(Salary) AS TotalSalary,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary
FROM Employees;

-- Сколько сотрудников получают больше 50000.
SELECT COUNT(*) AS SalaryAbove50000
FROM Employees
WHERE Salary > 50000;
```

### Результат

| Показатель | Значение |
| --- | ---: |
| Всего сотрудников | 10 |
| Сумма зарплат | 589000.00 |
| Средняя зарплата | 58900.00 |
| Минимальная зарплата | 43000.00 |
| Максимальная зарплата | 90000.00 |
| Зарплата выше 50000 | 7 |

### Вывод

`COUNT` считает записи, `SUM` складывает значения, `AVG` находит среднее, `MIN` и `MAX` — границы. `ROUND` округляет среднюю зарплату до двух знаков.

## Task 06 — GROUP BY: статистика по отделам

### SQL

```sql
USE PracticeDB;
GO

SELECT
    DepartmentId,
    COUNT(*) AS EmployeesCount,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC;
```

### Результат

| DepartmentId | Сотрудников | Средняя зарплата | Сумма |
| ---: | ---: | ---: | ---: |
| 4 | 1 | 90000.00 | 90000.00 |
| 1 | 4 | 60000.00 | 240000.00 |
| 2 | 3 | 57000.00 | 171000.00 |
| 3 | 2 | 44000.00 | 88000.00 |

### Вывод

`GROUP BY` собирает сотрудников одного отдела в группу. Для каждой группы считаются количество сотрудников, средняя и общая зарплата.

## Task 07 — GROUP BY + HAVING

### SQL

```sql
USE PracticeDB;
GO

-- Отделы, где больше двух сотрудников.
SELECT DepartmentId, COUNT(*) AS EmployeesCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2
ORDER BY DepartmentId;

-- Отделы, где средняя зарплата выше 55000.
SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AverageSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000
ORDER BY DepartmentId;

-- Отделы, где сумма зарплат выше 150000.
SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000
ORDER BY DepartmentId;
```

### Результат

Отделы, в которых больше двух сотрудников:

| DepartmentId | Сотрудников |
| ---: | ---: |
| 1 | 4 |
| 2 | 3 |

Отделы со средней зарплатой выше 55000:

| DepartmentId | Средняя зарплата |
| ---: | ---: |
| 1 | 60000.00 |
| 2 | 57000.00 |
| 4 | 90000.00 |

Отделы с суммой зарплат выше 150000:

| DepartmentId | Сумма зарплат |
| ---: | ---: |
| 1 | 240000.00 |
| 2 | 171000.00 |

### Вывод

`HAVING` проверяет условие после объединения строк в группы. `WHERE` фильтрует отдельные строки до группировки.

## Task 08 — INNER JOIN: сотрудники и отделы

### SQL

```sql
USE PracticeDB;
GO

SELECT
    e.EmployeeName,
    d.DepartmentName,
    e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;
```

### Результат

На тестовых данных возвращаются все 10 сотрудников с названиями их отделов.

| EmployeeName | DepartmentName | Salary |
| --- | --- | ---: |
| Ольга Смирнова | Аналитика | 61000.00 |
| Дмитрий Орлов | Аналитика | 58000.00 |
| Елена Волкова | Аналитика | 52000.00 |
| Алексей Лебедев | Менеджмент | 90000.00 |
| Пётр Сидоров | Разработка | 72000.00 |
| Анна Иванова | Разработка | 65000.00 |
| Мария Кузнецова | Разработка | 55000.00 |
| Иван Петров | Разработка | 48000.00 |
| Сергей Морозов | Тестирование | 45000.00 |
| Наталья Соколова | Тестирование | 43000.00 |

### Вывод

`INNER JOIN` соединяет сотрудников с отделами по `DepartmentId`. Сначала строки сортируются по названию отдела, затем по зарплате по убыванию.

## Task 09 — LEFT JOIN — сотрудники без проектов

### SQL

```sql
USE PracticeDB;
GO

SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL
ORDER BY e.EmployeeId;
```

### Результат

На данных из `init.sql` ожидается одна строка:

| EmployeeId | EmployeeName |
| ---: | --- |
| 9 | Наталья Соколова |

### Вывод

`LEFT JOIN` оставляет всех сотрудников, а для отсутствующих назначений на проекты возвращает `NULL`. Условие `IS NULL` находит сотрудников без проектов.

## Task 10 — Множественный JOIN — сотрудники, отделы и проекты

### SQL

```sql
USE PracticeDB;
GO

SELECT
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;
```

### Результат

На тестовых данных ожидаются 14 назначений:

| EmployeeName | DepartmentName | ProjectName | Hours |
| --- | --- | --- | ---: |
| Дмитрий Орлов | Аналитика | AI Assistant | 50 |
| Дмитрий Орлов | Аналитика | Data Warehouse | 70 |
| Елена Волкова | Аналитика | Mobile App | 95 |
| Ольга Смирнова | Аналитика | Data Warehouse | 110 |
| Алексей Лебедев | Менеджмент | AI Assistant | 200 |
| Алексей Лебедев | Менеджмент | CRM System | 30 |
| Анна Иванова | Разработка | CRM System | 120 |
| Анна Иванова | Разработка | Data Warehouse | 80 |
| Иван Петров | Разработка | Legacy Refactor | 40 |
| Иван Петров | Разработка | Mobile App | 90 |
| Мария Кузнецова | Разработка | Mobile App | 100 |
| Пётр Сидоров | Разработка | AI Assistant | 60 |
| Пётр Сидоров | Разработка | CRM System | 150 |
| Сергей Морозов | Тестирование | Legacy Refactor | 130 |

### Вывод

Через `INNER JOIN` соединены все четыре таблицы. Для каждого назначения выводятся сотрудник, отдел, проект и часы; `ORDER BY` задаёт порядок по трём полям.

## Task 11 — SELF JOIN — руководители сотрудников

### SQL

```sql
USE PracticeDB;
GO

SELECT
    e.EmployeeName,
    m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId
ORDER BY e.EmployeeId;
```

### Результат

На исходных данных ожидаются 10 строк:

| EmployeeName | ManagerName |
| --- | --- |
| Анна Иванова | NULL |
| Пётр Сидоров | NULL |
| Мария Кузнецова | Пётр Сидоров |
| Иван Петров | Анна Иванова |
| Ольга Смирнова | NULL |
| Дмитрий Орлов | Ольга Смирнова |
| Елена Волкова | NULL |
| Сергей Морозов | NULL |
| Наталья Соколова | Алексей Лебедев |
| Алексей Лебедев | NULL |

### Вывод

Таблица `Employees` соединяется сама с собой по `ManagerId`. `LEFT JOIN` нужен, чтобы сотрудники без руководителя тоже попали в результат.

## Task 12 — Подзапросы в WHERE

### SQL

```sql
USE PracticeDB;
GO

-- Сотрудники с зарплатой выше средней.
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees)
ORDER BY Salary DESC;

-- Сотрудники с самой большой зарплатой.
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees)
ORDER BY EmployeeName;
```

### Результат

Средняя зарплата по тестовым данным — 58900.00.

Сотрудники с зарплатой выше средней:

| EmployeeName | Salary |
| --- | ---: |
| Алексей Лебедев | 90000.00 |
| Пётр Сидоров | 72000.00 |
| Анна Иванова | 65000.00 |
| Ольга Смирнова | 61000.00 |

Максимальная зарплата — 90000.00, её получает Алексей Лебедев.

### Вывод

Подзапрос сначала вычисляет среднюю или максимальную зарплату, а внешний запрос использует это число в условии `WHERE`.

## Task 13 — Скалярные подзапросы в SELECT

### SQL

```sql
USE PracticeDB;
GO

SELECT
    e.EmployeeName,
    e.Salary,
    e.DepartmentId,
    ROUND((
        SELECT AVG(e2.Salary)
        FROM Employees e2
        WHERE e2.DepartmentId = e.DepartmentId
    ), 2) AS DepartmentAverage,
    ROUND(e.Salary - (
        SELECT AVG(e3.Salary)
        FROM Employees e3
        WHERE e3.DepartmentId = e.DepartmentId
    ), 2) AS SalaryDifference
FROM Employees e
ORDER BY e.EmployeeId;
```

### Результат

На тестовых данных:

| EmployeeName | Salary | DepartmentId | DepartmentAverage | SalaryDifference |
| --- | ---: | ---: | ---: | ---: |
| Анна Иванова | 65000.00 | 1 | 60000.00 | 5000.00 |
| Пётр Сидоров | 72000.00 | 1 | 60000.00 | 12000.00 |
| Мария Кузнецова | 55000.00 | 1 | 60000.00 | -5000.00 |
| Иван Петров | 48000.00 | 1 | 60000.00 | -12000.00 |
| Ольга Смирнова | 61000.00 | 2 | 57000.00 | 4000.00 |
| Дмитрий Орлов | 58000.00 | 2 | 57000.00 | 1000.00 |
| Елена Волкова | 52000.00 | 2 | 57000.00 | -5000.00 |
| Сергей Морозов | 45000.00 | 3 | 44000.00 | 1000.00 |
| Наталья Соколова | 43000.00 | 3 | 44000.00 | -1000.00 |
| Алексей Лебедев | 90000.00 | 4 | 90000.00 | 0.00 |

### Вывод

Скалярные подзапросы в `SELECT` вычисляют среднюю зарплату для отдела каждого сотрудника. Разница положительная, если зарплата выше средней, и отрицательная, если ниже.

## Task 14 — EXISTS и NOT EXISTS

### SQL

```sql
USE PracticeDB;
GO

-- Сотрудники с хотя бы одним проектом.
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE EXISTS (
    SELECT 1
    FROM EmployeeProjects ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;

-- Сотрудники без проектов.
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1
    FROM EmployeeProjects ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;
```

### Результат

На исходных данных первый запрос возвращает 9 сотрудников: Анна Иванова, Пётр Сидоров, Мария Кузнецова, Иван Петров, Ольга Смирнова, Дмитрий Орлов, Елена Волкова, Сергей Морозов, Алексей Лебедев.

Второй запрос возвращает одного сотрудника:

| EmployeeId | EmployeeName |
| ---: | --- |
| 9 | Наталья Соколова |

### Вывод

`EXISTS` проверяет наличие хотя бы одной подходящей записи, `NOT EXISTS` — её отсутствие. Запрос с `NOT EXISTS` даёт ту же выборку, что и `LEFT JOIN` в задании №9.

## Task 15 — UNION и UNION ALL

### SQL

```sql
USE PracticeDB;
GO

-- Объединить две выборки без повторений.
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE Salary > 60000
UNION
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

-- Объединить две выборки, сохранив повторения.
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE Salary > 60000
UNION ALL
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;
```

### Результат

В первой выборке 4 сотрудника с зарплатой выше 60000, во второй — 6 сотрудников, принятых до 2022 года.

`UNION` возвращает **6 уникальных строк**:

| EmployeeId | EmployeeName |
| ---: | --- |
| 1 | Анна Иванова |
| 2 | Пётр Сидоров |
| 3 | Мария Кузнецова |
| 5 | Ольга Смирнова |
| 8 | Сергей Морозов |
| 10 | Алексей Лебедев |

`UNION ALL` возвращает **10 строк** с повторениями:

| EmployeeId | EmployeeName |
| ---: | --- |
| 1 | Анна Иванова |
| 1 | Анна Иванова |
| 2 | Пётр Сидоров |
| 2 | Пётр Сидоров |
| 3 | Мария Кузнецова |
| 5 | Ольга Смирнова |
| 5 | Ольга Смирнова |
| 8 | Сергей Морозов |
| 10 | Алексей Лебедев |
| 10 | Алексей Лебедев |

### Вывод

`UNION` убирает повторяющиеся строки, а `UNION ALL` оставляет их. Анна, Пётр, Ольга и Алексей подходят сразу под оба условия, поэтому при `UNION ALL` встречаются два раза.

## Task 16 — UPDATE: изменение данных

### SQL

```sql
USE PracticeDB;
GO

-- Все изменения выполняются в транзакции.
BEGIN TRANSACTION;

-- 1. Увеличить зарплаты первого отдела на 10%.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1
ORDER BY EmployeeId;

UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentId = 1;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1
ORDER BY EmployeeId;

-- 2. Увеличить зарплату на 5000 принятым до 2022 года.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

UPDATE Employees
SET Salary = Salary + 5000
WHERE HireDate < '2022-01-01';

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

-- 3. Изменить дату найма одного сотрудника.
SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE EmployeeId = 4;

UPDATE Employees
SET HireDate = '2023-03-10'
WHERE EmployeeId = 4;

SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE EmployeeId = 4;

-- Возвращаем исходные данные для остальных заданий.
ROLLBACK TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary, HireDate
FROM Employees
WHERE EmployeeId IN (1, 4)
ORDER BY EmployeeId;
```

### Результат

Ожидаемые изменения на данных из `init.sql`:

| Действие | До | После |
| --- | --- | --- |
| Зарплата Анны, отдел 1 | 65000.00 | 71500.00 |
| Зарплата Петра, отдел 1 | 72000.00 | 79200.00 |
| Зарплата Анны после прибавки 5000 | 71500.00 | 76500.00 |
| Зарплата Ольги после прибавки 5000 | 61000.00 | 66000.00 |
| Дата найма Ивана | 2023-02-10 | 2023-03-10 |

Первый `UPDATE` изменяет 4 строки, второй — 6 строк, третий — 1 строку. Сотрудники, не подходящие под условия, не изменяются. После `ROLLBACK` данные снова исходные.

### Вывод

`UPDATE` изменяет только строки, указанные в `WHERE`. `SELECT` до и после помогает проверить результат. `ROLLBACK` сохраняет исходные тестовые данные.

## Task 17 — DELETE: удаление данных

### SQL

```sql
USE PracticeDB;
GO

-- Пробуем удалить записи, не сохраняя изменения в учебной базе.
BEGIN TRANSACTION;

-- 1. Удалить назначения с нулевым количеством часов (если есть).
SELECT COUNT(*) AS AssignmentsBefore
FROM EmployeeProjects;
SELECT COUNT(*) AS ZeroHoursBefore
FROM EmployeeProjects
WHERE Hours = 0;

DELETE FROM EmployeeProjects
WHERE Hours = 0;

SELECT COUNT(*) AS AssignmentsAfter
FROM EmployeeProjects;

-- 2. Удалить сотрудника №8, предварительно удалив его назначения.
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE EmployeeId = 8;
SELECT COUNT(*) AS EmployeeAssignmentsBefore
FROM EmployeeProjects
WHERE EmployeeId = 8;

DELETE FROM EmployeeProjects
WHERE EmployeeId = 8;

SELECT COUNT(*) AS AssignmentsAfterEmployeeCleanup
FROM EmployeeProjects;

SELECT COUNT(*) AS EmployeesBefore
FROM Employees;

DELETE FROM Employees
WHERE EmployeeId = 8;

SELECT COUNT(*) AS EmployeesAfter
FROM Employees;

-- 3. DELETE без WHERE только на тестовой копии.
SELECT EmployeeId, EmployeeName
INTO #EmployeesCopy
FROM Employees;

SELECT COUNT(*) AS CopyBefore
FROM #EmployeesCopy;

DELETE FROM #EmployeesCopy;

SELECT COUNT(*) AS CopyAfter
FROM #EmployeesCopy;

DROP TABLE #EmployeesCopy;

-- Отменяем удаления из основных таблиц.
ROLLBACK TRANSACTION;

SELECT COUNT(*) AS EmployeesRestored
FROM Employees;
SELECT COUNT(*) AS AssignmentsRestored
FROM EmployeeProjects;
```

### Результат

На данных `init.sql` ожидаются следующие количества:

| Действие | До | После |
| --- | ---: | ---: |
| Удаление назначений с `Hours = 0` | 14 | 14 |
| Удаление назначений сотрудника №8 | 14 | 13 |
| Удаление сотрудника №8 | 10 | 9 |
| `DELETE` без `WHERE` на копии | 9 | 0 |
| После `ROLLBACK`: сотрудники | 10 | 10 |
| После `ROLLBACK`: назначения | 14 | 14 |

В исходных данных нет назначений с нулевыми часами, поэтому первое удаление не затрагивает строки. У Сергея Морозова (`EmployeeId = 8`) есть одно назначение на проект и нет подчинённых, поэтому его можно удалить после удаления назначения.

### Вывод

`DELETE ... WHERE` удаляет только подходящие строки, а без `WHERE` — все строки в таблице. Перед удалением сотрудника нужно учитывать внешние ключи. `ROLLBACK` отменяет изменения после демонстрации.

## Task 18 — Транзакции: COMMIT и ROLLBACK

### SQL

```sql
USE PracticeDB;
GO

-- Пример 1. Отмена изменения.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;

BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary + 1000
WHERE EmployeeId = 1;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;

ROLLBACK TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;

-- Пример 2. Сохранение изменения.
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;

BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary + 1000
WHERE EmployeeId = 1;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;

COMMIT TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE EmployeeId = 1;
```

### Результат

При запуске после `init.sql` зарплата Анны Ивановой (`EmployeeId = 1`) меняется так:

| Проверка | Зарплата |
| --- | ---: |
| До первой транзакции | 65000.00 |
| Внутри первой транзакции | 66000.00 |
| После `ROLLBACK` | 65000.00 |
| Внутри второй транзакции | 66000.00 |
| После `COMMIT` | 66000.00 |

**Важно:** `COMMIT` сохраняет изменение в базе. Чтобы снова получить исходные тестовые данные, нужно повторно выполнить `init.sql` (он пересоздаёт всю `PracticeDB`). При повторном запуске задания без восстановления базы зарплата увеличится ещё на 1000.

### Вывод

`ROLLBACK` отменяет изменение зарплаты, а `COMMIT` сохраняет его. `SELECT` показывает значения до, внутри и после транзакции.

## Task 19 — VIEW: представление сотрудников и проектов

### SQL

```sql
USE PracticeDB;
GO

-- Если представление уже есть, удаляем его перед созданием.
IF OBJECT_ID(N'dbo.vw_EmployeeDetails', N'V') IS NOT NULL
    DROP VIEW dbo.vw_EmployeeDetails;
GO

-- CREATE VIEW выполняется отдельным пакетом команд.
CREATE VIEW dbo.vw_EmployeeDetails
AS
SELECT
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId;
GO

SELECT *
FROM dbo.vw_EmployeeDetails
ORDER BY DepartmentName, EmployeeName, ProjectName;
GO

DROP VIEW dbo.vw_EmployeeDetails;
GO

-- После удаления представления OBJECT_ID вернёт NULL.
SELECT OBJECT_ID(N'dbo.vw_EmployeeDetails', N'V') AS ViewAfterDrop;
```

### Результат

После создания `vw_EmployeeDetails` на исходных тестовых данных ожидается **14 строк** (по числу назначений сотрудников на проекты).

Примеры строк:

| EmployeeName | DepartmentName | ProjectName | Hours |
| --- | --- | --- | ---: |
| Дмитрий Орлов | Аналитика | AI Assistant | 50 |
| Елена Волкова | Аналитика | Mobile App | 95 |
| Алексей Лебедев | Менеджмент | CRM System | 30 |
| Анна Иванова | Разработка | Data Warehouse | 80 |

После выполнения `DROP VIEW` запрос с `OBJECT_ID` возвращает `NULL`. Само представление удаляется, а исходные таблицы и их данные остаются.

### Вывод

`VIEW` позволяет сохранить запрос к связанным таблицам и обращаться к нему как к таблице. `DROP VIEW` удаляет только представление.

## Task 20 — Индексы: создание и анализ

### SQL

В SSMS включить план выполнения (Ctrl+M), затем запустить запросы ниже.
`SET STATISTICS IO ON` покажет `logical reads` на вкладке «Сообщения».

```sql
USE PracticeDB;
GO

-- Удаляем индексы из предыдущих запусков, чтобы сравнить с исходным состоянием.
DROP INDEX IF EXISTS IX_Employees_DepartmentId ON Employees;
DROP INDEX IF EXISTS IX_Employees_Salary ON Employees;
GO

-- До создания индексов.
SET STATISTICS IO ON;
GO
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;
GO
SET STATISTICS IO OFF;
GO

-- Получить текст плана ДО индексов.
SET SHOWPLAN_TEXT ON;
GO
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;
GO
SET SHOWPLAN_TEXT OFF;
GO

-- Индексы на отдел и зарплату.
CREATE INDEX IX_Employees_DepartmentId ON Employees(DepartmentId);
CREATE INDEX IX_Employees_Salary ON Employees(Salary);
GO

-- После создания индексов: тот же запрос.
SET STATISTICS IO ON;
GO
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;
GO
SET STATISTICS IO OFF;
GO

-- Получить текст плана ПОСЛЕ создания индексов.
SET SHOWPLAN_TEXT ON;
GO
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;
GO
SET SHOWPLAN_TEXT OFF;
GO

-- Проверить, что оба индекса созданы.
SELECT name
FROM sys.indexes
WHERE object_id = OBJECT_ID('dbo.Employees')
  AND name IN ('IX_Employees_DepartmentId', 'IX_Employees_Salary')
ORDER BY name;
```

### Результат

Оба запроса до и после индексов должны вернуть одинаковые строки (если перед запуском выполнен `init.sql`):

| EmployeeId | EmployeeName | Salary |
| ---: | --- | ---: |
| 1 | Анна Иванова | 65000.00 |
| 2 | Пётр Сидоров | 72000.00 |
| 3 | Мария Кузнецова | 55000.00 |

После `CREATE INDEX` ожидаются два индекса: `IX_Employees_DepartmentId` и `IX_Employees_Salary`.

**Сравнение планов и logical reads (заполнить выводом SSMS):**

| Измерение | До индексов | После индексов |
| --- | --- | --- |
| Оператор плана | Вывод `SHOWPLAN_TEXT` | Вывод `SHOWPLAN_TEXT` |
| `logical reads` | Из сообщений `STATISTICS IO` | Из сообщений `STATISTICS IO` |

На учебной таблице всего 10 сотрудников, поэтому SQL Server может выбрать сканирование таблицы даже после создания индексов. Отличие плана и уменьшение `logical reads` нельзя гарантировать: они зависят от оптимизатора и количества данных. Точные значения нужно перенести из SSMS.

### Вывод

Индекс помогает находить записи по столбцу, но на очень маленькой таблице может не использоваться. `SHOWPLAN_TEXT` показывает выбранный план, а `STATISTICS IO` — число логических чтений.

## Task 21 — Хранимые процедуры

### SQL

```sql
USE PracticeDB;
GO

-- Первая процедура: сотрудники выбранного отдела.
CREATE OR ALTER PROCEDURE dbo.sp_GetEmployeesByDepartment
    @DeptId INT
AS
BEGIN
    SELECT EmployeeId, EmployeeName, Salary
    FROM Employees
    WHERE DepartmentId = @DeptId
    ORDER BY EmployeeId;
END;
GO

EXEC dbo.sp_GetEmployeesByDepartment @DeptId = 1;
GO

-- Вторая процедура: средняя зарплата через OUTPUT-параметр.
CREATE OR ALTER PROCEDURE dbo.sp_GetAverageSalaryByDepartment
    @DeptId INT,
    @AvgSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @AvgSalary = AVG(Salary)
    FROM Employees
    WHERE DepartmentId = @DeptId;
END;
GO

DECLARE @Result DECIMAL(10,2);

EXEC dbo.sp_GetAverageSalaryByDepartment
    @DeptId = 1,
    @AvgSalary = @Result OUTPUT;

SELECT @Result AS AverageSalary;
GO

-- Проверка отдела, в котором нет сотрудников.
DECLARE @EmptyResult DECIMAL(10,2);

EXEC dbo.sp_GetAverageSalaryByDepartment
    @DeptId = 99,
    @AvgSalary = @EmptyResult OUTPUT;

SELECT @EmptyResult AS AverageSalary;
GO
```

### Результат

После выполнения `init.sql` первая процедура с `@DeptId = 1` возвращает четырёх сотрудников:

| EmployeeId | EmployeeName | Salary |
| ---: | --- | ---: |
| 1 | Анна Иванова | 65000.00 |
| 2 | Пётр Сидоров | 72000.00 |
| 3 | Мария Кузнецова | 55000.00 |
| 4 | Иван Петров | 48000.00 |

Вторая процедура возвращает `AverageSalary = 60000.00`. Для отдела №99 без сотрудников результатом будет `NULL`.

### Вывод

Хранимая процедура выполняет сохранённый запрос и принимает параметры. Параметр `OUTPUT` позволяет вернуть вычисленное значение после выполнения процедуры.
