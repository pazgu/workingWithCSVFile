using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;

namespace workingWithCSVFile
{
    class BooksDictionary
    {
        private string filePath;
        private Dictionary<string, Book> bookDictionary;
        public BooksDictionary(string filePath)
        {
            this.filePath = filePath;
        }
        public void Insert_all_dictionary()
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            if (bookDictionary != null)
            {
                Console.WriteLine("\nThe dictionary is already filled with the records. You could press 3 to observe the whole records.");
                return;
            }
            bookDictionary = new Dictionary<string, Book>();
            while (csv.Read())
            {
                try
                {
                    string bookID = csv.GetField("bookID");
                    string title = csv.GetField("title");
                    string author = csv.GetField("authors");
                    Book newBook = new Book(bookID, title, author);
                    if (bookDictionary.ContainsKey(bookID))
                    {
                        Console.WriteLine("Book with ID: " + bookID + " already exists in the dictionary."); //To avoid a duplicated key error.
                    }
                    else
                    {
                        bookDictionary.Add(bookID, newBook);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading record. The error: {ex.Message}");
                }
            }
            Console.WriteLine("\nRecords inserted successfully!");
        }

        public void Search_by_book_id_dictionary()
        {
            if (bookDictionary == null)
            {
                Console.WriteLine("The dictionary is empty. For insert records to the dictionary please press 1.");
                return;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the book's ISBN: ");
                    string bookISBN = Console.ReadLine();
                    bool isBookISBN = int.TryParse(bookISBN, out _);
                    if ((!isBookISBN) || (bookISBN == ""))
                    {
                        throw new Exception("\nISBN is not valid. Please check you'd input just digits.");
                    }
                    if (!bookDictionary.ContainsKey(bookISBN))
                    {
                        Console.WriteLine("Book with ID " + bookISBN + " was not found in the dictionary.");
                        return;
                    }
                    Console.WriteLine("\nThe book's details are as follows:\nbook ID: " + bookISBN + "\ntitle: " + bookDictionary[bookISBN].getTitle() + "\nauthors: " + bookDictionary[bookISBN].getbookAuthor());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nWhat would you like to do?\n1. Try again\n2. Go back to menu\n");
                    int userChoice;
                    while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter 1 to try again or 2 to go back to the menu.");
                    }
                    switch (userChoice)
                    {
                        case 1:
                            continue;
                        case 2:
                            return;
                    }
                }
            }
        }

        public void Print_all_dictionary()
        {
            if (bookDictionary == null)
            {
                Console.WriteLine("The dictionary is empty. For insert records to the dictionary please press 1.");
                return;
            }
            int numberOfRecord = 1;
            foreach (KeyValuePair<string, Book> record in bookDictionary)
            {
                Console.WriteLine($"Record number: {numberOfRecord}, book ID: {record.Value.getBookID()}, title: {record.Value.getTitle()}, and authors: {record.Value.getbookAuthor()}");
                numberOfRecord++;
            }
        }

        public void Delete_record_dictionary()
        {
            if (bookDictionary == null)
            {
                Console.WriteLine("The dictionary is empty. For insert records to the dictionary please press 1.");
                return;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the book's ISBN: ");
                    string bookISBN = Console.ReadLine();
                    bool isBookISBN = int.TryParse(bookISBN, out _);
                    if ((!isBookISBN) || (bookISBN == ""))
                    {
                        throw new Exception("\nISBN is not valid. Please check you'd input just digits.");
                    }
                    if (!bookDictionary.ContainsKey(bookISBN))
                    {
                        Console.WriteLine("Book with ID " + bookISBN + " was not found in the dictionary.");
                        return;
                    }
                    Console.WriteLine($"The book: {bookDictionary[bookISBN].getTitle()} you requested to remove was deleted.");
                    bookDictionary.Remove(bookISBN);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nWhat would you like to do?\n1. Try again\n2. Go back to menu\n");
                    int userChoice;
                    while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter 1 to try again or 2 to go back to the menu.");
                    }
                    switch (userChoice)
                    {
                        case 1:
                            continue;
                        case 2:
                            return;
                    }
                }
            } 
        }

    }
}
 

