using System;
using bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore;

public class Seed{
    public static void Run(){
        using(var context = new AppDbContext()){
            var transaction = context.Database.BeginTransaction();

            try{

                if(!context.Books.Any() && !context.Authors.Any()){
                    // Books
                    context.Books.AddRange(
                        
                    );
                    var b1 = new Book{
                        Title = "The White Book",
                        Publisher = "Bonnier",
                        ReleaseDate = new DateTime(1922, 5, 20)
                    };
                    var b2 = new Book{
                        Title = "The Great Gatsby",
                        Publisher = "Scribner",
                        ReleaseDate = new DateTime(1925, 4, 10)
                    };
                    var b3 = new Book{
                        Title = "1984",
                        Publisher = "Secker & Warburg",
                        ReleaseDate = new DateTime(1949, 6, 8)
                    };
                    var b4 = new Book{
                        Title = "To Kill a Mockingbird",
                        Publisher = "J.B. Lippincott & Co.",
                        ReleaseDate = new DateTime(1960, 7, 11)
                    };
                    var b5 = new Book{
                        Title = "The Catcher in the Rye",
                        Publisher = "Little, Brown and Company",
                        ReleaseDate = new DateTime(1951, 7, 16)
                    };

                    // Authors
                    var a1 = new Author{
                        FirstName = "Han",
                        LastName = "Kang"
                    };
                    var a2 = new Author{
                        FirstName = "F. Scott",
                        LastName = "Fitzgerald"
                    };      
                    var a3 = new Author{
                        FirstName = "George",
                        LastName = "Orwell"
                    };
                    var a4 = new Author{
                        FirstName = "Harper",
                        LastName = "Lee"
                    };
                    var a5 = new Author{
                        FirstName = "J.D.",
                        LastName = "Salinger"
                    };

                    context.AddRange(b1, b2, b3, b4, b5, a1, a2, a3, a4, a5); // books and authors added
                    context.SaveChanges();

                    //relations
                    var bookAuthors = new[]{
                        new BookAuthor {Book = b1, Author = a1},
                        new BookAuthor {Book = b2, Author = a2},
                        new BookAuthor {Book = b3, Author = a3},
                        new BookAuthor {Book = b4, Author = a4},
                        new BookAuthor {Book = b5, Author = a5}
                    };
                    context.BookAuthors.AddRange(bookAuthors);  // Relationships added
                    context.SaveChanges();

                    var loan = new Loan {
                        BorrowerName = "John Smith",
                        BorrowerPhoneNumber = "0761234567",
                        BookId = 1,
                        LoanDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(+10)
                    };
                    context.Loans.AddRange(loan);  // loan added
                    context.SaveChanges();


                    transaction.Commit();
                    System.Console.WriteLine("Saved changes.");  
                }else{  
                    System.Console.WriteLine("There are already data in the database.");
                }
            }catch(Exception e){
                System.Console.WriteLine("An error occured" + e.Message);
            }
        
        }
    }
}