using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Moq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;
using TurtleGame.SharedKernel.Generators;
using TurtleGame.SharedKernel.Strategies.Interfaces;
using Xunit;
public class RacingCardManagerShould
{
    private RacingCardManager _sut;
    private readonly Mock<IRacingCardsFactory> _mockRacingCardsFactory = new Mock<IRacingCardsFactory> { DefaultValue = DefaultValue.Mock };
    private readonly Mock<IGenericMixStrategy> _mockGenericMixStrategy = new Mock<IGenericMixStrategy> { DefaultValue = DefaultValue.Mock };
    private readonly Mock<IMixDiscartCards> _mockMixDiscartCards = new Mock<IMixDiscartCards> { DefaultValue = DefaultValue.Mock };
    private readonly Mock<IRacingCard> _firstCard = new Mock<IRacingCard>();
    private readonly Mock<IRacingCard> _secondCard = new Mock<IRacingCard>();
    private readonly Mock<IRacingCard> _thirdCard = new Mock<IRacingCard>();
    public RacingCardManagerShould()
    {

        var returnList = new List<IRacingCard> { _firstCard.Object, _secondCard.Object, _thirdCard.Object };
        _mockRacingCardsFactory.Setup(x => x.Create()).Returns(returnList);

        _mockGenericMixStrategy.Setup(x => x.Mix<IRacingCard>(returnList))
            .Returns(new ReadOnlyCollection<IRacingCard>(returnList));

        _sut = new RacingCardManager(_mockRacingCardsFactory.Object,
                                     _mockGenericMixStrategy.Object,
                                     _mockMixDiscartCards.Object);
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

        _mockMixDiscartCards.Setup(x => x.MixAll())
            .Returns(new ReadOnlyCollection<IRacingCard>(listOfRacingCards));

        _sut = new RacingCardManager(_mockRacingCardsFactory.Object,
                                     _mockGenericMixStrategy.Object,
                                     _mockMixDiscartCards.Object);

        _sut.CountOfCards.Should().Be(countOfCards);
    }

    [Fact]
    private void Execute_Mix_From_Strategy()
    {
        _mockGenericMixStrategy.Verify(x => x.Mix<IRacingCard>(It.IsAny<List<IRacingCard>>()), Times.Once);
    }

    [Fact]
    private void Execute_MixAll_From_Discart_Cards()
    {
        _sut.TakeCard();
        _sut.TakeCard();
        _sut.TakeCard();
        _sut.TakeCard();
        _mockMixDiscartCards.Verify(x => x.MixAll(), Times.Once);
    }

    [Fact]
    private void Return_First_Card_From_The_List()
    {
        _sut.TakeCard().Should().Be(_firstCard.Object);
    }
    [Fact]
    private void Return_Second_Card_From_The_List()
    {
        _sut.TakeCard();
        _sut.TakeCard().Should().Be(_secondCard.Object);
    }
    [Fact]
    private void Return_Third_Card_From_The_List()
    {
        _sut.TakeCard();
        _sut.TakeCard();
        _sut.TakeCard().Should().Be(_thirdCard.Object);
    }
}