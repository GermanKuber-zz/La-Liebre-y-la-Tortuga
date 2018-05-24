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
        private readonly Mock<IPlayer> _playerOne;
        private readonly Mock<IPlayer> _playerTwo;
        private readonly IBoardGameFactory _boardGameFactory = new BoardGameFactory(new PlayersManagerFactory());

        public BoardGameShould()
        {
            _playerOne = new Mock<IPlayer>();
            _playerTwo = new Mock<IPlayer>();
            _sut = _boardGameFactory.ToTwoPlayer(_playerOne.Object, _playerTwo.Object);
        }

        [Fact]
        public void Give_Card_To_All_Players()
        {
            var playerThree = new Mock<IPlayer>();
            var playerFour = new Mock<IPlayer>();
            var playerFive = new Mock<IPlayer>();
            _sut = _boardGameFactory.ToFivePlayer(_playerOne.Object,
                _playerTwo.Object,
                playerThree.Object,
                playerFour.Object,
                playerFive.Object);

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

            ConfigurePlayerToTest(_playerOne, tmpBetCards);
            ConfigurePlayerToTest(_playerTwo, tmpBetCards);
            ConfigurePlayerToTest(playerThree, tmpBetCards);
            ConfigurePlayerToTest(playerFour, tmpBetCards);
            ConfigurePlayerToTest(playerFive, tmpBetCards);

            _sut.Start();
            _playerOne.Verify(mock => mock.GiveCard(It.IsIn<IBetCard>(betCards)), Times.Once());

        }





    }
}
