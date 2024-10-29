using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AllOperators
    {
        public static void AllOperations()
        {
            int Number1;
            Console.WriteLine("Enter first number:");
            Number1 = Convert.ToInt32(Console.ReadLine());
            int Number2;
            Console.WriteLine("Enter second number:");
            Number2 = Convert.ToInt32(Console.ReadLine());
            char operators;
            Console.WriteLine("Input Operator:");
            operators = Convert.ToChar(Console.ReadLine());
            switch (operators)
            {
                case '+':
                    Console.WriteLine($"{Number1}+{Number2}={ Number1 + Number2}");
                    break;
                case '-':
                    Console.WriteLine($"{Number1}-{Number2}={ Number1 - Number2}");
                    break;
                case '*':
                    Console.WriteLine($"{Number1}*{Number2}={ Number1 * Number2}");
                    break;
                case '/':
                    Console.WriteLine($"{Number1}/{Number2}={ Number1 / Number2}");
                    break;
                case '%':
                    Console.WriteLine($"{Number1}%{Number2}={ Number1 % Number2}");
                    break;
                default:
                    break;
            }

        }
        static void Main(string[] args)
        {
         
           AllOperations();
            Console.Read();
        }
    }

}
