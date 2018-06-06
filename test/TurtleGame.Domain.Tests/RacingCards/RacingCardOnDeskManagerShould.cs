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
        private List<IRacingCard> _listOfRacing;

        public RacingCardOnDeskManagerShould()
        {
            _listOfRacing = new List<IRacingCard> { new Mock<IRacingCard>().Object, new Mock<IRacingCard>().Object, new Mock<IRacingCard>().Object };

            var returnList = EnumerableGenerator.Generate(1, x => new Mock<IRacingCard>().Object);
            _sut = new RacingCardOnDeskManager();
        }

        [Fact]
        private void Add_New_Cards_To_Desk()
        {
            var racingCards = Domain.RacingCards.RacingCards.Create(_listOfRacing);

            _sut.FallCardsToDeck(racingCards);
            _sut.QuantityOfCardsToPlay.Should().Be(3);
        }
        [Fact]
        private void Return_Empty_Does_Not_Have_Discarts_Cards_For_Mix()
        {
            _sut.FallCardsToDeck(Domain.RacingCards.RacingCards.Create(_listOfRacing));
            var result = _sut.MixAll();
            result.Should().BeNullOrEmpty();
            _sut.QuantityOfCardsToPlay.Should().Be(3);
        }
    }
}


