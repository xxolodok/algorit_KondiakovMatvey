using System;
using System.Collections.Generic;

class Book
{
    public string AuthorLastName { get; set; }  
    public string BookName { get; set; }       
    public string YearOfPublishing { get; set; } 
    public string PublishingHouse { get; set; } 
    public DateTime? IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Book(string authorLastName, string bookName, string yearOfPublishing,
                string publishingHouse, DateTime? issueDate, DateTime? returnDate)
    {
        AuthorLastName = authorLastName;
        BookName = bookName;
        YearOfPublishing = yearOfPublishing;
        PublishingHouse = publishingHouse;
        IssueDate = issueDate;
        ReturnDate = returnDate;
    }
}

struct Library
{
    public List<Book> BookList { get; set; }

    public Library()
    {
        BookList = new List<Book>();
    }

    public List<Book> FindByIssue()
    {
        List<Book> foundList = new List<Book>();
        foreach (var book in BookList)
        {
            if (book.IssueDate == null) foundList.Add(book);
        }
        return foundList;
    }

    public List<Book> FindByReturn()
    {
        List<Book> foundList = new List<Book>();
        foreach (var book in BookList)
        {
            if (book.ReturnDate == null) foundList.Add(book);
        }
        return foundList;
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        // Заполнение библиотеки тестами
        library.BookList.Add(new Book("Толстой", "Война и мир", "2000", "Издательство 1",
                                    new DateTime(2025, 10, 1), new DateTime(2025, 11, 1)));
        library.BookList.Add(new Book("Достоевский", "Преступление и наказание", "1990", "Издательство 2",
                                    new DateTime(2025, 9, 15), new DateTime(2025, 10, 15)));
        library.BookList.Add(new Book("Гоголь", "Мёртвые души", "2001", "Издательство 3",
                                    new DateTime(2025, 8, 20), new DateTime(2025, 9, 20)));
        library.BookList.Add(new Book("Пушкин", "Евгений Онегин", "2015", "Издательство 4",
                                    null, null));
        library.BookList.Add(new Book("Лермонтов", "Герой нашего времени", "2000", "Издательство 5",
                                    new DateTime(2025, 11, 1), null));

        var dontIssueBooks = library.FindByIssue();
        var dontReturnBooks = library.FindByReturn();

        Console.WriteLine("Книги без даты выдачи:");
        Console.WriteLine("-----------------------");
        foreach (var book in dontIssueBooks)
        {
            Console.WriteLine($"Автор: {book.AuthorLastName}");
            Console.WriteLine($"Название: {book.BookName}");
            Console.WriteLine($"Год издания: {book.YearOfPublishing}");
            Console.WriteLine($"Издательство: {book.PublishingHouse}");
            Console.WriteLine();
        }

        Console.WriteLine("\nКниги без даты возврата:");
        Console.WriteLine("-----------------------");
        foreach (var book in dontReturnBooks)
        {
            Console.WriteLine($"Автор: {book.AuthorLastName}");
            Console.WriteLine($"Название: {book.BookName}");
            Console.WriteLine($"Год издания: {book.YearOfPublishing}");
            Console.WriteLine($"Издательство: {book.PublishingHouse}");
            Console.WriteLine($"Дата выдачи: {book.IssueDate?.ToString("dd.MM.yyyy") ?? "не указана"}");
            Console.WriteLine();
        }

    }
}