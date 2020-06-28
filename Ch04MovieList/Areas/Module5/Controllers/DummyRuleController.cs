using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Areas.Module5.Controllers
{
    [Area("Module5")]
    public class DummyRuleController : Controller
    {
        public IActionResult Index(string name, int num)
        {
            ViewBag.Name = name;
            ViewBag.Module = num;
            return View();
        }
    }
}
