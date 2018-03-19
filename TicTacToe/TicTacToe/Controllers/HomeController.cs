using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            GameModel game = GetActiveGame();
            return View(game);
        }

        [HttpPost]
        public ActionResult Index(int square)
        {
            GameModel game = GetActiveGame(square);
            PlaySquare(game, square);
            return RedirectToAction("Index");
        }

        private void PlaySquare(GameModel game, int square)
        {
            if (square == -1)
            {
                return;
            }

            if (game.Game[square] == ' ')
            {
                // Play 'X' where player chose
                game.Game[square] = 'X';

                // If game is not over, find a play for 'O'
                if (!game.IsGameOver)
                {
                    game.Game[GetOPlayIndex(game)] = 'O';
                }
            }
        }

        private int GetOPlayIndex(GameModel game)
        {
            int index = 4;

            // Check for winning plays for O. If there is one, win the game.
            for (int i = 0; i < 9; i++)
            {
                if (game.Game[i] == ' ' && game.DoesPlayerWinWithPlay('O', i))
                {
                    return i;
                }
            }

            // Check for winning plays for X. If there is one, block it.
            for (int i = 0; i < 9; i++)
            {
                if (game.Game[i] == ' ' && game.DoesPlayerWinWithPlay('X', i))
                {
                    return i;
                }
            }

            // Check for available spaces. (i + 4) % 9 steps through starting at the middle square
            for (int i = 0; i < 9; i++)
            {
                if (game.Game[(i + 4) % 9] == ' ')
                {
                    return (i + 4) % 9;
                }
            }

            return index;
        }

        private GameModel GetActiveGame(int square = 0)
        {
            GameModel game = null;

            if (Session["game"] == null || square == -1)
            {
                game = new GameModel();
                Session["game"] = game;
            }
            else
            {
                game = Session["game"] as GameModel;
            }

            return game;
        }
    }
}