using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 16. Методы расширения string.</summary>
public class Task16_StringMethods : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Методы расширения string";
    /// <summary>Описание задания.</summary>
    public string Description => "Добавить три метода для строк.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Статический класс StringExtensions",
        "IsPalindrome, WordCount, ReverseString",
        "Примеры на нескольких строках",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Три метода работают для нескольких строк.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Первый параметр метода расширения пишется this string.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        string[] examples = { "А роза упала на лапу Азора", "Привет мир", "abc" };
        foreach (string text in examples)
        {
            Console.WriteLine("Строка: " + text);
            Console.WriteLine("Палиндром: " + text.IsPalindrome());
            Console.WriteLine("Слов: " + text.WordCount());
            Console.WriteLine("Наоборот: " + text.ReverseString());
        }
    }
}


/// <summary>Методы расширения для строк.</summary>
public static class StringExtensions
{
    /// <summary>Проверяет, является ли строка палиндромом.</summary>
    public static bool IsPalindrome(this string text)
    {
        if (text == null) return false;
        string clean = "";
        foreach (char c in text.ToLower())
            if (char.IsLetterOrDigit(c)) clean += c;
        for (int i = 0; i < clean.Length / 2; i++)
            if (clean[i] != clean[clean.Length - i - 1]) return false;
        return true;
    }

    /// <summary>Подсчитывает слова в строке.</summary>
    public static int WordCount(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        string clean = "";
        foreach (char c in text)
            clean += char.IsLetterOrDigit(c) ? c : ' ';
        return clean.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>Переворачивает строку.</summary>
    public static string ReverseString(this string text)
    {
        if (text == null) return "";
        string result = "";
        for (int i = text.Length - 1; i >= 0; i--) result += text[i];
        return result;
    }
}
