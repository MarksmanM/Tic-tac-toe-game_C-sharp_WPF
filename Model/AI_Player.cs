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
        public Node CurrentNode { get; set; }

        public void MakeTurn() 
        {
            if (IsMyTurn())
            {
                //алгоритм действий

            }
        }

        /// <summary>
        /// Записывает ход игрока
        /// </summary>
        /// <param name="Turn"></param>
        public void TakeTurn(int[] Turn) 
        {
            Game.Cells[Turn[0], Turn[1]] = AI_Side ? 1 : 2;
            CurrentNode = CurrentNode.Nodes[Turn[0], Turn[1]];
        }

        public bool IsMyTurn()
        {
            if (Game.Playerturn == this.AI_Side) return true;
            else return false;
        }

        /// <summary>
        /// Инициализирует пустое игровое поле и дерево состояний
        /// </summary>
        /// <param name="PlayerSide">Игрок выбирает "X"/"O" сторону, бот получает противоположную</param>
        public AI_Player(bool PlayerSide)
        {
            Game = new Board();
            RootNode = new Node();
            //RootNode.Build_Tree();
            AI_Side = !PlayerSide;

        }
    }
}
