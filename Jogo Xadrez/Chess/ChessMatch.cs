using System;
using GameBoard;
using System.Text;
using System.Collections.Generic;

namespace Chess
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; set; }
        private HashSet<ChessPiece> _pieces;
        private HashSet<ChessPiece> _captured;


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            _pieces = new HashSet<ChessPiece>();
            _captured = new HashSet<ChessPiece>();
            PutPieces();

        }

        public void PerformMovement(Position origin, Position destination)
        {
            ChessPiece chessPiece = Board.RemovePiece(origin);
            chessPiece.IncreaseAmountMovements();
            ChessPiece capturedPiece = Board.RemovePiece(destination);
            Board.PuttingPiece(chessPiece, destination);
            if (capturedPiece != null)
            {
                _captured.Add(capturedPiece);
            }
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

        public HashSet<ChessPiece> CapturedPieces(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece piece in _captured)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<ChessPiece> PiecesInPlay(Color color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece piece in _pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            aux.ExceptWith(CapturedPieces(color));
            return aux;
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

        public void PutNewPiece(char column, int line, ChessPiece piece)
        {
            Board.PuttingPiece(piece, new ChessPosition(column, line).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Board, Color.White));
            PutNewPiece('c', 2, new Tower(Board, Color.White));
            PutNewPiece('d', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 2, new Tower(Board, Color.White));
            PutNewPiece('e', 1, new Tower(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('c', 7, new Tower(Board, Color.Black));
            PutNewPiece('c', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 7, new Tower(Board, Color.Black));
            PutNewPiece('e', 8, new Tower(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));
        }


    }
}
