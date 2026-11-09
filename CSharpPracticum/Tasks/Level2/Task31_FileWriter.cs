using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 31. IDisposable и using.</summary>
public class Task31_FileWriter : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "IDisposable и using";
    /// <summary>Описание задания.</summary>
    public string Description => "Записать текст в файл и закрыть его.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Поле StreamWriter",
        "Dispose",
        "using и using var",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "using сам вызывает Dispose.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        string path = Path.Combine(Path.GetTempPath(), "task31.txt");
        using (FileWriter writer = new FileWriter(path))
        {
            writer.WriteLine("Первая строка");
        }
        using var secondWriter = new FileWriter(path, true);
        secondWriter.WriteLine("Вторая строка");
        Console.WriteLine("Записали в файл: " + path);
    }

    private class FileWriter : IDisposable
    {
        private readonly StreamWriter writer;
        public FileWriter(string path, bool append = false)
        {
            writer = new StreamWriter(path, append);
        }
        public void WriteLine(string text) => writer.WriteLine(text);
        public void Dispose() => writer.Dispose();
    }
}
