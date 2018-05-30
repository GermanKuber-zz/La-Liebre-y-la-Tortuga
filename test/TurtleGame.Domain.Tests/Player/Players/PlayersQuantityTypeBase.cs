using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using TurtleGame.SharedKernel.Generators;

namespace TurtleGame.Domain.Tests.Player.Players
{
    public class PlayersQuantityTypeShouldBase
    {
        protected readonly Mock<IPlayer> PlayerOne = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        protected readonly Mock<IPlayer> PlayerTwo = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        protected readonly Mock<IPlayer> PlayerThree = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        protected readonly Mock<IPlayer> PlayerFour = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        protected readonly Mock<IPlayer> PlayerFive = new Mock<IPlayer> { DefaultValue = DefaultValue.Mock };
        protected readonly List<IBetCard> BetCards = new List<IBetCard>();
        public List<Mock<IPlayer>> ListOfPlayers { get; set; }
        protected IPlayersQuantityType Sut;
        public PlayersQuantityTypeShouldBase()
        {
            BetCards.AddRange(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
            ListOfPlayers = new List<Mock<IPlayer>> { PlayerOne, PlayerTwo, PlayerThree, PlayerFour, PlayerFive };
            ListOfPlayers.ForEach(x => x.Setup(s => s.GiveCard(It.IsAny<IBetCard>())));
        }

        protected void Differentes_Cards_To_All_Players(IPlayersQuantityType players, int countOfPlayers, int quantityOfDiferentsCardsPlayers)
        {
            List<IBetCard> list = new List<IBetCard>();
            ListOfPlayers.ToList().ForEach(player => player.Setup(x => x.GiveCard(It.IsAny<IBetCard>())).Callback((IBetCard s) => list.Add(s)));

            players.GiveCards(BetCards);

            list.Count.Should().Be(quantityOfDiferentsCardsPlayers);
            list.Distinct().Count().Should().Be(list.Count);
        }
        protected void SetupSutSutWithPlayers(int countOfUsers)
        {
            if (countOfUsers < 2 || countOfUsers > 5)
                throw new ArgumentException(nameof(countOfUsers));

            Sut = new PlayersQuantityType(new Domain.Player.PlayersQuantityType.Players(ListOfPlayers.Take(countOfUsers).Select(x => x.Object)));

        }

    }
}