using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class ArgumentException : ApplicationException
    {
        public ArgumentException(string msg) : base(msg)
        {

        }
    }
        class Integers
        {
            static void CHECKNUM(int num)
            {
                try
                {
                    if (num < 0)
                    {
                        throw new ArgumentException("number cannot zero enter number is positive");
                    }
                    else
                    {
                        Console.WriteLine("number is is positive");
                    }
                }
                catch (ArgumentException aa)
                {
                    Console.WriteLine("ERROR:" + aa.Message);

                }

            }
        static void Main()
        {
            Console.WriteLine("Enter number");
            int num = Convert.ToInt32(Console.ReadLine());
            CHECKNUM(num);
            Console.Read();
        }
        }

      
    
}
