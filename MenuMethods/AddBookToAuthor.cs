using bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

class AddBookToAuthor{

    public static void Run(){

        using (var context = new AppDbContext()){
            var Authors = context.Authors
                .Where(a => !context.Books.Any(b => b.BookAuthors.Any(ba => ba.Id == a.Id)))
                .ToList();


            var Books = context.Books
                    .Where(b => !b.BookAuthors.Any(a => b.BookAuthors.Any(ba => ba.Id == b.Id)))
                    .ToList();

            foreach(var b in Books){
                System.Console.WriteLine($"{b.Id} - {b.Title}");
            }
            System.Console.WriteLine();

            foreach(var a in Authors){
                System.Console.WriteLine($"{a.Id} - {a.FirstName} {a.LastName}");
            }



            System.Console.WriteLine("Add a connection between book and author (must use id from both):");
            while(true){
                System.Console.Write("Enter BookId: ");
                if (!int.TryParse(Console.ReadLine(), out int bookid)){
                        System.Console.WriteLine("Id could not be found, try again");
                        continue;
                }
                System.Console.Write("Enter AuthorId: ");
                if (!int.TryParse(Console.ReadLine(), out int authorid)){
                        System.Console.WriteLine("Id could not be found, try again");
                        continue;
                }

                var bookAuthor = new BookAuthor {
                    BookId = bookid,
                    AuthorId = authorid};

                context.BookAuthors.Add(bookAuthor);
                context.SaveChanges(); 

                System.Console.WriteLine($"added relationshipt between book with id {bookid} and author with id {authorid}");
                return;
            }
            

           
        }
    }
}
