using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class ReadLoans{
     public static void Run(){
        using (var context = new AppDbContext()){

            var loans = context.Loans.Include(l => l.Book).ToList();
                foreach (var l in loans){
                    System.Console.WriteLine($"{l.Id} - Book: {l.Book.Title} - Borrower: {l.BorrowerName} - Date: {l.LoanDate.ToString("yyyy-MM-dd")} returnDate: {l.ReturnDate?.ToString("yyyy-MM-dd")}");
                }
        }
     }
}