using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Xsi0
{
    public enum PlayerType { None, Computer, Human };

    public partial class MainForm : Form
    {
        private PlayerType _currentPlayer;
        private Bitmap _boardImage;
        private GameGrid _gameGrid;

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

            _currentPlayer = PlayerType.Computer;

            this.ClientSize = new System.Drawing.Size(700, 500);
            this.pictureBoxBoard.Size = new System.Drawing.Size(500, 500);

            pictureBoxBoard.Refresh();
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Bitmap board = new Bitmap(_boardImage);
            e.Graphics.DrawImage(board, 0, 0);

            if (_gameGrid == null)
                return;

            int dy = 250 + 12;
            Pen redPen = new Pen(Color.Red, 3);
            Pen bluePen = new Pen(Color.Blue, 3);

            for (int i = 0; i < _gameGrid.Size; ++i)
            {
                for(int j = 0; j < _gameGrid.Size; ++j)
                {
                    if (_gameGrid.Elements[i][j] == PlayerType.Computer)
                    {
                        e.Graphics.DrawEllipse(redPen, 12 + i * 125, dy - j * 125, 100, 100);
                    }
                    
                    if(_gameGrid.Elements[i][j] == PlayerType.Human)
                    {
                        e.Graphics.DrawLine(bluePen, 12 + i * 125, dy - j * 125, (i + 1) * 125 - 12, dy - (j - 1) * 125 - 24);
                        e.Graphics.DrawLine(bluePen, (i + 1) * 125 - 12, dy - j * 125, 12 + i * 125, dy - (j - 1) * 125 - 24);
                    }
                }
            }
        }

        private bool IsMoveValid(int x, int y)
        {
            if (_gameGrid.Elements[x][y] == PlayerType.None)
                return true;
            return false;
        }

        private void MakeMove(PlayerType playerType, int x, int y)
        {
            _gameGrid.Elements[x][y] = playerType;
        }

        private void pictureBoxBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if(_gameGrid == null)
            {
                MessageBox.Show("Porneste jocul!");
            }

            if (_currentPlayer != PlayerType.Human)
                return;

            int mouseX = e.X / 125;
            int mouseY = 2 - e.Y / 125;

            bool valid;

            try
            {
                valid = IsMoveValid(mouseX, mouseY);
            }
            catch
            {
                MessageBox.Show("Apasa in chenar!");
                valid = false;
            }

            if (valid)
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
            Pair coordinates = Minimax.FindNextPosition(_gameGrid, 0);
            MakeMove(PlayerType.Computer, coordinates.First(), coordinates.Second());
            pictureBoxBoard.Refresh();

            _currentPlayer = PlayerType.Human;
            CheckFinish();
        }

        private void CheckFinish()
        {
            bool end;
            PlayerType winner;
            _gameGrid.CheckFinish(out end, out winner);

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
            _gameGrid = new GameGrid();
            pictureBoxBoard.Refresh();

            if (_currentPlayer == PlayerType.None)
            {
                if (jucatorTextBox.Text == "Jucator: Om")
                    _currentPlayer = PlayerType.Human;
                else
                    _currentPlayer = PlayerType.Computer;
            }

            if (_currentPlayer == PlayerType.Computer)
                ComputerMove();
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string copyright =
                "X si 0 folosind Algoritmul Minimax \r\n" +
                "Inteligenta artificiala, Proiect 2024\r\n" +
                "Facut de Stoean Vlad, Tamas Priscil Gabriel si Apostu Radu\r\n";

            MessageBox.Show(copyright, "Despre jocul X si 0");
        }

        private void iesireToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPlayer = PlayerType.Computer;
            jucatorTextBox.Text = "Jucator: Computer";
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentPlayer = PlayerType.Human;
            jucatorTextBox.Text = "Jucator: Om";
        }
    }
}