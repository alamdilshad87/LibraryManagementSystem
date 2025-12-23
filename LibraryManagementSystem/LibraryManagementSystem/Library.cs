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