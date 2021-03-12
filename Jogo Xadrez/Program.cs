using GameBoard;
using System;
using Chess;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testando compilação da Classe Board 
            Board board = new Board(8, 8);

            // Colocando algumas peças no Tabuleiro para teste
            board.PuttingPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.PuttingPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.PuttingPiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);
        }


    }
}
