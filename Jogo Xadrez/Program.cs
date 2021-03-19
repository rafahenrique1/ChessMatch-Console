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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = chessMatch.Board.chessPiece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        chessMatch.ValidateDestinationPosition(origin, destination);

                        chessMatch.MakeAMove(origin, destination);
                    }
                    catch(GameBoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.PrintMatch(chessMatch);
            }
            catch (GameBoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
