using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships
{
    public class Carrier : Ship
    {
        public Carrier() :base(5,SquareStatus.CarrierShip)
        {
            Name = "Carrier";
           
        }
    }
}
