
using Gameoflife.Models;
using GameOfLife;
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

            GameOfLife.GameofLife gameOfLife = new GameOfLife.GameofLife(game2Play.Height, game2Play.Width,game2Play.Cells);
            
            Session["GameOfLife"] = gameOfLife;
            Session["GameIndex"] = gameIndex;
            return View(gameOfLife);
        }

        // POST: GameOfLife/PlayGameTick
        [HttpPost]
        public string PlayGameTick()
        {
            var gameOfLife = (GameOfLife.GameofLife)Session["GameOfLife"];
            var activeGames = (List<UserGame>)Session["ActiveGames"];
            int gameIndex =(int)Session["GameIndex"] ;
            gameOfLife.TakeTurn();
            var Cells = gameOfLife.Cells;
            string outCells = "";
            for (int h = 0; h <= gameOfLife.Height - 1; h++)
            {

                for (int w = 0; w <= gameOfLife.Width - 1; w++)
                {
                    if (Cells[h][w] == Cell.Dead)
                    {

                        outCells += "x";
                    }
                    else
                    {
                        outCells += "o";

                    }
                    
                }
                outCells += "\r\n";
            }
            activeGames.ElementAt(gameIndex).Cells = outCells;
            Session["ActiveGames"] = activeGames;
            return gameOfLife.ToString();
        }
    }
}