using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 20. Обобщённые методы.</summary>
public class Task20_Generics : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Обобщённые методы";
    /// <summary>Описание задания.</summary>
    public string Description => "Поменять значения и найти большее у разных типов.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Swap<T>(ref T, ref T)",
        "Max<T> с IComparable<T>",
        "Примеры int, string, double",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Для Max можно вызвать CompareTo.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int a = 3, b = 7;
        Swap(ref a, ref b);
        Console.WriteLine($"int: {a}, {b}, max = {Max(a, b)}");
        string s1 = "яблоко", s2 = "банан";
        Swap(ref s1, ref s2);
        Console.WriteLine($"string: {s1}, {s2}, max = {Max(s1, s2)}");
        double x = 2.5, y = 8.4;
        Swap(ref x, ref y);
        Console.WriteLine($"double: {x}, {y}, max = {Max(x, y)}");
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        (a, b) = (b, a);
    }

    private static T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) >= 0 ? a : b;
    }
}
