
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
            int[] Array2 = new int[Array1.Length];
            Console.WriteLine("Array1 elements are:");
            for (int i=0;i<Array1.Length;i++)
            {          
                Console.WriteLine(Array1[i]);
                Array2[i] = Array1[i];
            }
            Console.WriteLine("The elements of Array1 are copied into Array2: ");
            for(int j=0;j<Array2.Length;j++)
            {
                Console.WriteLine(Array2[j] + " ");
            }
           /* foreach (int item in Array1)
            {
                Array2[index] = item;
                Console.WriteLine( item);
                index++;
            }
            Console.WriteLine("Array2 elements are:");
            Console.WriteLine(string.Join(" ",Array2));*/
        }
        static void Main(string[] args)
        {
            Array();
            Console.Read();
        }
    }
  
}