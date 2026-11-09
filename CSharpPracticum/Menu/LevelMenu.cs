using CSharpPracticum.Common;

namespace CSharpPracticum.Menu;

/// <summary>Меню выбранного уровня.</summary>
public static class LevelMenu
{
    /// <summary>Показывает список заданий и запускает выбранное.</summary>
    public static void Show(int level, SortedDictionary<int, ITask> tasks)
    {
        while (true)
        {
            Console.WriteLine($"\n--- Уровень {level}: {(level == 1 ? "Базовый" : level == 2 ? "Средний" : "Продвинутый")} ---");
            foreach (var task in tasks)
                Console.WriteLine($"{task.Key}. {task.Value.Title}");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите задание: ");
            string input = Console.ReadLine()?.Trim().ToLower();
            if (input == "0" || input == "q")
                return;
            if (!int.TryParse(input, out int number) || !tasks.TryGetValue(number, out ITask taskToRun))
            {
                Console.WriteLine("Такого задания нет.");
                continue;
            }
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"Задание {number}. {taskToRun.Title}");
            Console.WriteLine("Описание: " + taskToRun.Description);
            Console.WriteLine("Требования:");
            foreach (string requirement in taskToRun.Requirements)
                Console.WriteLine("- " + requirement);
            Console.WriteLine("Подсказка: " + taskToRun.Hint);
            Console.WriteLine(new string('-', 50));
            try
            {
                taskToRun.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }
    }
}
