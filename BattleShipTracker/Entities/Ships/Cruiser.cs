using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser() : base(3,SquareStatus.CruiserShip)
        {
            Name = "Cruiser";
        }
    }
}
