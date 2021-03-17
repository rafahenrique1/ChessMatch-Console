using System;
using Chess;
using GameBoard;

namespace Jogo_Xadrez
{
    public class Screen
    {
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
            ConsoleColor originalBackgroud = Console.BackgroundColor;
            ConsoleColor changedBackgroud = ConsoleColor.DarkBlue;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackgroud;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackgroud;
                    }

                    PrinterPiece(board.chessPiece(i, j));
                }

                Console.BackgroundColor = originalBackgroud;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = originalBackgroud;
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
