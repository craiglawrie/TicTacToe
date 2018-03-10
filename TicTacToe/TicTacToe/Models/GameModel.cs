using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Game = new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        }

        public List<char> Game { get; set; }
    }
}