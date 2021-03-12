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
    }
}