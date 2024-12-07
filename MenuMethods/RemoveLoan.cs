namespace MenuMethods;

public class RemoveLoan{

    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){
                var loans = context.Loans.ToList(); 
                foreach(var l in loans){
                    System.Console.WriteLine($"{l.Id} - {l.Book.Title} - {l.BorrowerName}");
                }
                
                // Prompt user for Author ID to delete.
                System.Console.Write("\nEnter an loan id to delete: ");
                
                // Validate user input.
                if (!int.TryParse(Console.ReadLine(), out var loanId))
                {
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    Console.ResetColor();
                    continue;
                }

                var loanToRemove = context.Loans.Find(loanId);

                if (loanToRemove == null)
                {
                    System.Console.WriteLine("\nLoan ID not found. Please try again.");
                    Console.ResetColor();
                    continue;
                }

                System.Console.WriteLine($"\nAre you sure you want to delete the loan: {loanToRemove.Book.Title} ? (yes/no)");
                Console.ResetColor();
                
                var confirmation = Console.ReadLine()?.Trim().ToLower();
                if (confirmation != "yes")
                {
                    System.Console.WriteLine("\nDeletion cancelled. Returning to menu.");
                    return;
                }

                context.Loans.Remove(loanToRemove);
                context.SaveChanges();

                System.Console.WriteLine($"\nLoan {loanToRemove.Id} has been successfully deleted.");
                return;
            }
        }
    }
}
