/**************************************************************************
 *                                                                        *
 *  Copyright:   (c) 2016-2020, Florin Leon                               *
 *  E-mail:      florin.leon@academic.tuiasi.ro                           *
 *  Website:     http://florinleon.byethost24.com/lab_ia.html             *
 *  Description: Game playing. Minimax algorithm                          *
 *               (Artificial Intelligence lab 7)                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SimpleCheckers
{
    public enum PlayerType { None, Computer, Human };

    public partial class MainForm : Form
    {
        private PlayerType _currentPlayer; // om sau calculator
        private Bitmap _boardImage;
        private PlayerType [][]_grid;
        private int _size;

        private PlayerType[][] CreateNewGrid()
        {
            PlayerType[][] grid = new PlayerType[_size][];
            for (int i = 0; i < _size; i++)
            {
                grid[i] = new PlayerType[_size];
                for (int j = 0; j < _size; j++)
                {
                    grid[i][j] = PlayerType.None;
                }
            }

            return grid;
        }

        public MainForm()
        {
            InitializeComponent();

            try
            {
                _boardImage = (Bitmap)Image.FromFile("board.png");
            }
            catch
            {
                MessageBox.Show("Nu se poate incarca board.png");
                Environment.Exit(1);
            }

            _currentPlayer = PlayerType.None;
            _size = 3;

            _grid = CreateNewGrid();

            this.ClientSize = new System.Drawing.Size(700, 500);
            this.pictureBoxBoard.Size = new System.Drawing.Size(500, 500);

            pictureBoxBoard.Refresh();
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Bitmap board = new Bitmap(_boardImage);
            e.Graphics.DrawImage(board, 0, 0);

            if (_grid == null)
                return;

            int dy = 250 + 12;
            Pen redPen = new Pen(Color.Red, 3);
            Pen bluePen = new Pen(Color.Blue, 3);
            SolidBrush transparentRed = new SolidBrush(Color.FromArgb(192, 255, 0, 0));
            SolidBrush transparentBlue = new SolidBrush(Color.FromArgb(192, 0, 0, 255));

            for (int i = 0; i < _size; ++i)
            {
                for(int j = 0; j < _size; ++j)
                {
                    if (_grid[i][j] == PlayerType.Computer)
                    {
                        e.Graphics.DrawEllipse(redPen, 12 + i * 125, dy - j * 125, 100, 100);
                    }
                    
                    if(_grid[i][j] == PlayerType.Human)
                    {
                        e.Graphics.DrawLine(bluePen, 12 + i * 125, dy - j * 125, (i + 1) * 125 - 12, dy - (j - 1) * 125 - 24);
                        e.Graphics.DrawLine(bluePen, (i + 1) * 125 - 12, dy - j * 125, 12 + i * 125, dy - (j - 1) * 125 - 24);
                    }
                }
            }
        }

        private bool IsMoveValid(int x, int y)
        {
            if (_grid[x][y] == PlayerType.None)
                return true;
            return false;
        }

        private void MakeMove(PlayerType playerType, int x, int y)
        {
            _grid[x][y] = playerType;
        }

        private void pictureBoxBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentPlayer != PlayerType.Human)
                return;

            int mouseX = e.X / 125;
            int mouseY = 2 - e.Y / 125;

            if (IsMoveValid(mouseX, mouseY))
            {
                MakeMove(PlayerType.Human, mouseX, mouseY);
                pictureBoxBoard.Refresh();

                _currentPlayer = PlayerType.Computer;
                CheckFinish();

                if(_currentPlayer == PlayerType.Computer)
                    ComputerMove();
            }

        }

        private void ComputerMove()
        {
            int nr = Minimax.FindNextPosition(_grid, _size, 0);
            MakeMove(PlayerType.Computer, (int)(nr / 3), nr % 3);
            pictureBoxBoard.Refresh();

            _currentPlayer = PlayerType.Human;
            CheckFinish();
        }

        private void CheckFinish()
        {
            bool end = false;
            PlayerType winner = PlayerType.None;

            for(int i = 0; i < _size; ++i)
            {
                if (_grid[i][0] == _grid[i][1] && _grid[i][1] == _grid[i][2])
                {
                    end = true;
                    winner = _grid[i][0];
                    break;
                }

                if (_grid[0][i] == _grid[1][i] && _grid[1][i] == _grid[2][i])
                {
                    end = true;
                    winner = _grid[0][i];
                    break;
                }
            }

            if(end == false)
            {
                if(_grid[0][0] == _grid[1][1] && _grid[2][2] == _grid[1][1])
                {
                    end = true;
                    winner = _grid[0][0];
                }
                else if(_grid[0][2] == _grid[1][1] && _grid[2][0] == _grid[1][1])
                {
                    end = true;
                    winner = _grid[1][1];
                }
            }

            if (winner == PlayerType.None)
                end = false;

            if(end == false)
            {
                int remainingSpaces = 9;
                for(int i = 0; i < _size; i++)
                {
                    for(int j = 0; j < _size; j++)
                    {
                        if (_grid[i][j] != PlayerType.None)
                        {
                            remainingSpaces--;
                        }
                    }
                }

                if(remainingSpaces == 0)
                {
                    end = true;
                    winner = PlayerType.None;
                }
            }

            if (end)
            {
                if (winner == PlayerType.Computer)
                {
                    MessageBox.Show("Calculatorul a castigat!");
                    _currentPlayer = PlayerType.None;
                }
                else if (winner == PlayerType.Human)
                {
                    MessageBox.Show("Ai castigat!");
                    _currentPlayer = PlayerType.None;
                }
                else if (winner == PlayerType.None)
                {
                    MessageBox.Show("Egalitate!");
                    _currentPlayer = PlayerType.None;
                }
            }
        }

        private void jocNouToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _grid = CreateNewGrid();
            _currentPlayer = PlayerType.Computer;
            ComputerMove();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string copyright =
                "Proiect 2024, X si 0 folosind Algoritmul Minimax \r\n" +
                "Inteligenta artificiala, Laboratorul 8\r\n";

            MessageBox.Show(copyright, "Despre jocul Dame simple");
        }

        private void iesireToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}