using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 5. Таблица умножения.</summary>
public class Task05_Multiplication : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Таблица умножения";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести таблицу умножения 10 на 10.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Два вложенных for",
        "Ровные столбцы",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Напечатана ровная таблица 10 на 10.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для выравнивания пригодится {число,4}.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
                Console.Write($"{i * j,4}");
            Console.WriteLine();
        }
    }
}
