using System.Text.Json;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 44. Список задач.</summary>
public class Task44_TodoList : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Список задач";
    /// <summary>Описание задания.</summary>
    public string Description => "Добавлять, выполнять и удалять задачи с сохранением в JSON.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "TaskItem, TaskRepository и TaskService",
        "Добавление, просмотр, выполнение и удаление",
        "Сохранение в tasks.json",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Список задач сохраняется между запусками.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для сохранения используй System.Text.Json.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        TaskService service;
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory, "tasks.json");
            service = new TaskService(new TaskRepository(path));
        }
        catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
        {
            Console.WriteLine("Не удалось загрузить задачи: " + ex.Message);
            return;
        }

        while (true)
        {
            Console.WriteLine("\n1. Добавить задачу");
            Console.WriteLine("2. Показать задачи");
            Console.WriteLine("3. Отметить выполненной");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("0. Назад");
            Console.Write("Выбор: ");
            string choice = Console.ReadLine();
            if (choice == null || choice == "0") return;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Название: ");
                        service.Add(Console.ReadLine() ?? "");
                        Console.WriteLine("Задача добавлена.");
                        break;
                    case "2":
                        foreach (TaskItem task in service.GetAll())
                            Console.WriteLine($"{task.Id}. {task.Title} — {(task.IsDone ? "Готово" : "Не готово")}");
                        break;
                    case "3":
                        Console.Write("Номер задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int doneId))
                            Console.WriteLine(service.Complete(doneId) ? "Готово." : "Задача не найдена.");
                        else
                            Console.WriteLine("Неверный номер.");
                        break;
                    case "4":
                        Console.Write("Номер задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            Console.WriteLine(service.Remove(deleteId) ? "Удалено." : "Задача не найдена.");
                        else
                            Console.WriteLine("Неверный номер.");
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта.");
                        break;
                }
            }
            catch (Exception ex) when (ex is ArgumentException or IOException or UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    /// <summary>Задача для сохранения в JSON.</summary>
    public class TaskItem
    {
        /// <summary>Номер задачи.</summary>
        public int Id { get; set; }
        /// <summary>Название задачи.</summary>
        public string Title { get; set; }
        /// <summary>Признак выполнения.</summary>
        public bool IsDone { get; set; }
    }

    private class TaskRepository
    {
        private readonly string path;
        private readonly List<TaskItem> tasks;

        /// <summary>Загружает задачи из файла.</summary>
        public TaskRepository(string path)
        {
            this.path = path;
            tasks = File.Exists(path)
                ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(path)) ?? new List<TaskItem>()
                : new List<TaskItem>();
        }

        /// <summary>Возвращает список задач.</summary>
        public List<TaskItem> GetAll() => tasks;

        /// <summary>Добавляет задачу и сохраняет её.</summary>
        public void Add(string title)
        {
            int id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
            tasks.Add(new TaskItem { Id = id, Title = title, IsDone = false });
            Save();
        }

        /// <summary>Отмечает задачу выполненной.</summary>
        public bool Complete(int id)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if (task == null) return false;
            task.IsDone = true;
            Save();
            return true;
        }

        /// <summary>Удаляет задачу по номеру.</summary>
        public bool Remove(int id)
        {
            TaskItem task = tasks.Find(t => t.Id == id);
            if (task == null) return false;
            tasks.Remove(task);
            Save();
            return true;
        }

        private void Save()
        {
            File.WriteAllText(path, JsonSerializer.Serialize(tasks));
        }
    }

    private class TaskService
    {
        private readonly TaskRepository repository;

        /// <summary>Создаёт сервис задач.</summary>
        public TaskService(TaskRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>Возвращает все задачи.</summary>
        public List<TaskItem> GetAll() => repository.GetAll();

        /// <summary>Проверяет название и добавляет задачу.</summary>
        public void Add(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым.");
            repository.Add(title.Trim());
        }

        /// <summary>Отмечает задачу выполненной.</summary>
        public bool Complete(int id) => repository.Complete(id);
        /// <summary>Удаляет задачу.</summary>
        public bool Remove(int id) => repository.Remove(id);
    }
}
