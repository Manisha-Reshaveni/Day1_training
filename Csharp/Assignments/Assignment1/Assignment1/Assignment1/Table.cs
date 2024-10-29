using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Table
    {
        public static void Multiplication_Table()
        {
            int num;
            Console.WriteLine("Enter Number for Multiplication table:");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{num}*{i}={num * i}");
            }
        }
        static void Main(string[] args)
        {
            Multiplication_Table();
            Console.Read();
        }
    }
}
