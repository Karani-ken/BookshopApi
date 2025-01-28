using BookshopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookshopApi.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
