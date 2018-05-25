using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Types.Interfaces;
using TurtleGame.SharedKernel.Generators;

namespace TurtleGame.Domain.Tests.Player.Types
{
    public class PlayersShouldBase
    {
        protected readonly Mock<IPlayer> PlayerOne;
        protected readonly Mock<IPlayer> PlayerTwo;
        protected readonly Mock<IPlayer> PlayerThree;
        protected readonly Mock<IPlayer> PlayerFour;
        protected readonly Mock<IPlayer> PlayerFive;
        protected readonly List<IBetCard> BetCards;
        protected  IPlayers Sut;
        public PlayersShouldBase()
        {
            PlayerOne = new Mock<IPlayer>();
            PlayerTwo = new Mock<IPlayer>();
            PlayerThree = new Mock<IPlayer>();
            PlayerFour = new Mock<IPlayer>();
            PlayerFive = new Mock<IPlayer>();
            BetCards = new List<IBetCard>();
            BetCards.AddRange(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
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