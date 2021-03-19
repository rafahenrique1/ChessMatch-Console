using GameBoard;

namespace Chess
{
    public class Horse : ChessPiece
    {
        public Horse(Board board, Color color)
            : base(board, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        private bool HorseCanMove(Position position)
        {
            ChessPiece chessPiece = Board.chessPiece(position);
            return chessPiece == null || chessPiece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            position.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && HorseCanMove(position))
            {
                mat[position.Line, position.Column] = true;
            }

            return mat;
        }
    }
}
