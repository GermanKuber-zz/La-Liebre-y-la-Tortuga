using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Players.Interfaces;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayerManagerShould
    {
        private readonly IPlayersManager _sut;
        private readonly Mock<IPlayer> _playerOne = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerTwo = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerThree = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerFour = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerFive = new Mock<IPlayer>();
        private readonly IReadOnlyCollection<IBetCard> _betCards;
        private readonly Mock<IPlayers> _mockPlayers = new Mock<IPlayers>();
        private readonly Mock<IGenericMixStrategy> _mockgGenericMixStrategy = new Mock<IGenericMixStrategy>();

        public PlayerManagerShould()
        {
            _betCards = new ReadOnlyCollection<IBetCard>(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
            _playerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerTwo.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerThree.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerFour.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerFive.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _mockgGenericMixStrategy.Setup(x => x.Mix<IBetCard>(It.IsAny<List<IBetCard>>()))
                .Returns(EnumerableGenerator.Generate(10, x => new Mock<IBetCard>().Object));

            _mockPlayers.Setup(x => x.TakeCard());
            _mockPlayers.Setup(x => x.GiveCards(It.IsAny<IReadOnlyCollection<IBetCard>>()));
            _sut = new PlayersManager(_mockPlayers.Object, _mockgGenericMixStrategy.Object);
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
    }
}
