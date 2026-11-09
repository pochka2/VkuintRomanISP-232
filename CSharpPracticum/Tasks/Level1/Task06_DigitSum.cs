using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 6. Сумма цифр.</summary>
public class Task06_DigitSum : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Сумма цифр";
    /// <summary>Описание задания.</summary>
    public string Description => "Сложить цифры числа двумя способами.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Строка с int.Parse",
        "Арифметика через while",
        "Отрицательные числа по модулю",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Оба способа дают одинаковую сумму цифр.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для int.MinValue безопаснее сначала перевести число в long.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        int number = ConsoleHelper.ReadInt("Число: ");
        int[] tests = { number, 1234, -582, 0 };
        foreach (int value in tests)
            Console.WriteLine($"{value}: строка = {ByString(value)}, арифметика = {ByMath(value)}");
    }

    private static int ByString(int number)
    {
        string text = Math.Abs((long)number).ToString();
        int sum = 0;
        foreach (char digit in text)
            sum += int.Parse(digit.ToString());
        return sum;
    }

    private static int ByMath(int number)
    {
        long value = Math.Abs((long)number);
        int sum = 0;
        while (value > 0)
        {
            sum += (int)(value % 10);
            value /= 10;
        }
        return sum;
    }
}
