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


        public bool HasLost() => PrimaryBoard.AllSunk();

        public Player(string name)
        {
            Name = name;

            PrimaryBoard = new PrimaryBoard();
            MarkingBoard = new MarkingBoard();
            
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

            
            //only add ship if it is not already on board and 
            return PrimaryBoard.TryAddShip(request);
        }

        public AttackResult ProcessAttack(Coordinates coords)
        {
            var validationResults = new CoordinateValidator().Validate(coords);

            if (validationResults.Errors.Any())
            {
                throw new ArgumentException($"Invalid Argument Exception.{nameof(coords)}");
            }

            var result = PrimaryBoard.ProcessAttack(coords);

            return result.Item1;
        }


    }
}
