﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MovieList.Models.Olympics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ch04MovieList.Areas.Module7.Controllers
{
    [Area("Module7")]
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeCat = "all", string activeGame = "all")
        {
            var session = new OlympicsSession(HttpContext.Session);
            session.SetActiveCat(activeCat);
            session.SetActiveGame(activeGame);

            // if no count in session, get cookie and restore fave countries in session
            int? count = session.GetMyCountryCount();
            if (count == null) {
                var cookies = new OlympicsCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0) {
                    mycountries = context.Countries.Include(t => t.Category)
                        .Include(t => t.Game)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                }
                session.SetMyCountries(mycountries);
            }

            var model = new CountryListViewModel
            {
                ActiveCat = activeCat,
                ActiveGame = activeGame,
                Categories = context.Categories.ToList(),
                Games = context.Games.ToList()
            };
           
            IQueryable<Country> query = context.Countries;
            if (activeCat != "all") query = query.Where(
                t => t.Category.CategoryID.ToLower() == activeCat.ToLower());
            if (activeGame != "all") query = query.Where(
                t => t.Game.GameID.ToLower() == activeGame.ToLower());
            model.Countries = query.ToList();
            return View(model);

        }
        [HttpPost]
        public RedirectToActionResult Details(CountryViewModel model)
        {
            TempData["ActiveCat"] = model.ActiveCat;
            TempData["ActiveGame"] = model.ActiveGame;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new OlympicsSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Category)
                    .Include(t => t.Game)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveCat = session.GetActiveCat(),
                ActiveGame = session.GetActiveGame()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(t => t.Category)
                .Include(t => t.Game)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new OlympicsSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new OlympicsCookies(Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveCat = session.GetActiveCat(),
                    ActiveGame = session.GetActiveGame()
                });

        }
    }
}
