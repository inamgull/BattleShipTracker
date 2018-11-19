using System;
using System.Collections.Generic;
using System.Text;
using BattleShipTracker.Entities.Boards;
using BattleShipTracker.Entities.Players;
using BattleShipTracker.Entities.Ships;
using BattleShipTracker.Entities.Ships.Requests;
using Xunit;

namespace BattleShipTracker.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_WhenInitiated_ReturnsCorrectName()
        {
            //Arrange

            var player = new Player("Inam Gull");
            //Act
            var name = player.Name;

            //Assert
            Assert.Equal("Inam Gull", name);
        }

        [Fact]
        public void Player_WhenInitiated_ReturnsCorrectBoardsAndShips()
        {
            //Arrange & Act
            var player = new Player("Inam Gull");


            //Assert
            Assert.NotNull(player.PrimaryBoard);
            Assert.NotNull(player.MarkingBoard);
            Assert.NotNull(player.Ships);

        }

        [Fact]
        public void AddShip_WhenShipIsAdded_ReturnsSuccess()
        {
            //Arrange
            var player = new Player("My Player");


            var request = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(0, 0),
                Ship = new BattleShip()
                {
                    Name = "BattleShip"
                }
            };
            //Act
            var result = player.AddShip(request);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddShip_WhenAddedShipIsAlreadyPresent_ReturnsFalse()
        {
            //Arrange
            var player = new Player("My Player");

            var request = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(0, 0),
                Ship = new BattleShip()
                {
                    Name = "BattleShip"
                }
            };

            //Act
            player.AddShip(request);
            var result = player.AddShip(request);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void HasLost_WhenAllShipsSunk_ReturnTrue()
        {
            //Arrange
            var player = new Player("My Player");

            var request = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(0, 0),
                Ship = new Destroyer()
                {
                    Name = "Destroyer"
                }
            };

            //Act
            player.AddShip(request);
            player.ProcessAttack(new Coordinates(0, 0));
            player.ProcessAttack(new Coordinates(0, 1));
            player.ProcessAttack(new Coordinates(0, 2));

            //Assert
            var hasLost = player.HasLost();
            Assert.True(hasLost);
        }

        [Fact]
        public void HasLost_WhenAllShipsNotSunk_ReturnFalse()
        {
            //Arrange
            var player = new Player("My Player");

            var request = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(0, 0),
                Ship = new Destroyer
                {
                    Name = "Destroyer"
                }
            };

            var cruiserRequest = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(1, 0),
                Ship = new Cruiser
                {
                    Name = "Cruiser"
                }
            };

            //Act
            player.AddShip(request);
            player.AddShip(cruiserRequest);

            player.ProcessAttack(new Coordinates(0, 0));
            player.ProcessAttack(new Coordinates(0, 1));
            player.ProcessAttack(new Coordinates(0, 2));

            //Assert
            var hasLost = player.HasLost();
            Assert.False(hasLost);
        }

        [Fact]
        public void AddShip_WhenProvidedWithWrongCoordinates_ReturnFalse()
        {
            //Arrange
            var player = new Player("My Player");

            var request = new AddShipRequest
            {
                Direction = ShipDirection.Horizental,
                Origin = new Coordinates(-1, -1),
                Ship = new Destroyer()
                {
                    Name = "Destroyer"
                }
            };

            //Act & Assert
            Assert.Throws<ArgumentException>(()=>player.AddShip(request));
            
        }

    }
}
