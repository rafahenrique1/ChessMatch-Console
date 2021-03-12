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


    }
}
