using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class StreamReaderWriter
    {
       
        public void WriteData()
        {
            Console.WriteLine("Enter length:");
            int length = Convert.ToInt32(Console.ReadLine());

            string[] books = new string[length];
        FileStream fil = new FileStream("MyFileNew1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter stream = new StreamWriter(fil);
           

        Console.WriteLine("Enter Array :");
            for (int i = 0; i < books.Length; i++)
            {
                books[i] = Console.ReadLine();
                stream.WriteLine(books[i]);
            }

            stream.Flush();
            stream.Close();
            fil.Close();
        }
    
    }
    class FileCreation
    {
        static void Main(string[] args)
        {
         
            StreamReaderWriter obj = new StreamReaderWriter();
            obj.WriteData();
            Console.ReadKey();

        }
    }
}

