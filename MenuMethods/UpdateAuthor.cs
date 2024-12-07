using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class UpdateAuthor{
    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){

                var authors = context.Authors.ToList();
                foreach (var a in authors){
                    System.Console.WriteLine($"{a.Id} - First Name: {a.FirstName} - Last Name: {a.LastName}");
                }

                System.Console.Write("\nEnter the author ID to update: ");

                if (!int.TryParse(Console.ReadLine(), out var authorId)){
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    continue;
                }

                var authorToUpdate = context.Authors.FirstOrDefault(a => a.Id == authorId);

                if (authorToUpdate == null){
                    System.Console.WriteLine("\nAuthor ID not found. Please try again.");
                    continue;
                }

                System.Console.WriteLine($"\nCurrent details for Author {authorToUpdate.Id}:");
                System.Console.WriteLine($"Author First Name {authorToUpdate.FirstName}");
                System.Console.WriteLine($"Author Last Name: {authorToUpdate.LastName}");

                System.Console.Write("\nEnter new Authors FirstName (leave blank to keep current): ");
                var newFirstName = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newFirstName)){
                    authorToUpdate.FirstName = newFirstName;
                }

                 System.Console.Write("\nEnter new Authors LastName (leave blank to keep current): ");
                var newLastName = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newLastName)){
                    authorToUpdate.FirstName = newLastName;
                }


                context.SaveChanges();

                System.Console.WriteLine($"\nAuthor {authorToUpdate.Id} has been successfully updated.");
                return;
            }
        }
    }
}
