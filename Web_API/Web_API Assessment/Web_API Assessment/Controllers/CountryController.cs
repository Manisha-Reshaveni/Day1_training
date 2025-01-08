using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_Assessment.Models;

namespace Web_API_Assessment.Controllers
{
    [RoutePrefix("api/User")]
    public class CountryController : ApiController
    {
        List<Country> countries = new List<Country>();

        public CountryController()
        {
            countries.Add(new Country { ID = 1, CountryName = "Japan", Capital = "Tokyo" });
            countries.Add(new Country { ID = 2, CountryName = "Canada", Capital = "Ottawa" });
            countries.Add(new Country { ID = 3, CountryName = "USA", Capital = "Washington " });
        }


        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllCountries()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countries);
            return response;
        }
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryById(int cId)
        {
            string cname = countries.Where(c => c.ID == cId).SingleOrDefault()?.CountryName;
            if (cname == null)
            {
                return NotFound();
            }
            return Ok(cname);
        }
        // POST api/country
        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostAll([FromBody] Country country)
        {
            countries.Add(country);
            return countries;
        }
        [HttpPut]
        [Route("Put")]
        public IEnumerable<Country> Put(int Cid, [FromUri] Country c)
        {
            countries[Cid - 1] = c;
            return countries;
        }
        [HttpDelete]
        [Route("Delete")]
        public IEnumerable<Country> Delete(int cid)
        {
            countries.RemoveAt(cid - 1);
            return countries;
        }
    }
}
