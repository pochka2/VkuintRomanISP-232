using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 36. Дубликаты в списке.</summary>
public class Task36_Duplicates : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Дубликаты в списке";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти повторяющиеся числа двумя способами.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "HashSet<int> и Contains",
        "GroupBy и Where",
        "Два отдельных метода",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Оба способа находят одинаковые дубликаты.";
    /// <summary>Подсказка.</summary>
    public string Hint => "HashSet помогает запоминать встреченные числа.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 1, 5, 3, 2 };
        List<int> first = FindByHashSet(numbers);
        List<int> second = FindByGroupBy(numbers);

        Console.WriteLine("Список: " + string.Join(", ", numbers));
        Console.WriteLine("HashSet: " + string.Join(", ", first));
        Console.WriteLine("GroupBy: " + string.Join(", ", second));
        Console.WriteLine("Совпадают: " + first.SequenceEqual(second));
    }

    private static List<int> FindByHashSet(List<int> numbers)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> duplicates = new HashSet<int>();

        foreach (int number in numbers)
        {
            if (seen.Contains(number))
                duplicates.Add(number);
            else
                seen.Add(number);
        }

        return duplicates.OrderBy(x => x).ToList();
    }

    private static List<int> FindByGroupBy(List<int> numbers)
    {
        return numbers.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .OrderBy(x => x).ToList();
    }
}
