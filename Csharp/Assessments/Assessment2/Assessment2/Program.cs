using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract  class Student
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public double Grade { get; set; }
        public abstract  bool Ispassed(double  grade);
    }
    class Undergraduate:Student
    {
        
        public override bool Ispassed(double  grade)
        {
            if(grade>=70)
            {
                Console.WriteLine("Student udergraduate is passed");
            }
            
            return grade<=70;
        }
    }
    class Graduate:Student
    {
        public override bool Ispassed(double grade)
        {
            if (grade >= 80)
            {
                Console.WriteLine("Student graduate is passed");
            }
            return grade <= 80;


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter student ID:");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter student grade:");
            int grade = Convert.ToInt32(Console.ReadLine());
            Undergraduate uobj = new Undergraduate();
            uobj.Ispassed(grade);

            Console.WriteLine("Enter student name:");
            string gName = Console.ReadLine();
            Console.WriteLine("Enter student ID:");
            int gID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter student grade:");
            int gstudentgrade = Convert.ToInt32(Console.ReadLine());
            Graduate gobj = new Graduate();
       
            gobj.Ispassed(gstudentgrade);
            Console.Read();

        }
    }
}

