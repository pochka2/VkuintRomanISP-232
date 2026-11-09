using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 10. Пузырёк и вставки.</summary>
public class Task10_Sorting : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Пузырёк и вставки";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить два способа сортировки.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Два метода без Array.Sort и LINQ",
        "10 000 чисел",
        "Замер через Stopwatch",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Перед замерами сделай две копии массива.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Random random = new Random();
        int[] numbers = new int[10000];
        for (int i = 0; i < numbers.Length; i++) numbers[i] = random.Next(100000);
        int[] first = (int[])numbers.Clone();
        int[] second = (int[])numbers.Clone();
        Stopwatch watch = Stopwatch.StartNew();
        BubbleSort(first);
        watch.Stop();
        Console.WriteLine($"Пузырёк: {watch.ElapsedMilliseconds} мс");
        watch.Restart();
        InsertionSort(second);
        watch.Stop();
        Console.WriteLine($"Вставки: {watch.ElapsedMilliseconds} мс");
        bool equal = true;
        for (int i = 0; i < first.Length; i++)
            if (first[i] != second[i]) equal = false;
        Console.WriteLine("Результаты совпадают: " + equal);
    }

    private static void BubbleSort(int[] values)
    {
        for (int i = 0; i < values.Length - 1; i++)
            for (int j = 0; j < values.Length - 1 - i; j++)
                if (values[j] > values[j + 1])
                    (values[j], values[j + 1]) = (values[j + 1], values[j]);
    }

    private static void InsertionSort(int[] values)
    {
        for (int i = 1; i < values.Length; i++)
        {
            int current = values[i];
            int j = i - 1;
            while (j >= 0 && values[j] > current)
            {
                values[j + 1] = values[j];
                j--;
            }
            values[j + 1] = current;
        }
    }
}
