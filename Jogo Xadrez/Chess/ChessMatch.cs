using System;
using GameBoard;
using System.Text;

namespace Chess
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; set; }
        private Color _currentPlayer { get; set; }
        public bool Finished { get; set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            _currentPlayer = Color.White;
            PutPieces();
            Finished = false;
        }

        public void PerformMovement(Position origin, Position destination)
        {
            ChessPiece chessPiece = Board.RemovePiece(origin);
            chessPiece.IncreaseAmountMovements();
            ChessPiece capturedPiece = Board.RemovePiece(destination);
            Board.PuttingPiece(chessPiece, destination);
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
