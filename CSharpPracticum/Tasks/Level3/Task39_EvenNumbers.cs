using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 39. Генератор чётных чисел.</summary>
public class Task39_EvenNumbers : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Генератор чётных чисел";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести чётные числа через yield return.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IEnumerable<int> и yield return",
        "Без промежуточного списка",
        "Показать ленивое выполнение",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Чётные числа выводятся по одному.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Код внутри генератора выполняется при foreach.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        foreach (int number in GetEvenNumbers(10))
            Console.WriteLine("Получено: " + number);
    }

    private static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 2; i <= max; i += 2)
        {
            Console.WriteLine("Генератор: " + i);
            yield return i;
        }
    }
}
