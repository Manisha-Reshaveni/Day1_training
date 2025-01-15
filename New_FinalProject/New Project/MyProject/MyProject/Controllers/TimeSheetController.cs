using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.Models.Repository;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MyProject.Controllers
{
    public class TimesheetsController : Controller
    {
        private ProjectContext db = new ProjectContext();


        // GET: Timesheets
        public ActionResult Index()
        {
            var timesheets = db.Timesheets.ToList();
            return View(timesheets);
        }

        // GET: Timesheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // GET: Timesheets/Create
        public ActionResult Addattendence()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addattendence(Timesheet timesheet)
        {
            if (timesheet.Datenow < DateTime.Today || timesheet.Datenow > DateTime.Today)
            {
                ModelState.AddModelError("Datenow", "Attendance cannot be marked for past or future dates.");
            }
            if (ModelState.IsValid)
            {
                db.Timesheets.Add(timesheet);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Timesheet created successfully!";


            }

            return View(timesheet);
        }

        // GET: Timesheets/Edit/5
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Timesheet timesheet = null;

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        //        var response = httpClient.GetAsync($"timesheets/{id}").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var resultData = response.Content.ReadAsStringAsync().Result;
        //            timesheet = JsonConvert.DeserializeObject<Timesheet>(resultData);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
        //        }
        //    }

        //    if (timesheet == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(timesheet);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "ProjectID,Projectname,task,Datenow,category,Hours,remarks")] Timesheet timesheet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        //            var response = await httpClient.PutAsJsonAsync("timesheets", timesheet);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "An error occurred.");
        //            }
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View(timesheet);
        //}

        // GET: Timesheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,Projectname,task,Datenow,category,Hours,remarks")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timesheet);
        }

        // GET: Timesheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timesheet timesheet = db.Timesheets.Find(id);
            db.Timesheets.Remove(timesheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Timesheet timesheet = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        //        var response = httpClient.GetAsync($"timesheets/{id}").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var resultData = response.Content.ReadAsStringAsync().Result;
        //            timesheet = JsonConvert.DeserializeObject<Timesheet>(resultData);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
        //        }
        //    }

        //    if (timesheet == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(timesheet); // Return the Delete confirmation view
        //}

        //////////[HttpPost]
        //////////[ValidateAntiForgeryToken]
        //////////public async Task<ActionResult> DeleteConfirmed(int id)
        //////////{
        //////////    using (var httpClient = new HttpClient())
        //////////    {
        //////////        httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        //////////        var response = await httpClient.DeleteAsync($"timesheets/{id}");
        //////////        if (response.IsSuccessStatusCode)
        //////////        {
        //////////            return RedirectToAction("Index");
        //////////        }
        //////////        else
        //////////        {
        //////////            ModelState.AddModelError(string.Empty, "An error occurred while deleting the record.");
        //////////        }
        //////////    }

        //////////    return RedirectToAction("Index");
        //////////}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri("https://localhost:44327/api/");
        //        var response = await httpClient.DeleteAsync($"timesheets/{id}");

        //        if (response.StatusCode == HttpStatusCode.NotFound)
        //        {
        //            ModelState.AddModelError(string.Empty, "The requested timesheet was not found.");
        //        }
        //        else if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "An error occurred while deleting the record.");
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}