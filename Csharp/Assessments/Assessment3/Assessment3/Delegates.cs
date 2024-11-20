using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{

    class Delegates
    {
        delegate int Calculator(int x, int y);
        static void Main()
        {
            Console.WriteLine("Enter first parameter:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter secong parameter:");
            int y = Convert.ToInt32(Console.ReadLine());
            Operation(x, y, Addition);
            Operation(x, y, Subtraction);
            Operation(x, y, Multiply);
            Operation(x, y, Divide);
          
            Console.Read();
        }

        static void Operation(int x, int y, Calculator cal)  //delegate type as a parameter
        {
            int z = cal(x, y);
            Console.WriteLine(z);
        }
        static int Addition(int x, int y)
        {
            Console.WriteLine("-----ADDITION-------");
            return x + y;
        }
        static int Subtraction(int x, int y)
        {
            Console.WriteLine("-----SUBTRACTION-------");
            return x - y;
        }

        static int Multiply(int x, int y)
        {
            Console.WriteLine("-----MULTIPLICATION-------");
            return x * y;
        }

        static int Divide(int x, int y)
        {
            Console.WriteLine("-----DIVISION-------");
            return x / y;
        }



    }
    
}
//Write a console program that uses delegate object as an argument to call Calculator Functionalities
//    like 1. Addition, 2. Subtraction and 3. Multiplication
//    by taking 2 integers and returning the output to the user. You should display all the return values accordingly.
