using System;
using System.Linq;
using FluentAssertions;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Types;
using Xunit;

namespace TurtleGame.Domain.Tests.RacingCards
{
  public  class RacingCardManagerShould
    {
        private RacingCardManager _sut;

        public RacingCardManagerShould()
        {
            _sut = new RacingCardManager();
        }

        [Fact]
        private void Have_81_Cards_In_Total()
        {
            _sut.CountOfCards.Should().Be(81);
        }
        [Theory]
        [InlineData(typeof(HareRacingCard), 18)]
        [InlineData(typeof(TurtleRacingCard), 17)]
        [InlineData(typeof(WolfRacingCard), 16)]
        [InlineData(typeof(FoxRacingCard), 15)]
        private void Have_18_Cards_Of_Hare(Type type,int countOfCards)
        {
            _sut.Cards.Count(x => x.GetType() == type).Should().Be(countOfCards);
        }
    }
}


