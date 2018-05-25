using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Types;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Types
{
    public class ThreePlayersShould : PlayersShouldBase
    {
        public ThreePlayersShould()
        {
            Sut = new ThreePlayers(PlayerOne.Object, PlayerTwo.Object, PlayerThree.Object);
        }

        [Fact]
        private void Give_One_Cards_Every_Player()
        {
            Sut.GiveCards(BetCards);
            PlayerOne.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
            PlayerTwo.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
            PlayerThree.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
        }

        [Fact]
        public void Give_Differents_Cards_To_Three_Players()
        {
            Sut = new ThreePlayers(PlayerOne.Object, PlayerOne.Object, PlayerOne.Object);

            Differentes_Cards_To_All_Players(Sut, 3);
        }
        [Fact]
        public void Return_Number_Of_Player_Of_Three()
        {
            Sut.NumberOfPlayers.Should().Be(3);
        }
        [Fact]
        public void To_Assign_Players_Property()
        {
            Sut.PlayerOne.Should().NotBeNull();
            Sut.PlayerTwo.Should().NotBeNull();
            Sut.PlayerThree.Should().NotBeNull();
            Sut.PlayerFour.Should().BeOfType<NonePlayer>();
            Sut.PlayerFive.Should().BeOfType<NonePlayer>();
        }
    }
}