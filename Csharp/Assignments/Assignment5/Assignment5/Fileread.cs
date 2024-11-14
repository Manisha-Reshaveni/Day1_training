using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Reader
    {
      public string[] names = new string[5];
        public void fileWriteData()
        {
    
            FileStream fil = new FileStream("MyFile2.txt", FileMode.Append, FileAccess.Write);
            StreamWriter stream = new StreamWriter(fil);

             

        Console.WriteLine("Enter Names :");
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Console.ReadLine();
                stream.WriteLine(names[i]);
            }

            stream.Flush();
            stream.Close();
            fil.Close();
        }
        public void fileReadData()
        {
            FileStream fil = new FileStream("MyFile2.txt", FileMode.Open, FileAccess.Read);

            int count = 0;
            foreach (var lines in names)
            {
                count++;
            }
            Console.WriteLine("number of lines in file:{0} ", count);

            fil.Close();
        }
    }
        class Fileread
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length for an array");
            int length = Convert.ToInt32(Console.ReadLine());
            Reader obj = new Reader();
            obj.fileWriteData();
            obj.fileReadData();
            Console.ReadKey();

        }
    }
}
