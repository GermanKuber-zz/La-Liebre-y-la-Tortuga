using System;
using System.Diagnostics.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace TurtleGame.Domain.Tests
{
    public class BoardGameShould
    {
        private  BoardGame _sut;
        private readonly Mock<IPlayer> _playerOne;
        private readonly Mock<IPlayer> _playerTwo;

        public BoardGameShould()
        {
            _playerOne = new Mock<IPlayer>();
            _playerTwo = new Mock<IPlayer>();
            _sut = BoardGame.ToTwoPlayer(_playerOne.Object, _playerTwo.Object);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Set_Two_Playes(int numberOfPlayers)
        {
            _sut.SetPlayers(numberOfPlayers);
            _sut.NumberOfPlayers.Should().Be(numberOfPlayers);
        }

        [Fact]
        public void Not_Allow_More_Than_Five_Player()
        {
            Action act = () => _sut.SetPlayers(6);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Not_Allow_Less_Than_Two_Player()
        {
            Action act = () => _sut.SetPlayers(1);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Give_Card_To_All_Players()
        {
            var playerThree = new Mock<IPlayer>();
            var playerFour = new Mock<IPlayer>();
            var playerFive = new Mock<IPlayer>();
            _sut = BoardGame.ToFivePlayer(_playerOne.Object,
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






    }
}
