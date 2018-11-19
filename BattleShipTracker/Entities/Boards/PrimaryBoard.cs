using BattleShipTracker.Entities.Players;
using BattleShipTracker.Entities.Ships;
using BattleShipTracker.Entities.Ships.Requests;
using System;
using System.Collections.Generic;

namespace BattleShipTracker.Entities.Boards
{
    //Class for Primary board
    public class PrimaryBoard : Board
    {
        public PrimaryBoard()
        {

        }

        public bool TryAddShip(AddShipRequest request)
        {
            lock (request)
            {
                switch (request.Direction)
                {
                    case ShipDirection.Horizental:
                        return TryAddShipHorizental(request);
                    case ShipDirection.Vertical:
                        return TryAddShipVertical(request);
                    default:
                        return false;
                }
            }
            
        }

        public Tuple<AttackResult, Square> ProcessAttack(Coordinates coords)
        {
            var square = Squares[coords.Row, coords.Column];
            if (square.Hit)
            {
                return new Tuple<AttackResult, Square>(AttackResult.AlreadyMarked, square);
            }

            if (square.Status != SquareStatus.Available)
            {
                square.Hit = true;
                return new Tuple<AttackResult, Square>(AttackResult.Hit, square);
            }

            return new Tuple<AttackResult, Square>(AttackResult.Miss, square);
        }

        private bool TryAddShipVertical(AddShipRequest request)
        {
            if (!CanAddShipHorizental(request))
            {
                return false;
            }

            for (int i = request.Origin.Row; i < request.Ship.Size; i++)
            {
                Squares[i, request.Origin.Column].Status = request.Ship.ShipSquareStatus;
            }

            return true;
        }

        private bool TryAddShipHorizental(AddShipRequest request)
        {
            if (!CanAddShipVertical(request))
            {
                return false;
            }
            for (int i = request.Origin.Column; i < request.Ship.Size; i++)
            {
                Squares[request.Origin.Row, i].Status = request.Ship.ShipSquareStatus;
            }

            return true;
        }

        private bool CanAddShipVertical(AddShipRequest request)
        {
            if (request.Origin.Row + request.Ship.Size >= Rows)
            {
                return false;
            }

            for (int i = request.Origin.Row; i < request.Ship.Size; i++)
            {
                if (Squares[i, request.Origin.Column].Status != SquareStatus.Available)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CanAddShipHorizental(AddShipRequest request)
        {
            if (request.Origin.Column + request.Ship.Size >= Cols)
            {
                return false;
            }

            for (int i = request.Origin.Column; i < request.Ship.Size; i++)
            {
                if (Squares[request.Origin.Row, i].Status != SquareStatus.Available)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
