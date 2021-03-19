using System;
using GameBoard;
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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            _pieces = new HashSet<ChessPiece>();
            _captured = new HashSet<ChessPiece>();
            PutPieces();
        }

        public ChessPiece PerformMovement(Position origin, Position destination)
        {
            ChessPiece chessPiece = Board.RemovePiece(origin);
            chessPiece.IncreaseAmountMovements();
            ChessPiece capturedPiece = Board.RemovePiece(destination);
            Board.PuttingPiece(chessPiece, destination);
            if (capturedPiece != null)
            {
                _captured.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, ChessPiece capturedPiece)
        {
            ChessPiece chessPiece = Board.RemovePiece(destination);
            chessPiece.DecreaseAmountMovements();
            if (capturedPiece != null)
            {
                Board.PuttingPiece(capturedPiece, destination);
                _captured.Remove(capturedPiece);
            }

            Board.PuttingPiece(chessPiece, origin);
        }

        public void MakeAMove(Position origin, Position destination)
        {
            ChessPiece capturedPiece = PerformMovement(origin, destination);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new GameBoardException("You cannot put yourself in check!");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckMateTest(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
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

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private ChessPiece King(Color color)
        {
            foreach (ChessPiece piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool IsInCheck(Color color)
        {
            ChessPiece K = King(color);
            if (K == null)
            {
                throw new GameBoardException($"There's no King of color {color} on the board!");
            }

            foreach (ChessPiece piece in PiecesInPlay(Opponent(color)))
            {
                bool[,] mat = piece.PossibleMovements();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (ChessPiece piece in PiecesInPlay(color))
            {
                bool[,] mat = piece.PossibleMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destination = new Position(i, j);
                            ChessPiece capturedPiece = PerformMovement(origin, destination);
                            bool checkTest = IsInCheck(color);
                            UndoMovement(origin, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void PutNewPiece(char column, int line, ChessPiece piece)
        {
            Board.PuttingPiece(piece, new ChessPosition(column, line).ToPosition());
            _pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(Board, Color.White));
            PutNewPiece('b', 1, new Horse(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Horse(Board, Color.White));
            PutNewPiece('h', 1, new Tower(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White));
            PutNewPiece('b', 2, new Pawn(Board, Color.White));
            PutNewPiece('c', 2, new Pawn(Board, Color.White));
            PutNewPiece('d', 2, new Pawn(Board, Color.White));
            PutNewPiece('e', 2, new Pawn(Board, Color.White));
            PutNewPiece('f', 2, new Pawn(Board, Color.White));
            PutNewPiece('g', 2, new Pawn(Board, Color.White));
            PutNewPiece('h', 2, new Pawn(Board, Color.White));

            PutNewPiece('a', 8, new Tower(Board, Color.Black));
            PutNewPiece('b', 8, new Horse(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Horse(Board, Color.Black));
            PutNewPiece('h', 8, new Tower(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black));
        }
    }
}
