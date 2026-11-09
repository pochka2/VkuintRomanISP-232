using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 12. Палиндром.</summary>
public class Task12_Palindrome : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Палиндром";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить слово или фразу.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Не учитывать регистр, пробелы и пунктуацию",
        "Без LINQ Reverse",
        "Пустая строка — палиндром",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Палиндром определяется без учёта регистра и пробелов.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Можно сравнивать символы с двух концов.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.Write("Текст: ");
        string input = Console.ReadLine() ?? "";
        string clean = "";
        foreach (char c in input.ToLower())
            if (char.IsLetterOrDigit(c)) clean += c;
        bool palindrome = true;
        for (int i = 0; i < clean.Length / 2; i++)
            if (clean[i] != clean[clean.Length - i - 1]) palindrome = false;
        Console.WriteLine(palindrome ? "Палиндром" : "Не палиндром");
    }
}
