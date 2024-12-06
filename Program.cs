using Microsoft.EntityFrameworkCore;
using bibliotekssystem.Models;
using Menu;
namespace bibliotekssystem;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Seed.Run(); // if there are no data, add data to the database
        System.Console.WriteLine("Done!");

        Menu.Menu.Run();
        

        

    }
}
