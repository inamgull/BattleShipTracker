using System.Collections.Generic;

namespace BattleShipTracker.Entities.Boards
{
    //Class for marking board
    public class MarkingBoard : Board
    {
        public bool MarkSquare(Coordinates coordinates)
        {
            if (Squares[coordinates.Row, coordinates.Column].Status != SquareStatus.Available)
            {
                return false;
            }

            Squares[coordinates.Row, coordinates.Column].Status = SquareStatus.Marked;

            return true;
        }

    }
}
