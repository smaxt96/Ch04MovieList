using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MovieList.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Controllers
{
    public class BirthdayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Age = null;
            ViewBag.Name = null;
            return View();
        }
        [HttpPost]
        public IActionResult Index(BirthDateModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Age = model.CalculateCurrentAge();
                ViewBag.Name = model.FirstName;
            }
            else
            {
                ViewBag.Age = null;
                ViewBag.Name = null;
            }
            return View(model);
        }
    }
}
