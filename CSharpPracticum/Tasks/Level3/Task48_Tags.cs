using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 48. Git: теги.</summary>
public class Task48_Tags : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: теги";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать аннотированный тег v1.0.0.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git tag -a v1.0.0",
        "git push origin v1.0.0",
        "git tag и git show в git-notes.md"
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Тег v1.0.0 должен появиться на GitHub.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для публикации тега используй git push origin v1.0.0.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Для завершения задания нужен тег v1.0.0 на GitHub.");
        Console.WriteLine("Команды и локальная проверка: git-notes.md");
    }
}
