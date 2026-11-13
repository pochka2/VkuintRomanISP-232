using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 43. Обработка исключений.</summary>
public class Task43_Exceptions : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Обработка исключений";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить три вида ошибок, catch и finally.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "FormatException и DivideByZeroException",
        "Собственный CustomException",
        "Несколько catch и finally",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Каждая ошибка обработана, finally выполняется всегда.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Сначала укажи конкретные catch, затем общий.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        for (int i = 1; i <= 3; i++)
        {
            try
            {
                ThrowError(i);
            }
            // Общий catch должен быть последним, иначе он перехватит все ошибки.
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException: " + ex.Message);
            }
            catch (CustomException ex)
            {
                Console.WriteLine("CustomException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }
        }
    }

    private static void ThrowError(int number)
    {
        if (number == 1) throw new FormatException("Неверный формат.");
        if (number == 2) throw new DivideByZeroException("Деление на ноль.");
        if (number == 3) throw new CustomException("Своя ошибка.");
    }

    private class CustomException : Exception
    {
        /// <summary>Создаёт собственную ошибку.</summary>
        public CustomException(string message) : base(message) { }
    }
}
