using MVC_Assignment1.Models;
using MVC_Assignment1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository repo;
       // ContactContext db;
        public ContactController()
        {
            repo = new ContactRepository();
        }
        // GET: Contact

        public async Task<ActionResult> Index()
        {
            var contacts = await repo.GetAllAsync();
            return View(contacts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long id)
        {
            // Fetch the specific contact based on the ID
            var contact = await repo.GetAllAsync();
            var contacts = (await repo.GetAllAsync()).FirstOrDefault(c => c.Id == id);

            if (contacts == null)
            {
                return HttpNotFound();
            }

            return View(contacts); 
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Deleted(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}