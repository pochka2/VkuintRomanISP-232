using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 46. Git: stash.</summary>
public class Task46_Stash : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: stash";
    /// <summary>Описание задания.</summary>
    public string Description => "Спрятать незакоммиченные изменения и восстановить их.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git stash и git stash list",
        "Переключение ветки",
        "git stash pop и вывод в git-notes.md"
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Изменения восстановлены, вывод записан в git-notes.md.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Команды и результат находятся в git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("git stash и git stash pop выполняются в терминале.");
        Console.WriteLine("Вывод команд: git-notes.md");
    }
}
