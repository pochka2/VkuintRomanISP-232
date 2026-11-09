using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 13. Подсчёт слов.</summary>
public class Task13_WordCounter : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Подсчёт слов";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать повторения слов в тексте.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Dictionary<string, int>",
        "Убрать знаки пунктуации и регистр",
        "Отсортировать по частоте",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Раздели строку через Split и используй OrderByDescending.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.Write("Текст: ");
        string text = Console.ReadLine() ?? "";
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\t', '\n', '\r', '(', ')' };
        string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> counts = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (!counts.ContainsKey(word)) counts[word] = 0;
            counts[word]++;
        }
        foreach (var pair in counts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            Console.WriteLine($"{pair.Key} → {pair.Value}");
    }
}
