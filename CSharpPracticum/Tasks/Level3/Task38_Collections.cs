using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 38. List и LinkedList.</summary>
public class Task38_Collections : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "List и LinkedList";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить вставку элементов в середину коллекций.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "100000 элементов в каждой коллекции",
        "1000 вставок в середину",
        "Замер времени через Stopwatch",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Выведено время вставки для обеих коллекций.";
    /// <summary>Подсказка.</summary>
    public string Hint => "У LinkedList можно вставлять после найденного узла.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<int> list = new List<int>();
        LinkedList<int> linked = new LinkedList<int>();

        for (int i = 0; i < 100000; i++)
        {
            list.Add(i);
            linked.AddLast(i);
        }

        LinkedListNode<int> middle = linked.First;
        for (int i = 0; i < 49999; i++)
            middle = middle.Next;

        Stopwatch watch = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
            list.Insert(50000 + i, i);
        watch.Stop();
        long listTime = watch.ElapsedTicks;

        watch.Restart();
        for (int i = 0; i < 1000; i++)
            middle = linked.AddAfter(middle, i);
        watch.Stop();
        long linkedTime = watch.ElapsedTicks;

        Console.WriteLine("List: " + listTime + " тиков");
        Console.WriteLine("LinkedList: " + linkedTime + " тиков");
        Console.WriteLine("Разница: " + (listTime - linkedTime) + " тиков");
        Console.WriteLine("Результаты совпадают: " + list.SequenceEqual(linked));

        // List сдвигает элементы при вставке.
        // LinkedList вставляет быстрее, если нужный узел уже найден,
        // но искать элемент по индексу в LinkedList медленнее.
    }
}
