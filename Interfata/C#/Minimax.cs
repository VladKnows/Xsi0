using System;

namespace Xsi0
{
    /// <summary>
    /// Implementeaza algoritmul de cautare a mutarii optime
    /// </summary>
    public partial class Minimax
    {
        /// <summary>
        /// Algoritmul Minimax recursiv 
        /// implementeaza algoritmul Minimax, care exploreaza recursiv toate miscarile posibile pentru a determina cea mai buna mutare
        /// maximizeaza scorul pentru un jucator si minimizeaza pentru celalalt
        /// </summary>
        private static (double score, Pair move) FindNextPosition(GameGrid gameGrid, int depth, bool isMaximizing)
        {
            bool end;
            PlayerType player;
            gameGrid.CheckFinish(out end, out player);

            if (depth == 0 || end)
            {
                return (gameGrid.EvaluationFunction(isMaximizing ? PlayerType.Human : PlayerType.Computer), null);
            }

            double bestScore = isMaximizing ? double.MinValue : double.MaxValue;
            Pair bestMove = gameGrid.ValidMoves()[0];

            foreach (var move in gameGrid.ValidMoves())
            {
                GameGrid nextGameGrid = new GameGrid(gameGrid);
                nextGameGrid.SetElement(move.First(), move.Second(), isMaximizing ? PlayerType.Computer : PlayerType.Human);

                bool _end;
                PlayerType _player;

                nextGameGrid.CheckFinish(out _end, out _player);

                
                if (!isMaximizing && _end && _player == PlayerType.Human)
                {
                    return (double.MinValue, move);
                }

                var (score, _) = FindNextPosition(nextGameGrid, depth - 1, !isMaximizing);

                if (isMaximizing && score > bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
                else if (!isMaximizing && score < bestScore)
                {
                    bestScore = score;
                    bestMove = move;
                }
            }

            return (bestScore, bestMove);
        }

        /// <summary>
        /// Wrapper simplificat pentru apelarea algoritmului Minimax.
        /// </summary>
        public static Pair GetOptimalMove(GameGrid gameGrid, int depth)
        {
            var (_, move) = FindNextPosition(gameGrid, depth, true);
            return move;
        }
    }
}