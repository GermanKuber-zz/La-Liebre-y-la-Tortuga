using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.Types;
using Xunit;
using System.Linq;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using System;

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
            ListOfPlayers.Take(2)
                         .ToList()
                         .ForEach(player => player.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2)));
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Return_Number_Of_Player_Of_Two(int quantityOfPlayers)
        {
            SetupSutSutWithPlayers(quantityOfPlayers);
            Sut.NumberOfPlayers.Should().Be(quantityOfPlayers);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Take_Card_From_User(int quantityOfPlayers)
        {
            SetupSutSutWithPlayers(quantityOfPlayers);
            Sut.TakeCard();
            ListOfPlayers.Take(quantityOfPlayers).ToList().ForEach(x => x.Verify(v => v.TakeRacingCard(), Times.Exactly(1)));
        }

        [Theory]
        [InlineData(2,4)]
        [InlineData(3,3)]
        [InlineData(4,4)]
        [InlineData(5,5)]
        public void Give_Differents_Cards_To_Each_Players(int quantityOfPlayers, int quantityOfDiferentsCardsPlayers)
        {
            SetupSutSutWithPlayers(quantityOfPlayers);

            Differentes_Cards_To_All_Players(Sut, quantityOfPlayers, quantityOfDiferentsCardsPlayers);
        }
        [Fact]
        private void Give_One_Cards_Every_Player()
        {
            Sut = new PlayersQuantityType(new Domain.Player.PlayersQuantityType.Players(ListOfPlayers.Select(x => x.Object)));
            Sut.GiveCards(BetCards);
            ListOfPlayers.ForEach(player => player.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(1)));
        }
    }
}