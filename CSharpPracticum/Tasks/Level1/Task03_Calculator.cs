using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 3. Калькулятор.</summary>
public class Task03_Calculator : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Калькулятор";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать два числа с выбранным оператором.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Операции + - * / через switch",
        "Обработать деление на ноль и неверный ввод",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Все четыре действия работают, деление на ноль обработано.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Используй switch и TryParse.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        double a = ConsoleHelper.ReadDouble("Первое число: ");
        double b = ConsoleHelper.ReadDouble("Второе число: ");
        Console.Write("Операция (+ - * /): ");
        string operation = Console.ReadLine();
        switch (operation)
        {
            case "+": Console.WriteLine(a + b); break;
            case "-": Console.WriteLine(a - b); break;
            case "*": Console.WriteLine(a * b); break;
            case "/":
                if (b == 0) Console.WriteLine("На ноль делить нельзя.");
                else Console.WriteLine(a / b);
                break;
            default: Console.WriteLine("Неизвестная операция"); break;
        }
    }
}
