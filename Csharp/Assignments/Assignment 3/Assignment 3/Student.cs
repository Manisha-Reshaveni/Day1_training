using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Student
    {
        public int RollNo;
        public string Name;
        public string ClassName;
        public int Semester;
        public string Branch;
        public int[] marks = new int[5];
        public Student(int rollno, string name, string classname, int sem, string branch)
        {
            RollNo = rollno;
            Name = name;
            ClassName = classname;
            Semester = sem;
            Branch = branch;
        }
        public void Get_Marks()
        {
         
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("Enter the subject {0} marks", i + 1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
               
            }
           
        }

    }
    class Display : Student
    {
        public Display(int rollno, string name, string classname, int sem, string branch): base(rollno, name, classname, sem, branch)
        {
            Console.WriteLine("this is constructor");
        }
        public void DisplayResult()
        {
            int sum = 0;
            float average;

            for (int j = 0; j < marks.Length; j++)
            {
                if (marks[j] < 35)
                {
                    Console.WriteLine("Failed in subject {0}", j + 1);
                }
            }
            for(int k=0;k<marks.Length;k++)
            {
                sum = sum + marks[k];
            }
            Console.WriteLine("sum of marks of a student:"+sum);
            Console.WriteLine("Average of student marks:{0}", sum / marks.Length);
            average = sum / marks.Length;
            bool result = false;
            for (int l = 0; l < marks.Length; l++)
            {
                if (average > 50 && marks[l] < 35)
                {
                    result = true;
                    Console.WriteLine("Student Failed in subject {0} ", l + 1);
                }
            }
          
           
                if(result||average<50)
                {
                    Console.WriteLine("STUDENT FAILED!");
                }
                else
                {
                    Console.WriteLine("STUDENT PASSED");
                }
            
        }
        public void DisplayData()
        {
            Console.WriteLine("Student Roll No : {0}", RollNo);
            Console.WriteLine("Student Name : {0}", Name);
            Console.WriteLine("Class : {0}", ClassName);
            Console.WriteLine("Semester : {0}", Semester);
            Console.WriteLine("Branch : {0}", Branch);
        }


    }
    class Inheritance2
    {
        public static void Main()
        {
            Console.WriteLine("Enter the student roll");
            int rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the student class");
            string classname = Console.ReadLine();
            Console.WriteLine("Enter the semester");
            int sem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student branch");
            string branch = Console.ReadLine();

            Display d = new Display(rollno, name, classname, sem, branch);
            d.Get_Marks();
            Console.WriteLine();
            Console.WriteLine(" *****Result of student******");
            Console.WriteLine();
            d.DisplayResult();
            Console.WriteLine();
            Console.WriteLine("******Student Details*******");
            Console.WriteLine();
            d.DisplayData();
            Console.Read();

        }
    }
}
