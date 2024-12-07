using Microsoft.EntityFrameworkCore;

namespace MenuMethods;

public class ReadAuthorsFromSpecificBook{

    public static void Run(){
        using(var context = new AppDbContext()){

            var Books = context.Books.ToList();
            foreach(var b in Books){
                System.Console.WriteLine($"{b.Id} - {b.Title} {b.Publisher}");
            }
        
            System.Console.Write("Enter book id: ");

            if (!int.TryParse(Console.ReadLine(), out var bookId)){
                System.Console.WriteLine("\nInvalid ID format. Please enter a valid numeric ID.");
            }

            var book = context.Books.Include(a => a.BookAuthors)
                .ThenInclude(b => b.Author)
                .Where(b => b.Id == bookId) 
                .SelectMany(b => b.BookAuthors.Select(a => a.Author))
                .ToList();


            if(!book.Any()){
                System.Console.WriteLine($"\nNo authors found from book with id: {bookId}");
            }

            System.Console.WriteLine($"\nAuthors worked on book with id: {bookId}\n");
            foreach (var a in book){
                System.Console.WriteLine($"- {a.FirstName} {a.LastName}");
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