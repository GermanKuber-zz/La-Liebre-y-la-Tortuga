using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Generators;
using Xunit;

namespace TurtleGame.Domain.Tests.RacingCards
{
    public class RacingCardOnDeskManagerShould
    {
        private IRacingCardOnDeskManager _sut;

        public RacingCardOnDeskManagerShould()
        {
            var returnList = EnumerableGenerator.Generate(1, x => new Mock<IRacingCard>().Object);
            _sut = new RacingCardOnDeskManager();
        }

        [Fact]
        private void Add_New_Cards_To_Desk()
        {
            var listOfRacing = new List<IRacingCard> { new Mock<IRacingCard>().Object, new Mock<IRacingCard>().Object, new Mock<IRacingCard>().Object };
            var racingCards = Domain.RacingCards.RacingCards.Create(listOfRacing);

            _sut.FallCardsToDeck(racingCards);
            _sut.QuantityOfCards.Should().Be(3);
        }
    }
}


