using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using TurtleGame.SharedKernel.Generators;

namespace TurtleGame.Domain.Tests.Player.Players
{
    public class PlayersQuantityTypeShouldBase
    {
        protected readonly Mock<IPlayer> PlayerOne = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerTwo = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerThree = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerFour = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerFive = new Mock<IPlayer>();
        protected readonly List<IBetCard> BetCards = new List<IBetCard>();
        public List<Mock<IPlayer>> ListOfPlayers { get; set; }
        protected IPlayersQuantityType Sut;
        public PlayersQuantityTypeShouldBase()
        {
            BetCards.AddRange(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
            ListOfPlayers = new List<Mock<IPlayer>> { PlayerOne, PlayerTwo, PlayerThree, PlayerFour, PlayerFive };
        }

        protected void Differentes_Cards_To_All_Players(IPlayersQuantityType players, int countOfPlayers)
        {
            List<IBetCard> list = new List<IBetCard>();
            PlayerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>())).Callback((IBetCard s) => list.Add(s));


            players.GiveCards(BetCards);

            list.Count.Should().Be(countOfPlayers);
            list.Distinct().Count().Should().Be(list.Count);
        }

    }
}