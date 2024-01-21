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
    /// ToDo: сделать рефакторинг этой жути, кто это писал
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

        public int[,] Cells = new int[3, 3];
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

        /// <summary>
        /// Остались ли ещё пустые клетки
        /// </summary>
        /// <returns></returns>
        public bool IsSomeEmptyCell()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Cells[i,j] == 0) return true;
                }
            }
            return false;
        }
         

        /// <summary>
        /// Проверка, заполнил ли кто-то какой-либо ряд
        /// </summary>
        /// <returns></returns>
        int IsSomeRowFilled()
        {
            if ((Cells[0, 0] == 1 && Cells[0, 1] == 1 && Cells[0, 2] == 1) |
                (Cells[1, 0] == 1 && Cells[1, 1] == 1 && Cells[1, 2] == 1) |
                (Cells[2, 0] == 1 && Cells[2, 1] == 1 && Cells[2, 2] == 1))
                return 1;
            else if ((Cells[0, 0] == 2 && Cells[0, 1] == 2 && Cells[0, 2] == 2) |
                     (Cells[1, 0] == 2 && Cells[1, 1] == 2 && Cells[1, 2] == 2) |
                     (Cells[2, 0] == 2 && Cells[2, 1] == 2 && Cells[2, 2] == 2))
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
            if ((Cells[0, 0] == 1 && Cells[1, 0] == 1 && Cells[2, 0] == 1) |
                (Cells[0, 1] == 1 && Cells[1, 1] == 1 && Cells[2, 1] == 1) |
                (Cells[0, 2] == 1 && Cells[1, 2] == 1 && Cells[2, 2] == 1))
                return 1;
            else if ((Cells[0, 0] == 2 && Cells[1, 0] == 2 && Cells[2, 0] == 2) |
                    (Cells[0, 1] == 1 && Cells[1, 1] == 1 && Cells[2, 1] == 2) |
                    (Cells[0, 2] == 2 && Cells[1, 2] == 2 && Cells[2, 2] == 2))
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
            if ((Cells[0, 0] == 1 && Cells[1, 1] == 1 && Cells[2, 2] == 1) |
                (Cells[0, 2] == 1 && Cells[1, 1] == 1 && Cells[2, 0] == 1))
                return 1;
            else if ((Cells[0, 0] == 2 && Cells[1, 1] == 2 && Cells[2, 2] == 2) |
                     (Cells[0, 2] == 2 && Cells[1, 1] == 2 && Cells[2, 0] == 2))
                return 2;
            else
                return 0;
        }

        void RestartGame()
        {
            Playerturn = true;
            Cells = new int[3, 3];
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
