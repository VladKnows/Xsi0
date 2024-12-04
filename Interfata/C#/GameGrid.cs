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

        private enum LineType { Row, Column, Diagonal };
        private bool IsGoingToWin(LineType lineType, int index, PlayerType playerType)
        {
            int nr = 0;
            bool oneSpace = false;

            switch(lineType)
            {
                case LineType.Row:
                    for(int i = 0; i < _size; ++i)
                    {
                        if (_elements[index][i] == playerType)
                            nr++;
                        else if (_elements[index][i] == PlayerType.None)
                            oneSpace = true;
                    }
                    break;
                case LineType.Column:
                    for (int i = 0; i < _size; ++i)
                    {
                        if (_elements[i][index] == playerType)
                            nr++;
                        else if (_elements[i][index] == PlayerType.None)
                            oneSpace = true;
                    }
                    break;
                default:
                    if (index == 0)
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (_elements[i][i] == playerType)
                                nr++;
                            else if (_elements[i][i] == PlayerType.None)
                                oneSpace = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (_elements[_size - i - 1][i] == playerType)
                                nr++;
                            else if (_elements[_size - i - 1][i] == PlayerType.None)
                                oneSpace = true;
                        }
                    }
                    break;
            }

            if (nr == _size - 1 && oneSpace)
                return true;

            return false;
        }

        private bool Win(LineType lineType, int index, PlayerType playerType)
        {
            int nr = 0;

            switch (lineType)
            {
                case LineType.Row:
                    for (int i = 0; i < _size; ++i)
                    {
                        if (_elements[index][i] == playerType)
                            nr++;
                    }
                    break;
                case LineType.Column:
                    for (int i = 0; i < _size; ++i)
                    {
                        if (_elements[i][index] == playerType)
                            nr++;
                    }
                    break;
                default:
                    if (index == 0)
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (_elements[i][i] == playerType)
                                nr++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (_elements[_size - i - 1][i] == playerType)
                                nr++;
                        }
                    }
                    break;
            }

            if (nr == _size)
                return true;

            return false;
        }

        private bool isInLine(int x, int y, int index, LineType lineType)
        {
            switch (lineType)
            {
                case LineType.Row:
                    for (int i = 0; i < _size; ++i)
                    {
                        if (index == x && i == y)
                            return true;
                    }
                    break;
                case LineType.Column:
                    for (int i = 0; i < _size; ++i)
                    {
                        if (i == x && index == y)
                            return true;
                    }
                    break;
                default:
                    if (index == 0)
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (i == x && i == y)
                                return true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _size; ++i)
                        {
                            if (_size - i - 1 == x && i == y)
                                return true;
                        }
                    }
                    break;
            }

            return false;
        }

        private bool ThreeSymbols(int x, int y, PlayerType playerType)
        {
            int nr = 0;
            for(int i = 0; i < _size; ++i)
            {
                if (isInLine(x, y, i, LineType.Row) && IsGoingToWin(LineType.Row, i, playerType))
                    nr++;
                if (isInLine(x, y, i, LineType.Column) && IsGoingToWin(LineType.Column, i, playerType))
                    nr++;
                if (i < 2 && isInLine(x, y, i, LineType.Diagonal) && IsGoingToWin(LineType.Diagonal, i, playerType))
                    nr++;
            }

            if (nr >= 2)
                return true;
            return false;
        }

        private double ScoreForCell(int x, int y, PlayerType playerType)
        {
            double score = 0;

            for (int i = 0; i < _size; ++i)
            {
                if (isInLine(x, y, i, LineType.Row))
                    score += 10;
                if (isInLine(x, y, i, LineType.Column))
                    score += 10;
                if (i < 2 && isInLine(x, y, i, LineType.Diagonal))
                    score += 10;
            }

            if (playerType == PlayerType.Human)
                score *= -1;
            return score;
        }

        /// <summary>
        /// Calculeaza functia de evaluare statica pentru configuratia (tabla) curenta
        /// Algoritmul calculeaza un scor in functie de:
        /// - Daca unul din jucatori este pe cale sa termine o linie / coloana
        /// - In cate linii / coloane poate fi X sau 0
        /// </summary>
        public double EvaluationFunction(PlayerType playerType)
        {
            double score = -1000;

            //Verificare castig
            for (int i = 0; i < _size; ++i)
            {
                if (Win(LineType.Column, i, PlayerType.Computer))
                    return double.MaxValue;
                if (Win(LineType.Row, i, PlayerType.Computer))
                    return double.MaxValue;
                if (i < 2 && Win(LineType.Diagonal, i, PlayerType.Computer))
                    return double.MaxValue;
            }

            //Verifica daca playerul are loc liber pentru victorie
            for (int i = 0; i < _size; ++i)
            {
                if (IsGoingToWin(LineType.Column, i, PlayerType.Human))
                    return double.MinValue;
                if (IsGoingToWin(LineType.Row, i, PlayerType.Human))
                    return double.MinValue;
                if (i < 2 && IsGoingToWin(LineType.Diagonal, i, PlayerType.Human))
                    return double.MinValue;
            }

            //Verifica daca exista 3 simboluri care o runda mai tarziu ar putea forma o linie
            for (int i = 0; i < _size; ++i)
            {
                for (int j = 0; j < _size; ++j)
                {
                    if (_elements[i][j] == PlayerType.Computer && ThreeSymbols(i, j, PlayerType.Computer))
                        return double.MaxValue / 2;
                }
            }

            //Calculeaza punctaje pentru fiecare simbol
            score = 0;
            for (int i = 0; i < _size; ++i)
            {
                for (int j = 0; j < _size; ++j)
                {
                    if (_elements[i][j] != PlayerType.None)
                        score += ScoreForCell(i, j, playerType);
                }
            }

            return score;
        }
    }
}
