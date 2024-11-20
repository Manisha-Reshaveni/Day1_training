using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Files
    {
     
        public void WriteData()
        {
                  
            FileStream fil = new FileStream("MyFile1.txt", FileMode.Append, FileAccess.Write);

            StreamWriter stream = new StreamWriter(fil);
          
            Console.WriteLine("Enter any string:");

            string str = Console.ReadLine();
            //text to file
            stream.Write(str);


            stream.Flush();
            stream.Close();
            fil.Close();
        }

    }
    class FileCreation
    {
        static void Main(string[] args)
        {

            Files obj = new Files();
            obj.WriteData();
            Console.ReadKey();

        }
    }
}

//3.Write a program in C# Sharp to append some text to an existing file.
//    If file is not available, then create one in the same workspace.
