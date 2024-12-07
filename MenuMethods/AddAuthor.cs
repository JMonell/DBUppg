using bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

class AddAuthor{

    public static void Run(){

        using (var context = new AppDbContext()){
            System.Console.WriteLine("Add an author:");

            System.Console.Write("Enter First Name: ");
            var firstName = Console.ReadLine()?.Trim();
            System.Console.Write("Enter a Last Name: ");
            var lastName = Console.ReadLine()?.Trim();

            var author = new Author {
                FirstName = firstName,
                LastName = lastName,
            };
                context.Authors.Add(author);   
                context.SaveChanges();
                System.Console.WriteLine($"author {author.FirstName} {author.LastName} has been added to DataBase");

        }
    }
}