using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public class BattleShip : Ship
    {
        public BattleShip() : base(4, SquareStatus.BattleShip)
        {
            Name = "BattleShip";
        }
    }
}
