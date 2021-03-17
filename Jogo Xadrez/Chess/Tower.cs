using System;
using GameBoard;

namespace Chess
{
    public class Tower : ChessPiece
    {
        public Tower(Board board, Color color)
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool TowerCanMove(Position position)
        {
            ChessPiece chessPiece = Board.chessPiece(position);
            return chessPiece == null || chessPiece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            // Up
            position.SetValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && TowerCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.Line = position.Line - 1;
            }

            // Down
            position.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(position) && TowerCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.Line = position.Line + 1;
            }

            // Right
            position.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(position) && TowerCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.Column = position.Column + 1;
            }

            // Left
            position.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(position) && TowerCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.Column = position.Column - 1;
            }

            return mat;
        }
    }
}