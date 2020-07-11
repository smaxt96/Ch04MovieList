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
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Category)
                    .Include(t => t.Game)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveCat = TempData.Peek("ActiveCat").ToString(),
                ActiveGame = TempData.Peek("ActiveGame").ToString()
            };
            return View(model);
        }
    }
}
