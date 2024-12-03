using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsi0
{
    /// <summary>
    /// Clasa in care se regaseste starea jocului
    /// </summary>
    public class GameGrid
    {
        private PlayerType[][] _elements { get; }
        private int _size;

        public PlayerType[][] Elements
        {
            get { return _elements; }
        }

        public void SetElement(int x, int y, PlayerType value)
        {
            _elements[x][y] = value;
        }

        public int Size
        {
            get { return _size; }
        }

        public GameGrid(int size = 3)
        {
            _size = size;

            _elements = new PlayerType[size][];
            for (int i = 0; i < size; i++)
            {
                _elements[i] = new PlayerType[size];
                for (int j = 0; j < _size; j++)
                {
                    _elements[i][j] = PlayerType.None;
                }
            }
        }

        public GameGrid(GameGrid gameGrid)
        {
            _size = gameGrid.Size;
            _elements = new PlayerType[_size][];
            for (int i = 0; i < _size; i++)
            {
                _elements[i] = new PlayerType[_size];
                for (int j = 0; j < _size; j++)
                {
                    _elements[i][j] = gameGrid.Elements[i][j];
                }
            }
        }

        /// <summary>
        /// Verifica daca jocul a fost castigat de catre un jucator
        /// </summary>
        public void CheckFinish(out bool end, out PlayerType winner)
        {
            end = false;
            winner = PlayerType.None;

            for (int i = 0; i < _size; ++i)
            {
                if (_elements[i][0] == _elements[i][1] && _elements[i][1] == _elements[i][2])
                {
                    end = true;
                    winner = _elements[i][0];
                    break;
                }

                if (_elements[0][i] == _elements[1][i] && _elements[1][i] == _elements[2][i])
                {
                    end = true;
                    winner = _elements[0][i];
                    break;
                }
            }

            if (end == false)
            {
                if (_elements[0][0] == _elements[1][1] && _elements[1][1] == _elements[2][2])
                {
                    end = true;
                    winner = _elements[0][0];
                }
                else if (_elements[0][2] == _elements[1][1] && _elements[2][0] == _elements[1][1])
                {
                    end = true;
                    winner = _elements[1][1];
                }
            }

            if (winner == PlayerType.None)
                end = false;

            if (end == false)
            {
                int remainingSpaces = 9;
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        if (_elements[i][j] != PlayerType.None)
                        {
                            remainingSpaces--;
                        }
                    }
                }

                if (remainingSpaces == 0)
                {
                    end = true;
                    winner = PlayerType.None;
                }
            }
        }

        /// <summary>
        /// Returneaza o lista de tip Pair cu toate locurile valide
        /// </summary>
        public List<Pair> ValidMoves()
        {
            List<Pair> validMoves = new List<Pair>();

            for (int i = 0; i < _size; ++i)
            {
                for (int j = 0; j < _size; ++j)
                {
                    if (_elements[i][j] == PlayerType.None)
                        validMoves.Add(new Pair(i, j));
                }
            }

            return validMoves;
        }

        /// <summary>
        /// Calculeaza functia de evaluare statica pentru configuratia (tabla) curenta
        /// </summary>
        public double EvaluationFunction()
        {
            double score = 0;

            /*TODO*/

            return score;
        }
    }
}
