using LibraryBookServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBookServiceApi.EntityFramework;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
}