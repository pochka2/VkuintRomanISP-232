using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 40. Async и обработка ошибок.</summary>
public class Task40_Download : IAsyncTask
{
    /// <summary>Название задания.</summary>
    public string Title => "Async и обработка ошибок";
    /// <summary>Описание задания.</summary>
    public string Description => "Имитировать скачивание и обработать пустую ссылку.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "async, await и Task.Delay(1000)",
        "Ошибка ArgumentException для пустой ссылки",
        "Успешный и ошибочный вызовы",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Скачивание работает, ошибка обрабатывается.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Используй await внутри try/catch.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    /// <summary>Запускает задание асинхронно.</summary>
    public async Task RunAsync()
    {
        foreach (string url in new[] { "https://example.com/file", "" })
        {
            try
            {
                string result = await DownloadAsync(url);
                Console.WriteLine(result);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    private static async Task<string> DownloadAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Пустая ссылка.");

        await Task.Delay(1000);
        return "Скачивание завершено: " + url;
    }
}
