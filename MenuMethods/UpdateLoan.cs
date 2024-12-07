using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class UpdateLoan{
    public static void Run(){
        using (var context = new AppDbContext()){
            while (true){
                var loans = context.Loans.Include(l => l.Book).ToList();
                foreach (var l in loans){
                    System.Console.WriteLine($"{l.Id} - Book: {l.Book.Title} - Borrower: {l.BorrowerName} - Date: {l.LoanDate.ToString("yyyy-MM-dd")} returnDate: {l.ReturnDate?.ToString("yyyy-MM-dd")}");
                }

                System.Console.Write("\nEnter the loan ID to update: ");

                if (!int.TryParse(Console.ReadLine(), out var loanId)){
                    System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
                    continue;
                }

                var loanToUpdate = context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);

                if (loanToUpdate == null){
                    System.Console.WriteLine("\nLoan ID not found. Please try again.");
                    continue;
                }

                System.Console.WriteLine($"\nCurrent details for Loan {loanToUpdate.Id}:");
                System.Console.WriteLine($"Book Title: {loanToUpdate.Book.Title}");
                System.Console.WriteLine($"Borrower Name: {loanToUpdate.BorrowerName}");
                System.Console.WriteLine($"Loan Date: {loanToUpdate.LoanDate.ToString("yyyy-MM-dd")}");
                System.Console.WriteLine($"Loan Date: {loanToUpdate.ReturnDate.ToString()}");

                System.Console.Write("\nEnter new Borrower Name (leave blank to keep current): ");
                var newBorrowerName = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newBorrowerName)){
                    loanToUpdate.BorrowerName = newBorrowerName;
                }

                System.Console.Write("Enter new Loan Date (yyyy-MM-dd, leave blank to keep current): ");
                var newLoanDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newLoanDateInput)){
                    if (DateTime.TryParseExact(newLoanDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var newLoanDate)){
                        loanToUpdate.LoanDate = newLoanDate;
                    }else{
                        System.Console.WriteLine("Invalid date format. Loan Date not updated.");
                    }
                }

                System.Console.Write("Enter return Date (yyyy-MM-dd, leave blank to keep current): ");
                var newReturnDateInput = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(newReturnDateInput)){
                    if (DateTime.TryParseExact(newReturnDateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var newReturnDate)){
                        loanToUpdate.ReturnDate = newReturnDate;
                    }else{
                        System.Console.WriteLine("Invalid date format. Return Date not updated.");
                    }
                }

                context.SaveChanges();

                System.Console.WriteLine($"\nLoan {loanToUpdate.Id} has been successfully updated.");
                return;
            }
        }
    }
}
