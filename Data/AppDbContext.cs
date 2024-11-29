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
        modelBuilder.Entity<BookAuthor>(ba =>{
            ba.HasKey(e => new { e.BookId, e.AuthorId });
    
            ba.HasOne(e => e.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(e => e.BookId);
            
            ba.HasOne(e => e.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(e => e.AuthorId);    
        });

        modelBuilder.Entity<Loan>(l =>{
            l.HasOne(b=> b.Book)
            .WithMany(l => l.loans)
            .HasForeignKey(b => b.BookId);
        });

    }



}