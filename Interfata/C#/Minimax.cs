using System;

namespace Xsi0
{
    /// <summary>
    /// Implementeaza algoritmul de cautare a mutarii optime
    /// </summary>
    public partial class Minimax
    {
        /// <summary>
        /// Primeste o configuratie ca parametru, cauta mutarea optima si returneaza configuratia
        /// care rezulta prin aplicarea acestei mutari optime
        /// </summary>
        public static Pair FindNextPosition(GameGrid gameGrid, int depth)
        {
            /*TODO*/
            double bestScore = double.MinValue;
            Pair bestMove = gameGrid.ValidMoves()[0];

            foreach (var move in gameGrid.ValidMoves())
            {
                GameGrid nextGameGrid = new GameGrid(gameGrid);
                nextGameGrid.SetElement(move.First(), move.Second(), PlayerType.Computer);
                double score = nextGameGrid.EvaluationFunction(PlayerType.Computer);

                if (score > bestScore)
                {
                    bestMove = move;
                    bestScore = score;
                }
            }

            return bestMove;
        }
    }
}