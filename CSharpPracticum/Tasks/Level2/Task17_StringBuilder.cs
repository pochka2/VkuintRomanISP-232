using System.Text;
using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 17. StringBuilder и конкатенация.</summary>
public class Task17_StringBuilder : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "StringBuilder и конкатенация";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить время сборки длинной строки.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "10000 чисел двумя способами",
        "Stopwatch",
        "Сравнить результат и время",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Строки совпадают, время и разница выведены.";
    /// <summary>Подсказка.</summary>
    public string Hint => "StringBuilder не создаёт новую строку на каждом сложении.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Stopwatch watch = Stopwatch.StartNew();
        string first = "";
        for (int i = 0; i < 10000; i++) first += i.ToString();
        watch.Stop();
        long simpleTime = watch.ElapsedTicks;
        watch.Restart();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 10000; i++) builder.Append(i);
        string second = builder.ToString();
        watch.Stop();
        long builderTime = watch.ElapsedTicks;
        Console.WriteLine($"Через +: {simpleTime} тиков");
        Console.WriteLine($"StringBuilder: {builderTime} тиков");
        Console.WriteLine($"Разница: {simpleTime - builderTime} тиков");
        Console.WriteLine("Строки равны: " + (first == second));
        // При + каждый раз создаётся новая строка, поэтому StringBuilder обычно быстрее.
    }
}
