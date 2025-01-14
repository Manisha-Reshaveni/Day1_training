using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using System.Data.Entity;

namespace MyProject.Controllers
{
  //  public class ProjectDetailsController : Controller
   // {
        // GET: ProjectDetails
        //ProjectContext db = new ProjectContext();

        //public ActionResult Index()
        //{
        //    var projectDetails = db.ProjectDetails.ToList();
        //    return View(projectDetails);
        //}
        //    // GET: ProjectDetails/Details/1
        //    public ActionResult Details(int projectId, string projectName)
        //    {
        //        var projectDetails = db.ProjectDetails.Find(projectId, projectName);
        //        return View(projectDetails);
        //    }

        //    // GET: ProjectDetails/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: ProjectDetails/Create
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(ProjectDetails projectDetails)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.ProjectDetails.Add(projectDetails);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(projectDetails);
        //    }

        //    // GET: ProjectDetails/Edit/1
        //    public ActionResult Edit(int projectId, string projectName)
        //    {
        //        var projectDetails = db.ProjectDetails.Find(projectId, projectName);
        //        return View(projectDetails);
        //    }

        //    // POST: ProjectDetails/Edit/1
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(ProjectDetails projectDetails)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(projectDetails).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(projectDetails);
        //    }

        //    // GET: ProjectDetails/Delete/1
        //    public ActionResult Delete(int projectId, string projectName)
        //    {
        //        var projectDetails = db.ProjectDetails.Find(projectId, projectName);
        //        return View(projectDetails);
        //    }

        //    // POST: ProjectDetails/Delete/1
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int projectId, string projectName)
        //    {
        //        var projectDetails = db.ProjectDetails.Find(projectId, projectName);
        //        db.ProjectDetails.Remove(projectDetails);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}


  //  }
}
