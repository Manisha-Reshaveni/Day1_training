using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class SumandTriple
    {
        public static void Sum()
        {
            int val1;
            Console.WriteLine("Enter value1 for sum:");
            val1 = Convert.ToInt32(Console.ReadLine());
            int val2;
            Console.WriteLine("Enter value2 for sum:");
            val2 = Convert.ToInt32(Console.ReadLine());
            if (val1 != val2)
                Console.WriteLine($"Sum of numbers{val1 + val2}");
            else if (val1 == val2)
                Console.WriteLine($"Triple of their number{(val1 + val2) * 3}");
        }
        static void Main(string[] args)
        {
 
            Sum();
            Console.Read();
        }
    }


}
