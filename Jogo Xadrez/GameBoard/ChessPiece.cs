﻿namespace GameBoard
{
    public abstract class ChessPiece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberOfMovements { get; protected set; }
        public Board Board { get; protected set; }

        public ChessPiece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMovements = 0;
        }

        public void IncreaseAmountMovements()
        {
            NumberOfMovements++;
        }

        public abstract bool[,] PossibleMovements();
    }
}
