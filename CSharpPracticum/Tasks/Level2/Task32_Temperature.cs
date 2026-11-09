using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 32. Температура.</summary>
public class Task32_Temperature : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Температура";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить свойства с валидацией.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Celsius не ниже -273.15",
        "ArgumentOutOfRangeException",
        "Fahrenheit только get",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Температура проверяется и переводится в Фаренгейты.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Fahrenheit = Celsius * 9 / 5 + 32.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Temperature temp = new Temperature();
        temp.Celsius = 25;
        Console.WriteLine($"{temp.Celsius} C = {temp.Fahrenheit} F");
        try { temp.Celsius = -300; }
        catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex.Message); }
        Console.WriteLine("Сейчас: " + temp.Celsius);
    }

    private class Temperature
    {
        private double celsius;
        /// <summary>Температура в градусах Цельсия.</summary>
        public double Celsius
        {
            get => celsius;
            set
            {
                if (value < -273.15) throw new ArgumentOutOfRangeException(nameof(value), "Ниже абсолютного нуля нельзя.");
                celsius = value;
            }
        }
        /// <summary>Температура в градусах Фаренгейта.</summary>
        public double Fahrenheit => Celsius * 9 / 5 + 32;
    }
}
