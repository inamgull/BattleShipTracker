using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Size { get; }
        public int Hits { get; private set; } = 0;

        public SquareStatus ShipSquareStatus { get;}
        public bool IsSunk => Hits >= Size;
        protected Ship(int size, SquareStatus shipSquareStatus)
        {
            Size = size;
            ShipSquareStatus = shipSquareStatus;
        }

        public void IncrementHit()
        {
            Hits++;
        }
    }
}
