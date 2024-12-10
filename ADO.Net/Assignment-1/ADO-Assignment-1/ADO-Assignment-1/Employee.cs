using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Assignment_1
{
    class Employee
    {
      public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set;}
        public  DateTime DOJ { get; set; }
        public String City { get; set; }
        static void Main(string[] args)
        {
            List<Employee> Emplist = new List<Employee>
              {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla",
                    Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla",
                   Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai"},
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza",
                    Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh",
                    Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
               new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh",
                   Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
               new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak",
                   Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan",
                    Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
               new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey",
                   Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
              new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry",
                  Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
               new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah",
                   Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            //1. Display a list of all the employee who have joined before 1/1/2015
            var emp = Emplist.Where(e => e.DOJ<new DateTime(2015,1,1)).Select(employees => employees);
            Console.WriteLine("-------------------------------Employee who joined before 1/1/2015--------------------------");

            foreach (var Emp in emp)
            {
                Console.WriteLine(Emp.EmployeeID+"    " +Emp.FirstName+"    "+Emp.LastName+"    "+Emp.Title+"    "+Emp.DOJ.ToShortDateString()+"    "+Emp.City);
            }


            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            var empDOB = Emplist.Where(e => e.DOB > new DateTime(1990, 1, 1)).Select(name => name);
            Console.WriteLine("-------------------------------employee whose date of birth is after 1/1/1990--------------------------");
            foreach (var Emp in empDOB)
            {
              
                Console.WriteLine(Emp.EmployeeID + "    " + Emp.FirstName + "    " + Emp.LastName + "    " + Emp.Title + "    " + Emp.DOB.ToShortDateString() + "    " + Emp.City);
            }


            //3. Display a list of all the employee whose designation is Consultant and Associate
            var empDesignation = Emplist.Where(e => (e.Title== "Consultant" || e.Title== "Associate")).Select(name => name);
            Console.WriteLine("-------------------------------employee whose designation is Consultant and Associate--------------------------");
            foreach (var Emp in empDesignation)
            {

                Console.WriteLine(Emp.EmployeeID + "    " + Emp.FirstName + "    " + Emp.LastName + "    " + Emp.Title );
            }


            //4. Display total number of employees
            var EmpCount = Emplist.Count();
            Console.WriteLine("-------------------------------total number of employees--------------------------");
            Console.WriteLine("Total number of employees"+" "+EmpCount);


            //5. Display total number of employees belonging to “Chennai”
            var EmpChennai = Emplist.Count(e => e.City == "Chennai");
            Console.WriteLine("-------------------------------total number of employees belonging to Chennai--------------------------");
            Console.WriteLine("Total number of employees belonging to Chennai"+" "+EmpChennai);

            //6. Display highest employee id from the list
            var empId = Emplist.Max(e => e.EmployeeID);
            Console.WriteLine("------------------------------- Highest Employee id from the list--------------------------");
            Console.WriteLine(empId);

            //7. Display total number of employee who have joined after 1/1/2015
            var empDOJ = Emplist.Where(e => e.DOJ > new DateTime(2015, 1, 1)).Select(name => name);
            Console.WriteLine("-------------------------------Employee who have joined after 1/1/2015--------------------------");
            foreach (var Emp in empDOJ)
            {

                Console.WriteLine(Emp.EmployeeID + "    " + Emp.FirstName + "    " + Emp.LastName + "    " + Emp.Title + "    " + Emp.DOJ.ToShortDateString() + "    " + Emp.City);
            }
            //8. Display total number of employee whose designation is not “Associate”
            var EmpAss = Emplist.Where(e => e.Title!="Associate").Count();
            Console.WriteLine("-------------------------------Employee whose designation is not Associate--------------------------");
            Console.WriteLine("Total number of employee whose designation is not “Associate” " + " " + EmpAss);

            //9. Display total number of employee based on City
            var Emp_COUNT_based_OnCity = Emplist.GroupBy(e => e.City);
            Console.WriteLine("----------------------------------------------Total number of employee based on City-------------------------------------------------");
            foreach (var Emp in Emp_COUNT_based_OnCity)
            {

                Console.WriteLine("Total number of employee in"+" "+Emp.Key+":"+Emp.Count());
            }

            //10. Display total number of employee based on city and title
            var Emp_COUNT = Emplist.GroupBy(e => (e.City,e.Title));
            Console.WriteLine("----------------------------------------------Total number of employee based on City and Title-------------------------------------------------");
            foreach (var Emp in Emp_COUNT)
            {

                Console.WriteLine( Emp.Key + ":" + Emp.Count());
            }

            //11. Display total number of employee who is youngest in the list
            var young = Emplist.OrderByDescending(e => e.DOB.ToShortDateString()).Last();
            Console.WriteLine("----------------------------------------------Employee is youngest in the list-------------------------------------------------");
            Console.WriteLine("Employee is youngest in the LIST:"+young.FirstName +" "+young.LastName+" " +young.DOB.ToShortDateString());
            Console.Read();
        }
    }
}
