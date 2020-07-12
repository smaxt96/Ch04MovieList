using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MovieList.Models.Olympics;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Areas.Module7.Controllers
{
    [Area("Module7")]
    public class FavoritesController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicsSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicsSession(HttpContext.Session);
            var cookies = new OlympicsCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveCat = session.GetActiveCat(),
                    ActiveGame = session.GetActiveGame()
                });
        }
    }
}
