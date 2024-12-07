
using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class ReadBooksAndAuthors{
    public static void Run(){
        System.Console.WriteLine("hej!");

        using (var context = new AppDbContext()){

            var BookAuthor = context.Books
                    .Include(ba => ba.BookAuthors)  // From this one you get for an example the Author ID.
                    .ThenInclude(a => a.Author)
                    .ToList();
            
            // var AuthorsWithoutBooks = context.Authors
            //         .Where(a => !a.BookAuthors.Any())
            //         .ToList();

            // var BooksWithoutAuthors = context.Books
            //         .Where(b => !b.BookAuthors.Any())
            //         .ToList();

            foreach (var book in BookAuthor){
                foreach (var author in book.BookAuthors){
                    //  Helped by Nico  with formatting
                    var authors = string.Join(", ", book.BookAuthors.Select(a => $"{a.Author.FirstName} {a.Author.LastName}"));
                    var books = string.Join(", ", book.BookAuthors.Select(b => $"{b.Book.Title}"));
                    var releaseDate = book.ReleaseDate?.ToString("yyyy-MM-dd") ?? "N/A";
                    Console.WriteLine($"Author ID: {author.AuthorId} - Author: {authors,-25} Book ID: {book.Id} - Title: {books,-25} Release: {releaseDate,-15} Publisher: {book.Publisher}");
                }
            }
        }
    }
}
