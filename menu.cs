using MenuMethods;

namespace Menu;
public class Menu{

    public static void Run(){
        System.Console.WriteLine("Menu:");

        int input = 0;

        while(input != -1){
            input = MenuSelection();
            MenuSwitch(input);
        }
    }
    private static int MenuSelection(){

        //crud
        System.Console.WriteLine(
@"
1  - AddAuthor               2 - AddBook          3 - AddLoan                         4 - AddBookToAuthor
5  - RemoveAuthor            6 - RemoveBook       7 - RemoveLoan
8  - UpdateAuthor            9 - UpdateBook      10 - UpdateLoan
11 - ReadBooksAndAuthors    12 - ReadLoans       13 - ReadBooksFromSpecificAuthor    14 - ReadAuthorsFromSpecificBook
15 - Quit");    

// Lista alla böcker tillsammans med deras författare.
// Lista alla lånade böcker och deras återlämningsdatum.
        int input = 0;

        try{
            input = Convert.ToInt32(Console.ReadLine());
            if(input < 1 || input >15){
                System.Console.WriteLine("need to be a valid number");
                return MenuSelection();
            }


        }catch(Exception e){
            System.Console.WriteLine(e.Message);
            return MenuSelection();
        }   
        return input;
    }

    public static void MenuSwitch(int input){

        switch (input){
            case 1:
                Console.WriteLine("AddAuthor selected.");
                MenuMethods.AddAuthor.Run();
                break;
            case 2:
                Console.WriteLine("AddBook selected.");
                MenuMethods.AddBook.Run();
                break;
            case 3:
                Console.WriteLine("AddLoan selected.");
                MenuMethods.AddLoan.Run();
                break;
            case 4:
                Console.WriteLine("AddBookToAuthor selected.");
                MenuMethods.AddBookToAuthor.Run();
                break;
            case 5:
                Console.WriteLine("RemoveAuthor selected.");
                MenuMethods.RemoveAuthor.Run();
                break;
            case 6:
                Console.WriteLine("RemoveBook selected.");
                MenuMethods.RemoveBook.Run();
                break;
            case 7:
                Console.WriteLine("RemoveLoan selected.");
                MenuMethods.RemoveLoan.Run();
                break;
            case 8:
                Console.WriteLine("UpdateAuthor selected.");
                MenuMethods.UpdateAuthor.Run();
                break;
            case 9:
                Console.WriteLine("UpdateBook selected.");
                MenuMethods.UpdateBook.Run();
                break;
            case 10:
                Console.WriteLine("UpdateLoan selected.");
                MenuMethods.UpdateLoan.Run();
                break;
            case 11:
                Console.WriteLine("ReadBooksAndAuthors selected.");
                MenuMethods.ReadBooksAndAuthors.Run();
                break;
            case 12:
                Console.WriteLine("ReadLoans selected.");
                MenuMethods.ReadLoans.Run();
                break;
            case 13:
                Console.WriteLine("ReadBooksFromSpecificAuthor selected.");
                MenuMethods.ReadBooksFromSpecificAuthor.Run();
                break;
            case 14:
                Console.WriteLine("ReadAuthorsFromSpecificBook selected.");
                // Add logic for ReadAuthorsFromSpecificBook
                MenuMethods.ReadAuthorsFromSpecificBook.Run();
                break;
            case 15:
                Console.WriteLine("Quitting the program...");
                Environment.Exit(0);
                break;    
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }



    }
}