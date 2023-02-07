using LibraryBookServiceApi.Models;

namespace LibraryBookServiceApi.AppServices;

public interface IBookService
{
    Book? GetBook(int id);
    List<Book> GetAllBooks();

    Book AddBook(Book book);

    Book UpdateBook(Book newBook);

    Task RemoveBook(int id);
}