using bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

class AddBook{

    public static void Run(){

        using (var context = new AppDbContext()){
            System.Console.WriteLine("Add a book:");

            System.Console.Write("Enter Title: ");
            var title = Console.ReadLine()?.Trim();
            System.Console.Write("Enter publisher: ");
            var publisher = Console.ReadLine()?.Trim();

            DateTime? releaseDate = null; // Nullable DateTime to handle optional input
            while (releaseDate == null){
                System.Console.Write("Enter Release Date (yyyy-MM-dd): ");
                var dateInput = Console.ReadLine()?.Trim();

                                                                    //to get exact format of date input
                if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate)){
                    releaseDate = parsedDate; // Set releaseDate if parsing succeeds
                }else{
                    System.Console.WriteLine("Invalid date format. Please try again.");
                    Console.ResetColor();
                }
            }

            var book = new Book{
                Title = title,
                Publisher = publisher,
                ReleaseDate = releaseDate
            };
                context.Books.Add(book);   
                context.SaveChanges();
                System.Console.WriteLine($"book {book.Title} has been added to DataBase");

        }
    }
}