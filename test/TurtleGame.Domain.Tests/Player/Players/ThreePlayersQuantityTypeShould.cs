using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.PlayersQuantityType;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Players
{
    public class ThreePlayersQuantityTypeShould : PlayersQuantityTypeBase
    {
        public ThreePlayersQuantityTypeShould()
        {
            Sut = new ThreePlayersQuantityType(PlayerOne.Object, PlayerTwo.Object, PlayerThree.Object);
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
            Sut = new ThreePlayersQuantityType(PlayerOne.Object, PlayerOne.Object, PlayerOne.Object);

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
            Sut.PlayerThree.Should().NotBeNull();
        }
        [Fact]
        public void Take_Card_From_User()
        {
            Sut.TakeCard();

            PlayerThree.Verify(x => x.TakeRacingCard(), Times.Exactly(1));
        }

     
    }
}