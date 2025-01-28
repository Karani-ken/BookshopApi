using BookshopApi.Data;
using BookshopApi.Models;
using BookshopApi.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace BookshopApi.Services
{
    public class BookService : IBookInterface
    {

        private readonly AppDbContext _appDbContext;

        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> AddBook(Book book)
        {
            _appDbContext.Books.Add(book);
            await _appDbContext.SaveChangesAsync();

            return "Book was added successfully";
           
        }

        public async Task<string> DeleteBook(Book book)
        {
           _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();
            return "Book Deleted Succesfuly";
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
           return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _appDbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateBook(Book book)
        {
           _appDbContext.Books.Update(book);
            await _appDbContext.SaveChangesAsync();

            return "Book updated successfully";
        }
    }
}
