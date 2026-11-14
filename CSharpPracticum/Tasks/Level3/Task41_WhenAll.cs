using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 41. Task.WhenAll.</summary>
public class Task41_WhenAll : IAsyncTask
{
    /// <summary>Название задания.</summary>
    public string Title => "Task.WhenAll";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить последовательный и параллельный запуск задач.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "10 задач с Task.Delay(500)",
        "Последовательный await и Task.WhenAll",
        "Stopwatch и сравнение результатов",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Результаты совпадают, параллельный запуск быстрее.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Task.WhenAll ждёт все задачи одновременно.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    /// <summary>Запускает задание асинхронно.</summary>
    public async Task RunAsync()
    {
        Stopwatch watch = Stopwatch.StartNew();
        List<int> first = new List<int>();

        for (int i = 1; i <= 10; i++)
            first.Add(await WorkAsync(i));

        watch.Stop();
        long firstTime = watch.ElapsedMilliseconds;

        watch.Restart();
        Task<int>[] tasks = new Task<int>[10];
        for (int i = 0; i < 10; i++)
            tasks[i] = WorkAsync(i + 1);

        int[] second = await Task.WhenAll(tasks);
        watch.Stop();
        long secondTime = watch.ElapsedMilliseconds;

        Console.WriteLine("Последовательно: " + firstTime + " мс");
        Console.WriteLine("Параллельно: " + secondTime + " мс");
        Console.WriteLine("Результаты совпадают: " + first.SequenceEqual(second));

        // При параллельном запуске ожидания идут одновременно.
    }

    private static async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }
}
