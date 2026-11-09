using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 11. Диагональ матрицы.</summary>
public class Task11_Matrix : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Диагональ матрицы";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать сумму главной диагонали.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "N не меньше 2",
        "Случайные значения",
        "Сумма диагонали в одном for",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Выведена матрица и сумма её диагонали.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Суммируй matrix[i, i].";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int size = ConsoleHelper.ReadInt("Размер N (от 2): ");
        if (size < 2)
        {
            Console.WriteLine("Размер должен быть не меньше 2.");
            return;
        }
        int[,] matrix = new int[size, size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(1, 10);
                Console.Write($"{matrix[i, j],3}");
                if (j == size - 1) Console.WriteLine();
            }
        int sum = 0;
        for (int i = 0; i < size; i++) sum += matrix[i, i];
        Console.WriteLine("Сумма диагонали: " + sum);
    }
}
