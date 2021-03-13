using GameBoard;
using System;
using Chess;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testando a Classe ToPosition
            ChessPosition chessPosition = new ChessPosition('a', 1);

            Console.WriteLine(chessPosition);

            Console.WriteLine(chessPosition.ToPosition());
        }
    }
}
