using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;

namespace workingWithCSVFile
{
    class Book
    {
        protected string bookID;
        protected string title;
        protected string bookAuthor;

        public Book(string bookID, string title, string bookAuthor)
        {
            this.bookID = bookID;
            this.title = title;
            this.bookAuthor = bookAuthor;
        }

        public string getBookID()
        {
            return this.bookID;
        }

        public void setBookID(string bookID)
        {
            this.bookID = bookID;
        }
        public string getTitle()
        {
            return this.title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getbookAuthor()
        {
            return this.bookAuthor;
        }

        public void setbookAuthor(string bookAuthor)
        {
            this.bookAuthor = bookAuthor;
        }

        public override string ToString()
        {
            return this.bookID + ", " + this.title + ", " + this.bookAuthor;
        }
    }
}
