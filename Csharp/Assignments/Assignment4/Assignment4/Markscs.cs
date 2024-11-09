using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Scholarship
    { 
         double  scholarship_Amount;
     public void  Merits(int marks,double fees)
        {
          

            if (marks>= 70 && marks<= 80)
            {
              scholarship_Amount= fees * ((double)20/100);
                Console.WriteLine(scholarship_Amount);
               
            }
            if (marks >= 80 && marks <= 90)
            {
                scholarship_Amount = fees * ((double)30 / 100);
                Console.WriteLine(scholarship_Amount);
            }
            if (marks> 90)
            {
                scholarship_Amount = fees * ((double)50 / 100);
                Console.WriteLine(scholarship_Amount);
            }
        }
    }
    class Markscs
    {
        static void Main()
        {
            Console.WriteLine("Enter student marks:");
           int  marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter student fees:");
            double fees = Convert.ToDouble(Console.ReadLine());
           
            Scholarship obj = new Scholarship();
           obj.Merits(marks,fees);
            Console.Read();
        }
    }
}
