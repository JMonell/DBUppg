using Microsoft.EntityFrameworkCore;
using bibliotekssystem.Models;

public class AppDbContext : DbContext{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Loan> Loans { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CustomerDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        
    }



}