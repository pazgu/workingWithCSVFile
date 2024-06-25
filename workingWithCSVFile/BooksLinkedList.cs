using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;

namespace workingWithCSVFile
{
    class Node<T>
    {
        private Book record;
        private Node<Book> next;
        private string filePath;
        public Node(string filePath) 
        {
            this.filePath = filePath;
        }
        private Node(Book record, string filePath)
        {
            this.record = record;
            this.next = null;
            this.filePath = filePath;
        }

        public Book GetValue()
        {
            return this.record;
        }

        public Node<Book> GetNext()
        {
            return this.next;
        }

        public void SetValue(Book record)
        {
            this.record = record;
        }

        public void SetNext(Node<Book> next)
        {
            this.next = next;
        }

        public override string ToString()
        {
            return this.record.ToString();
        }

        public bool HasNext()
        {
            return (this.next != null);
        }
        public void Insert_all_linked_list()
        {
            if (next != null)
            {
                Console.WriteLine("\nThe linked list is already filled with the records. You could press 3 to observe the whole records.");
                return;
            }
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            Node<Book> firstNode = null;
            while (csv.Read())
            {
                try
                {
                    string bookID = csv.GetField("bookID");
                    string title = csv.GetField("title");
                    string author = csv.GetField("authors");
                    Book newBook = new Book(bookID, title, author);
                    Node<Book> newNode = new Node<Book>(newBook, filePath);
                    if (next == null) //for the first node to be initialized 
                    {
                        next = newNode;
                    }
                    else 
                    {
                        firstNode.SetNext(newNode); //sets last node to point to the new node
                    }
                    firstNode = newNode; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading record. The error: {ex.Message}");
                }
            }
            Console.WriteLine("\nRecords inserted successfully!");
        }

        public void Search_by_book_id_linked_list()
        {
            if (next == null)
            {
                Console.WriteLine("The linked list is empty. For insert records to the array please press 1.");
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
                    Node<Book> firstNode = next;
                    while (firstNode != null) 
                    {
                        if (firstNode.GetValue() == null) //for a case record was not insert to the node 
                        {
                            firstNode = firstNode.GetNext();
                            continue;
                        }
                        if (firstNode.GetValue().getBookID() == bookISBN)
                        {
                            Console.WriteLine("\nThe book's details are as follows: book id: " + firstNode.ToString());
                            return;
                        }
                        firstNode = firstNode.GetNext();
                    }
                    Console.WriteLine("Book with ISBN " + bookISBN + " was not found.");
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

        public void Print_all_linked_list()
        {
            if (next == null)
            {
                Console.WriteLine("The linked list is empty. To insert records to the linked list please press 2.");
                return;
            }
            Node<Book> firstNode = next;
            int numberOfRecord = 1;
            while (firstNode != null)
            {
                if (firstNode.GetValue() == null) 
                {
                    firstNode = firstNode.GetNext();
                    continue;
                }
                Console.WriteLine("Record number: " + numberOfRecord + ", book id: " + firstNode.ToString());
                firstNode = firstNode.GetNext();
                numberOfRecord++;
            }
        }

        public void Delete_record_linked_list()
        {
            if (next == null)
            {
                Console.WriteLine("The linked list is empty. For insert records to the linked list please press 1.");
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
                        throw new Exception("ISBN is not valid. Please check your input just contains digits.");
                    }
                    Node<Book> firstNode = next;
                    Node<Book> previousNode = null; //helps me modify the next property of the previous node exisiting before the node I want to remove
                    while (firstNode != null)
                    {
                        if (firstNode.GetValue() == null) //for a case record was not insert to the node 
                        {
                            firstNode = firstNode.GetNext();
                            continue;
                        }
                        if (firstNode.GetValue().getBookID() == bookISBN)
                        {
                            if (previousNode == null) //if this node is the first in the list
                            {
                                next = next.GetNext(); // update the reference to the next node in the list (and by that modifies the head node of the list)
                            }
                            else
                            {
                                previousNode.SetNext(firstNode.GetNext()); //connects between the previous node and the node after the one that has been removed
                            }
                            Console.WriteLine("The book: " + firstNode.GetValue().getTitle() + " you requested to remove was deleted.");
                            return;
                        }
                        previousNode = firstNode;
                        firstNode = firstNode.GetNext();
                    }
                    Console.WriteLine("Book with ID " + bookISBN + " was not found in the linked list.");
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
