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
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.chessPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write(board.chessPiece(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
