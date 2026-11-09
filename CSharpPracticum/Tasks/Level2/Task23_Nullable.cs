using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 23. Nullable и операторы.</summary>
public class Task23_Nullable : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Nullable и операторы";
    /// <summary>Описание задания.</summary>
    public string Description => "Показать работу null, ?? и ?..";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "FindValue возвращает int?",
        "??, ?., HasValue и Value",
        "Найденный и отсутствующий ключ",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Значение Value читаем только после проверки HasValue.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        foreach (string key in new[] { "one", "missing" })
        {
            int? value = FindValue(key);
            Console.WriteLine($"{key}: {value ?? -1}");
            if (value.HasValue) Console.WriteLine("Через Value: " + value.Value);
            else Console.WriteLine("Значение не найдено.");
        }
        Person person = null;
        Console.WriteLine("Имя: " + (person?.Name ?? "нет имени"));
        person = new Person { Name = "Олег" };
        Console.WriteLine("Имя: " + (person?.Name ?? "нет имени"));
    }

    private static int? FindValue(string key)
    {
        Dictionary<string, int> values = new Dictionary<string, int> { ["one"] = 1 };
        return values.TryGetValue(key, out int number) ? number : null;
    }

    private class Person
    {
        public string Name { get; set; }
    }
}
