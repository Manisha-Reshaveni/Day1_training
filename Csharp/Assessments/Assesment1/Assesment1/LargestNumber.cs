using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    class LargestNumber
    {
        public static void Larger()
        {
            int num1;
            int num2;
            int num3;
           
            Console.WriteLine("Enter any number1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any number3:");
            num3 = Convert.ToInt32(Console.ReadLine());
            int largest = (num1 > num2) ? (num1 > num3 ? num1 : num3) : (num2 > num3 ? num2 : num3);
            Console.WriteLine("THE LARGEST NUMBER IS :{0}",largest);
        }
       
    }
}
