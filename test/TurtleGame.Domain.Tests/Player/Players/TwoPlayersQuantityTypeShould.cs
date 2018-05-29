using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.Types;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Players
{
    public class TwoPlayersQuantityTypeShould : PlayersQuantityTypeBase
    {

        public TwoPlayersQuantityTypeShould()
        {
            Sut = new TwoPlayersQuantityType(PlayerOne.Object, PlayerTwo.Object);
        }

        [Fact]
        private void Give_Two_Cards_Every_Player()
        {
            Sut.GiveCards(BetCards);
            PlayerOne.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2));
            PlayerTwo.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2));
        }

        [Fact]
        public void Give_Differents_Cards_To_Two_Players()
        {
            Sut = new TwoPlayersQuantityType(PlayerOne.Object, PlayerOne.Object);

            Differentes_Cards_To_All_Players(Sut, 4);
        }
        [Fact]
        public void Return_Number_Of_Player_Of_Two()
        {
            Sut.NumberOfPlayers.Should().Be(2);
        }
        [Fact]
        public void To_Assign_Players_Property()
        {
            Sut.PlayerOne.Should().NotBeNull();
            Sut.PlayerTwo.Should().NotBeNull();
            Sut.PlayerThree.Should().BeOfType<NonePlayer>();
            Sut.PlayerFour.Should().BeOfType<NonePlayer>();
            Sut.PlayerFive.Should().BeOfType<NonePlayer>();
        }
        [Fact]
        public void Take_Card_From_User()
        {
            Sut.TakeCard();

            PlayerOne.Verify(x => x.TakeRacingCard(), Times.Exactly(1));
        }

    }
}