using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Swap
    {
        public static void  SwappingNumbers()
        {
            int a;
            int b ;
            Console.WriteLine($" Enter A value:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"B value:");
            b = Convert.ToInt32(Console.ReadLine());
        
            a = a+b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Swapped A value is:{a}");
            Console.WriteLine($"Swapped b value is:{b}");

        }

        static void Main(string[] args)
        {
            SwappingNumbers();
            Console.Read();
        }
    }
}
