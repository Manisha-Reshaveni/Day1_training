using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API_Assessment.Models
{
    public class Country
    {
//        1. Create a Model called Country under Models Folder.
//2. Add Properties in the country model as 
//   ID, CountryName, Capital
 
//3. Create an Empty api controller called Country
 
//4. Perform CRUD operations using either (HTTPResponseMessage/ IHttpActionResult / others) and
//        consume the api using either  Postman/Swagger

        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }

    }
}