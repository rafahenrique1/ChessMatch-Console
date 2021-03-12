namespace GameBoard
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private ChessPiece[,] _chessPieces { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _chessPieces = new ChessPiece[Lines, Columns];
        }

        public ChessPiece chessPiece(int line, int column)
        {
            return _chessPieces[line, column];
        }

        public void PuttingPiece(ChessPiece piece, Position position)
        {
            _chessPieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

    }
}
