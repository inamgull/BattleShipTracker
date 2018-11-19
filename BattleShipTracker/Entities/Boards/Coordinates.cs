namespace BattleShipTracker.Entities.Boards
{
   
    public class Coordinates
    {
        public int Row { get; }
        public int Column { get;}

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
