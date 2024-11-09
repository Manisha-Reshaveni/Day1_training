using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Doctor
    {
        private  int RegnNo;
        private string Name;
        private double Feescharged;
        public int regnNo
        {
            get{ return RegnNo; }
            set { RegnNo = value; } 
        }
        public string name
        {
            get
            { return Name; }
            set { Name = value; }

        }
        public double feescharged
        {
            get { return Feescharged; }
            set { Feescharged = value; }
        }
        public void DoctorDisplay()
        {
            Console.WriteLine("----------Display details of Doctor----------");
            Console.WriteLine("Registration Number:{0} ", regnNo);
            Console.WriteLine("Name:{0}", name);
            Console.WriteLine("Fee charged :{0} ", feescharged);
         
        }

    }
    class Books
    {
         string  Book_Name;
        string  Author_Name;
        //public string bookname
        //{
        //    get { return Book_Name; }
        //    set { Book_Name = value; }
        //}
        //public string authorname
        //{
        //    get { return Author_Name; }
        //    set { Author_Name = value; }
        //}
        public Books(string bookname,string authorname)
        {
            this.Book_Name = bookname;
            this.Author_Name = authorname;
        }
        public void BokksDisplay()
        {
            Console.WriteLine("------------- Detailds of BooksIndexers------------");
            Console.WriteLine("Book Name:{0} ", Book_Name);
            Console.WriteLine("Author Name:{0}", Author_Name);
           

        }

    }  
    class BookShelf
    {
        Books[] indexobj = new Books[5];  // composition/aggregation 

        public Books this[int i]
        {
            get
            {
                return indexobj[i];
            }
            set { indexobj[i] = value; }
        }

    }
    class Medical
    {
       
          public static void Main()
          {
           
            Doctor obj = new Doctor();
            Console.WriteLine("Enter Registration Number:");
            int registrationno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            string name= Console.ReadLine();
            Console.WriteLine("Enter Fee Charge:");
            double Feecharge = Convert.ToDouble(Console.ReadLine());
            obj.regnNo = registrationno;
            obj.name = name;     
            obj.feescharged = Feecharge;
            obj.DoctorDisplay();
            Console.WriteLine("-------------BooksandAuthor------------");
            Console.WriteLine("Enter Bookname:");
            string bookname = Console.ReadLine();
            Console.WriteLine("Enter AuthorName:");
            string authorname = Console.ReadLine();
            Books obj1 = new Books(bookname, authorname);
            obj1.BokksDisplay();
            Console.WriteLine("-------------BooksIndexers------------");
           
            BookShelf fv = new BookShelf();
           for(int i=0;i<5;i++)
            {
                Console.WriteLine("Enter {0} Bookname:",i+1);
                string book_name = Console.ReadLine();
                Console.WriteLine("Enter AuthorName:",i+1);
                string author_name = Console.ReadLine();
                fv[i] = new Books(book_name, author_name);
            }
         
                for (int i = 0; i < 5; i++)
                {
                    fv[i].BokksDisplay();
                }

            Console.Read();


          }
    }
}







