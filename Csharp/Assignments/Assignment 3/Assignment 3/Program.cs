using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Length
    {
        public static void Length_string()
        {

            Console.WriteLine("Enter any string:");
            string str = Console.ReadLine();
            int length = str.Length;
            Console.WriteLine("Length of string:{0}", length);
            Console.WriteLine("Reversed string is:");
            string reversed =" ";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversed += str[i];
               
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }
     
        public static void Sameornot()
        {
            Console.WriteLine("Enter first word:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter second word:");
            string second = Console.ReadLine();
            if (first == second)
            {
                Console.WriteLine("First and second words are same");
            }
            else
            {
                Console.WriteLine("Both words are not same");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Length.Length_string();
            Length.Sameornot();
            Accounts a1 = new Accounts();
        

            //a1.Credit();
            //a1.Debit();
            Console.Read();
        }
    }
  
}
