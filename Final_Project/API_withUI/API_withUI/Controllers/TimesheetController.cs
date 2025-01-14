using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_withUI.Models;

namespace API_withUI.Controllers
{
    public class TimesheetController : ApiController
    {
        private readonly Context db = new Context();

        // GET: api/Project
        public IQueryable<Timesheet> GetProject()
        {
            return db.Timesheet;
        }

        // GET: api/Project/5
        [ResponseType(typeof(Timesheet))]
        public IHttpActionResult GetProject(int id)
        {
            Timesheet p = db.Timesheet.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // PUT: api/Project/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(Timesheet Timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != product.ProductId)
            //{
            //    return BadRequest();
            //}

            db.Entry(Timesheet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProductExists(id))
                //{
                return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

      

        // Post
        [HttpPost]
        public IHttpActionResult PostNewProject([FromBody] Timesheet p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation Failed");
            }
            db.Timesheet.Add(new Timesheet()
            {
                ProjectID = p.ProjectID,
                Projectname = p.Projectname,
                task = p.task,
                category = p.category,
                Datenow = p.Datenow,
                Hours = p.Hours,
                remarks = p.remarks,
               
            });
            db.SaveChanges();
            return Ok("Success");
        }


        // DELETE: api/Products/5
        [ResponseType(typeof(Timesheet))]
        [Route("api/timesheets/{id}")]
        public IHttpActionResult DeleteProject(int id)
        {
            Timesheet Timesheet = db.Timesheet.Find(id);
            if (Timesheet == null)
            {
                return NotFound();
            }

            db.Timesheet.Remove(Timesheet);
            db.SaveChanges();

            return Ok(Timesheet);
        }

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
