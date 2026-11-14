using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 49. Git: reflog.</summary>
public class Task49_Reflog : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: reflog";
    /// <summary>Описание задания.</summary>
    public string Description => "Удалить коммит и восстановить его через reflog.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Сделать коммит и удалить через reset --hard",
        "Найти коммит в git reflog",
        "Восстановить коммит и сохранить вывод"
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Коммит найден и восстановлен, история сохранена.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Результаты команд записаны в git-notes.md.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Console.WriteLine("Восстановление коммита выполнено в отдельном Git-репозитории.");
        Console.WriteLine("Команды, reflog и log: git-notes.md.");
    }
}
