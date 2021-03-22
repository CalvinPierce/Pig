using Microsoft.AspNetCore.Mvc;
using Pig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pig.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var session = new GameSession(HttpContext.Session);
            var game = session.GetGame();

            if (game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayerName} wins!";
            }
            return View(game);
        }
        public IActionResult NewGame()
        {
            var session = new GameSession(HttpContext.Session);
            var game = session.GetGame();

            game.NewGame();

            session.SetGame(game);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Roll()
        {
            var session = new GameSession(HttpContext.Session);
            var game = session.GetGame();

            game.Roll();

            session.SetGame(game);
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Hold()
        {
            var session = new GameSession(HttpContext.Session);
            var game = session.GetGame();

            game.Hold();

            session.SetGame(game);
            return RedirectToAction("Index");
        }
    }
}
