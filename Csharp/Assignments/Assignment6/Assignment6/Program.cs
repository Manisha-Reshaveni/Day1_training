using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter List length:");
            int length = Convert.ToInt32(Console.ReadLine());
         
            List<int> numbers = new List<int> { };
            for(int i=1;i<length;i++)
            {
                Console.WriteLine("enter list inputs:"+i);
                int a= Convert.ToInt32(Console.ReadLine());
                numbers.Add(a);

            }
            foreach (var value in numbers)
                {
                    Console.Write("{0} ", value);
                }         
                var square = numbers.Select(x => x * x);

                Console.WriteLine("-----Squares of Numbers------");
                foreach (int n in square)
                {
                  if(n>20)
                {
                    Console.WriteLine(n);
                }

                }
            Console.Read();
        }
    }
}
