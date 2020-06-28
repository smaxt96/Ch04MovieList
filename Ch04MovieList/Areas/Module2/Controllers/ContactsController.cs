using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MovieList.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Areas.Module2.Controllers
{
    [Area("Module2")]
    public class ContactsController : Controller
    {
        private ContactContext context { get; set; }

        public ContactsController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Contacts = context.Contacts.OrderBy(c => c.Name).ToList();
            return View("Add", new Contact());
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Contacts");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" :
                ViewBag.Contacts = context.Contacts.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Contacts");
        }
        public IActionResult Index()
        {
            var contacts = context.Contacts.OrderBy(c => c.Name).ToList();
            return View(contacts);
        }
    }
}
