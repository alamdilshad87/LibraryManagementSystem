using System;
using System.Collections.Generic;
using System.Linq;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}
public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
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