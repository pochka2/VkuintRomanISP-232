using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 47. Git: rebase -i.</summary>
public class Task47_Squash : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: rebase -i";
    /// <summary>Описание задания.</summary>
    public string Description => "Объединить четыре коммита в один.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Ветка feature/squash-demo",
        "Четыре коммита и rebase -i HEAD~4",
        "История до и после в git-notes.md"
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Четыре коммита объединены в один.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Вывод git log сохранён в git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Объединение коммитов выполняется командами Git.");
        Console.WriteLine("Результат: git-notes.md");
    }
}
