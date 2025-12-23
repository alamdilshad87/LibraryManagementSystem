using System;
using System.Collections.Generic;

public class Book
{
    public int Id;
    public string Title;
    public string Author;
    public string Genre;
    public bool IsAvailable;
}

public class Member
{
    public int Id;
    public string Name;
    public List<Book> BorrowedBooks = new List<Book>();
}
public class Library
{
    private List<Book> _books = new List<Book>();
    private List<Member> _members = new List<Member>();
    private int _nextBookId = 1;
    private int _nextMemberId = 1;

    public Book AddBook(string title, string author, string genre)
    {
        Book book = new Book();
        book.Id = _nextBookId++;
        book.Title = title;
        book.Author = author;
        book.Genre = genre;
        book.IsAvailable = true;

        _books.Add(book);
        return book;
    }

    public Member AddMember(string name)
    {
        Member member = new Member();
        member.Id = _nextMemberId++;
        member.Name = name;

        _members.Add(member);
        return member;
    }

    public List<Book> SearchByTitle(string title)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in _books)
        {
            if (book.Title.ToLower().Contains(title.ToLower()))
            {
                result.Add(book);
            }
        }

        return result;
    }

    public List<Book> SearchByAuthor(string author)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in _books)
        {
            if (book.Author.ToLower().Contains(author.ToLower()))
            {
                result.Add(book);
            }
        }

        return result;
    }

    public List<Book> SearchByGenre(string genre)
    {
        List<Book> result = new List<Book>();

        foreach (Book book in _books)
        {
            if (book.Genre.ToLower().Contains(genre.ToLower()))
            {
                result.Add(book);
            }
        }

        return result;
    }

    public bool IsAvailable(int bookId)
    {
        foreach (Book book in _books)
        {
            if (book.Id == bookId)
            {
                return book.IsAvailable;
            }
        }
        return false;
    }

    public void BorrowBook(int bookId, int memberId)
    {
        Book book = null;
        Member member = null;

        foreach (Book b in _books)
        {
            if (b.Id == bookId)
            {
                book = b;
                break;
            }
        }

        foreach (Member m in _members)
        {
            if (m.Id == memberId)
            {
                member = m;
                break;
            }
        }

        if (book == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        if (member == null)
        {
            Console.WriteLine("Member not found");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Book already borrowed");
            return;
        }

        book.IsAvailable = false;
        member.BorrowedBooks.Add(book);
    }

    public void ReturnBook(int bookId, int memberId)
    {
        Member member = null;
        Book book = null;

        foreach (Member m in _members)
        {
            if (m.Id == memberId)
            {
                member = m;
                break;
            }
        }

        if (member == null)
        {
            Console.WriteLine("Member not found");
            return;
        }

        foreach (Book b in member.BorrowedBooks)
        {
            if (b.Id == bookId)
            {
                book = b;
                break;
            }
        }

        if (book == null)
        {
            Console.WriteLine("Book not borrowed by member");
            return;
        }

        book.IsAvailable = true;
        member.BorrowedBooks.Remove(book);
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }
}
class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook("Clean Code", "Robert Martin", "Programming");
        library.AddBook("Harry Potter", "J.K. Rowling", "Fantasy");
        library.AddBook("C# Basics", "Microsoft", "Programming");

        library.AddMember("Dilshad");
        library.AddMember("Gaurav");

        Console.WriteLine("\nSearch by Title: Clean");
        List<Book> titleSearch = library.SearchByTitle("Clean");
        foreach (Book b in titleSearch)
        {
            PrintBook(b);
        }

        Console.WriteLine("\nSearch by Author: Rowling");
        List<Book> authorSearch = library.SearchByAuthor("Rowling");
        foreach (Book b in authorSearch)
        {
            PrintBook(b);
        }

        Console.WriteLine("\nBorrowing Book Id 1 by Member Id 1");
        library.BorrowBook(1, 1);

        Console.WriteLine("\nIs Book 1 Available?");
        Console.WriteLine(library.IsAvailable(1));

        Console.WriteLine("\nReturning Book Id 1");
        library.ReturnBook(1, 1);

        Console.WriteLine("\nAll Books:");
        foreach (Book b in library.GetAllBooks())
        {
            PrintBook(b);
        }
    }

    static void PrintBook(Book book)
    {
        Console.WriteLine(
            "Id: " + book.Id +
            ", Title: " + book.Title +
            ", Author: " + book.Author +
            ", Genre: " + book.Genre +
            ", Available: " + book.IsAvailable
        );
    }
}