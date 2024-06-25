using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;

namespace workingWithCSVFile
{
    class BooksArray
    {
        private string filePath;
        private Book[] booksArray;

        public BooksArray(string filePath)
        {
            this.filePath = filePath;
        }
        public void Insert_all_array()
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            if (booksArray == null)
            {
                booksArray= new Book[11127];
            }
            else
            {
                Console.WriteLine("\nThe array is already filled with the records. You could press 3 to observe the whole records.");
                return;
            }
            int i = 0;
            while (i < booksArray.Length && csv.Read()) //when it reaches the end of the array, it will stop reading records
            {
                try
                {
                    string bookID = csv.GetField("bookID");
                    string title = csv.GetField("title");
                    string author = csv.GetField("authors");
                    Book newBook = new Book(bookID, title, author);
                    booksArray[i] = newBook;
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occur while reading record: {i+1}. The error: { ex.Message}");
                }
            }
            Console.WriteLine("\nRecords inserted successfully!");
        }
        public void Search_by_book_id_array()
        {
            if (booksArray == null)
            {
                Console.WriteLine("The array is empty. For insert records to the array please press 1.");
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
                    for (int i = 0; i < booksArray.Length; i++)
                    {
                        if (booksArray[i] == null) //In case a record wasn't insert or array is declered with more cells than records exisiting.
                        {
                            continue; 
                        }
                        if (booksArray[i].getBookID() == bookISBN)
                        {
                            Console.WriteLine("\nThe book's details are as follows:\nbook ID: " + bookISBN + "\ntitle: " + booksArray[i].getTitle() + "\nauthors: " + booksArray[i].getbookAuthor());
                            break;
                        }
                    }
                    Console.WriteLine("Book with ID " + bookISBN + " was not found in the array.");
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

        public void Print_all_array()
        {
            if (booksArray == null)
            {
                Console.WriteLine("The array is empty. For insert records to the array please press 1.");
                return;
            }
            int numberOfRecord = 1;
            for (int i = 0; i < booksArray.Length; i++)
            {
                if (booksArray[i] == null)
                {
                    continue;
                }
                Console.WriteLine("Record number: " + numberOfRecord + ", book ID: " + booksArray[i].getBookID() + ", title: " + booksArray[i].getTitle() + ", and authors: " + booksArray[i].getbookAuthor());
                numberOfRecord++;
            }
        }

        public void Delete_record_array()
        {
            if (booksArray == null)
            {
                Console.WriteLine("The array is empty. For insert records to the array please press 1.");
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
                        throw new Exception("ISBN is not valid. Please check you'd input just digits.");
                    }
                    for (int i = 0; i < booksArray.Length; i++)
                    {
                        if (booksArray[i] == null)
                        {
                            continue;
                        }
                        if (booksArray[i].getBookID() == bookISBN)
                        {
                            Console.WriteLine("The book: " + booksArray[i].getTitle() + " you requested to remove was deleted.");
                            booksArray[i] = null;
                            return;
                        }
                    }
                    Console.WriteLine("Book with ID " + bookISBN + " was not found in the array.");
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
