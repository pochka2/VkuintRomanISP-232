using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

/// <summary>Задание 15. Git: ветка и merge.</summary>
public class Task15_GitBasics : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: ветка и merge";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать ветку, объединить изменения и разрешить конфликт.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "feature/git-basics",
        "Конфликт строки README.md",
        "git log --graph --oneline --all в git-notes.md",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Есть merge, разрешённый конфликт и история в git-notes.md.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Результаты команд находятся в git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Задание выполняется командами Git в репозитории.");
        Console.WriteLine("Команды и результат: файл git-notes.md");
    }
}
