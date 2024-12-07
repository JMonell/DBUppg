using bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

class AddLoan{

    public static void Run(){

        using (var context = new AppDbContext()){

            var Books = context.Books
                    .Where(b => !b.BookAuthors.Any(a => b.BookAuthors.Any(ba => ba.Id == b.Id)))
                    .ToList();

            foreach(var b in Books){
                System.Console.WriteLine($"{b.Id} - {b.Title}");
            }
            System.Console.WriteLine();
            
            System.Console.WriteLine("Add a Loan:");

            System.Console.Write("Enter borrowers name: ");
            var borrowerName = Console.ReadLine()?.Trim();
            System.Console.Write("Enter a phone number: ");
            var borrowerPhoneNr = Console.ReadLine()?.Trim();
            System.Console.Write("Enter a book id: ");
            if (!int.TryParse(Console.ReadLine(), out int bookid)){
                        System.Console.WriteLine("Id could not be found, try again");
                        
                }
            // DateTime? returnDate = null; // Nullable DateTime to handle optional input
            // while (returnDate == null){
            //     System.Console.Write("Enter Release Date (yyyy-MM-dd): ");
            //     var dateInput = Console.ReadLine()?.Trim();

            //                                                         //to get exact format of date input
            //     if (DateTime.TryParseExact(dateInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate)){
            //         returnDate = parsedDate; // Set releaseDate if parsing succeeds
            //     }else{
            //         System.Console.WriteLine("Invalid date format. Please try again.");
            //         Console.ResetColor();
            //     }
            // }

            var loan = new Loan {
                BorrowerName = borrowerName,
                BorrowerPhoneNumber = borrowerPhoneNr,
                BookId = bookid,
                LoanDate = DateTime.Now,
                // ReturnDate = returnDate
            };
            var loanDateFormatted = loan.LoanDate.ToString("yyyy-MM-dd") ?? "N/A";
            context.Loans.Add(loan);   
            context.SaveChanges();
            System.Console.WriteLine($"Loan {loan.BorrowerName} book id: {loan.BookId} {loanDateFormatted} has been added to DataBase");

        }
    }
}
/*
public string BorrowerName { get; set; }
        public string BorrowerPhoneNumber { get; set; }
        
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
*/