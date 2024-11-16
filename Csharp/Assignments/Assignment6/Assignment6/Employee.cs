using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Emp
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCity { get; set; }
        public double EmployeeSalary { get; set; }
    
   
    }
    class Employee
    {
     

        static void Main()
        {

            Console.WriteLine("Enter List length:");
            int length = Convert.ToInt32(Console.ReadLine());
            List<Emp> emplist = new List<Emp> { };
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Enter Employe ID:");
                int Employee_ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employe Name:");
                string Employee_Name = Console.ReadLine();
                Console.WriteLine("Enter Employe City:");
                string Employee_City = Console.ReadLine();
                Console.WriteLine("Enter Employe Salary:");
                double Employee_Salary = Convert.ToDouble(Console.ReadLine());
                emplist.Add(new Emp { EmployeeID = Employee_ID,
                EmployeeName=Employee_Name,
                EmployeeCity=Employee_City,
                EmployeeSalary=Employee_Salary});
            }
            Console.WriteLine("-----Details of All employees--------");
            foreach (var All in emplist)
            {
                Console.WriteLine("Employee ID:{0} Name: {1} City:{2} Salary:{3} ",All.EmployeeID, All.EmployeeName, All.EmployeeCity, All.EmployeeSalary);           
            }
            Console.WriteLine("----- Employees whose salary is greater than 45000--------");
            foreach(var emp in emplist)
            {
                if (emp.EmployeeSalary > 45000)
                    Console.WriteLine(emp.EmployeeName);
            }
            Console.WriteLine("----- Employees data who belong to Bangalore Region are--------");
            foreach (var emp in emplist)
            {
                if (emp.EmployeeCity=="bengalore")
                    Console.WriteLine(emp.EmployeeName +"from"+emp.EmployeeName);
            }

            IEnumerable<Emp> Ascendingorder = emplist.OrderBy(n => n.EmployeeName);              
            Console.WriteLine("----- Employees data by their names is Ascending order -------");

            foreach (var emp in Ascendingorder)
            {
                Console.WriteLine(emp.EmployeeName);
            }
         
            Console.ReadLine();
        }
    }     

             
}

