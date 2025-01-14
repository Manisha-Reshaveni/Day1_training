using System;

using System.Collections.Generic;

using System.Linq;

using System.Web.Mvc;

using MyProject.Models;

using MyProject.Models.Repository;

namespace MyProject.Controllers

{

    public class ManagerLeaveController : Controller

    {

        private readonly IRepository<ManagerLeave> _managerLeaveRepository;

        private readonly ProjectContext _db;

        public ManagerLeaveController()

        {

            _managerLeaveRepository = new Repository<ManagerLeave>();

            _db = new ProjectContext();

        }

        // GET: ManagerLeave

        public ActionResult ManagerLeaveIndex()

        {

            return View();

        }

        public ActionResult ManagerApplyLeave()

        {

            var leave = new ManagerLeave

            {

                Holidays = new List<DateTime>

                {

                    new DateTime(DateTime.Now.Year, 1, 26), // Republic Day

                    new DateTime(DateTime.Now.Year, 3, 31), // Holi

                    new DateTime(DateTime.Now.Year, 4, 14), // Tamil New Year/Ugadi

                    new DateTime(DateTime.Now.Year, 5, 1), // Labour Day

                    new DateTime(DateTime.Now.Year, 8, 15), // Independence Day

                    new DateTime(DateTime.Now.Year, 9, 15), // Ganesh Chaturthi

                    new DateTime(DateTime.Now.Year, 9, 17), // Onam

                    new DateTime(DateTime.Now.Year, 11, 7), // Diwali

                    new DateTime(DateTime.Now.Year, 12, 25) // Christmas

                }

            };

            return View(leave);

        }

        [HttpPost]

        public ActionResult ManagerApplyLeave(ManagerLeave leave)

        {

            // Ensure holidays are loaded

            leave.Holidays = new List<DateTime>

            {

                new DateTime(DateTime.Now.Year, 1, 26), // Republic Day

                new DateTime(DateTime.Now.Year, 3, 31), // Holi

                new DateTime(DateTime.Now.Year, 4, 14), // Tamil New Year/Ugadi

                new DateTime(DateTime.Now.Year, 5, 1), // Labour Day

                new DateTime(DateTime.Now.Year, 8, 15), // Independence Day

                new DateTime(DateTime.Now.Year, 9, 15), // Ganesh Chaturthi

                new DateTime(DateTime.Now.Year, 9, 17), // Onam

                new DateTime(DateTime.Now.Year, 11, 7), // Diwali

                new DateTime(DateTime.Now.Year, 12, 25) // Christmas

            };

            // Validation: Check if leave starts in the past

            if (leave.FromDate < DateTime.Now.Date)

            {

                ModelState.AddModelError("FromDate", "Leave cannot start in the past.");

            }

            // Validation: Check if leave is applied at least 2 days in advance

            if ((leave.FromDate - DateTime.Now.Date).TotalDays < 2)

            {

                ModelState.AddModelError("FromDate", "Leave must be applied at least 2 days in advance.");

            }

            // Validation: Check if ToDate is earlier than FromDate

            if (leave.ToDate < leave.FromDate)

            {

                ModelState.AddModelError("ToDate", "To Date cannot be earlier than From Date.");

            }

            // Calculate number of leave days

            leave.DaysOfLeave = 0;

            for (var date = leave.FromDate; date <= leave.ToDate; date = date.AddDays(1))

            {

                if (!leave.Holidays.Contains(date))

                {

                    leave.DaysOfLeave++;

                }

            }

            // Ensure leave.DaysOfLeave is positive

            if (leave.DaysOfLeave <= 0)

            {

                ModelState.AddModelError("DaysOfLeave", "Invalid number of leave days.");

            }

            // Validation: Ensure leave does not overlap with public holidays

            if (leave.DaysOfLeave > 0 && Enumerable.Range(0, leave.DaysOfLeave)

                .Select(offset => leave.FromDate.AddDays(offset))

                .Any(date => leave.Holidays.Contains(date)))

            {

                ModelState.AddModelError("", "Leave cannot include public holiday dates.");

            }

            // Ensure FromDate is valid for week calculations

            if (leave.FromDate > DateTime.MinValue.AddDays(7))

            {

                // Validation: Restrict leave to 2 per week

                var weekStart = leave.FromDate.AddDays(-(int)leave.FromDate.DayOfWeek);

                var weekEnd = weekStart.AddDays(6);

                var weeklyLeaveCount = _db.ManagerLeaves

                    .Count(l => l.FromDate >= weekStart && l.ToDate <= weekEnd && l.ManagerId == leave.ManagerId);

                if (weeklyLeaveCount + leave.DaysOfLeave > 2)

                {

                    ModelState.AddModelError("", "You cannot apply for more than 2 leave days in a week.");

                }

            }

            else

            {

                ModelState.AddModelError("", "FromDate is too early for valid week calculations.");

            }

            // Validation: Restrict leave to 8 per month

            var monthlyLeaveCount = _db.ManagerLeaves

                .Count(l => l.FromDate.Month == leave.FromDate.Month && l.ManagerId == leave.ManagerId);

            if (monthlyLeaveCount + leave.DaysOfLeave > 8)

            {

                ModelState.AddModelError("", "You cannot apply for more than 8 leave days in a month.");

            }

            // If all validations pass

            if (ModelState.IsValid)

            {

                _managerLeaveRepository.Insert(leave);

                _managerLeaveRepository.Save();

                TempData["SuccessMessage"] = "Leave applied successfully.";

                return RedirectToAction("ManagerLeaveIndex");

            }

            return View(leave);

        }

    }

}