using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.Models.Repository;

namespace MyProject.Controllers
{
    public class ManagerController : Controller
    {
        public ProjectContext db = new ProjectContext();

        //--------------------Manager Timesheet-----------------------------
        // GET: Manager
        public ActionResult ManagerTimesheetIndex()
        {
            return View();

        }

        // GET: Timesheets/Create
        public ActionResult Addattendence()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addattendence(ManagerTimesheet mngtimesheet)
        {
            if (mngtimesheet.Datenow < DateTime.Today || mngtimesheet.Datenow > DateTime.Today)
            {
                ModelState.AddModelError("Datenow", "Attendance cannot be marked for past or future dates.");
            }

            if (ModelState.IsValid)
            {
                db.ManagerTimesheet.Add(mngtimesheet);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Timesheet created successfully.";
                return RedirectToAction("Addattendence");
            }

            return View(mngtimesheet);
        }

    }
}
