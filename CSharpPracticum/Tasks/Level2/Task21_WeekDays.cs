using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 21. Дни недели.</summary>
public class Task21_WeekDays : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Дни недели";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести русские названия и выходные дни.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "enum с семью днями",
        "IsWeekend",
        "GetRussianName",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Все семь дней выведены с признаком выходного.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Суббота и воскресенье — выходные.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            Console.WriteLine($"{GetRussianName(day)} — {(IsWeekend(day) ? "выходной" : "будний")}");
    }

    private enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    private static bool IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    private static string GetRussianName(DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => "Неизвестно"
        };
    }
}
