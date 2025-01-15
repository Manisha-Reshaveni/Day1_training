using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models.Repository;
using MyProject.Models;
using System.Web.Security;

namespace MyProject.Controllers
{
    public class ProjectController : Controller
    {
       // IRepository<EmployeeLogin> _employeeRepository = null;
        IRepository<ManagerLogin> _managerRepository = null;
        private IRepository<EmployeeDetails> _emprepo = null;
        IRepository<ProjectDetails> _project = null;
        public ProjectController()
        {
           // _employeeRepository = new Repository<EmployeeLogin>();
            _managerRepository = new Repository<ManagerLogin>();
            _emprepo = new Repository<EmployeeDetails>();
            _project = new Repository<ProjectDetails>();
        }
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult SignUpEmployee()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult SignUpEmployee(EmployeeLogin employee)
        //{
        //    .Insert(employee);
        //    _employeeRepository.Save();
        //    return RedirectToAction("ManagerDashboard");
        //}
       // Action method for EmployeeLogin
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeLogin(EmployeeDetails model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidEmployee(model.EmpID, model.Password))
                {
                    //var v = _emprepo.GetById(model.EmployeeID);
                    EmployeeDetails v = _emprepo.GetById(model.EmpID);
                    SetUserDataInSession(v);


                    return RedirectToAction("EmployeeDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
        private void SetUserDataInSession(EmployeeDetails user)
        {
            // Store user data in session
            Session["Name"] = user.Employeename;
            Session["EmpID"] = user.EmpID;
            Session["Grade"] = user.Grade;
            Session["Designation"] = user.Designation;
           // Session["Username"] = user.Username;
            
        }
        private EmployeeDetails GetUserDataFromSession()
        {
            // Retrieve user data from session
           int EmployeeID = (int)Session["EmpID"];
            string username = (string)Session["Name"];
            string Grade=(String)Session["Grade"];
            string Designation = (string)Session["Designation"];
            // Retrieve other user properties as needed

            // Create a User object and return it
            EmployeeDetails user = new EmployeeDetails
            {
                EmpID = EmployeeID,
                Employeename = username,
                Grade = Grade,
                Designation = Designation
            };

            return user;
        }
        private void SetManagerDataInSession(ManagerLogin user)
        {
            // Store user data in session
            Session["Name"] = user.Name;
            Session["ManagerID"] = user.ManagerID;
            Session["Grade"] = user.Grade;
            Session["Designation"] = user.Designation;
            Session["Status"] = user.Status;
            Session["Phone"] = user.Phone;
            Session["Email"] = user.Email;
            
            // Session["Username"] = user.Username;

        }
        private ManagerLogin GetManagerDataFromSession()
        {
            // Retrieve user data from session
            
            string ManagerName = (string)Session["Name"];
            int ManagerID = (int)Session["ManagerID"];
            string Phone = (String)Session["Phone"];
            string Status = (string)Session["Status"];
            String Email = (String)Session["Email"];
            string Grade = (String)Session["Grade"];
            string Designation = (string)Session["Designation"];
            // Retrieve other user properties as needed

            // Create a User object and return it
            ManagerLogin user = new ManagerLogin
            {
                ManagerID = ManagerID,
                Name = ManagerName,
                Grade = Grade,
                Designation = Designation,
                Status = Status,
                Phone = Phone,
                Email = Email,


            };

            return user;
        }

        public ActionResult EmployeeDashboard(EmployeeDetails v)
        {
            EmployeeDetails user = GetUserDataFromSession();

            return View(user);
            //return View(v);
        }

        public ActionResult SignUpManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpManager(ManagerLogin manager)
        {
            _managerRepository.Insert(manager);
            _managerRepository.Save();
            return RedirectToAction("ManagerLogin");
        }
        // Action method for ManagerLogin
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(ManagerLogin model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidManager(model.Name, model.Password))
                {
                    ManagerLogin v = _managerRepository.GetById(model.Name);
                    SetManagerDataInSession(v);
                    return RedirectToAction("ManagerDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        public ActionResult ManagerDashboard()
        {
            var user = GetManagerDataFromSession();
            return View(user);
        }

        private bool IsValidEmployee(int Employeeid, string password)
        {
            var employee = _emprepo.GetAll().FirstOrDefault(e => e.EmpID == Employeeid && e.Password == password);
            return employee != null;
        }

        private bool IsValidManager(string name, string password)
        {
            var manager = _managerRepository.GetAll().FirstOrDefault(e => e.Name == name && e.Password == password);
            return manager != null;
        }

        // Additional action method for Employee details
        public ActionResult EmployeeDetails(string Name)
        {
            var employee = _emprepo.GetById(Name);
            return View(employee);
        }

        // Additional action method for Manager details
        public ActionResult ManagerDetails(int id)
        {
            var manager = _managerRepository.GetById(id);
            return View(manager);
        }
        //Employee index-----------------------------------------------------------------------------
        public ActionResult EmployeeIndex()
        {
            var employees = _emprepo.GetAll();
            return View(employees);
        }
        public ActionResult EmployeeCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeCreate(EmployeeDetails emp)
        {
            if (ModelState.IsValid)
            {
                _emprepo.Insert(emp);
                _emprepo.Save();
                return RedirectToAction("EmployeeIndex");
            }
            else
            {
                return View();
            }
        }
        public ActionResult EmployeeDisplay( int id)
        {
            var emp = _emprepo.GetById(id);
            return View(emp);
        }
        public ActionResult EmployeeDelete(int id)
        {
            _emprepo.Delete(id);
            _emprepo.Save();
            return RedirectToAction("EmployeeIndex");
        }
        public ActionResult EmployeeEdit(int id)
        {
            var emp = _emprepo.GetById(id);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeEdit(EmployeeDetails emp)
        {
            if (ModelState.IsValid)
            {
                _emprepo.Update(emp);
                _emprepo.Save();
                return RedirectToAction("EmployeeIndex");
            }
            else
            {
                return View(emp);
            }
        }

        // ProjectIndex-----------------------------------------------------------------------------
        public ActionResult ProjectIndex()
        {
            var pro = _project.GetAll();
            return View(pro);
        }
        public ActionResult ProjectCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjectCreate(ProjectDetails pro)
        {
            if (ModelState.IsValid)
            {
                _project.Insert(pro);
                _project.Save();
                return RedirectToAction("ProjectIndex");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ProjectDisplay(int id)
        {
            var pro = _project.GetById(id);
            return View(pro);
        }
        public ActionResult ProjectDelete(int id)
        {
            _project.Delete(id);
            _project.Save();
            return RedirectToAction("ProjectIndex");
        }
        public ActionResult ProjectEdit(int id)
        {
            var pro = _project.GetById(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult ProjectEdit(ProjectDetails pro)
        {
            if (ModelState.IsValid)
            {
                _project.Update(pro);
                _project.Save();
                return RedirectToAction("ProjectIndex");
            }
            else
            {
                return View(pro);
            }
        }


        //--------------------------------------------------------------------------------------
        // Additional action method for Employee creation
        public ActionResult CreateEmployee()
        {
            return View();
        }

        // Additional action method for Manager creation
        public ActionResult CreateManager()
        {
            return View();
        }

        // Additional action method to handle form submission for creating Employee
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeDetails employee)
        {
            _emprepo.Insert(employee);
            _emprepo.Save();

            return RedirectToAction("EmployeeLogin");
        }

        // Additional action method to handle form submission for creating Manager
        [HttpPost]
        public ActionResult CreateManager(ManagerLogin manager)
        {
            _managerRepository.Insert(manager);
            _managerRepository.Save();

            return RedirectToAction("ManagerLogin");
        }
    }
}