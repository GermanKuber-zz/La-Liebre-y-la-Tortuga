using FluentAssertions;
using Moq;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayersQuantityTypeShould
    {

        private IPlayersQuantityType _sut;
        private Mock<IPlayers> _mockIPlayers = new Mock<IPlayers> { DefaultValue = DefaultValue.Mock };
        private Mock<IPlayer> _firstPlayer = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        private Mock<IPlayer> _secondPlayer = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        public PlayersQuantityTypeShould()
        {
            _mockIPlayers.Setup(x => x.First()).Returns(_firstPlayer.Object);
            _mockIPlayers.Setup(x => x.GiveMeNextTo(_firstPlayer.Object))
                       .Returns(_secondPlayer.Object);

            _sut = new PlayersQuantityType(_mockIPlayers.Object);
        }

        [Fact]
        public void Show_First_Player_Is_Player_One()
        {
            _sut.CurrentFirstPlayer.Should().Be(_firstPlayer.Object);
        }

        [Fact]
        public void Change_First_Player_To_Second()
        {
            _sut.ChangeFirstPlayer();
            _sut.CurrentFirstPlayer.Should().Be(_secondPlayer.Object);
        }
    }
}
