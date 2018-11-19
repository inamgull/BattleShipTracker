using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BattleShipTracker.Entities.Boards;
using BattleShipTracker.Entities.Boards.Validators;
using BattleShipTracker.Entities.Ships;
using BattleShipTracker.Entities.Ships.Requests;

namespace BattleShipTracker.Entities.Players
{
    //Player class for a single player. Has Name, Primary and Marking Board and exposes methods to process attack.
    public class Player
    {
        public string Name { get; }
        public PrimaryBoard PrimaryBoard { get; set; }
        public MarkingBoard MarkingBoard { get; set; }
        public IList<Ship> Ships { get; set; }

        public bool HasLost() => Ships.All(x => x.IsSunk);

        public Player(string name)
        {
            Name = name;

            PrimaryBoard = new PrimaryBoard();
            MarkingBoard = new MarkingBoard();
            Ships = new List<Ship>();
        }

        public bool AddShip(AddShipRequest request)
        {
            var validator = new AddShipRequestValidator();
            var validationResults = validator.Validate(request);
            if (validationResults.Errors.Any())
            {
                //in real world return the real errors.
                throw new ArgumentException($"Invalid Argument Exception.{nameof(request)}");
            }

            if (Ships.FirstOrDefault(x => x.ShipSquareStatus == request.Ship.ShipSquareStatus) != null)
            {
                return false;
            }
            //only add ship if it is not already on board and 
            if (!PrimaryBoard.TryAddShip(request)) return false;
            Ships.Add(request.Ship);
            return true;

        }

        public AttackResult ProcessAttack(Coordinates coords)
        {
            var validationResults = new CoordinateValidator().Validate(coords);

            if (validationResults.Errors.Any())
            {
                throw new ArgumentException($"Invalid Argument Exception.{nameof(coords)}");
            }

            var result = PrimaryBoard.ProcessAttack(coords);
            if (result.Item1 == AttackResult.Hit)
            {
                var ship = Ships.First(x => x.ShipSquareStatus == result.Item2.Status);
                ship.IncrementHit();
            }

            return result.Item1;
        }


    }
}
