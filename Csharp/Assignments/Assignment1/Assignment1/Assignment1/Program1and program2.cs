using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class EqualNumbers
    {
        static void Numbers()
        {
            int firstvalue;
            int secondvalue;
            Console.WriteLine("Enter first value :");
            firstvalue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second value:");
            secondvalue = Convert.ToInt32(Console.ReadLine());
            
            if (firstvalue == secondvalue)
                Console.WriteLine("{0} and {1} are Equal", firstvalue, secondvalue);
            else
                Console.WriteLine("{0} and {1} are not Equal", firstvalue, secondvalue);
        }
        class CheckNumber
        {
            public static void PositiveorNegative()
            {
                int value;
                Console.WriteLine("Enter Test Data:");
                value = Convert.ToInt32(Console.ReadLine());

                if (value>0)
                    Console.WriteLine("{0} is a positive number", value);
                if (value<0)
                    Console.WriteLine("{0} is a negative number", value);
            }
        }
        class Operators
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
                    operators= Convert.ToChar(Console.ReadLine());
                switch(operators)
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
        }
        
        static void Main(string[] args)
        {
            Numbers();
            CheckNumber. PositiveorNegative();
            Operators.AllOperations();
            Console.Read();
        }
    }
}
