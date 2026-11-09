using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 33. LINQ: сотрудники.</summary>
public class Task33_Employees : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "LINQ: сотрудники";
    /// <summary>Описание задания.</summary>
    public string Description => "Выбрать лучших, среднюю зарплату и возраст.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "10+ сотрудников",
        "Top-3 по зарплате",
        "GroupBy и Average",
        "Where старше 30",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Выведены топ-3, средняя зарплата и фильтр по возрасту.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Здесь пригодятся OrderByDescending, Take и GroupBy.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Анна", 24, 65000, "IT"), new Employee("Иван", 35, 90000, "IT"),
            new Employee("Петр", 40, 72000, "HR"), new Employee("Оля", 28, 60000, "HR"),
            new Employee("Нина", 31, 80000, "IT"), new Employee("Дима", 22, 55000, "Продажи"),
            new Employee("Катя", 36, 95000, "Продажи"), new Employee("Макс", 43, 110000, "IT"),
            new Employee("Лена", 29, 70000, "Продажи"), new Employee("Саша", 33, 78000, "HR")
        };
        Console.WriteLine("Топ-3 зарплаты:");
        foreach (Employee e in employees.OrderByDescending(e => e.Salary).Take(3))
            Console.WriteLine($"{e.Name}: {e.Salary}");
        Console.WriteLine("Средняя по отделам:");
        foreach (var group in employees.GroupBy(e => e.Department))
            Console.WriteLine($"{group.Key}: {group.Average(e => e.Salary):F2}");
        Console.WriteLine("Старше 30:");
        foreach (Employee e in employees.Where(e => e.Age > 30))
            Console.WriteLine($"{e.Name}, {e.Age}");
    }

    private class Employee
    {
        /// <summary>Имя.</summary>
        public string Name { get; }
        /// <summary>Свойство.</summary>
        public int Age { get; }
        /// <summary>Свойство.</summary>
        public decimal Salary { get; }
        /// <summary>Свойство.</summary>
        public string Department { get; }
        /// <summary>Создаёт сотрудника.</summary>
        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }
    }
}
