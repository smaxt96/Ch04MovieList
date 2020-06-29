using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch04MovieList.Models.Olympics;
using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieList.Areas.Module7.Controllers
{
    [Area("Module7")]
    public class OlympicController : Controller
    {
        private CountryContext context;

        public OlympicController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(string activeCat = "all", string activeGame = "all")
        {
            var model = new OlympicsViewModel
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
    }
}
