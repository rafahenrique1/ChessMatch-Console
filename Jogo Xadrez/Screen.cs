using System;
using System.Collections.Generic;
using Chess;
using GameBoard;

namespace Jogo_Xadrez
{
    public class Screen
    {
        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Shift: " + chessMatch.Shift);
           
            if (!chessMatch.Finished)
            {
                Console.WriteLine("Wait for movement: " + chessMatch.CurrentPlayer);
                if (chessMatch.Check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("Winner: " + chessMatch.CurrentPlayer);
            }
        }

        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(chessMatch.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(chessMatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<ChessPiece> chessPieces)
        {
            Console.Write("[");
            foreach(ChessPiece piece in chessPieces)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    PrinterPiece(board.chessPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkBlue;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrinterPiece(board.chessPiece(i, j));
                }

                Console.BackgroundColor = originalBackground;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string readPosition = Console.ReadLine();
            char column = readPosition[0];
            int line = int.Parse(readPosition[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrinterPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (chessPiece.Color == Color.White)
                {
                    Console.Write(chessPiece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(chessPiece);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}
