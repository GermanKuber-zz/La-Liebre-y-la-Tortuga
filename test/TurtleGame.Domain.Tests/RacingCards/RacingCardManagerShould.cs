using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;

namespace TurtleGame.Domain.Tests.RacingCards
{
    public class RacingCardManagerShould
    {
        private RacingCardManager _sut;
        private readonly Mock<IRacingCardsFactory> _mockRacingCardsFactory = new Mock<IRacingCardsFactory>();
        private readonly Mock<IGenericMixStrategy> _mockGenericMixStrategy = new Mock<IGenericMixStrategy>();

        public RacingCardManagerShould()
        {
            var returnList = EnumerableGenerator.Generate(1, x => new Mock<IRacingCard>().Object);

            _mockRacingCardsFactory.Setup(x => x.Create()).Returns(returnList);

            _mockGenericMixStrategy.Setup(x => x.Mix<IRacingCard>(It.IsAny<List<IRacingCard>>()))
                .Returns(new ReadOnlyCollection<IRacingCard>(returnList));

            _sut = new RacingCardManager(_mockRacingCardsFactory.Object, _mockGenericMixStrategy.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(18)]
        [InlineData(81)]
        private void Return_Count_Of_Racing_Cards(int countOfCards)
        {
            var listOfRacingCards = EnumerableGenerator.Generate(countOfCards, x => new Mock<IRacingCard>().Object);

            _mockRacingCardsFactory.Setup(x => x.Create()).Returns(listOfRacingCards);
            _mockGenericMixStrategy.Setup(x => x.Mix<IRacingCard>(It.IsAny<List<IRacingCard>>()))
                .Returns(new ReadOnlyCollection<IRacingCard>(listOfRacingCards));

            _sut = new RacingCardManager(_mockRacingCardsFactory.Object,
                                         _mockGenericMixStrategy.Object);

            _sut.CountOfCards.Should().Be(countOfCards);
        }

        [Fact]
        private void Execute_Mix_From_Strategy()
        {
            _mockGenericMixStrategy.Verify(x => x.Mix<IRacingCard>(It.IsAny<List<IRacingCard>>()), Times.Once);
        }


    
    }
}


