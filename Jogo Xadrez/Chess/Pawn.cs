using GameBoard;

namespace Chess
{
    public class Pawn : ChessPiece
    {
        public Pawn(Board board, Color color)
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ThereIsEnemy(Position position)
        {
            ChessPiece chessPiece = Board.chessPiece(position);
            return chessPiece != null && chessPiece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.chessPiece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && NumberOfMovements == 0)
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && NumberOfMovements == 0)
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ThereIsEnemy(position))
                {
                    mat[position.Line, position.Column] = true;
                }
            }

            return mat;
        }
    }
}
