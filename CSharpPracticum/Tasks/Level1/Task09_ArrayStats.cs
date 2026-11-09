using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 9. Массив: min/max/sum/avg.</summary>
public class Task09_ArrayStats : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Массив: min/max/sum/avg";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти характеристики массива.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Четыре отдельных метода",
        "Без LINQ",
        "Пустой массив не должен ломать программу",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Найдены минимум, максимум, сумма и среднее.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Начни min и max с первого элемента массива.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Random random = new Random();
        int[] numbers = new int[20];
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = random.Next(1, 101);
        Console.WriteLine("Массив: " + string.Join(", ", numbers));
        Console.WriteLine("Мин: " + Min(numbers));
        Console.WriteLine("Макс: " + Max(numbers));
        Console.WriteLine("Сумма: " + Sum(numbers));
        Console.WriteLine("Среднее: " + Average(numbers));
    }

    private static int Min(int[] values)
    {
        if (values.Length == 0) return 0;
        int min = values[0];
        foreach (int value in values)
            if (value < min) min = value;
        return min;
    }

    private static int Max(int[] values)
    {
        if (values.Length == 0) return 0;
        int max = values[0];
        foreach (int value in values)
            if (value > max) max = value;
        return max;
    }

    private static long Sum(int[] values)
    {
        long sum = 0;
        foreach (int value in values) sum += value;
        return sum;
    }

    private static double Average(int[] values)
    {
        if (values.Length == 0) return 0;
        return (double)Sum(values) / values.Length;
    }
}
