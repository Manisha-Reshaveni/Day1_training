using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class CriketTeam
    {
        public int Matches { get; set; }
        public int sum { get; set; }
        public double Average { get; set; }

        public void Pointscalculation(int NumberofMatches)
        {
            sum = 0;
           
            for(int i=0;i<NumberofMatches;i++)
            {
                Console.WriteLine($"Enter Score for match{i + 1}");
                sum += Convert.ToInt32(Console.ReadLine());
            
            }
      
            Matches = NumberofMatches;
            Average = (double)sum / NumberofMatches;
          
        }
        public void display()
        {
          
            Console.WriteLine($"Number of matches:{Matches}");
            Console.WriteLine("----------sum of scores---------");
            Console.WriteLine($"sum of Scrores:{sum}");
            Console.WriteLine("----------Average of scores---------");
            Console.WriteLine($"average of scores:{Average}");
          


        }

    }
    class Driver
    {
       

        static void Main(string[] args)
        {
            CriketTeam criketobj = new CriketTeam();
            Console.WriteLine("Enter number of matches");
            int noofmatches = Convert.ToInt32(Console.ReadLine());
          
            criketobj.Pointscalculation(noofmatches);
            criketobj.display();
            Console.Read();
        }
    }
}
//. Write a program to find the Sum and the Average points scored by the teams in the IPL.
//    Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that 
//    takes no.of matches as input and accepts that many scores from 
//    the user. The function should then return the Count of Matches, Average and Sum of the scores.
