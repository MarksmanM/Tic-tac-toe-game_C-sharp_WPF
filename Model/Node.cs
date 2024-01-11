using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_game.Model
{
    public class Node
    {
        public Node[,] Nodes = new Node[3, 3];
        public int[] Index { get; set; }
        public List<int[]> Turns { get; set; }
        public int Depth { get; set;  }
        public bool Value {  get; set; }

        /*
        public void UpdateTurns() 
        {
            for (int i = 0; i < Turns.Length; i++) 
            {
                for (int j = 0; j < Turns[i].Length; j++) 
                {
                    int[] index = { i, j };
                    if (Array.IndexOf(Turns,index ) != -1)
                    {
                        Nodes[i, j] = null;
                    }   
                    else
                    {
                        for (int k = 0; k < Turns.Length; k++)
                        {
                            Nodes[i,j].Turns[k] = Turns[k];
                        }
                        Nodes[i,j].Depth = Depth + 1;
                        Nodes[i,j].Turns[Turns.Length] = new int[] { i, j };
                    }
                    Nodes[i,j].UpdateTurns();
                }
            }
        }*/
        
        /// <summary>
        /// Создание дочернего узла
        /// </summary>
        /// <param name="cell"></param>
        public void AddChild(int[] cell) 
        {
            Node ChildNode = new Node(cell);
            Nodes[cell[0], cell[1]] = ChildNode;
            Nodes[cell[0], cell[1]].Depth = Depth + 1;
            Nodes[cell[0], cell[1]].Turns.AddRange(Turns);
            Nodes[cell[0], cell[1]].Value = !Value;
        }

        /// <summary>
        /// Построение дерева всех возомжных игровых вариантов 
        /// </summary>
        public void Build_Tree() 
        {
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++) 
                {
                    int[] Child_index = { i, j };
                    if (!Turns.Contains(Child_index) & Depth < 8) 
                    {
                        AddChild(Child_index);
                        Nodes[i, j].Build_Tree();
                    }

                }
            }
        }

        public int[] FindBestTurn() 
        {
        
        }

        public int WeighyFunction(List<int[]> Turns) 
        {
            int[,] Matrix = ListToMatrix(Turns);
            if () return 10;
            else if () return -10;
            else return 0;
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

        public Node(int[] cell) 
        {
            Index = cell;
            Depth = 0;
            Turns = new List<int[]>
            {
                Index
            };
            Value = true;
        }
    }
}
