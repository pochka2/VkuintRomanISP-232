using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 34. LINQ: группы слов.</summary>
public class Task34_WordGroups : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "LINQ: группы слов";
    /// <summary>Описание задания.</summary>
    public string Description => "Сгруппировать слова по первой букве.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "10+ слов",
        "GroupBy(w => w[0])",
        "Сортировка групп и слов",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Сначала отсортируй группы, затем слова в них.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        string[] words = { "арбуз", "банан", "апельсин", "вишня", "ананас",
            "груша", "виноград", "брусника", "дыня", "гранат", "ежевика", "дынька" };
        var groups = words.GroupBy(w => w[0]).OrderBy(g => g.Key);
        foreach (var group in groups)
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.OrderBy(w => w))}");
    }
}
