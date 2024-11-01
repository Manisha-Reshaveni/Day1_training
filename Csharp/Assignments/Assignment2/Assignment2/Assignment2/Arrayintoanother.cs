
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment2
{
    class Arrayintoanother
    {
        public static void Array()
        {
            int[] Array1 = new int[] { 1, 2, 3, 4, 3 };
            int[] Array2 = new int[5];
            int index = 0;
            Console.WriteLine("Array1 elements are:");
            foreach (int item in Array1)
            {
                Array2[index] = item;
                Console.WriteLine( item);
                index++;
            }
            Console.WriteLine("Array2 elements are:");
            Console.WriteLine(string.Join(" ",Array2));
        }
        static void Main(string[] args)
        {
            Array();
            Console.Read();
        }
    }
  
}