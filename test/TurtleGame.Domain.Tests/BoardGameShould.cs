using FluentAssertions;
using Xunit;

namespace TurtleGame.Domain.Tests
{

    public class BoardGameShould
    {
        private readonly BoardGame _sut;

        public BoardGameShould()
        {
            _sut = new BoardGame();
        }


        [Fact]
        public void Initializate_Bet_Cards()
        {
            _sut.BetCards.Count.Should().Be(5);
        }

    }
}