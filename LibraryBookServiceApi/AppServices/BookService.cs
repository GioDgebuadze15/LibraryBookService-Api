using LibraryBookServiceApi.EntityFramework;
using LibraryBookServiceApi.Models;

namespace LibraryBookServiceApi.AppServices;

public class BookService : IBookService
{
    private readonly AppDbContext _ctx;

    public BookService(AppDbContext ctx)
    {
        _ctx = ctx;
    }


    public Book? GetBook(int id) => _ctx.Books.FirstOrDefault(x => x.Id.Equals(id));

    public List<Book> GetAllBooks() => _ctx.Books.ToList();

    public Book AddBook(Book book)
    {
        if (!IsDateValid(book.DateOfPublish))
            return new Book();

        _ctx.Add(book);
        _ctx.SaveChanges();
        return book;
    }

    public Book UpdateBook(Book newBook)
    {
        if (!IsDateValid(newBook.DateOfPublish))
            throw new ArgumentException("Date of publish must be in the past!");

        var book = _ctx.Books.FirstOrDefault(x => x.Id.Equals(newBook.Id));
        if (book == null)
            throw new ArgumentNullException();


        book.Title = newBook.Title;
        book.Author = newBook.Author;
        book.DateOfPublish = newBook.DateOfPublish;

        _ctx.SaveChanges();
        return book;
    }

    public async Task RemoveBook(int id)
    {
        var book = _ctx.Books.FirstOrDefault(x => x.Id.Equals(id));
        if (book == null)
            throw new ArgumentException("Can't find book to remove");

        _ctx.Remove(book);
        await _ctx.SaveChangesAsync();
    }

    private static bool IsDateValid(DateTime date) => DateTime.Now.Subtract(date).Milliseconds > 0;
}