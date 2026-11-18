using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static string connectionString = "";

    private static async Task Main()
    {
        connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION") ?? "";
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            Console.WriteLine("Не задана переменная PRACTICE_DB_CONNECTION.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\n=== PracticeDB ===");
            Console.WriteLine("1. Список сотрудников (задание 28)");
            Console.WriteLine("2. Добавить сотрудника (задание 29)");
            Console.WriteLine("3. Отчёт по отделам (задание 30)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            if (choice == "0" || choice == null)
                return;

            if (choice == "1")
            {
                await ShowEmployees();
            }
            else if (choice == "2")
            {
                Console.Write("Имя: ");
                string name = (Console.ReadLine() ?? "").Trim();

                Console.Write("Зарплата: ");
                string salaryText = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
                if (!decimal.TryParse(salaryText, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal salary))
                {
                    Console.WriteLine("Некорректная зарплата.");
                    continue;
                }

                Console.Write("Номер отдела: ");
                if (!int.TryParse(Console.ReadLine(), out int departmentId))
                {
                    Console.WriteLine("Некорректный номер отдела.");
                    continue;
                }

                await AddEmployee(name, salary, departmentId);
            }
            else if (choice == "3")
            {
                await ShowDepartmentReport();
            }
            else
            {
                Console.WriteLine("Нет такого пункта.");
            }
        }
    }

    private static async Task ShowEmployees()
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "SELECT EmployeeName, Salary FROM Employees ORDER BY EmployeeId", connection);
            using var reader = await command.ExecuteReaderAsync();

            bool found = false;
            while (await reader.ReadAsync())
            {
                found = true;
                Console.WriteLine($"{reader.GetString(0)} — {reader.GetDecimal(1):F2}");
            }

            if (!found)
                Console.WriteLine("Сотрудников нет.");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Ошибка SQL: " + ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            Console.WriteLine("Ошибка подключения: " + ex.Message);
        }
    }

    private static async Task AddEmployee(string name, decimal salary, int departmentId)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 100)
        {
            Console.WriteLine("Имя должно содержать от 1 до 100 символов.");
            return;
        }
        if (salary <= 0 || salary >= 100000000m || decimal.Round(salary, 2) != salary)
        {
            Console.WriteLine("Некорректная сумма зарплаты.");
            return;
        }
        if (departmentId <= 0)
        {
            Console.WriteLine("Некорректный номер отдела.");
            return;
        }

        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // В учебной базе имя не уникально, поэтому проверяем повтор сами.
            using (var check = new SqlCommand(
                "SELECT COUNT(*) FROM Employees WHERE EmployeeName = @name", connection))
            {
                check.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                int count = Convert.ToInt32(await check.ExecuteScalarAsync());
                if (count > 0)
                {
                    Console.WriteLine("Сотрудник с таким именем уже есть.");
                    return;
                }
            }

            int employeeId;
            using (var insert = new SqlCommand(@"
                INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId)
                OUTPUT INSERTED.EmployeeId
                VALUES (@name, @salary, CAST(GETDATE() AS DATE), @deptId)", connection))
            {
                insert.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                var salaryParam = insert.Parameters.Add("@salary", SqlDbType.Decimal);
                salaryParam.Precision = 10;
                salaryParam.Scale = 2;
                salaryParam.Value = salary;
                insert.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;

                employeeId = Convert.ToInt32(await insert.ExecuteScalarAsync());
            }

            using var verify = new SqlCommand(@"
                SELECT EmployeeId, EmployeeName, Salary, DepartmentId
                FROM Employees
                WHERE EmployeeId = @id", connection);
            verify.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;

            using var reader = await verify.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                Console.WriteLine("Добавлен сотрудник:");
                Console.WriteLine($"ID: {reader.GetInt32(0)}");
                Console.WriteLine($"Имя: {reader.GetString(1)}");
                Console.WriteLine($"Зарплата: {reader.GetDecimal(2):F2}");
                Console.WriteLine($"Отдел: {reader.GetInt32(3)}");
            }
        }
        catch (SqlException ex) when (ex.Number == 547)
        {
            Console.WriteLine("Ошибка: такого отдела нет.");
        }
        catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
        {
            Console.WriteLine("Ошибка: дубликат записи.");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Ошибка SQL: " + ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            Console.WriteLine("Ошибка подключения: " + ex.Message);
        }
    }

    private static async Task ShowDepartmentReport()
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(@"
                SELECT d.DepartmentName,
                       COUNT(e.EmployeeId) AS EmpCount,
                       AVG(e.Salary) AS AvgSalary
                FROM Departments d
                LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId
                GROUP BY d.DepartmentId, d.DepartmentName
                ORDER BY d.DepartmentName, d.DepartmentId", connection);
            using var reader = await command.ExecuteReaderAsync();

            Console.WriteLine(string.Format("{0,-20} | {1,12} | {2,16}",
                "Отдел", "Сотрудников", "Средняя зарплата"));
            Console.WriteLine(new string('-', 55));

            bool found = false;
            while (await reader.ReadAsync())
            {
                found = true;
                string department = reader.GetString(0);
                int count = reader.GetInt32(1);
                string average = reader.IsDBNull(2) ? "N/A" : reader.GetDecimal(2).ToString("F2");

                Console.WriteLine(string.Format("{0,-20} | {1,12} | {2,16}",
                    department, count, average));
            }

            if (!found)
                Console.WriteLine("Отделов нет.");
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Ошибка SQL: " + ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            Console.WriteLine("Ошибка подключения: " + ex.Message);
        }
    }

}
