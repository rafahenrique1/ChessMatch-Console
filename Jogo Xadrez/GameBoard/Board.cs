namespace GameBoard
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private ChessPiece[,] _chessPiece { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _chessPiece = new ChessPiece[Lines, Columns];
        }

        public ChessPiece chessPiece(int line, int column)
        {
            return _chessPiece[line, column];
        }

        public ChessPiece chessPiece(Position position)
        {
            return _chessPiece[position.Line, position.Column];
        }

        public bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return chessPiece(position) != null;

        }

        public void PuttingPiece(ChessPiece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new GameBoardException("There's already a piece in that position!");
            }
            _chessPiece[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new GameBoardException("Invalid position!");
            }
        }

    }
}
