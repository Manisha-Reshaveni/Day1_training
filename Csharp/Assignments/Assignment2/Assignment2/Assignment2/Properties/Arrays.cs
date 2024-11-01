using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Properties
{
    class Arrays
    {
        public static void Array()
        {
            int[] arr = new int[] { 2, 3, 4, 5,1 };
            int sum = 0;
            int min=arr[0];
            int max=arr[0];
            for(int i= 0;i< arr.Length;i++)
             
            {

                sum += arr[i];
                if (arr[i]< min)
                    min = arr[i];
                if (arr[i] >max)
                    max = arr[i];
                Console.WriteLine( "Given Array elements are: " + arr[i]);
            }
           
            Console.WriteLine($"Average of an array is {sum/arr.Length}");
            Console.WriteLine("Minimum of an array is {0} ",min);
            Console.WriteLine("Minimum of an array is {0} ", max);

        }

        static void Main(string[] args)
        {
            Array();
            Console.Read();
        }
    }
}
