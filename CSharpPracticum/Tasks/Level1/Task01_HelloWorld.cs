using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 1. Hello, World + дата.</summary>
public class Task01_HelloWorld : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Hello, World + дата";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести приветствие и сегодняшнюю дату.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Console.WriteLine, DateTime.Now",
        "Формат даты dd.MM.yyyy",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Используй DateTime.Now.ToString(\"dd.MM.yyyy\").";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Привет, мир!");
        Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
    }
}
