using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyProject.Models;



namespace API_withUI.Controllers

{

    public class EmployeeDetailsController : ApiController

    {

        private IRepository<EmployeeDetails> _repository;

        public EmployeeDetailsController()

        {

            _repository = new Repository<EmployeeDetails>();

        }

        // GET: api/EmployeeDetails

        public IQueryable<EmployeeDetails> GetEmployeeDetails()

        {

            return _repository.GetAll().AsQueryable();

        }

       

  

        // PUT: api/EmployeeDetails/5

        [ResponseType(typeof(void))]

        public IHttpActionResult PutEmployeeDetails(EmployeeDetails employeeDetails)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }

            _repository.Update(employeeDetails);

            try

            {

                _repository.Save();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!EmployeeDetailsExists(employeeDetails.EmpID))

                {

                    return NotFound();

                }

                else

                {

                    throw;

                }

            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        // POST: api/EmployeeDetails

        [HttpPost]

        public IHttpActionResult PostEmployeeDetails([FromBody] EmployeeDetails employeeDetails)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest("Validation Failed");

            }

            try

            {

                // Check for primary key conflicts

                if (_repository.GetAll().Any(e => e.EmpID == employeeDetails.EmpID))

                {

                    return Conflict();

                }

                _repository.Insert(employeeDetails);

                _repository.Save();

                return Ok("Success");

            }

            catch (DbUpdateException ex)

            {

                // Handle database update exceptions

                if (ex.InnerException != null && ex.InnerException.InnerException != null)

                {

                    var sqlException = ex.InnerException.InnerException as SqlException;

                    if (sqlException != null && (sqlException.Number == 2601 || sqlException.Number == 2627))

                    {

                        // Handle primary key or unique constraint violations

                        return Conflict();

                    }

                }

                return InternalServerError(ex);

            }

            catch (Exception ex)

            {

                // Handle all other exceptions

                return InternalServerError(ex);

            }

        }

        // DELETE: api/EmployeeDetails/5

        [ResponseType(typeof(EmployeeDetails))]

        [Route("api/EmployeeDetails/{id}")]

        public IHttpActionResult DeleteEmployeeDetails(int id)

        {

            EmployeeDetails employeeDetails = _repository.GetById(id);

            if (employeeDetails == null)

            {

                return NotFound();

            }

            _repository.Delete(employeeDetails);

            _repository.Save();

            return Ok(employeeDetails);

        }

        protected override void Dispose(bool disposing)

        {

            if (disposing)

            {

                _repository = null;

            }

            base.Dispose(disposing);

        }

        private bool EmployeeDetailsExists(int id)

        {

            return _repository.GetAll().Count(e => e.EmpID == id) > 0;

        }

    }

}