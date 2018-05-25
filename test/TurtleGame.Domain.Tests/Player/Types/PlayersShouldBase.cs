using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Players.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Generators;

namespace TurtleGame.Domain.Tests.Player.Types
{
    public class PlayersShouldBase
    {
        protected readonly Mock<IPlayer> PlayerOne = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerTwo = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerThree = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerFour = new Mock<IPlayer>();
        protected readonly Mock<IPlayer> PlayerFive = new Mock<IPlayer>();
        protected readonly List<IBetCard> BetCards = new List<IBetCard>();
        protected readonly Mock<IRacingCardManager> MockRacingCardManager = new Mock<IRacingCardManager>();
        protected  IPlayers Sut;
        public PlayersShouldBase()
        {
            BetCards.AddRange(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
            MockRacingCardManager.Setup(x => x.TakeCard()).Returns(new Mock<IRacingCard>().Object);
        }

        protected void Differentes_Cards_To_All_Players(IPlayers players, int countOfPlayers)
        {
            List<IBetCard> list = new List<IBetCard>();
            PlayerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>())).Callback((IBetCard s) => list.Add(s));


            players.GiveCards(BetCards);

            list.Count.Should().Be(countOfPlayers);
            list.Distinct().Count().Should().Be(list.Count);
        }
      
    }
}