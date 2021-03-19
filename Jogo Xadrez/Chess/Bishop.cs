using GameBoard;

namespace Chess
{
    public class Bishop : ChessPiece
    {
        public Bishop(Board board, Color color)
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool BishopCanMove(Position position)
        {
            ChessPiece chessPiece = Board.chessPiece(position);
            return chessPiece == null || chessPiece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            // North West
            position.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && BishopCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.SetValues(position.Line - 1, position.Line + 1);       
            }

            // North West
            position.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && BishopCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.SetValues(position.Line - 1, position.Line - 1);
            }

            // North East
            position.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && BishopCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.SetValues(position.Line - 1, position.Line + 1);
            }

            // South East
            position.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && BishopCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.SetValues(position.Line + 1, position.Line + 1);
            }

            // South West
            position.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && BishopCanMove(position))
            {
                mat[position.Line, position.Column] = true;
                if (Board.chessPiece(position) != null && Board.chessPiece(position).Color != Color)
                {
                    break;
                }

                position.SetValues(position.Line + 1, position.Line - 1);
            }

            return mat;
        }
    }
}
