using System;
using CalculatorLibrary;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter Name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int Age = Convert.ToInt32(Console.ReadLine());

            Class1 obj = new Class1();
            obj.CalculateConcession(Name, Age);
            Console.Read();
        }
    }
}
