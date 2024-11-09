using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{

  

    interface Istudent
    {
       
        string Name { get; set; }
        int studentId { get; set; }

        void ShowDetails();
    }

    class Dayscholar : Istudent
    {
        public int studentId { get; set; }
        public string Name { get; set; }
        public void ShowDetails()
        {
            Console.WriteLine("*************Dayscholar student Details****************");
            Console.WriteLine("Name of the student:{0}", Name);
            Console.WriteLine("student ID:{0}", studentId);
        }
    }
    class Resident : Istudent
    {
        public int studentId { get; set; }
        public string Name { get;  set; }
        public void ShowDetails()
        {
            Console.WriteLine("*************Resident student Details****************");
            Console.WriteLine("Name of the student:{0}", Name);
            Console.WriteLine("student ID:{0}", studentId);
        }
    }

    class Interface
    {
        static void Main()
        {
            Console.WriteLine("*************Enter Dayscholar student Details****************");
            Console.WriteLine("Enter Student id:");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name:");
            string  studenName = Console.ReadLine();
            Istudent obj = new Dayscholar();
            obj.studentId = Id;
            obj.Name = studenName;
            obj.ShowDetails();
            Console.WriteLine("*************Enter Resident student Details****************");
            Console.WriteLine("Enter Student id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name:");
            string Name = Console.ReadLine();
            Resident obj2 = new Resident();
            obj2.Name = Name;
            obj2.studentId = id;
            obj2.ShowDetails();

            Console.Read();
        }

    }
}
//5.Create an Interface IStudent with StudentId and Name as Properties, void ShowDetails() as its method.Create 2 classes
//    Dayscholar and Resident that implements the interface Properties and Methods
