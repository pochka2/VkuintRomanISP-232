using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 19. Стек и очередь на массиве.</summary>
public class Task19_StackQueue : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Стек и очередь на массиве";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать собственные стек и очередь.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Push Pop Peek / Enqueue Dequeue Peek",
        "Count и IsEmpty",
        "Удвоение массива",
        "Исключение для пустого",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Стек и очередь работают, пустые коллекции не ломают программу.";
    /// <summary>Подсказка.</summary>
    public string Hint => "У очереди удобно хранить индекс первого элемента.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine("Стек сверху: " + stack.Peek());
        Console.WriteLine("Забрали: " + stack.Pop());
        Console.WriteLine("Осталось: " + stack.Count);
        stack.Pop();
        stack.Pop();
        try { stack.Pop(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

        MyQueue<int> queue = new MyQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        Console.WriteLine("Очередь первый: " + queue.Peek());
        Console.WriteLine("Забрали: " + queue.Dequeue());
        Console.WriteLine("Осталось: " + queue.Count);
        queue.Dequeue();
        queue.Dequeue();
        try { queue.Dequeue(); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
    }

    private class MyStack<T>
    {
        private T[] items = new T[2];
        /// <summary>Свойство.</summary>
        public int Count { get; private set; }
        /// <summary>Свойство.</summary>
        public bool IsEmpty => Count == 0;

        /// <summary>Добавляет в стек.</summary>
        public void Push(T item)
        {
            if (Count == items.Length) Array.Resize(ref items, items.Length * 2);
            items[Count++] = item;
        }

        /// <summary>Удаляет из стека.</summary>
        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст.");
            T item = items[--Count];
            items[Count] = default(T);
            return item;
        }

        /// <summary>Смотрит первый элемент.</summary>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст.");
            return items[Count - 1];
        }
    }

    private class MyQueue<T>
    {
        private T[] items = new T[2];
        private int start;
        /// <summary>Свойство.</summary>
        public int Count { get; private set; }
        /// <summary>Свойство.</summary>
        public bool IsEmpty => Count == 0;

        /// <summary>Добавляет в очередь.</summary>
        public void Enqueue(T item)
        {
            if (Count == items.Length)
            {
                T[] newItems = new T[items.Length * 2];
                for (int i = 0; i < Count; i++)
                    newItems[i] = items[(start + i) % items.Length];
                items = newItems;
                start = 0;
            }
            items[(start + Count) % items.Length] = item;
            Count++;
        }

        /// <summary>Удаляет из очереди.</summary>
        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста.");
            T item = items[start];
            items[start] = default(T);
            start = (start + 1) % items.Length;
            Count--;
            return item;
        }

        /// <summary>Смотрит первый элемент.</summary>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста.");
            return items[start];
        }
    }
}
