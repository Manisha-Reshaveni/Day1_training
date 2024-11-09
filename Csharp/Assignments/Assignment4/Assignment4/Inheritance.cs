using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Employee
    {
        int Empid;
        string Empname;
        float Salary;
        public Employee(int EmployeeID,string EmpName,float Salary)
        {
            this.Empid = EmployeeID;
            this.Empname = EmpName;
            this.Salary = Salary;
        }
        public void Display()
        {
            Console.WriteLine("EmployeID:{0}",Empid);
            Console.WriteLine("EmployeName:{0}", Empname);
            Console.WriteLine(" EmployeName:{0}", Salary);
        }
    }
    class parttime : Employee
    {
        public int wages;
        public parttime(int EmployeeID, string EmpName, float Salary):base(EmployeeID, EmpName, Salary)
        {
        }
    }
    class Inheritance
    {
        public static void Main()
        {
            Console.WriteLine("Enter EmployeID:");
            int EmpID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employe name:");
            string EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employe salary:");
            float EmpSalary = Convert.ToInt32(Console.ReadLine());
            parttime obj = new parttime(EmpID, EmpName, EmpSalary);
            obj.Display();
            Console.Read();
        }
    }
}



