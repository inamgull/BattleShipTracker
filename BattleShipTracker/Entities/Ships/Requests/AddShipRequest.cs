using BattleShipTracker.Entities.Boards;

namespace BattleShipTracker.Entities.Ships.Requests
{
    public class AddShipRequest
    {
        public Ship Ship { get; set; }
        public ShipDirection Direction { get; set; }
        public Coordinates Origin { get; set; }
    }
}
