using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    class Program
    {
        public static void  Removechar()
        {
            string str;
            int position;
            Console.WriteLine("Enter string:");
            str = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter position:");
            position = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(str.Substring(0, position)+str.Substring(position + 1));
            //Console.WriteLine(str.Substring(position + 1));
        }
        static void Main(string[] args)
        {
            Removechar();
          
            LargestNumber.Larger();
            Count.Occurrence();
            Console.Read();
           
          
        }
    }
}
//. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
//Sample Input:
//"Python", 1
//"Python", 0
//"Python", 4
//Expected Output:
//Pthon
//ython
//Pythn
