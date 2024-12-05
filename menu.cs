


public class Menu{

    public static void Run(){
        System.Console.WriteLine("Menu:");

        int MenuIndex = 0;

        while(MenuIndex != -1){
            MenuSelection();
        }
    }
    private static int MenuSelection(){

        //crud
        System.Console.WriteLine(@"1 - AddAuthor
2 - AddBook
3 - AddBookToAuthor
4 - AddLoan
5 - RemoveAuthor
6 - RemoveBook
7 - RemoveLoan");

        try{

        }
    }
}