using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 35. Git: PR и rebase.</summary>
public class Task35_GitAdvanced : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: PR и rebase";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить Git, пул-реквест и объединение коммитов.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        ".gitignore и .editorconfig",
        "feature/task-35 и PR в main",
        "feature/rebase-demo и squash",
        "Вывод команд в git-notes.md",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Git-команды и результаты собраны в файле git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Задание выполняется в GitHub и Git.");
        Console.WriteLine("Подробности: git-notes.md");
    }
}
