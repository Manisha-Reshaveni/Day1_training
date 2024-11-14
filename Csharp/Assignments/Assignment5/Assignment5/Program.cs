using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Books
    {
        string BookName;
        string AuthorName;
     
        public Books(string bookname, string authorname)
        {
            this.BookName = bookname;
            this.AuthorName = authorname;
        }
        public void BooksDisplay()
        {
           
                Console.WriteLine($"------------- Details of Book------------");
                Console.WriteLine("Book Name:{0} ", BookName);
                Console.WriteLine("Author Name:{0}", AuthorName);

            
        }

    }
    class BookShelf
    {
        Books[] bobj = new Books[5];  // composition/aggregation 

        public Books this[int i]
        {
            get
            {
                return bobj[i];
            }
            set { bobj[i] = value; }
        }

    }
    class Program
    { 
      
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Bookname:");
            string bookname = Console.ReadLine();
            Console.WriteLine("Enter AuthorName:");
            string authorname = Console.ReadLine();
            Books obj1 = new Books(bookname, authorname);
            obj1.BooksDisplay();

            BookShelf fv = new BookShelf();
            for (int i = 0; i < 5; i++)
            {
     
                Console.WriteLine("Enter {0} Bookname:", i + 1);
                string book_name = Console.ReadLine();
                Console.WriteLine("Enter AuthorName:", i + 1);
                string author_name = Console.ReadLine();
                fv[i] = new Books(book_name, author_name);
            }

            for (int i = 0; i < 5; i++)
            {
                fv[i].BooksDisplay();
            }

            Console.Read();
        }
    }
}
 
