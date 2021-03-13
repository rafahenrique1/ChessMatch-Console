using System;

namespace GameBoard
{
    public class GameBoardException : Exception
    {
        public GameBoardException(string message)
            : base(message)
        {
        }
    }
}
