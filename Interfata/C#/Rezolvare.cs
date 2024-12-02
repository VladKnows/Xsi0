using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SimpleCheckers
{
    public partial class Board
    {
        /// <summary>
        /// Calculeaza functia de evaluare statica pentru configuratia (tabla) curenta
        /// </summary>
        public double EvaluationFunction()
        {
            double sumY = 0;
            foreach (var piece in Pieces)
                sumY += piece.Y;

            return 12 - sumY;
        }

        /// <summary>
        /// Calculeaza functia de evaluare statica pentru configuratia curenta
        /// Modul in care acest lucru se face:
        /// +Cu cat piesele calculatorului sunt mai in fata cu atat acumuleaza un numar mai mare de puncte
        /// +Cu cat piesele jucatorului sunt mai in fata cu atat se scade mai mult din numarul de puncte
        /// +Cu cat sunt mai aproape piesele calculatorului de un loc liber de final pe tabla se acumuleaza mai multe puncte
        /// +Se scad puncte pentru fiecare piesa care nu s-a deplasat de pe prima linie (din partea calculatorului)
        /// </summary>
        public double SmarterEvaluationFunction()
        {
            double sumComputer = 0, sumPlayer = 0;

            foreach (var piece in Pieces)
            {
                if (piece.Player == PlayerType.Human)
                {
                    sumPlayer += Math.Pow(4, piece.Y);
                }
                else
                {
                    if (piece.Y != 3)
                        sumComputer += Math.Pow(4, Size - 1 - piece.Y);
                    else
                        sumComputer -= 50;

                    if (piece.Y != 0)
                    {
                        int[] xToFinish = { 1, 1, 1, 1 };

                        foreach (var piece2 in Pieces)
                        {
                            if (piece2.Y == 0)
                                xToFinish[piece2.X] = 0;
                        }

                        int minDist = 3;
                        for (int i = 0; i < 4; ++i)
                        {
                            if (xToFinish[i] == 0)
                                continue;
                            else
                            {
                                if (minDist > Math.Abs(piece.X - i))
                                    minDist = Math.Abs(piece.X - i);
                            }
                        }

                        sumComputer += Math.Pow(2, 3 - minDist);
                    }
                }
            }

            return sumComputer - sumPlayer;
        }
    }

    //=============================================================================================================================

    public partial class Piece
    {
        /// <summary>
        /// Returneaza lista tuturor mutarilor permise pentru piesa curenta (this)
        /// in configuratia (tabla de joc) primita ca parametru
        /// </summary>
        public List<Move> ValidMoves(Board currentBoard)
        {
            List<Move> validMoves = new List<Move>();
            for (int i = 0; i < 9; ++i)
            {
                Move move = new Move(this.Id, (X - 1) + (i / 3), (Y - 1) + (i % 3));
                if (IsValidMove(currentBoard, move))
                    validMoves.Add(move);
            }
            return validMoves;
        }

        /// <summary>
        /// Testeaza daca o mutare este valida intr-o anumita configuratie
        /// </summary>
        public bool IsValidMove(Board currentBoard, Move move)
        {
            if(move.NewX < 0 || move.NewY < 0 || move.NewX >= currentBoard.Size || move.NewY >= currentBoard.Size)
                return false;

            foreach(var piece in currentBoard.Pieces)
            {
                if(piece.X == move.NewX && piece.Y == move.NewY)
                    return false;
            }

            if (Math.Abs(this.X - move.NewX) > 1 || Math.Abs(this.Y - move.NewY) > 1)
                return false;

            return true;
        }
    }

    //=============================================================================================================================

    public partial class Minimax
    {
        /// <summary>
        /// Primeste o configuratie ca parametru, cauta mutarea optima si returneaza configuratia
        /// care rezulta prin aplicarea acestei mutari optime
        /// </summary>
        private static int maxDepth;
        private static Board bestBoard;
        public static Board FindNextBoard(Board currentBoard, int depth)
        {
            if(depth == 0)
            {
                maxDepth = 2;
            }

            Board bestCurrentBoard = new Board();
            double currentMax = Double.MinValue;

            foreach(var piece in currentBoard.Pieces)
            {
                PlayerType playerType;

                if (depth % 2 == 0)
                    playerType = PlayerType.Computer;
                else
                    playerType = PlayerType.Human;

                if(piece.Player == playerType)
                {
                    foreach(var move in piece.ValidMoves(currentBoard))
                    {
                        Board newBoard = currentBoard.MakeMove(move);

                        if (depth != maxDepth)
                        {
                            Board nextBoard = FindNextBoard(newBoard, depth + 1);
                            
                            if(nextBoard.SmarterEvaluationFunction() > currentMax)
                            {
                                bestCurrentBoard = nextBoard;
                                currentMax = nextBoard.SmarterEvaluationFunction();

                                if(depth == 0)
                                {
                                    bestBoard = newBoard;
                                }
                            }
                        }
                        else
                        {
                            if(newBoard.SmarterEvaluationFunction() > currentMax)
                            {
                                currentMax = newBoard.SmarterEvaluationFunction();
                                bestCurrentBoard = newBoard;
                            }
                        }
                        
                    }
                }
            }

            if(depth == 0)
                return bestBoard;
            else
                return bestCurrentBoard;
        }
    }
}