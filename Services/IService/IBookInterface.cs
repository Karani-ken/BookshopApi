using BookshopApi.Models;

namespace BookshopApi.Services.IService
{
    public interface IBookInterface
    {
        //add a book
        Task<string> AddBook(Book book); // accepts a Book object and returns a string indicating asynchrous method

        //get books
        Task<IEnumerable<Book>> GetAllBooks(); // returns I enumerable books
        /*
         An IEnumerable is a collection of objects that can be iterated over, one item at a time
            Does not allow adding, removing, or modifying elements directly
         */


        //delete a book
        Task<string> DeleteBook(Book book);

        //get book by id
        Task<Book> GetBookById(int id);

        //edit a book
        Task<string> UpdateBook(Book book);
    }
}
