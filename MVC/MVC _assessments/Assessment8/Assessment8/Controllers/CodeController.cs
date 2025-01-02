using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment8.Models;

namespace Assessment8.Controllers
{
    public class CodeController : Controller
    {
        
        northwindEntities db = new northwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            List<Customer> custlist = db.Customers.ToList();
            return View(custlist);
         
        }
        //  1. First action method should return all customers residing in Germany
        public ActionResult GetAllCustomersInGermany()
        {
            var list = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(list);
           
        }
        //  2. Second action method should return customer details with an orderId==10248
        public ActionResult GetCustomerDetails()
        {
        
            var orders= db.Orders.Where(o=>o.OrderID==10248).Select(o=>o.Customer).FirstOrDefault();

            return View(orders);
        }
    }
}