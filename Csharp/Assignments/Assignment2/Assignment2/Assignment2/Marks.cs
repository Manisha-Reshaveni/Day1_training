using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Marks
    {
        public static void Markslist()
        {
            int[] marks = new int[10];
            int total = 0;
            int min = marks[0];
            int max = marks[0];

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Subject{i + 1 + " "}");
                marks[i] = Convert.ToInt32(Console.ReadLine());
                total += marks[i];
   
                if (marks[i] > max)
                    max = marks[i];
                if (marks[i]<min)
                    min = marks[i];

            }
            Console.WriteLine("Total of array elements is:{0}", (double)total);
            Console.WriteLine("Average of array elements is:{0}", (double)total /marks.Length);
            Console.WriteLine("Maximum of array elements is:{0}", max);
            Console.WriteLine($"Minimum of array elements is:{min}");
            Console.WriteLine("Ascending order:");
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = i+1; j < marks.Length; j++)
                {
                    if (marks[i] > marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }
                   
                }
    
                Console.WriteLine( marks[i]);
            }
            Console.WriteLine("Descending order:");
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {
                    if (marks[i] < marks[j])
                    {
                        int temp = marks[i];
                        marks[i] = marks[j];
                        marks[j] = temp;
                    }

                }

                Console.WriteLine(marks[i]);
            }
           
        

            // for(int i = 0; i < 10; i++)
            //  {
            //     Console.WriteLine($"Ascending order {marks[i]}");
            // }

        }

        static void Main(string[] args)
        {
            Markslist();
            Console.Read();
        }
    }
}
