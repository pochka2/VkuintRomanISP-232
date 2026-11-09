namespace CSharpPracticum.Common;

/// <summary>Простые методы для ввода с консоли.</summary>
public static class ConsoleHelper
{
    /// <summary>Читает целое число, пока ввод не станет правильным.</summary>
    public static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            Console.WriteLine("Введите целое число.");
        }
    }

    /// <summary>Читает вещественное число.</summary>
    public static double ReadDouble(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out double number))
                return number;
            Console.WriteLine("Введите число.");
        }
    }
}
