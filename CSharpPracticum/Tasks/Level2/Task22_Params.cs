using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 22. params и перегрузка.</summary>
public class Task22_Params : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "params и перегрузка";
    /// <summary>Описание задания.</summary>
    public string Description => "Суммировать произвольное количество чисел.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Sum(params int[])",
        "Перегрузка для списка чисел",
        "Пустой вызов равен нулю",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Сумма верная для чисел, массива и пустого вызова.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Проверь сумму чисел, массива и пустой вызов.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Аргументы: " + Sum(1, 2, 3));
        Console.WriteLine("Массив: " + Sum(new[] { 1, 2, 3 }));
        Console.WriteLine("Список: " + Sum(new List<int> { 1, 2, 3 }));
        Console.WriteLine("Пусто: " + Sum());
    }

    private static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers) sum += number;
        return sum;
    }

    private static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers) sum += number;
        return sum;
    }
}
