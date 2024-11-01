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
            for (int s = 0; s < 4; s++)
            {
                if (s%2==0)
                    for (int i = 0; i < 5; i++)
                    {

                        Console.Write(a + " ");

                    }
       
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write(a);
                    }
                }
                Console.WriteLine();

            }
        }



        static void Main(string[] args)
        {
            Numbers();
            Console.Read();
        }
    }
}
