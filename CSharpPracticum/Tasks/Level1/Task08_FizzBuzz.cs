using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 8. FizzBuzz.</summary>
public class Task08_FizzBuzz : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "FizzBuzz";
    /// <summary>Описание задания.</summary>
    public string Description => "Числа от 1 до 100 с заменой кратных.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "15 -> FizzBuzz",
        "3 -> Fizz, 5 -> Buzz",
        "Сначала проверить 15",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Числа от 1 до 100 выведены с заменами.";
    /// <summary>Подсказка.</summary>
    public string Hint => "if / else if.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 15 == 0) Console.WriteLine("FizzBuzz");
            else if (i % 3 == 0) Console.WriteLine("Fizz");
            else if (i % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(i);
        }
    }
}
