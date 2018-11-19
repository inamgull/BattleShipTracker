using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public class Submarine : Ship
    {
        public Submarine():base(3,SquareStatus.SubmarineShip)
        {
            Name = "Submarine";
        }
    }
}
