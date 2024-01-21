using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tic_tac_toe_game.Model
{
    public class Node
    {
        public Node[,] Nodes = new Node[3, 3];
        public int[] Index { get; set; }
        public List<int[]> Turns { get; set; }
        public int Depth { get; set;  }
        public bool Value {  get; set; }
        
        /// <summary>
        /// Создание дочернего узла
        /// </summary>
        /// <param name="cell"></param>
        public void AddChild(int[] cell) 
        {
            Node ChildNode = new Node(cell, Depth);
            Nodes[cell[0], cell[1]] = ChildNode;
            Nodes[cell[0], cell[1]].Turns.AddRange(Turns);
            Nodes[cell[0], cell[1]].Value = !Value;
        }

        /// <summary>
        /// Построение дерева всех возмoжных игровых вариантов 
        /// </summary>
        public void Build_Tree() 
        {
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++) 
                {
                    int[] Child_index = { i, j };
                    if (!Turns.Contains(Child_index) & Depth < 8) // ToDo: добавить проверку на наличие победителя
                    {
                        AddChild(Child_index);
                        Nodes[i, j].Build_Tree();
                    }

                }
            }
        }

        /// <summary>
        /// Поиск оптимального хода
        /// ToDo: Учесть сложность бота (нуб, средний, бог)
        /// ToDo: Добавить проверку, правда ли сейчас ход бота
        /// </summary>
        /// <param name="difficulty"> 0 - нуб, 1 - средний, 2 - бог</param>
        /// <returns></returns>
        public int[] FindBestTurn(int difficulty) 
        {
            int[] best_index = { -1, -1 };

            int BestScore = -100;
            //int[,] Matrix = ListToMatrix(Turns);
            int winner = FindWinnner(ListToMatrix(Turns));          
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int[] index = { i, j };
                    int score = Nodes[i, j].MinMax();
                    if (score > BestScore) 
                    {
                        BestScore = score;
                        best_index = index;
                    }

                }
            }
            return best_index;
        }

        /// <summary>
        /// Алгоритм минимакс для отыскания оптимального хода с учетом оптимальной игры противника
        /// </summary>
        /// <param name="aiplayer"></param>
        /// <returns></returns>
        public int MinMax() 
        {
            int[,] Matrix = ListToMatrix(Turns);
            int winner = FindWinnner(Matrix);
            int BestScore = Value? -1000: 1000;
            if (Value)
            {
                if (winner == 1) return 10;
                else if (winner == 2) return -10;
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BestScore = Math.Max(BestScore, Nodes[i, j].MinMax());
                        }
                    }
                }
            }
            else 
            {
                if (winner == 1) return -10;
                else if (winner == 2) return 10;
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            BestScore = Math.Min(BestScore, Nodes[i, j].MinMax());
                        }
                    }
                }
            }
            return BestScore;
        }

        public int FindWinnner(int[,] matrix) 
        {
            if (IsSomeColomnFilled(matrix) == 1 | IsSomeRowFilled(matrix) == 1 | IsSomeDiagFilled(matrix) == 1) return 1;
            else if (IsSomeColomnFilled(matrix) == 2 | IsSomeRowFilled(matrix) == 2 | IsSomeDiagFilled(matrix) == 2) return 2;
            else return 0;
        }

        int IsSomeRowFilled(int[,] matrix)
        {
            if ((matrix[0, 0] == 1 && matrix[0, 1] == 1 && matrix[0, 2] == 1) |
                (matrix[1, 0] == 1 && matrix[1, 1] == 1 && matrix[1, 2] == 1) |
                (matrix[2, 0] == 1 && matrix[2, 1] == 1 && matrix[2, 2] == 1))
                return 1;
            else if ((matrix[0, 0] == 2 && matrix[0, 1] == 2 && matrix[0, 2] == 2) |
                     (matrix[1, 0] == 2 && matrix[1, 1] == 2 && matrix[1, 2] == 2) |
                     (matrix[2, 0] == 2 && matrix[2, 1] == 2 && matrix[2, 2] == 2))
                return 2;
            else
                return 0;
        }

        int IsSomeColomnFilled(int[,] matrix)
        {
            if ((matrix[0,0] == 1 && matrix[1,0] == 1 && matrix[2,0] == 1) |
                (matrix[0,1] == 1 && matrix[1,1] == 1 && matrix[2,1] == 1) |
                (matrix[0,2] == 1 && matrix[1,2] == 1 && matrix[2,2] == 1))
                return 1;
            else if ((matrix[0, 0] == 2 && matrix[1, 0] == 2 && matrix[2, 0] == 2) |
                    (matrix[0, 1] == 1 && matrix[1, 1] == 1 && matrix[2, 1] == 2) |
                    (matrix[0, 2] == 2 && matrix[1, 2] == 2 && matrix[2, 2] == 2))
                return 2;
            else
                return 0;
        }

        int IsSomeDiagFilled(int[,] matrix)
        {
            if ((matrix[0, 0] == 1 && matrix[1, 1] == 1 && matrix[2, 2] == 1) |
                (matrix[0, 2] == 1 && matrix[1, 1] == 1 && matrix[2, 0] == 1))
                return 1;
            else if ((matrix[0, 0] == 2 && matrix[1, 1] == 2 && matrix[2, 2] == 2) |
                     (matrix[0, 2] == 2 && matrix[1, 1] == 2 && matrix[2, 0] == 2))
                return 2;
            else
                return 0;
        }

        /// <summary>
        /// Преобразует список последовательности ходов в матрицу игрового поля
        /// </summary>
        /// <param name="Turns"></param>
        /// <returns></returns>
        public int[,] ListToMatrix(List<int[]> Turns) 
        {
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < Turns.Count; i++) 
            {
                int[] index = Turns[i];
                if ((Turns.Count - (i+1)) % 2 == 0)
                {
                    matrix[index[0], index[1]] = 1;
                }
                else 
                {
                    matrix[index[0], index[1]] = 2;
                }
            }
            return matrix;
        }

        public Node(int[] cell,int depth) 
        {
            Index = cell;
            Depth = depth + 1;
            Turns = new List<int[]>
            {
                Index
            };
            Value = true;
        }

        /// <summary>
        /// RootNode
        /// </summary>
        public Node()
        {
            Index = null;
            Depth = 1;
            Turns = new List<int[]>();
            Value = true;
        }
    }
}
