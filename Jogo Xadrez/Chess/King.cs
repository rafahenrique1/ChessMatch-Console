﻿using System;
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
    }
}
