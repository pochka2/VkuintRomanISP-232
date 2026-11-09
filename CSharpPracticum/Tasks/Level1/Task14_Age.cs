using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 14. Возраст по дате рождения.</summary>
public class Task14_Age : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Возраст по дате рождения";
    /// <summary>Описание задания.</summary>
    public string Description => "Определить возраст в годах, месяцах и днях.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "DateTime.TryParse",
        "Правильный учёт ещё не наступившего дня рождения",
        "Некорректная дата не роняет программу",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Проверяй, что дата не в будущем.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.Write("Дата рождения: ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birth))
        {
            Console.WriteLine("Неверная дата.");
            return;
        }
        birth = birth.Date;
        DateTime today = DateTime.Today;
        if (birth > today)
        {
            Console.WriteLine("Дата ещё не наступила.");
            return;
        }
        int years = today.Year - birth.Year;
        if (birth.AddYears(years) > today) years--;
        DateTime current = birth.AddYears(years);
        int months = 0;
        while (current.AddMonths(1) <= today)
        {
            current = current.AddMonths(1);
            months++;
        }
        int days = (today - current).Days;
        Console.WriteLine($"{years} лет, {months} месяцев, {days} дней");
    }
}
