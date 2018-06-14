using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayerShould
    {
        private IPlayers _sut;
        private IEnumerable<IPlayer> _mockListOfPlayers;
        private Mock<IPlayer> _firstPlayer = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        private Mock<IPlayer> _secondPlayer = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };

        public PlayerShould()
        {
            _mockListOfPlayers = new List<IPlayer> { _firstPlayer.Object, _secondPlayer.Object };
            _sut = new Domain.Player.Players(_mockListOfPlayers);
        }

        [Fact]
        public void Return_Me_Second_Player()
        {
            _sut.GiveMeNextTo(_firstPlayer.Object).Should().Be(_secondPlayer.Object);
        }
        [Fact]
        public void Return_Me_First_Player_When_The_Previous_Was_The_Last()
        {
            _sut.GiveMeNextTo(_firstPlayer.Object);
            _sut.GiveMeNextTo(_secondPlayer.Object).Should().Be(_firstPlayer.Object);
        }

    }
}

