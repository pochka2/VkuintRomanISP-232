namespace CSharpPracticum.Common;

/// <summary>Общее описание задания.</summary>
public interface ITask
{
    /// <summary>Название задания.</summary>
    string Title { get; }
    /// <summary>Что нужно сделать.</summary>
    string Description { get; }
    /// <summary>Условия задания.</summary>
    string[] Requirements { get; }
    /// <summary>Что должно получиться.</summary>
    string ExpectedResult { get; }
    /// <summary>Подсказка по решению.</summary>
    string Hint { get; }
    /// <summary>Запуск задания.</summary>
    void Run();
}

 
/// <summary>Задание с асинхронным запуском.</summary>
public interface IAsyncTask : ITask
{
    /// <summary>Асинхронный запуск задания.</summary>
    Task RunAsync();
}
