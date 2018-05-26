using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.SharedKernel.Generators;
using Xunit;

namespace TurtleGame.Domain.Tests.Player
{
    public class PlayerManagerShould
    {
        private IPlayersManager _sut;
        private readonly Mock<IPlayer> _playerOne = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerTwo = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerThree = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerFour = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerFive = new Mock<IPlayer>();
        private readonly Mock<IRacingCardManager> _mockRacingCardManager = new Mock<IRacingCardManager>();
        private readonly IPlayersManagerFactory _playersManagerFactory;


        private readonly IReadOnlyCollection<IBetCard> _betCards;

        public PlayerManagerShould()
        {
            _betCards = new ReadOnlyCollection<IBetCard>(EnumerableGenerator.Generate(5, x => new Mock<IBetCard>().Object));
            _playersManagerFactory = new PlayersManagerFactory();
            _playerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerTwo.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerThree.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerFour.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerFive.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));

            _sut = _playersManagerFactory.ToTwoPlayer(_playerOne.Object, _playerTwo.Object);
        }

        [Fact]
        public void Give_Card_To_All_Players()
        {

            _sut = _playersManagerFactory.ToFivePlayer(_playerOne.Object,
                _playerTwo.Object,
                _playerThree.Object,
                _playerFour.Object,
                _playerFive.Object);

            _sut.GiveBetCards(_betCards);

            _playerOne.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            _playerTwo.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            _playerThree.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            _playerFour.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            _playerFive.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
        }
        [Fact]
        public void Give_Differents_Cards_To_All_Players()
        {
            List<IBetCard> list = new List<IBetCard>();
            _playerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>())).Callback((IBetCard s) => list.Add(s));


            _sut = _playersManagerFactory.ToFivePlayer(_playerOne.Object,
                                        _playerOne.Object,
                                        _playerOne.Object,
                                        _playerOne.Object,
                                        _playerOne.Object);

            _sut.GiveBetCards(_betCards);


            _playerOne.Verify(mock => mock.GiveCard(It.IsIn<IBetCard>(_betCards)), Times.Exactly(5));
            list.Count.Should().Be(5);
            list.Distinct().Count().Should().Be(list.Count);

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
        public void Give_Two_Card_Each_Two_Players_When_Only_Are_Two_Players()
        {

            _sut.GiveBetCards(_betCards);

            _playerOne.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2));
            _playerOne.Verify(x => x.GiveCard(It.IsAny<IBetCard>()), Times.Exactly(2));

        }
    }
}
