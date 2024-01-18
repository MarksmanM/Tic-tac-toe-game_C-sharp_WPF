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
        public Node RootNode { get; set; }

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

        public void TakeTurn() 
        {
        
        }

        /// <summary>
        /// Инициализирует пустое игровое поле и дерево состояний
        /// </summary>
        /// <param name="PlayerSide">Игрок выбирает "X"/"O" сторону, бот получает противоположную</param>
        public AI_Player(bool PlayerSide)
        {
            Game = new Board();
            RootNode = new Node();
            RootNode.Build_Tree();
            AI_Side = !PlayerSide;

        }
    }
}
