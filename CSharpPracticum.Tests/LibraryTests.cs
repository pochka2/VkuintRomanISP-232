using CSharpPracticum.Tasks.Level3;
using Xunit;

namespace CSharpPracticum.Tests;

/// <summary>Проверки задания 45.</summary>
public class LibraryTests
{
    /// <summary>Выдача делает книгу недоступной.</summary>
    [Fact]
    public void Borrow_MakesBookUnavailable()
    {
        var library = new Task45_Library.Library();
        var book = new Task45_Library.Book("Книга", "Автор");
        var reader = new Task45_Library.Reader("Иван");
        library.AddBook(book);

        library.Borrow(book, reader);

        Assert.False(book.IsAvailable);
    }

    /// <summary>Книга добавляется к читателю.</summary>
    [Fact]
    public void Borrow_AddsBookToReader()
    {
        var library = new Task45_Library.Library();
        var book = new Task45_Library.Book("Книга", "Автор");
        var reader = new Task45_Library.Reader("Иван");
        library.AddBook(book);

        library.Borrow(book, reader);

        Assert.Single(reader.BorrowedBooks);
    }

    /// <summary>Возврат снова делает книгу доступной.</summary>
    [Fact]
    public void Return_MakesBookAvailable()
    {
        var library = new Task45_Library.Library();
        var book = new Task45_Library.Book("Книга", "Автор");
        var reader = new Task45_Library.Reader("Иван");
        library.AddBook(book);
        library.Borrow(book, reader);

        library.Return(book, reader);

        Assert.True(book.IsAvailable);
        Assert.Empty(reader.BorrowedBooks);
    }

    /// <summary>Одну книгу нельзя выдать дважды.</summary>
    [Fact]
    public void Borrow_TwiceThrows()
    {
        var library = new Task45_Library.Library();
        var book = new Task45_Library.Book("Книга", "Автор");
        library.AddBook(book);
        library.Borrow(book, new Task45_Library.Reader("Иван"));

        Assert.Throws<InvalidOperationException>(() =>
            library.Borrow(book, new Task45_Library.Reader("Оля")));
    }

    /// <summary>Четвёртую книгу взять нельзя.</summary>
    [Fact]
    public void Borrow_FourthBookThrows()
    {
        var library = new Task45_Library.Library();
        var reader = new Task45_Library.Reader("Иван");
        for (int i = 1; i <= 4; i++)
            library.AddBook(new Task45_Library.Book("Книга " + i, "Автор"));

        var books = new List<Task45_Library.Book>
        {
            new Task45_Library.Book("Первая", "Автор"),
            new Task45_Library.Book("Вторая", "Автор"),
            new Task45_Library.Book("Третья", "Автор"),
            new Task45_Library.Book("Четвёртая", "Автор")
        };
        foreach (var book in books)
            library.AddBook(book);

        for (int i = 0; i < 3; i++)
            library.Borrow(books[i], reader);

        Assert.Throws<InvalidOperationException>(() => library.Borrow(books[3], reader));
    }

    /// <summary>Нельзя вернуть чужую книгу.</summary>
    [Fact]
    public void Return_NotBorrowedThrows()
    {
        var library = new Task45_Library.Library();
        var book = new Task45_Library.Book("Книга", "Автор");
        var reader = new Task45_Library.Reader("Иван");
        library.AddBook(book);

        Assert.Throws<InvalidOperationException>(() => library.Return(book, reader));
    }
}
