using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;
using Xunit;

namespace TurtleGame.Domain.RacingCards
{

    public class PreConditionNoMoreThanFourShould
    {
        private IPreConditionRaicingCards _sut;

        public PreConditionNoMoreThanFourShould()
        {
            _sut = new PreConditionNoMoreThanFour();
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        private void Validate_Return_Value(int countOfRaicingCards, bool resultValue)
        {
            var result = _sut.Validate(RacingCards.Create(new List<IRacingCard>(Enumerable.Range(0, countOfRaicingCards)
                .ToList()
                .Select(x => new Mock<IRacingCard>().Object))));

            result.Should().Be(resultValue);
        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        private void Validate_Call_Next_In_Chain(int countOfRaicingCards)
        {
            var mockNext = new Mock<IPreConditionRaicingCards>();
            _sut.SetNext(mockNext.Object);
            var result = _sut.Validate(RacingCards.Create(new List<IRacingCard>(Enumerable.Range(0, countOfRaicingCards)
                .ToList()
                .Select(x => new Mock<IRacingCard>().Object))));

            mockNext.Verify(x => x.Validate(It.IsAny<IRacingCards>()));
        }
    }

}