using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 18. TryParse и try/catch.</summary>
public class Task18_Parsing : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "TryParse и try/catch";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить способы преобразования строки в число.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "TryParse с out",
        "Parse с FormatException",
        "Проверить число и abc",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Оба способа обрабатывают 123 и abc.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Каждый способ в отдельном методе.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        foreach (string text in new[] { "123", "abc" })
        {
            Console.WriteLine("Ввод: " + text);
            Console.WriteLine($"TryParse: {TryMethod(text, out int a)}, значение {a}");
            Console.WriteLine($"try/catch: {CatchMethod(text, out int b)}, значение {b}");
        }
    }

    private static bool TryMethod(string text, out int number)
    {
        return int.TryParse(text, out number);
    }

    private static bool CatchMethod(string text, out int number)
    {
        try
        {
            number = int.Parse(text);
            return true;
        }
        catch (FormatException)
        {
            number = 0;
            return false;
        }
    }
}
