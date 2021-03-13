using GameBoard;
using System;
using Chess;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Testando compilação da Classe Board 
                Board board = new Board(8, 8);

                // Colocando algumas peças no Tabuleiro para teste
                board.PuttingPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PuttingPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.PuttingPiece(new King(board, Color.Black), new Position(0, 2));

                board.PuttingPiece(new Tower(board, Color.White), new Position(3, 5));

                Screen.PrintBoard(board);
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
