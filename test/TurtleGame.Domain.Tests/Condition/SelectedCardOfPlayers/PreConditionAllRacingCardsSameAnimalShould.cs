using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;
using Xunit;

namespace TurtleGame.Domain.RacingCards
{
    public class PreConditionAllRacingCardsSameAnimalShould: PreconditionShouldBase
    {
        private IPreConditionRaicingCards _sut;
        private Mock<IRacingCards> _mockRacingCards = new Mock<IRacingCards>();
        public PreConditionAllRacingCardsSameAnimalShould()
        {
            Sut = new PreConditionAllRacingCardsSameAnimal();
        }

        [Fact]
        private void Validate_Return_Value()
        {
            Sut.Validate(_mockRacingCards.Object);
            _mockRacingCards.Verify(x => x.AllCardAreTheSameAnimal(), Times.Once);
        }
    }

}