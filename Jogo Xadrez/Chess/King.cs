using GameBoard;

namespace Chess
{
    public class King : ChessPiece
    {
        public King(Board board, Color color)
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool KingCanMove(Position position)
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
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // North East
            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Right
            position.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // South East
            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Down
            position.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // South West
            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Left
            position.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // North West
            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && KingCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }


            // #

            return mat;
        }
    }
}
