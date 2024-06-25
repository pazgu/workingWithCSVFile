using workingWithCSVFile;
using System.Diagnostics;
enum MainActions 
{
    DictionaryFunctions= 1,
    ArrayFunctions,
    LinkedListFunctions,
    Goodbye
}
enum DataStructuresActions //for each data structure
{
    InsertRecords = 1, 
    SearchById,
    PrintRecords,
    DeleteRecordById,
    MainMenu
}
class Program
{
    public static void Main(string[] args)
    {
        string filePath = @"C:\Users\pazgu\Desktop\books.csv";
        /*
        This file path refers to where the file is currrenty place in my computer.
        If you wouldn't have the file, I would have place the file inside the program and then
        use the path: string filePath = "books.csv";
        */
        BooksDictionary booksDictionary = new BooksDictionary(filePath); //class for dictionary's functions.
        BooksArray booksArray= new BooksArray(filePath);
        Node<Book> booksLinkedList = new Node<Book>(filePath);

        bool flagMainMenu = true; 
        while (flagMainMenu == true)
        {
            try
            {
                Console.WriteLine("\nWelcome to Kotar Rishon Lezion library\n\nPress button 1-4 to execute: \n\n (1) Functions using dictionary \n (2) Functions using array \n (3) Functions using linked list \n (4) Exit");
                string buttonNumberMain = Console.ReadLine();
                if (Enum.TryParse(buttonNumberMain, out MainActions actionMain))
                {
                    switch (actionMain)
                    {
                        case MainActions.DictionaryFunctions:
                            {
                                bool flagSecondaryMenu = true; //So flag will be reset, for the loop after user press main menu
                                while (flagSecondaryMenu == true)
                                {
                                    Console.WriteLine("\nPress button 1-5 according to the following: \n\n (1) Insert whole records to the dictionary \n (2) Search a record by its book id \n (3) Print whole records \n (4) Delete a record by its book id \n (5) Main menu");
                                    string buttonNumber = Console.ReadLine();
                                    if (Enum.TryParse(buttonNumber, out DataStructuresActions action))
                                    {
                                        switch (action)
                                        {
                                            //To measure the running time of each function I used 2 classes: Stopwatch and DateTimeOffset
                                            case DataStructuresActions.InsertRecords:
                                                Stopwatch stopwatchInsert = new Stopwatch();
                                                stopwatchInsert.Start();
                                                booksDictionary.Insert_all_dictionary();
                                                stopwatchInsert.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchInsert.ElapsedMilliseconds} milliseconds");
                                                //ElapsedMilliseconds is property of the class, used to present the running time in milliseconds
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.SearchById:
                                                DateTimeOffset valBeforeSearch = (DateTimeOffset)DateTime.UtcNow;
                                                booksDictionary.Search_by_book_id_dictionary();
                                                DateTimeOffset valAfterSearch = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valSearch = valAfterSearch - valBeforeSearch;
                                                string millisecondsSearch = valSearch.TotalMilliseconds.ToString(); //Converts the string to milliseconds 
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsSearch} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.PrintRecords:
                                                Stopwatch stopwatchPrint = new Stopwatch();
                                                stopwatchPrint.Start();
                                                booksDictionary.Print_all_dictionary();
                                                stopwatchPrint.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchPrint.ElapsedMilliseconds} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.DeleteRecordById:
                                                DateTimeOffset valBeforeDelete = (DateTimeOffset)DateTime.UtcNow;
                                                booksDictionary.Delete_record_dictionary();
                                                DateTimeOffset valAfterDelete = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valDelete = valAfterDelete - valBeforeDelete;
                                                string millisecondsDelete = valDelete.TotalMilliseconds.ToString(); 
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsDelete} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.MainMenu:
                                                flagSecondaryMenu = false;
                                                break;
                                            default:
                                                Console.WriteLine("\nInput is wrong and there is no such action. Please enter number from 1 to 5.\n"); //for digits input
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("\nTry again and please enter digits only."); //for non digits input
                                }
                                break;
                            }
                        case MainActions.ArrayFunctions:
                            {
                                bool flagSecondaryMenu = true;
                                while (flagSecondaryMenu == true)
                                {
                                    Console.WriteLine("\nPress button 1-5 according to the following: \n\n (1) Insert whole records to the array \n (2) Search a record by its book id \n (3) Print whole records \n (4) Delete a record by its book id \n (5) Main menu");
                                    string buttonNumber = Console.ReadLine();
                                    if (Enum.TryParse(buttonNumber, out DataStructuresActions action))
                                    {
                                        switch (action)
                                        {
                                            case DataStructuresActions.InsertRecords:
                                                Stopwatch stopwatchInsert = new Stopwatch();
                                                stopwatchInsert.Start();
                                                booksArray.Insert_all_array();
                                                stopwatchInsert.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchInsert.ElapsedMilliseconds} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.SearchById:
                                                DateTimeOffset valBeforeSearch = (DateTimeOffset)DateTime.UtcNow;
                                                booksArray.Search_by_book_id_array();
                                                DateTimeOffset valAfterSearch = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valSearch = valAfterSearch - valBeforeSearch;
                                                string millisecondsSearch = valSearch.TotalMilliseconds.ToString(); 
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsSearch} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.PrintRecords:
                                                Stopwatch stopwatchPrint = new Stopwatch();
                                                stopwatchPrint.Start();
                                                booksArray.Print_all_array();
                                                stopwatchPrint.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchPrint.ElapsedMilliseconds} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.DeleteRecordById:
                                                DateTimeOffset valBeforeDelete = (DateTimeOffset)DateTime.UtcNow;
                                                booksArray.Delete_record_array();
                                                DateTimeOffset valAfterDelete = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valDelete = valAfterDelete - valBeforeDelete;
                                                string millisecondsDelete = valDelete.TotalMilliseconds.ToString();
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsDelete} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.MainMenu:
                                                flagSecondaryMenu = false;
                                                break;
                                            default:
                                                Console.WriteLine("\nInput is wrong and there is no such action. Please enter number from 1 to 5.\n");
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("\nTry again and please enter digits only."); 
                                }
                                break;
                            }
                        case MainActions.LinkedListFunctions:
                            {
                                bool flagSecondaryMenu = true;
                                while (flagSecondaryMenu == true)
                                {
                                    Console.WriteLine("\nPress button 1-5 according to the following: \n\n (1) Insert whole records to the linked list \n (2) Search a record by its book id \n (3) Print whole records \n (4) Delete a record by its book id \n (5) Main menu");
                                    string buttonNumber = Console.ReadLine();
                                    if (Enum.TryParse(buttonNumber, out DataStructuresActions action))
                                    {
                                        switch (action)
                                        {
                                            case DataStructuresActions.InsertRecords:
                                                Stopwatch stopwatchInsert = new Stopwatch();
                                                stopwatchInsert.Start();
                                                booksLinkedList.Insert_all_linked_list();
                                                stopwatchInsert.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchInsert.ElapsedMilliseconds} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.SearchById:
                                                DateTimeOffset valBeforeSearch = (DateTimeOffset)DateTime.UtcNow;
                                                booksLinkedList.Search_by_book_id_linked_list();
                                                DateTimeOffset valAfterSearch = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valSearch = valAfterSearch - valBeforeSearch;
                                                string millisecondsSearch = valSearch.TotalMilliseconds.ToString(); 
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsSearch} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.PrintRecords:
                                                Stopwatch stopwatchPrint = new Stopwatch();
                                                stopwatchPrint.Start();
                                                booksLinkedList.Print_all_linked_list();
                                                stopwatchPrint.Stop();
                                                Console.WriteLine($"Amount of time takes the function to run: {stopwatchPrint.ElapsedMilliseconds} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.DeleteRecordById:
                                                DateTimeOffset valBeforeDelete = (DateTimeOffset)DateTime.UtcNow;
                                                booksLinkedList.Delete_record_linked_list();
                                                DateTimeOffset valAfterDelete = (DateTimeOffset)DateTime.UtcNow;
                                                TimeSpan valDelete = valAfterDelete - valBeforeDelete;
                                                string millisecondsDelete = valDelete.TotalMilliseconds.ToString();
                                                Console.WriteLine($"Amount of time takes the function to run: {millisecondsDelete} milliseconds");
                                                Console.WriteLine("\n");
                                                break;
                                            case DataStructuresActions.MainMenu:
                                                flagSecondaryMenu = false;
                                                break;
                                            default:
                                                Console.WriteLine("\nInput is wrong and there is no such action. Please enter number from 1 to 5.\n");
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("\nTry again and please enter digits only."); 
                                }
                                break;
                            }
                        case MainActions.Goodbye:
                            {
                                Console.WriteLine("Goodbye!");
                                flagMainMenu = false;
                                break;
                            }
                        default:
                            Console.WriteLine("\nInput is wrong and there is no such action. Please enter number from 1 to 5.\n"); 
                            break;
                    }
                }
                else
                    Console.WriteLine("\nTry again and please enter digits only."); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
        }
    }
}
