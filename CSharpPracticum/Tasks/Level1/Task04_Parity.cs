using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 4. Чётность числа.</summary>
public class Task04_Parity : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Чётность числа";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить число двумя способами.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "% 2 == 0",
        "Тернарный оператор",
        "Два отдельных метода",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Оба метода должны вернуть результат.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int number = ConsoleHelper.ReadInt("Число: ");
        Console.WriteLine("Через остаток: " + CheckByRemainder(number));
        Console.WriteLine("Через ?: " + CheckByTernary(number));
    }

    private static bool CheckByRemainder(int number)
    {
        return number % 2 == 0;
    }

    private static string CheckByTernary(int number)
    {
        return number % 2 == 0 ? "Чётное" : "Нечётное";
    }
}
