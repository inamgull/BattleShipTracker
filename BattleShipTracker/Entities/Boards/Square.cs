using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipTracker.Entities.Boards
{
    public class Square
    {
        public Coordinates Coordinates { get; set; }
        public SquareStatus Status { get; set; }
        public bool Hit { get; set; }
        public Square(Coordinates coordinates)
        {
            Coordinates = coordinates;
            Status = SquareStatus.Available;
            Hit = false;
        }


    }
}
