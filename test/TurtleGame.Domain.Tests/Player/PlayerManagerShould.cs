using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayerManagerShould
    {
        private readonly IPlayersManager _sut;
        private readonly IReadOnlyCollection<IBetCard> _betCards;
        private readonly Mock<IPlayersQuantityType> _mockPlayers = new Mock<IPlayersQuantityType> { DefaultValue = DefaultValue.Mock };
        private readonly Mock<IGenericMixStrategy> _mockgGenericMixStrategy = new Mock<IGenericMixStrategy>();
        private readonly Mock<IRacingCardManager> _mockRacingCardManager = new Mock<IRacingCardManager>();
        public PlayerManagerShould()
        {
            _betCards = new ReadOnlyCollection<IBetCard>(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));

            _mockgGenericMixStrategy.Setup(x => x.Mix<IBetCard>(It.IsAny<List<IBetCard>>()))
                .Returns(EnumerableGenerator.Generate(10, x => new Mock<IBetCard>().Object));

            _sut = new PlayersManager(_mockPlayers.Object, _mockRacingCardManager.Object, _mockgGenericMixStrategy.Object);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void Not_Allow_More_Neither_Less_Than_Five_Cards(int countOfCards)
        {
            Action act = () => _sut.GiveBetCards(new
                ReadOnlyCollection<IBetCard>(EnumerableGenerator
                                    .Generate<IBetCard>(countOfCards, x => new Mock<IBetCard>().Object)));

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Give_Cards_To_Users()
        {
            _sut.GiveBetCards(_betCards);

            _mockPlayers.Verify(x => x.GiveCards(It.IsAny<IReadOnlyCollection<IBetCard>>()), Times.Exactly(1));
        }

        [Fact]
        public void Give_Seven_Times_Race_Cards()
        {
            _sut.GiveRaicingCards();

            _mockPlayers.Verify(x => x.TakeCard(), Times.Exactly(7));
        }


        [Theory]
        [InlineData(2)]
        [InlineData(19)]
        public void Call_CardsTurn_To_Players(int quantityOfCalls)
        {
            var callback = new Mock<SelectedCardsConfirmationDelegate>();
            var deskIsValidForTheNextPlayerCallback = new Mock<DeskIsValidForTheNextPlayerDelegate>();
            deskIsValidForTheNextPlayerCallback.SetupSequence(x => x())
                                                .Returns(false);

            Enumerable.Range(0, quantityOfCalls)
                .ToList()
                .ForEach(x => _sut.CardsTurn(callback.Object, deskIsValidForTheNextPlayerCallback.Object));

            _mockPlayers.Verify(x => x.CardsTurn(callback.Object), Times.Exactly(quantityOfCalls));

        }
    }
}
