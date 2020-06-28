using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Areas.Module5.Controllers
{
    [Area("Module5")]
    public class DummyAttributeController : Controller
    {
        [Route("module5/dummyattribute/custom")]
        public IActionResult MyIndex()
        {
            return View("Index");
        }
    }
}
