using GameBoard;
using System;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testando compilação da Classe Board 
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);
        }


    }
}
