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
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            if (choice == "0" || choice == null)
                return;

            if (choice == "1")
                await ShowEmployees();
            else
                Console.WriteLine("Нет такого пункта.");
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
    }
}
