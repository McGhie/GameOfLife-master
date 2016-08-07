
using System.Web.Mvc;

namespace Gameoflife.Controllers
{
    public class GameOfLifeController : Controller
    {
        // GET: GameOfLife/PlayGame
        public ActionResult PlayGame()
        {
            var gameOfLife = new GameOfLife.GameOfLife(0, 1);

            Session["GameOfLife"] = gameOfLife;

            return View(gameOfLife);
        }

        // POST: GameOfLife/PlayGameTick
        [HttpPost]
        public string PlayGameTick()
        {
            var gameOfLife = (GameOfLife.GameOfLife)Session["GameOfLife"];

            gameOfLife.TakeTurn();

            return gameOfLife.ToString();
        }
    }
}