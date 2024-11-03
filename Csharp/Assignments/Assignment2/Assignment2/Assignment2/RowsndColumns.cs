using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class RowsndColumns
    {
        public static void Numbers()
        {
            int a;
           Console.WriteLine("ENTER A VALUE:");
            a = Convert.ToInt32(Console.ReadLine());
            for (int s = 0; s < 2; s++)
            {
                Console.WriteLine("{0} {0} {0} {0}", a, a, a, a);
                Console.WriteLine("{0}{0}{0}{0}", a, a, a, a);
            }
              

            
        }



        static void Main(string[] args)
        {
            Numbers();
            Console.Read();
        }
    }
}
