using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SimpleCheckers
{
    public class Evaluation
    {
        /// <summary>
        /// Calculeaza functia de evaluare statica pentru configuratia (tabla) curenta
        /// </summary>
        public static double EvaluationFunction(PlayerType[][] grid, int size)
        {
            double score = 0;
            
            

            return score;
        }
    }

    //=============================================================================================================================

    public partial class Minimax
    {
        private static List<int> ValidMoves(PlayerType [][]grid, int size)
        {
            List<int> validMoves = new List<int>();

            for(int i = 0; i < size; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    if (grid[i][j] == PlayerType.None)
                        validMoves.Add(i * size + j);
                }
            }
            
            return validMoves;
        }

        /// <summary>
        /// Primeste o configuratie ca parametru, cauta mutarea optima si returneaza configuratia
        /// care rezulta prin aplicarea acestei mutari optime
        /// </summary>
        public static int FindNextPosition(PlayerType[][]grid, int size, int depth)
        {
            int bestMove = -1;
            double bestScore = double.MinValue;

            foreach(var move in ValidMoves(grid, size))
            {
                grid[move / 3][move % 3] = PlayerType.Computer;
                double score = Evaluation.EvaluationFunction(grid, size);

                if (score > bestScore)
                {
                    bestMove = move;
                    bestScore = score;
                }

                grid[move / 3][move % 3] = PlayerType.None;
            }

            return bestMove;
        }
    }
}