using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class ReadBooksFromSpecificAuthor{

    public static void Run(){
        using(var context = new AppDbContext()){

            var Authors = context.Authors.ToList();
            foreach(var a in Authors){
                System.Console.WriteLine($"{a.Id} - {a.FirstName} {a.LastName}");
            }
        
            System.Console.Write("Enter author id: ");

            if (!int.TryParse(Console.ReadLine(), out var authorId)){
                System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
            }

            var author = context.Authors.Include(a => a.BookAuthors)
                .ThenInclude(a => a.Book)
                .Where(a => a.Id == authorId) 
                .SelectMany(a => a.BookAuthors.Select(b => b.Book))
                .ToList();


            if(!author.Any()){
                System.Console.WriteLine($"\nNo books found from author with id: {authorId}");
            }

            System.Console.WriteLine($"\nBooks by author with id: {authorId}\n");
            foreach (var b in author){
                System.Console.WriteLine($"- {b.Title, -30} Publisher: {b.Publisher, -20} Release date: {b.ReleaseDate?.ToString("yyyy-MM-dd")}");
                
            } 
        
        }
    }
}







/*
using Bibliotekssystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class authorwbook
{
    public static void Run()
    {
        System.Console.Write("Author first name: ");
        var input = Console.ReadLine();
        using (var context = new AppDbContext())
        {
        var authorb = context.Authors.Include(a => a.BookAuthors)
            .ThenInclude(a => a.Book)
            .Where(a => a.FirstName.Contains(input)) //filtrera firstname med where
            .SelectMany(a => a.BookAuthors.Select(bo => bo.Book)) //för att ta ut alla böcker från relation
            .ToList();
        
        if(!authorb.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"No books found for the author {input}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            System.Console.WriteLine($"Books written by {input}");
            foreach (var book in authorb)
            {
                System.Console.WriteLine($"book title: {book.Title}");
            }
        }          

        }
    }
}

*/