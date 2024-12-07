namespace MenuMethods;

public class RemoveAuthor{// Class for deleting an Author (Delete => CRUD)

    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){
                var Authors = context.Authors.ToList(); // Fetch the list of all Authors.
                foreach(var a in Authors){
                    System.Console.WriteLine($"{a.Id} - {a.FirstName} {a.LastName}");
                }
                
                // Prompt user for Author ID to delete.
                System.Console.Write("\nEnter an Author ID to delete: ");
                
                // Validate user input.
                if (!int.TryParse(Console.ReadLine(), out var authorId))
                {
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    Console.ResetColor();
                    
                    // Display all authors for reference.
                    foreach (var a in Authors)
                    {
                        System.Console.WriteLine($"Author: {a.FirstName} {a.LastName} - ID: {a.Id}");
                    }
                    continue;
                }

                // Find the author by ID.
                var authorToRemove = context.Authors.Find(authorId);

                // Check if the author exists.
                if (authorToRemove == null)
                {
                    System.Console.WriteLine("\nAuthor ID not found. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                // Confirm deletion.
                System.Console.WriteLine($"\nAre you sure you want to delete the author: {authorToRemove.FirstName} {authorToRemove.LastName}? (yes/no)");
                Console.ResetColor();
                
                var confirmation = Console.ReadLine()?.Trim().ToLower();
                if (confirmation != "yes")
                {
                    System.Console.WriteLine("\nDeletion cancelled. Returning to menu.");
                    return;
                }

                // Delete the author.
                context.Authors.Remove(authorToRemove);
                context.SaveChanges();

                // Confirm success.
                System.Console.WriteLine($"\nAuthor {authorToRemove.FirstName} {authorToRemove.LastName} has been successfully deleted.");
                Console.ResetColor();
                return; // Exit after successful deletion.
            }
        }
    }
}
