using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 37. Фибоначчи с мемоизацией.</summary>
public class Task37_Fibonacci : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Фибоначчи с мемоизацией";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить обычную рекурсию и Dictionary.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Обычная рекурсия и Dictionary<int, long>",
        "Замер времени для N от 30 до 35",
        "Вывести оба времени и разницу",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Результаты совпадают, мемоизация быстрее.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Сохраняй уже вычисленные числа в Dictionary.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int n = 35;
        Stopwatch watch = Stopwatch.StartNew();
        long first = Fibonacci(n);
        watch.Stop();
        long firstTime = watch.ElapsedTicks;

        watch.Restart();
        long second = FibonacciMemo(n, new Dictionary<int, long>());
        watch.Stop();
        long secondTime = watch.ElapsedTicks;

        Console.WriteLine("Число Фибоначчи: " + first);
        Console.WriteLine("Обычная рекурсия: " + firstTime + " тиков");
        Console.WriteLine("С Dictionary: " + secondTime + " тиков");
        Console.WriteLine("Разница: " + (firstTime - secondTime) + " тиков");
        Console.WriteLine("Результаты совпадают: " + (first == second));
    }

    private static long Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    private static long FibonacciMemo(int n, Dictionary<int, long> cache)
    {
        if (n <= 1) return n;
        if (cache.TryGetValue(n, out long result)) return result;

        result = FibonacciMemo(n - 1, cache) + FibonacciMemo(n - 2, cache);
        cache[n] = result;
        return result;
    }
}
