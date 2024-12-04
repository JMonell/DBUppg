using Microsoft.EntityFrameworkCore;
using bibliotekssystem.Models;
namespace bibliotekssystem;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Seed.Run(); // if there are no data, add data to the database

    }
}
