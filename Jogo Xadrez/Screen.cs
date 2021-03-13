using System;
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
                    if (board.chessPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrinterPiece(board.chessPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void PrinterPiece(ChessPiece chessPiece)
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
        }
    }
}
