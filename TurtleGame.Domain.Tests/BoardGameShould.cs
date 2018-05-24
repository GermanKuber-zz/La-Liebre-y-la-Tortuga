using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Factories;
using TurtleGame.Domain.Factories.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests
{



    public class BoardGameShould
    {
        private BoardGame _sut;
        private readonly Mock<IPlayer> _playerOne = new Mock<IPlayer>();
        private readonly Mock<IPlayer> _playerTwo = new Mock<IPlayer>();
        private readonly Mock<IPlayersManagerFactory> _mockPlayersManagerFactory = new Mock<IPlayersManagerFactory>();
        private readonly Mock<IPlayersManager> _mockPlayersManager = new Mock<IPlayersManager>(MockBehavior.Strict);

        private readonly IBoardGameFactory _boardGameFactory;

        public BoardGameShould()
        {
            _playerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _playerTwo.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            _mockPlayersManager.Setup(x => x.NumberOfPlayers).Returns(2);

            _mockPlayersManager.Setup(x => x.PlayerOne).Returns(_playerOne.Object);
            _mockPlayersManager.Setup(x => x.PlayerTwo).Returns(_playerTwo.Object);
            _mockPlayersManagerFactory.Setup(x => x.ToTwoPlayer(It.IsAny<IPlayer>(), It.IsAny<IPlayer>()))
                .Returns(_mockPlayersManager.Object);
            _mockPlayersManagerFactory.Setup(x => x.ToFivePlayer(It.IsAny<IPlayer>(), It.IsAny<IPlayer>(),
                    It.IsAny<IPlayer>(), It.IsAny<IPlayer>(), It.IsAny<IPlayer>()))
                .Returns(_mockPlayersManager.Object);
            _boardGameFactory = new BoardGameFactory(_mockPlayersManagerFactory.Object);
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne.Object, _playerTwo.Object);
        }

        [Fact]
        public void Give_Card_To_All_Players()
        {
            var playerThree = new Mock<IPlayer>();
            playerThree.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            var playerFour = new Mock<IPlayer>();
            playerFour.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));
            var playerFive = new Mock<IPlayer>();
            playerFive.Setup(x => x.GiveCard(It.IsAny<IBetCard>()));

            _sut = _boardGameFactory.ToFivePlayer(_playerOne.Object,
                _playerTwo.Object,
                playerThree.Object,
                playerFour.Object,
                playerFive.Object);

            _mockPlayersManager.Setup(x => x.NumberOfPlayers).Returns(5);
        
            _mockPlayersManager.Setup(x => x.PlayerThree).Returns(playerThree.Object);
            _mockPlayersManager.Setup(x => x.PlayerFour).Returns(playerFour.Object);
            _mockPlayersManager.Setup(x => x.PlayerFive).Returns(playerFive.Object);

            _sut.Start();
            _playerOne.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            _playerTwo.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            playerThree.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            playerFour.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
            playerFive.Verify(mock => mock.GiveCard(It.IsAny<IBetCard>()), Times.Once());
        }
        [Fact]
        public void Give_Diferent_Cards_To_All_Players()
        {
            void ConfigurePlayerToTest(Mock<IPlayer> playerToConfigure, List<IBetCard> list)
            {
                playerToConfigure.Setup(x => x.GiveCard(It.IsAny<IBetCard>()))
                    .Callback((IBetCard s) =>
                    {
                        if (list.Contains(s))
                            throw new Exception();
                        list.Add(s);
                    });
            }

            var playerThree = new Mock<IPlayer>();
            var playerFour = new Mock<IPlayer>();
            var playerFive = new Mock<IPlayer>();
            _sut = _boardGameFactory.ToFivePlayer(_playerOne.Object,
                _playerTwo.Object,
                playerThree.Object,
                playerFour.Object,
                playerFive.Object);

            IReadOnlyCollection<IBetCard> betCards = _sut.GiveAllBetCards();
            var tmpBetCards = new List<IBetCard>();
            _mockPlayersManager.Setup(x => x.NumberOfPlayers).Returns(5);

            _mockPlayersManager.Setup(x => x.PlayerThree).Returns(playerThree.Object);
            _mockPlayersManager.Setup(x => x.PlayerFour).Returns(playerFour.Object);
            _mockPlayersManager.Setup(x => x.PlayerFive).Returns(playerFive.Object);

            ConfigurePlayerToTest(_playerOne, tmpBetCards);
            ConfigurePlayerToTest(_playerTwo, tmpBetCards);
            ConfigurePlayerToTest(playerThree, tmpBetCards);
            ConfigurePlayerToTest(playerFour, tmpBetCards);
            ConfigurePlayerToTest(playerFive, tmpBetCards);

            _sut.Start();
            _playerOne.Verify(mock => mock.GiveCard(It.IsIn<IBetCard>(betCards)), Times.Once());

        }

        [Fact]
        public void Give_Two_Card_Each_Two_Players_When_Only_Are_Two_Players()
        {
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne.Object,
                _playerTwo.Object);
            var countCardsPlayerOne = 0;
            var countCardsPlayerTwo = 0;
            _mockPlayersManager.Setup(x => x.NumberOfPlayers).Returns(2);

            _playerOne.Setup(x => x.GiveCard(It.IsAny<IBetCard>()))
                .Callback(() => ++countCardsPlayerOne);
            _playerTwo.Setup(x => x.GiveCard(It.IsAny<IBetCard>()))
                .Callback(() => ++countCardsPlayerTwo);

            _sut.Start();
            countCardsPlayerOne.Should().Be(2);
            countCardsPlayerTwo.Should().Be(2);
        }
    }
}
