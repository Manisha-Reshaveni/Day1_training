using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    class Count
    {
        public static void Occurrence()
        {
            string str;
            char letters;
            int occurance = 0;
            Console.WriteLine("Enter string:");
            str = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter character for find occurance :");
            letters = Console.ReadLine()[0];
            foreach(char c in str)
            {
                if (c== letters)
                    occurance++;
            }
            Console.WriteLine("occurance of the given charcter :" + occurance);
        }
    }
}
