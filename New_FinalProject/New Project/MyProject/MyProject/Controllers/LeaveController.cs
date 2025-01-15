using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.Models.Repository;
using MyProject.Controllers;

namespace MyProject.Controllers
{
    public class LeaveController : Controller
    {
        private IRepository<EmployeeLeaveRequest> db = null;

        public LeaveController()
        {
            db = new Repository<EmployeeLeaveRequest>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplyLeave()
        {

            return View();
        }

        [HttpPost]

        public ActionResult ApplyLeave(EmployeeLeaveRequest leaveRequest)

        {

            try

            {

                // Validation: Check if leave starts in the past

                if (leaveRequest.FromDate < DateTime.Now.Date)

                {

                    ModelState.AddModelError("FromDate", "Leave cannot start in the past.");

                }

                // Validation: Check if leave is applied at least 2 days in advance

                if ((leaveRequest.FromDate - DateTime.Now.Date).TotalDays < 2)

                {

                    ModelState.AddModelError("FromDate", "Leave must be applied at least 2 days in advance.");

                }

                // Validation: Check if ToDate is earlier than FromDate

                if (leaveRequest.ToDate < leaveRequest.FromDate)

                {

                    ModelState.AddModelError("ToDate", "To Date cannot be earlier than From Date.");

                }

                // Calculate number of leave days

                leaveRequest.DaysOfLeave = (leaveRequest.ToDate - leaveRequest.FromDate).Days + 1; // Inclusive of both dates

                // Ensure leave.DaysOfLeave is positive

                if (leaveRequest.DaysOfLeave <= 0)

                {

                    ModelState.AddModelError("DaysOfLeave", "Invalid number of leave days.");

                }

                // Validation: Restrict leave to 2 per week

                try

                {

                    var weekStart = leaveRequest.FromDate.AddDays(-(int)leaveRequest.FromDate.DayOfWeek);

                    var weekEnd = weekStart.AddDays(6);

                    var weeklyLeaveCount = db.GetAll()

                        .Count(l => l.FromDate >= weekStart && l.ToDate <= weekEnd && l.EmployeeId == leaveRequest.EmployeeId);

                    if (weeklyLeaveCount + leaveRequest.DaysOfLeave > 2)

                    {

                        ModelState.AddModelError("", "You cannot apply for more than 2 leave days in a week.");

                    }

                }

                catch (ArgumentOutOfRangeException ex)

                {

                    ModelState.AddModelError("", "Weekly date calculation resulted in an out-of-range value.");

                }

                // Validation: Restrict leave to 8 per month

                try

                {

                    var monthlyLeaveCount = db.GetAll()

                        .Count(l => l.FromDate.Month == leaveRequest.FromDate.Month && l.EmployeeId == leaveRequest.EmployeeId);

                    if (monthlyLeaveCount + leaveRequest.DaysOfLeave > 8)

                    {

                        ModelState.AddModelError("", "You cannot apply for more than 8 leave days in a month.");

                    }

                }

                catch (ArgumentOutOfRangeException ex)

                {

                    ModelState.AddModelError("", "Monthly date calculation resulted in an out-of-range value.");

                }

                // If all validations pass

                if (ModelState.IsValid)

                {

                    // Set initial values for manager-related properties

                    leaveRequest.ManagerApprovalStatus = "Pending"; // Initial status

                    leaveRequest.ManagerComments = ""; // Default value

                    db.Insert(leaveRequest);

                    db.Save();

                    // Use TempData to display a success message after submission

                    TempData["SuccessMessage"] = "Leave Application is successful";

                    // Stay on the same page after success, so that the pop-up shows

                    return View(leaveRequest);

                }

            }

            catch (ArgumentOutOfRangeException ex)

            {

                ModelState.AddModelError("", "Date calculation resulted in an out-of-range value.");

            }

            return View(leaveRequest); // Stay on the same page if model is invalid

        }

        public ActionResult PendingLeaveApproval()
        {
            var pendingLeaveRequests = db.GetAll().Where(l => !l.IsApproved);
            return View(pendingLeaveRequests);
        }

        [HttpPost]
        public ActionResult ApproveLeave(int leaveRequestId)
        {
            var leaveRequest = db.GetById(leaveRequestId);
            if (leaveRequest != null)
            {
                leaveRequest.IsApproved = true;
                db.Update(leaveRequest);
                db.Save();
            }

            return RedirectToAction("PendingLeaveApproval");
        }

        [HttpPost]
        public ActionResult DeleteLeave(int leaveRequestId)
        {
            var leaveRequest = db.GetById(leaveRequestId);
            if (leaveRequest != null)
            {
                db.Delete(leaveRequestId);
                db.Save();
            }

            return RedirectToAction("PendingLeaveApproval");
        }

        [HttpPost]
        public ActionResult AcceptLeave(int id)
        {
            // Logic for accepting leave (update status, etc.)
            var leaveRequest = db.GetById(id);
            if (leaveRequest != null)
            {
                leaveRequest.ManagerApprovalStatus = "Accepted";
                db.Update(leaveRequest);
                db.Save();
            }

            // Return JSON response
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult RejectLeave(int id)
        {
            // Logic for rejecting leave (update status, etc.)
            var leaveRequest = db.GetById(id);
            if (leaveRequest != null)
            {
                leaveRequest.ManagerApprovalStatus = "Rejected";
                db.Update(leaveRequest);
                db.Save();
            }

            // Return JSON response
            return Json(new { success = true });
        }
    }


}