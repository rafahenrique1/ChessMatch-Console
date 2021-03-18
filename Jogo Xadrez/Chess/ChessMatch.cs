using System;
using GameBoard;
using System.Text;

namespace Chess
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();

        }

        public void PerformMovement(Position origin, Position destination)
        {
            ChessPiece chessPiece = Board.RemovePiece(origin);
            chessPiece.IncreaseAmountMovements();
            ChessPiece capturedPiece = Board.RemovePiece(destination);
            Board.PuttingPiece(chessPiece, destination);
        }

        public void MakeAMove(Position origin, Position destination)
        {
            PerformMovement(origin, destination);
            Shift++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.chessPiece(position) == null)
            {
                throw new GameBoardException("There's no piece in the chosen origin position!");
            }
            if (CurrentPlayer != Board.chessPiece(position).Color)
            {
                throw new GameBoardException("The piece of origin chosen is not yours!");
            }
            if (!Board.chessPiece(position).ThereIsPossibleMovements())
            {
                throw new GameBoardException("There aren't possible movements for the chosen piece of origin");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!Board.chessPiece(origin).CanMoveTo(destination))
            {
                throw new GameBoardException("Invalid target position!");
            }
        }

        private void PutPieces()
        {
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PuttingPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PuttingPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }


    }
}
