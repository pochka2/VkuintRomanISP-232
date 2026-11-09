using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 2. Примитивные типы.</summary>
public class Task02_Primitives : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Примитивные типы";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести значения и названия типов переменных.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "int, long, double, float, decimal, bool, char, string",
        "GetType().Name",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Показаны значения всех типов и их названия.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для float пишем f, для decimal — m.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int a = 12;
        long b = 120000L;
        double c = 3.14;
        float d = 2.5f;
        decimal e = 100.25m;
        bool f = true;
        char g = 'А';
        string h = "Привет";
        Console.WriteLine($"int = {a} ({a.GetType().Name})");
        Console.WriteLine($"long = {b} ({b.GetType().Name})");
        Console.WriteLine($"double = {c} ({c.GetType().Name})");
        Console.WriteLine($"float = {d} ({d.GetType().Name})");
        Console.WriteLine($"decimal = {e} ({e.GetType().Name})");
        Console.WriteLine($"bool = {f} ({f.GetType().Name})");
        Console.WriteLine($"char = {g} ({g.GetType().Name})");
        Console.WriteLine($"string = {h} ({h.GetType().Name})");
    }
}
