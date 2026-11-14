using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

/// <summary>Задание 45. Библиотека.</summary>
public class Task45_Library : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Библиотека";
    /// <summary>Описание задания.</summary>
    public string Description => "Выдавать и возвращать книги с ограничением до трёх.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Book, Reader и Library",
        "Выдача, возврат и лимит в 3 книги",
        "Обработка ошибок и юнит-тесты",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Выдача и возврат работают, ошибки обрабатываются.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Перед выдачей проверь доступность и количество книг.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Library library = new Library();
        Book first = new Book("Война и мир", "Лев Толстой");
        Book second = new Book("Капитанская дочка", "Александр Пушкин");
        Reader reader = new Reader("Иван");

        library.AddBook(first);
        library.AddBook(second);
        library.Borrow(first, reader);
        Console.WriteLine("Взято: " + first.Title);

        try
        {
            library.Borrow(first, reader);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        library.Return(first, reader);
        Console.WriteLine("Возвращено: " + first.Title);
    }

    /// <summary>Книга.</summary>
    public class Book
    {
        /// <summary>Название книги.</summary>
        public string Title { get; }
        /// <summary>Автор.</summary>
        public string Author { get; }
        /// <summary>Доступна ли книга.</summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>Создаёт книгу.</summary>
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    /// <summary>Читатель.</summary>
    public class Reader
    {
        /// <summary>Имя читателя.</summary>
        public string Name { get; }
        /// <summary>Взятые книги.</summary>
        public List<Book> BorrowedBooks { get; } = new List<Book>();

        /// <summary>Создаёт читателя.</summary>
        public Reader(string name)
        {
            Name = name;
        }
    }

    /// <summary>Библиотека с выдачей и возвратом.</summary>
    public class Library
    {
        private readonly List<Book> books = new List<Book>();

        /// <summary>Добавляет книгу.</summary>
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        /// <summary>Выдаёт книгу.</summary>
        public void Borrow(Book book, Reader reader)
        {
            if (!books.Contains(book))
                throw new InvalidOperationException("Такой книги нет.");
            if (!book.IsAvailable)
                throw new InvalidOperationException("Книга уже выдана.");
            if (reader.BorrowedBooks.Count >= 3)
                throw new InvalidOperationException("Нельзя брать больше трёх книг.");

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }

        /// <summary>Принимает книгу обратно.</summary>
        public void Return(Book book, Reader reader)
        {
            if (!reader.BorrowedBooks.Contains(book))
                throw new InvalidOperationException("Читатель не брал эту книгу.");

            reader.BorrowedBooks.Remove(book);
            book.IsAvailable = true;
        }
    }
}
