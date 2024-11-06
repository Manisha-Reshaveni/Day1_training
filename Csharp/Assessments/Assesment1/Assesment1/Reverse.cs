using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    class Reverse
    {
        public static string  Reversed(string str)
        {
            char[] arr = str.ToCharArray();
            char temp = ' ';
            int n = str.Length;
            temp = arr[0];
            arr[0] = arr[n - 1];
            arr[n - 1] = temp;
            string res = string.Join( "",arr);
            return res;
          
          
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any string:");
            string str = Console.ReadLine();
            Console.WriteLine("Changed string is:"+Reversed( str));
            Console.Read();

        }
    }
     
          
    
}
