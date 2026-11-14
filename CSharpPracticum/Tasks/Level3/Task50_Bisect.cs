using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 50. Git: bisect.</summary>
public class Task50_Bisect : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: bisect";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти коммит с ошибкой через git bisect.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "История из 10+ коммитов",
        "Намеренно сломать функцию и найти первый плохой коммит",
        "Отметки good/bad, bisect reset и вывод команд"
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Первый ошибочный коммит найден, поиск завершён.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Команды и найденный коммит указаны в git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Поиск ошибочного коммита выполнен в отдельном Git-репозитории.");
        Console.WriteLine("Команды и результат git bisect: git-notes.md.");
    }
}
