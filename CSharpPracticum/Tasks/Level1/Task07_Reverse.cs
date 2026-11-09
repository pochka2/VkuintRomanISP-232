using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 7. Реверс строки.</summary>
public class Task07_Reverse : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Реверс строки";
    /// <summary>Описание задания.</summary>
    public string Description => "Напечатать строку задом наперёд.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Без LINQ и Array.Reverse",
        "Цикл for с конца",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Можно добавлять символы в результат по одному.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.Write("Строка: ");
        string text = Console.ReadLine() ?? "";
        string result = "";
        for (int i = text.Length - 1; i >= 0; i--)
            result += text[i];
        Console.WriteLine("Результат: " + result);
    }
}
