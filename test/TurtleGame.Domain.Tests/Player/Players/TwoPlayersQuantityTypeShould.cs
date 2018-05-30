using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.Types;
using Xunit;

namespace TurtleGame.Domain.Tests.Player.Players
{
    public class TwoPlayersQuantityTypeShould : PlayersQuantityTypeShouldBase
    {

        public TwoPlayersQuantityTypeShould()
        {
            Sut = new PlayersQuantityType(new Domain.Player.PlayersQuantityType.Players(new List<IPlayer> { PlayerOne.Object, PlayerTwo.Object }));
        }

        [Fact]
        private void Give_Two_Cards_Every_Player()
        {
            Sut.GiveCards(BetCards);
            ListOfPlayers.ForEach(player => player.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2)));
        }

        [Fact]
        public void Give_Differents_Cards_To_Two_Players()
        {
            Sut = new PlayersQuantityType(new Domain.Player.PlayersQuantityType.Players(new List<IPlayer> { PlayerOne.Object, PlayerOne.Object }));

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
            ListOfPlayers.ForEach(player => player.Should().NotBeNull());
            ListOfPlayers.ForEach(player => player.Should().BeOfType<NonePlayer>());
        }
        [Fact]
        public void Take_Card_From_User()
        {
            Sut.TakeCard();

            PlayerOne.Verify(x => x.TakeRacingCard(), Times.Exactly(1));
        }
        [Fact]
        public void Give_Differents_Cards_To_Three_Players()
        {
            Sut = new PlayersQuantityType(new Domain.Player.PlayersQuantityType.Players(new List<IPlayer> { PlayerOne.Object, PlayerOne.Object, PlayerOne.Object, PlayerOne.Object, PlayerOne.Object }));

            Differentes_Cards_To_All_Players(Sut, 5);
        }
        [Fact]
        private void Give_One_Cards_Every_Player()
        {
            Sut.GiveCards(BetCards);
            ListOfPlayers.ForEach(player => player.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1)));
        }
    }
}