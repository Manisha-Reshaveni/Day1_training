using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Days
    {
        public static void StringDays()
        {
            int Day;
            Console.WriteLine("Enter a number to convert to day:");
            Day = Convert.ToInt32(Console.ReadLine());
            switch (Day)
            {
                case 0:
                    Console.WriteLine("SUNDAY");
                    break;
                case 1:
                    Console.WriteLine("MONDAY");
                    break;
                case 2:
                    Console.WriteLine("TUESDAY");
                    break;
                case 3:
                    Console.WriteLine("WEDNESDAY");
                    break;
                case 4:
                    Console.WriteLine("THURSDAY");
                    break;
                case 5:
                    Console.WriteLine("MONDAY");
                    break;
                case 6:
                    Console.WriteLine("FRIDAY");
                    break;
                case 7:
                    Console.WriteLine("SATURDAY");
                    break;
                default:
                    break;
            }

        }

        static void Main(string[] args)
        {
            StringDays();
            Console.Read();
        }
    }
}
