using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.RacingCards
{
    public class RacingCardManagerShould
    {
        private RacingCardManager _sut;
        private Mock<IRacingCardsFactory> _mockRacingCardsFactory;

        public RacingCardManagerShould()
        {
            _mockRacingCardsFactory = new Mock<IRacingCardsFactory>();
            _mockRacingCardsFactory.Setup(x => x.Create()).Returns(new List<IRacingCard> { new Mock<IRacingCard>().Object });

            _sut = new RacingCardManager(_mockRacingCardsFactory.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(18)]
        [InlineData(81)]
        private void Return_Count_Of_Racing_Cards(int countOfCards)
        {
            var listOfRacingCards = Enumerable.Range(1, countOfCards)
                .Select(x => new Mock<IRacingCard>().Object).ToList();
            _mockRacingCardsFactory.Setup(x => x.Create()).Returns(listOfRacingCards);
            _sut = new RacingCardManager(_mockRacingCardsFactory.Object);


            _sut.CountOfCards.Should().Be(countOfCards);
        }
    }
}


