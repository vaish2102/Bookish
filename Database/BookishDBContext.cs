using Bookish.Models;
using Microsoft.EntityFrameworkCore;
namespace Bookish.Database;
public class BookishDBContext : DbContext {
    public BookishDBContext(): base(){}
    public DbSet<Book> Book { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
    }
}    