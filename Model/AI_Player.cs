using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_tac_toe_game.Model;

namespace Tic_tac_toe_game.Model
{
    /// <summary>
    /// Бот для игры против игрока
    /// </summary>
    public class AI_Player
    {
        public Board Game { get; set; }
        public bool AI_Side { get; set; }

        public bool IsMyTurn() 
        {
            if (Game.Playerturn == this.AI_Side) return true;
            else return false;
        }

        public void MakeTurn() 
        {
            if (IsMyTurn()) 
            {
                //алгоритм действий

            }
        }

        /// <summary>
        /// Игрок выбирает "X"/"O" сторону, бот получает противоположную
        /// </summary>
        /// <param name="PlayerSide"></param>
        public AI_Player(bool PlayerSide)
        {
            this.AI_Side = !PlayerSide;
        }
    }
}
