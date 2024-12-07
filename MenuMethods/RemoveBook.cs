namespace MenuMethods;

public class RemoveBook{

    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){
                var books = context.Books.ToList(); 
                foreach(var b in books){
                    System.Console.WriteLine($"{b.Id} - {b.Title}");
                }
                
                System.Console.Write("\nEnter an book id to delete: ");
                
                if (!int.TryParse(Console.ReadLine(), out var bookId)){
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    Console.ResetColor();
                    continue;
                }

                var bookToRemove = context.Books.Find(bookId);

                if (bookToRemove == null){
                    System.Console.WriteLine("\nBook ID not found. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                System.Console.WriteLine($"\nAre you sure you want to delete the book: {bookToRemove.Title} ? (yes/no)");
                Console.ResetColor();
                
                var confirmation = Console.ReadLine()?.Trim().ToLower();
                if (confirmation != "yes"){
                    System.Console.WriteLine("\nDeletion cancelled. Returning to menu.");
                    return;
                }

                context.Books.Remove(bookToRemove);
                context.SaveChanges();

                System.Console.WriteLine($"\nBook {bookToRemove.Title} has been successfully deleted.");
                return;
            }
        }
    }
}
