
using Gameoflife.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gameoflife.Controllers
{
    public class GameOfLifeController : Controller
    {
        // GET: GameOfLife/PlayGame
        public ActionResult PlayGame(int gameIndex)
        {
            var activeGames = (List<UserGame>)Session["ActiveGames"];
            UserGame game2Play = activeGames.ElementAt(gameIndex);
            GameOfLife.GameofLife gameOfLife = new GameOfLife.GameofLife(game2Play.Height, game2Play.Width);
            gameOfLife.InsertTemplate(game2Play.Cells);

            // var gameOfLife = new GameOfLife.GameofLife(0, 1);

            Session["GameOfLife"] = gameOfLife;

            return View(gameOfLife);
        }

        // POST: GameOfLife/PlayGameTick
        [HttpPost]
        public string PlayGameTick()
        {
            var gameOfLife = (GameOfLife.GameofLife)Session["GameOfLife"];

            gameOfLife.TakeTurn();

            return gameOfLife.ToString();
        }
    }
}