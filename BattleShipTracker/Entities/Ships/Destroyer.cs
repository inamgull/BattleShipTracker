using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer() : base(2,SquareStatus.DestroyerShip)
        {
            Name = "Destroyer";
        }
    }
}
