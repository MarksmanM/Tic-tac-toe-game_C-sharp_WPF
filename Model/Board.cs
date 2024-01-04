using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_game.Model
{
    /// <summary>
    /// Core class of the game
    /// </summary>
    public class Board
    {
        /// <summary>
        /// X turn -> true  O turn -> false
        /// (O) (O) (X)
        /// (_) (X) (_)
        /// (O) (X) (_)
        /// 
        /// 
        /// (2) (2) (1)
        /// (_) (1) (_)
        /// (2) (1) (_)
        /// A1 = 1 => крестик
        /// A2 = 2 => нолик
        /// 
        /// </summary>
        public bool Playerturn { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int B3 { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }


        public int X_count { get; set; }
        public int O_count { get; set; }


        /// <summary>
        /// Проверка, победил ли кто-то из игроков
        /// </summary>
        /// <returns>
        /// 1 -> X wins
        /// 2 -> 0 wins
        /// features: add win col/raw/diag inf (int ->[int,str,int])
        /// </returns>
        public int IsSomeoneWin()
        {
            if (this.IsSomeRowFilled() == 1 | this.IsSomeColomnFilled() == 1 | this.IsSomeDiagFilled() == 1)
            {
                this.RestartGame();
                X_count += 1;
                return 1; // крестики wins, игровое поле уже очищено, необходимо View окно привести к изначальному состоянию, с учетом изменения счёта
            }
            else if (this.IsSomeRowFilled() == 2 | this.IsSomeColomnFilled() == 2 | this.IsSomeDiagFilled() == 2)
            {
                this.RestartGame();
                O_count += 1;
                return 2; // нолики wins
            }
            else
            {   if (this.IsSomeEmptyCell())
                {
                    this.MakeTurn(); // смена хода
                    return 0; //играем дальше
                }
                else
                {
                    this.RestartGame();
                    return -1; // ничья :( начинаем заново
                }
            }
        }

        public bool IsSomeEmptyCell() 
        {
            if (A1 == 0 | A2 == 0 | A3 == 0 | B1 == 0 | B2 == 0 | B3 == 0 | C1 == 0 | C2 == 0 | C3 == 0) return true;
            else
            {
                return false;
            }
        }
         

        /// <summary>
        /// Проверка, заполнил ли кто-то какой-либо ряд
        /// </summary>
        /// <returns></returns>
        int IsSomeRowFilled()
        {
            if ((this.A1 == 1 && this.A2 == 1 && this.A3 == 1) |
                (this.B1 == 1 && this.B2 == 1 && this.B3 == 1) |
                (this.C1 == 1 && this.C2 == 1 && this.C3 == 1))
                return 1;
            else if ((this.A1 == 2 && this.A2 == 2 && this.A3 == 2) |
                     (this.B1 == 2 && this.B2 == 2 && this.B3 == 2) |
                     (this.C1 == 2 && this.C2 == 2 && this.C3 == 2))
                return 2;
            else
                return 0;
        }

        /// <summary>
        /// Проверка, заполнил ли кто-то какой-либо столбец
        /// </summary>
        /// <returns></returns>
        int IsSomeColomnFilled()
        {
            if ((this.A1 == 1 && this.B1 == 1 && this.C1 == 1) |
                (this.A2 == 1 && this.B2 == 1 && this.C2 == 1) |
                (this.A3 == 1 && this.B3 == 1 && this.C3 == 1))
                return 1;
            else if ((this.A1 == 2 && this.B1 == 2 && this.C1 == 2) |
                     (this.A2 == 2 && this.B2 == 2 && this.C2 == 2) |
                     (this.A3 == 2 && this.B3 == 2 && this.C3 == 2))
                return 2;
            else
                return 0;
        }


        /// <summary>
        /// Проверка, заполнил ли кто-то какую-либо диагональ
        /// </summary>
        /// <returns></returns>
        int IsSomeDiagFilled()
        {
            if ((this.A1 == 1 && this.B2 == 1 && this.C3 == 1) |
                (this.A3 == 1 && this.B2 == 1 && this.C1 == 1))
                return 1;
            else if ((this.A1 == 2 && this.B2 == 2 && this.C3 == 2) |
                     (this.A3 == 2 && this.B2 == 2 && this.C1 == 2))
                return 2;
            else
                return 0;
        }

        void RestartGame()
        {
            Playerturn = true;
            this.A1 = 0;
            this.B1 = 0;
            this.C1 = 0;
            this.A2 = 0;
            this.B2 = 0;
            this.C2 = 0;
            this.A3 = 0;
            this.B3 = 0;
            this.C3 = 0;
        }

        void MakeTurn()
        {
            if (this.Playerturn) this.Playerturn = false;
            else this.Playerturn = true;
        }

        /// <summary>
        /// Базовый конструктор, который заполняет игровое поле нулями
        /// </summary>
        public Board()
        {
            this.RestartGame();
            this.X_count = 0;
            this.O_count = 0;
        }
    }
}
