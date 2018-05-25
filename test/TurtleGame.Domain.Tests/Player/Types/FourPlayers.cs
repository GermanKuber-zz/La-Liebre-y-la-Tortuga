using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Players;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Types
{
    public class FourPlayersShould : PlayersShouldBase
    {
        public FourPlayersShould()
        {
            Sut = new FourPlayers(PlayerOne.Object, PlayerTwo.Object, PlayerThree.Object, PlayerFour.Object, MockRacingCardManager.Object);
        }

        [Fact]
        private void Give_One_Cards_Every_Player()
        {
            Sut.GiveCards(BetCards);
            PlayerOne.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
            PlayerTwo.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
            PlayerThree.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
            PlayerFour.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1));
        }

        [Fact]
        public void Give_Differents_Cards_To_Three_Players()
        {
            Sut = new FourPlayers(PlayerOne.Object, PlayerOne.Object, PlayerOne.Object, PlayerOne.Object, MockRacingCardManager.Object);

            Differentes_Cards_To_All_Players(Sut, 4);
        }
        [Fact]
        public void Return_Number_Of_Player_Of_Three()
        {
            Sut.NumberOfPlayers.Should().Be(4);
        }
        [Fact]
        public void To_Assign_Players_Property()
        {
            Sut.PlayerOne.Should().NotBeNull();
            Sut.PlayerTwo.Should().NotBeNull();
            Sut.PlayerThree.Should().NotBeNull();
            Sut.PlayerFour.Should().NotBeNull();
            Sut.PlayerFive.Should().BeOfType<NonePlayer>();
        }
    }
}