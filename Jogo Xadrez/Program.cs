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
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = chessMatch.Board.chessPiece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    chessMatch.PerformMovement(origin, destiny);
                }
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
