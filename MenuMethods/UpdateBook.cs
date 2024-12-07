using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class UpdateBook{
    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){
                var books = context.Books.ToList();
                foreach (var b in books){
                    System.Console.WriteLine($"{b.Id} - Title: {b.Title} - Publisher: {b.Publisher} - ReleaseDate: {b.ReleaseDate}");
                }

                System.Console.Write("\nEnter the book ID to update: ");

                if (!int.TryParse(Console.ReadLine(), out var bookId)){
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    continue;
                }

                var bookToUpdate = context.Books.FirstOrDefault(b => b.Id == bookId);

                if (bookToUpdate == null){
                    System.Console.WriteLine("\nBook ID not found. Please try again.");
                    continue;
                }

                System.Console.WriteLine($"\nCurrent details for Book {bookToUpdate.Id}:");
                System.Console.WriteLine($"Book Title: {bookToUpdate.Title}");
                System.Console.WriteLine($"Publisher: {bookToUpdate.Publisher}");
                System.Console.WriteLine($"Release Date: {bookToUpdate.ReleaseDate?.ToString("yyyy-MM-dd")}");

                System.Console.Write("\nEnter new Title (leave blank to keep current): ");
                var newTitle = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newTitle)){
                    bookToUpdate.Title = newTitle;
                }

                System.Console.Write("\nEnter new Publisher (leave blank to keep current): ");
                var newPublisher = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newPublisher)){
                    bookToUpdate.Publisher = newPublisher;
                }

                System.Console.Write("Enter new Release Date (yyyy-MM-dd, leave blank to keep current): ");
                var newReleaseDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newReleaseDateInput)){
                    if (DateTime.TryParseExact(newReleaseDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var newReleaseDate)){
                        bookToUpdate.ReleaseDate = newReleaseDate;
                    }else{
                        System.Console.WriteLine("Invalid date format. Release Date not updated.");
                    }
                }

                context.SaveChanges();
                System.Console.WriteLine($"\nBook {bookToUpdate.Id} has been successfully updated.");
                return;
            }
        }
    }
}
