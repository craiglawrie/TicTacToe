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

        public char Winner
        {
            get
            {
                char result = ' ';

                // check rows
                for (int i = 0; i < 3; i++)
                {
                    if (Game[i * 3] == Game[i * 3 + 1] && Game[i * 3 + 1] == Game[i * 3 + 2] && Game[i * 3] != ' ')
                    {
                        return Game[i * 3];
                    }
                }

                // check columns
                for (int i = 0; i < 3; i++)
                {
                    if (Game[i] == Game[i+3] && Game[i+3] == Game[i+6] && Game[i] != ' ')
                    {
                        return Game[i];
                    }
                }

                // check diagonal down
                if (Game[0] == Game[4] && Game[4] == Game[8] && Game[0] != ' ')
                {
                    return Game[0];
                }

                // check diagonal up
                if (Game[2] == Game[4] && Game[4] == Game[6] && Game[2] != ' ')
                {
                    return Game[2];
                }

                return result;
            }
        }

        public bool DoesPlayerWinWithPlay(char c, int index)
        {
            List<char> temporaryGameList = Game.ToList();

            if(temporaryGameList[index] == ' ')
            {
                temporaryGameList[index] = c;
            }
            else
            {
                return false;
            }

            GameModel temporaryGame = new GameModel();
            temporaryGame.Game = temporaryGameList;

            return temporaryGame.IsGameOver;
        }

        public bool IsGameOver
        {
            get
            {
                return (Winner != ' ' || !Game.Contains(' '));
            }
        }

    }
}